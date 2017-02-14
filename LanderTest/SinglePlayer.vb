Imports System.Drawing.Graphics
Imports System.Drawing.Pen
Imports System.Drawing.Color
Imports System.Drawing.Brush
Imports System.Drawing.Point
Imports System.Drawing.Bitmap
Imports System.Drawing.Drawing2D


Public Class SinglePlayer

    Dim landerObject As LanderImageProcessor = New LanderImageProcessor

    'Public Server Vars

    'This portion of code intiailizes a bunch of global variables used through out the code
    'The power variable is an integer that must be a power of two
    'It determines how many points are used to generate the terrain
    Dim power As Integer = 128 'Math.Pow(2, Math.Ceiling(Math.Log(Me.Width) / (Math.Log(2))))
    'The points array stores the y components for the terrain points 
    'The index is used to generate the x coordinate
    Dim points(power) As Integer
    'The pathPoints array is an array of points used to create the graphic path
    Dim pathPoints(power) As Point
    'Scrolltracker keeps track of which point of the array to begin drawing from
    'It is incremented in the scroll Right sub and subtracted by one in the scrollLeft sub
    Dim scrollTracker As Integer = 0
    Dim intervalTracker As Integer = 0
    'Point inerval is the variable that determines how far each point is plotted on the screen
    Dim pointInterval As Integer = 14
    'PlatformNum is the number of platforms
    Dim platformNum As Integer = 6
    Dim zoomDisplace As Integer = 0
    'The displace and roughness variable are used to determine the jaggedness of the terrain in the midpoint displacment function
    Dim displace = 250
    Dim roughness = 0.8
    'The platform points array is used to keep track of where the platforms are insereted to check for landings
    Dim platformPoints(platformNum, 2) As Integer
    'The terrain is a graphics path drawn on the screen
    Dim terrain As New GraphicsPath
    Dim whitepen As Pen = New Pen(System.Drawing.Color.White, 3)
    Dim translateRight As New Matrix
    Dim translateLeft As New Matrix
    'boolean used to detect if the lander landed
    Dim landed As Boolean = False
    'max speed value for a safe landing
    Dim maxLandingSpeed = 30


    ' Reminder Try to cap the acceleration

    Dim Timer As Stopwatch ' used to make sure that the game runs at same speed on all computers
    Dim backBuffer As Image ' this is the buffer for the drawing surface for the lander image
    Dim graphics As Graphics ' this is the drawing surface for the lander image
    Dim clientWidth As Integer ' Width of the form
    Dim clientHeight As Integer ' Height of the form
    Dim frameInterval As Long   ' time that the frame is on the screen in milliseconds
    Dim dt As Double ' frameInterval in seconds
    Dim startTick As Long  ' time on the Timer stop watch when the frame is put on the screen
    ' Dim landerImage As Rectangle ' Image of the lander
    Dim velocity As Point  ' Velocity of the lander (acceleration vector)
    Const GRAVITY As Integer = 50 ' Gravity acting on the lander (acceleration vector)
    Dim angle As Double  ' Angle that the lander is positioned at
    Const MIN_ANGLE As Integer = 0 ' Rightmost angle
    Const MAX_ANGLE As Integer = 180 'Leftmost angle
    Const THRUST_SPEED As Integer = 2 'This is an acceleration magnitude
    Dim thrustX As Double  ' Thrust in X direction
    Dim thrustY As Double  ' Thrust in Y direction
    Const PI As Double = 3.14159265 ' Used to convert angle to radians
    Dim fuel As Long ' Fuel value for the lander
    Dim fuelTimer As New System.Timers.Timer  ' Timer used for decrementing the fuel
    Dim lowFuelTimer As New System.Timers.Timer  ' Timer used for flashing the low fuel warning
    Dim lowFuelSeen As Boolean = False ' Needed because timer events cannot change controls on a form since they are run on a seperate thread
    Dim thrusting As Boolean ' tells if lander is thrusting
    Dim crashed As Boolean = False ' Tells is lander has crashed
    'Dim landed As Boolean = False  ' Tells if lander has lander
    Dim accelerationY As Double ' Net Acceleration in the Y direction
    Dim keyLeftPressed As Boolean = False ' Tells if left key is pressed
    Dim keyRightPressed As Boolean = False ' Tells if right key is pressed
    Dim keyUpPressed As Boolean = False   ' Tells if up key is pressed

    Dim landerLocation As Point ' needed because a picturebox location cannot be changed with an expression
    Dim landerLocation2 As Point
    'While the Form exists run GameLoop
    Private Sub LanderTest_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        GameLoop()
    End Sub

    'The add patforms sub adds in the specidfied number of platforms 
    Private Sub Add_Platforms()
        'Create a random number sequence
        Static Generator As System.Random = New System.Random()
        'Creates a platforms
        For i = 0 To platformNum - 1
            'find a random number beteween 0 and 5 less than the number of points
            Dim platformStart As Integer = Generator.Next(0, power - 5)
            'find a random number from 2 to 5 to determine platform size
            Dim platformSize As Integer = Generator.Next(1, 5)
            'add the platform location and size to the platfrom array
            platformPoints(i, 0) = platformStart
            platformPoints(i, 1) = platformSize
            'take the value at the start of the platform and ammend the proceeding points depending on the size
            For j = 0 To platformSize
                points(platformStart + j) = points(platformStart)
            Next
        Next
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainMenu.Hide()

        landerObject.preloadLanderImages()
        landerObject.loadLanderImages(40)
        'start terrain
        'Maximize screen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Black

        'Try to improve screen flickering
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)


        translateRight.Translate(1, 0)
        translateLeft.Translate(-1, 0)

        'Generate the start and endpoints of the terrain
        points(0) = Height / 2 + (Rnd() * displace * 2) - displace
        points(power) = Height / 2 + (Rnd() * displace * 2) - displace
        displace *= roughness

        'In this while loop find the midpoint between each 2 sets of points 
        'Displace the midpoint by a randomly generated number scaled by the roughness and max displacement
        Dim i As Integer = 1
        While i < power
            Dim j As Integer = (power / i) / 2
            While j < power
                points(j) = ((points(j - (power / i) / 2) + points(j + (power / i) / 2)) / 2)
                points(j) += (Rnd() * displace * 2) - displace
                j += power / i
            End While
            displace *= roughness
            i = i * 2
        End While
        'Make sure the start and end of the terrain line up
        points(power) = points(0)
        'Add the platforms
        Add_Platforms()
        'Add all the points to the pathPoints array
        For i = 0 To power
            Dim nextPoint = New Point(pointInterval * i, points(i))
            pathPoints(i) = nextPoint
        Next




        Me.DoubleBuffered = True  ' Prevents flickering
        'Me.WindowState = FormWindowState.Maximized ' Maximize the window on form load
        'Msg Box
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle


        Timer = New Stopwatch()
        clientWidth = Me.Size.Width()
        clientHeight = Me.Size.Height()
        frameInterval = 17 ' about 60 FPS
        dt = frameInterval / 1000  ' frameInterval now in seconds

        Me.ClientSize = New Size(clientWidth, clientHeight)
        backBuffer = New Bitmap(clientWidth, clientHeight)
        graphics = graphics.FromImage(backBuffer)
        velocity = New Point(0, 0)
        angle = 90
        'landerImage = New Rectangle(150, 50, 10, 20) ' To be replaced with picture of lander?

        fuel = 1000 ' Initialize fuel to 1000
        'Set fuel timer properties
        fuelTimer.Interval = frameInterval
        AddHandler fuelTimer.Elapsed, AddressOf fuelTimer_Tick

        'Set fuel warning timer properties
        lowFuelTimer.Interval = frameInterval * 10
        AddHandler lowFuelTimer.Elapsed, AddressOf fuelWarningTimer_Tick

    End Sub

    'This is the scoring method, it takes the size of the platform and the vertical speed
    'It set the label fo the score to the score
    Private Sub score(ByVal verticalSpeed, ByVal Mulitplier)
        Dim Score As Double = Mulitplier * 1000 * (maxLandingSpeed - verticalSpeed) / (maxLandingSpeed - 1)
        lblScoreValue.Text = CInt(Score)
    End Sub

    'This is the paint event the draws the terrain
    Private Sub Main_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'Reset the terrain add all the path points to the graphicpath and draw the path with a white pen on a black background
        terrain.Reset()
        terrain.AddLines(pathPoints)
        e.Graphics.Clear(Transparent)
        e.Graphics.DrawPath(whitepen, terrain)
    End Sub

    'The function will be the main controller for the terrain
    'Right now it uses the mouses location as the lunar location
    Private Sub LunarTerrain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'See if need to scroll left, right or neither and flag the appropriate boolean variables
        If e.X < 200 Then
            scrollLeft()
        ElseIf e.X > 1200 Then
            scrollRight()
        End If

        'Check to see if lander location is on the graphics path
        If terrain.IsVisible(e.X, e.Y) Then
            Dim verticalSpeed = 25
            'Find the closest point on the left of the lander
            Dim impactPoint = Math.Floor(e.X / pointInterval)
            'Find the correct index for the point adjusted for scrolling using the scrollTracker
            If scrollTracker + impactPoint < power Then
                impactPoint += scrollTracker
            Else
                impactPoint = scrollTracker - impactPoint
            End If

            'loop through the platform  array that contains the left most point for each platform
            For i = 0 To platformNum
                'if the Impact point is is to the right of the start and to the left of the ending
                'and the speed is less then the max allowed speed for landing then get a score 
                If impactPoint > platformPoints(i, 0) Then
                    If impactPoint - platformPoints(i, 0) <= platformPoints(i, 1) Then
                        If verticalSpeed <= maxLandingSpeed Then
                            Console.WriteLine("Size " & platformPoints(i, 1))
                            'score using the vertical speed and multiplier which is the max platform size minus the actual size(smaller platform bigger multiplier
                            score(verticalSpeed, 6 - platformPoints(i, 1))
                            landed = True
                        End If
                    End If
                End If
            Next
            If landed Then

            Else
                Dim Restart As Boolean = MessageBox.Show("You have crashed. Would you like to restart?", "Lander Crash", MessageBoxButtons.YesNoCancel)
                If Restart = DialogResult.Yes Then
                    'spawnLander(origin, True)    'restart game
                    'picLander.Image = Image.FromFile(LanderIdle90Upright.png)
                Else
                    'exit game

                End If
            End If
        End If
        'this will be changed to a timer function but for now it just sleeps so it doesnt go to fast
        'The timer will need to take into account lander speed to adjust how fast terrain scrolls
        'Threading.Thread.Sleep(30)
    End Sub

    'Controls Gameplay and Renders New Frame
    Private Sub GameLoop()
        MessageBox.Show("Start Game") ' Display Directions, also allows wait til network connection is made
        Timer.Start()
        Do While (Me.Created)
            startTick = Timer.ElapsedMilliseconds
            GameLogic()
            RenderScene()
            picLander.Image = landerObject.getNewLanderImage(angle, crashed, thrusting)
            Application.DoEvents()
            ' Required to make sure all computers run game at the same speed
            Do While Timer.ElapsedMilliseconds - startTick < frameInterval

            Loop
        Loop
    End Sub


    'This function handles the event where the lander reaches the right side of the screen (temporairly it uses the mouse location
    'It increments the sroll tracker and ammends the graphic path to show the shifted terrain
    Private Sub scrollRight()
        Dim nextPoint As Point
        Dim j As Integer = 0

        'If the interval tracker is less than the point interval then transform the graphics path to
        'shift the path over to the right
        'when the point interval is reached set the graphics path to start at the next point
        If intervalTracker < pointInterval Then
            terrain.Transform(translateRight)
            intervalTracker += 1
        Else
            intervalTracker = 0
            scrollTracker += 1
            'If scroll tracker is at the end of the array loop to begining
            'If not increment the scroll tracker
            If scrollTracker = power Then
                scrollTracker = 0
            End If

            'Using the scroll tracker  to shift, add the points  to the graphicspath points array 
            For i = 0 To power
                If (scrollTracker + i < power) Then
                    nextPoint = New Point(pointInterval * i, points(i + scrollTracker))
                    pathPoints(i) = nextPoint
                ElseIf j <= scrollTracker Then
                    nextPoint = New Point(pointInterval * i, points(j))
                    pathPoints(i) = nextPoint
                    j += 1
                End If
            Next
        End If
        'invlaidate the form to call the paint array
        Me.Invalidate()
    End Sub

    'This function handles the event where the lander reaches the left side of the screen (temporairly it uses the mouse location)
    'It decreases the sroll tracker and ammends the graphic path to show the shifted terrain
    Private Sub scrollLeft()
        Dim nextPoint As Point
        Dim j As Integer = 0

        'If scroll tracker is at the beginning of the array loop to the end
        'If not decrement the tracker
        If scrollTracker = 0 Then
            scrollTracker = power
        End If

        'If the interval tracker is greater than 0 then transform the graphics path to
        'shift the path over to the left
        'when the pinterval tracker is 0 set the graphics path to start at the next point
        If intervalTracker > 0 Then
            intervalTracker -= 1
            terrain.Transform(translateLeft)
        Else
            intervalTracker = 13
            scrollTracker -= 1
            'Using the scroll tracker  to shift, add the points  to the graphicspath points array
            For i = 0 To power
                If (scrollTracker + i < power) Then
                    nextPoint = New Point(pointInterval * i, points(scrollTracker + i))
                    pathPoints(i) = nextPoint
                ElseIf j <= scrollTracker Then
                    nextPoint = New Point(pointInterval * i, points(j))
                    pathPoints(i) = nextPoint
                    j += 1
                End If
            Next
        End If
        'invlaidate the form to call the paint array
        Me.Invalidate()
    End Sub


    Private Sub GameLogic()
        'Move Lander with velocity result of last frame

        MoveLander()
        accelerationY = GRAVITY + thrustY

        velocity.X += thrustX * dt
        velocity.Y += accelerationY * dt
        LimitVelocity()
        landerLocation.X += velocity.X * dt
        landerLocation.Y += velocity.Y * dt
        'landerImage.X += (velocity.X * dt) ' x position
        'landerImage.Y += (velocity.Y * dt) ' y position
        ' detectCollision(crashed)
        ApplyBoundaries()

    End Sub

    Private Sub ApplyBoundaries()

        'Set invisible wall on left boundary
        If landerLocation.X < 0 Then
            landerLocation.X = 0
            velocity.X = 0
        End If

        'Set invisible wall on right boundary
        If landerLocation.X + picLander.Width > clientWidth Then
            landerLocation.X = clientWidth - picLander.Width
            velocity.X = 0
        End If

        'Set invisible ceiling
        If landerLocation.Y < 0 Then
            landerLocation.Y = 0
            velocity.Y = 0
        End If

        'Set invisible floor
        If landerLocation.Y + picLander.Height > clientHeight Then
            landerLocation.Y = clientHeight - picLander.Height
            velocity.Y = 0

        End If
    End Sub



    Private Sub RenderScene()
        lblAngle.Text = angle
        lblVelX.Text = velocity.X
        lblVelY.Text = velocity.Y
        lblLocX.Text = landerLocation.X
        lblLocY.Text = landerLocation.Y

        lblFuel.Text = fuel
        lblLowFuel.Visible = lowFuelSeen
        If fuel = 0 Then
            lblLowFuel.Visible = False
            lblOutOfFuel.Visible = True
        End If
        ' If thrusting then
        '   play thrust sound

        ' If crashed then
        '   play crash animation and sound
        '   spawn

        ' If landed then
        '   show label saying good landing
        '   spawn

        backBuffer = New Bitmap(clientWidth, clientHeight)
        graphics = graphics.FromImage(backBuffer)
        pbSurface.Image = Nothing
        'graphics.FillRectangle(Brushes.Blue(), landerImage) ' To be replaced with image of drawLander(angle) Function
        picLander.Location = (landerLocation)


        pbSurface.Image = backBuffer
    End Sub

    ' Handles keydown events that will change a boolean to allow for "simultaneous" key input
    Private Sub KeysPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'Dim sendbytes() As Byte
        If e.KeyValue = Keys.Left Then
            keyLeftPressed = True
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("left ")
            'TCPServer.Send(sendbytes)
        ElseIf e.KeyValue = Keys.Right Then
            keyRightPressed = True
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("right ")
            'TCPServer.Send(sendbytes)
        ElseIf e.KeyValue = Keys.Up Then
            keyUpPressed = True
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("up ")
            'TCPServer.Send(sendbytes)
        End If
    End Sub

    ' Sets the key that was released to false
    Private Sub KeyReleased(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp

        If e.KeyValue = Keys.Left Then
            keyLeftPressed = False
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("LEFT ")
            'TCPServer.Send(sendbytes)
        ElseIf e.KeyValue = Keys.Right Then
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("RIGHT ")
            'TCPServer.Send(sendbytes)
            keyRightPressed = False
        ElseIf e.KeyValue = Keys.Up Then
            keyUpPressed = False
            'sendbytes = System.Text.Encoding.ASCII.GetBytes("UP ")
            'TCPServer.Send(sendbytes)
        End If

    End Sub
    ' Handles movement 
    Private Sub MoveLander()
        'Rotate Left
        If keyLeftPressed Then
            angle += 1

            If angle > MAX_ANGLE Then
                angle = MAX_ANGLE
            End If

        End If

        'Rotate Right
        If keyRightPressed Then
            angle -= 1

            If angle < MIN_ANGLE Then
                angle = MIN_ANGLE
            End If

        End If

        'Apply Thrust if there is fuel
        If fuel > 0 Then

            If keyUpPressed Then
                Thrust()
            End If
        Else
        End If
    End Sub

    Private Sub Thrust()
        fuelTimer.Enabled = True
        thrusting = True
        ' Because THRUST_SPEED is a magnitude it must be converted to it's component vectors and added to the velocity
        thrustX += THRUST_SPEED * Cosine(angle)
        thrustY += -1 * THRUST_SPEED * Sine(angle) ' Negative Value because top left corner of window is (0,0)
    End Sub

    Private Sub fuelTimer_Tick(sender As Object, e As Timers.ElapsedEventArgs)
        If fuel <> 0 Then
            fuel -= 1
            ' Low fuel show warning start lowFuelTimer
            If fuel < 200 And fuel > 0 Then
                lowFuelTimer.Enabled = True
            ElseIf fuel = 0 Then
                lowFuelTimer.Enabled = False
                thrustY = 0 ' make ship drops even if up arrow is pressed
            End If
        End If
    End Sub

    Private Sub StopThrust(Sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.Up Then
            fuelTimer.Enabled = False
            thrustX = 0
            thrustY = 0
            thrusting = False
        End If
    End Sub

    ' GetAngle function that will return the value of the angle
    ' GetLocation function that will return the location
    ' GetVelocity function that will return the velocity

    Private Function Cosine(angle As Double) As Double
        Cosine = Math.Cos(angle * PI / 180)
    End Function

    Private Function Sine(angle As Double) As Double
        Sine = Math.Sin(angle * PI / 180)
    End Function

    ' Set booleans that will make RenderScene flicker the Low Fuel warning
    Private Sub fuelWarningTimer_Tick(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        If lowFuelSeen Then
            lowFuelSeen = False
        Else
            lowFuelSeen = True
        End If
    End Sub

    ' Function drawLander(angle, thrusting)
    '   Series of if statements for if lander is between certain angle and is thrusting
    '   Then draw appropriate lander picture

    ' Function land(locationX, locationY, angle, velocity, terrain)
    '   if lander collides with terrain at > 25 velocity
    '   then set crashed to true,
    '   elseif lander collides with terrain at < 25 velocity and angle = about 90
    '   add 50 * multiplier value and set landed to True

    ' Limits velocity to allow easier maneuvering
    Private Sub LimitVelocity()
        If velocity.Y > 50 Then ' Limit down velocity
            velocity.Y = 50
        ElseIf velocity.Y < -50 Then ' Limit up velocity
            velocity.Y = -50
        End If

        If velocity.X > 50 Then
            velocity.X = 50 ' Limit Right velocity
        ElseIf velocity.X < -50 Then
            velocity.X = -50
        End If
    End Sub


End Class
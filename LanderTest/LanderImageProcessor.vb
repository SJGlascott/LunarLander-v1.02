' Project: Lunar Lander
' LanderImageProcessor version 2.0.0.0
'
' Description:
'   This module has one public function which accepts parameters regarding the state of a Lander
'   object, and returns a lander image that corresponds to those conditions. Supports rotation
'   and burn animation.
'
'   Version 2.0.0.0 simplifies the updateSprite method to improve effeciency, and adds
'   support for non-standard degrees of rotation, where the lander object's angle doesn't exactly match
'   of the of the pre-defined image angles.
'
' Author: Joshua Church
' Date: April 30, 2016
' IDE: Visual Studio 2015

Class LanderImageProcessor

    ' Arrays for the static, half thrusting, and thrusting lander images over the full range of rotation,
    ' as well a Bitmap object for the crashed lander image are declared.
    Dim staticLanderImages(16) As Bitmap
    Dim thrustingLanderImages(16) As Bitmap
    Dim halfThrustingLanderImages(16) As Bitmap
    Dim crashedLanderImage As Bitmap

    Dim landerImage As Bitmap
    Dim flameIsFlickering As Boolean = True     ' Indicates whether a short or long flame should be rendered.
    Dim frame As Integer = 0                    ' Indicates the current frame of the flame animation.
    Dim imageIndex As Integer                   ' The subscript for the appropriate lander image.
    Const CEILING As Integer = 3                ' The frame which toggles the flame animation.
    Const ANGLE_INCREMENT As Double = 11.25     ' The angle in degrees between the rotated lander images.

    Public Sub preloadLanderImages()

        ' Load first five static lander images into array
        staticLanderImages(0) = My.Resources.LanderNormal0
        staticLanderImages(1) = My.Resources.LanderNormal1
        staticLanderImages(2) = My.Resources.LanderNormal2
        staticLanderImages(3) = My.Resources.LanderNormal3
        staticLanderImages(4) = My.Resources.LanderNormal4

        ' Load first five thrusting lander images into array.
        thrustingLanderImages(0) = My.Resources.LanderThrusting0
        thrustingLanderImages(1) = My.Resources.LanderThrusting1
        thrustingLanderImages(2) = My.Resources.LanderThrusting2
        thrustingLanderImages(3) = My.Resources.LanderThrusting3
        thrustingLanderImages(4) = My.Resources.LanderThrusting4

        ' Load first five half thrusting lander images into array.
        halfThrustingLanderImages(0) = My.Resources.LanderHalfThrusting0
        halfThrustingLanderImages(1) = My.Resources.LanderHalfThrusting1
        halfThrustingLanderImages(2) = My.Resources.LanderHalfThrusting2
        halfThrustingLanderImages(3) = My.Resources.LanderHalfThrusting3
        halfThrustingLanderImages(4) = My.Resources.LanderHalfThrusting4

        ' Load the crashed lander image
        crashedLanderImage = My.Resources.LanderCrash

    End Sub

    Public Sub preloadOpponentImages()

        ' Load first five static lander images into array
        staticLanderImages(0) = My.Resources.LanderNormal0Green
        staticLanderImages(1) = My.Resources.LanderNormal1Green
        staticLanderImages(2) = My.Resources.LanderNormal2Green
        staticLanderImages(3) = My.Resources.LanderNormal3Green
        staticLanderImages(4) = My.Resources.LanderNormal4Green

        ' Load first five thrusting lander images into array.
        thrustingLanderImages(0) = My.Resources.LanderThrusting0Green
        thrustingLanderImages(1) = My.Resources.LanderThrusting1Green
        thrustingLanderImages(2) = My.Resources.LanderThrusting2Green
        thrustingLanderImages(3) = My.Resources.LanderThrusting3Green
        thrustingLanderImages(4) = My.Resources.LanderThrusting4Green

        ' Load first five half thrusting lander images into array.
        halfThrustingLanderImages(0) = My.Resources.LanderHalfThrusting0Green
        halfThrustingLanderImages(1) = My.Resources.LanderHalfThrusting1Green
        halfThrustingLanderImages(2) = My.Resources.LanderHalfThrusting2Green
        halfThrustingLanderImages(3) = My.Resources.LanderHalfThrusting3Green
        halfThrustingLanderImages(4) = My.Resources.LanderHalfThrusting4Green

        ' Load the crashed lander image
        crashedLanderImage = My.Resources.LanderCrashGreen

    End Sub

    Public Sub loadLanderImages(width As Integer)
        ' This method obtains the static and thrusting lander images from resources,
        ' scales them, generates the remaining lander images needed using 270 rotations
        ' and flips across the X axis, and stores the resulting images in two Bitmap arrays.
        ' The method also scales the crash image and assigns it to an image variable.

        ' The height of the first lander image is the width of the lander, as it is rotated 90 degrees.
        ' The width desired is divided by the stock image width to find the scale factor needed.

        Dim scaleFactor As Double = width / My.Resources.LanderNormal0.Height

        ' Scale the crashed lander image.
        crashedLanderImage = scaleImage(crashedLanderImage,
                                        My.Resources.LanderCrash.Height * scaleFactor,
                                        My.Resources.LanderCrash.Width * scaleFactor)

        For i As Integer = 0 To 4
            ' Each of the five images already loaded into the image arrays are scaled,
            ' based on their existing dimensions and the scale factor.
            staticLanderImages(i) = scaleImage(staticLanderImages(i),
                           staticLanderImages(i).Height * scaleFactor,
                           staticLanderImages(i).Width * scaleFactor)

            thrustingLanderImages(i) = scaleImage(thrustingLanderImages(i),
                                                  thrustingLanderImages(i).Height * scaleFactor,
                                                  thrustingLanderImages(i).Width * scaleFactor)

            halfThrustingLanderImages(i) = scaleImage(halfThrustingLanderImages(i),
                                                      halfThrustingLanderImages(i).Height * scaleFactor,
                                                      halfThrustingLanderImages(i).Width * scaleFactor)
        Next

        For i As Integer = 0 To 4
            ' Copy the images to be rotated 90 degrees (elements 0 to 4) to their respective elements (8 to 12),
            ' and then perform the rotation.
            staticLanderImages(i + 8) = New Bitmap(staticLanderImages(i))
            staticLanderImages(i + 8).RotateFlip(RotateFlipType.Rotate270FlipNone)

            thrustingLanderImages(i + 8) = New Bitmap(thrustingLanderImages(i))
            thrustingLanderImages(i + 8).RotateFlip(RotateFlipType.Rotate270FlipNone)

            halfThrustingLanderImages(i + 8) = New Bitmap(halfThrustingLanderImages(i))
            halfThrustingLanderImages(i + 8).RotateFlip(RotateFlipType.Rotate270FlipNone)
        Next

        For i As Integer = 0 To 3
            ' Copy the first set of images to be horizontally flipped (elements 0 to 3)
            ' to their respective elements (elements 16 to 13), and then perform the flip.
            staticLanderImages(16 - i) = New Bitmap(staticLanderImages(i))
            staticLanderImages(16 - i).RotateFlip(RotateFlipType.RotateNoneFlipX)

            thrustingLanderImages(16 - i) = New Bitmap(thrustingLanderImages(i))
            thrustingLanderImages(16 - i).RotateFlip(RotateFlipType.RotateNoneFlipX)

            halfThrustingLanderImages(16 - i) = New Bitmap(halfThrustingLanderImages(i))
            halfThrustingLanderImages(16 - i).RotateFlip(RotateFlipType.RotateNoneFlipX)
        Next

        ' Copy the last set of images to be horizontally flipped (elements 11 to 9)
        ' to their respecive elements (elements 5 to 7), and then perform the flip.
        For i As Integer = 0 To 2

            staticLanderImages(i + 5) = New Bitmap(staticLanderImages(11 - i))
            staticLanderImages(i + 5).RotateFlip(RotateFlipType.RotateNoneFlipX)

            thrustingLanderImages(i + 5) = New Bitmap(thrustingLanderImages(11 - i))
            thrustingLanderImages(i + 5).RotateFlip(RotateFlipType.RotateNoneFlipX)

            halfThrustingLanderImages(i + 5) = New Bitmap(halfThrustingLanderImages(11 - i))
            halfThrustingLanderImages(i + 5).RotateFlip(RotateFlipType.RotateNoneFlipX)
        Next
    End Sub

    Public Function getNewLanderImage(currentAngle As Double, landerHasCrashed As Boolean, landerIsThrusting As Boolean) As Bitmap
        ' Returns a lander image that matches state of the lander object (whether it has crashed, whether it
        ' is thrusting) and the current angle of the lander object.

        ' Calculate the nearest image position to the lander object's actual angle.
        imageIndex = Math.Round(currentAngle / ANGLE_INCREMENT, MidpointRounding.AwayFromZero)

        ' The following If structure uses the calculated image index, as well as lander object properties indicating
        ' whether it has crashed and whether it is currently thrusting, to assign the correct lander image to the picLander
        ' PictureBox control.
        If landerHasCrashed Then
            landerImage = crashedLanderImage
        ElseIf landerIsThrusting And flameIsFlickering Then
            ' If short flame should be rendered this branch executes.
            landerImage = (halfThrustingLanderImages(imageIndex))
        ElseIf landerIsThrusting Then
            ' If a long frame should be rendered this branch executes.
            landerImage = (thrustingLanderImages(imageIndex))
        Else
            ' This branch executes if the lander is not thrusting.
            landerImage = (staticLanderImages(imageIndex))
        End If

        ' This code increments the frame variable on each iteration of the loop, until it
        ' equals the CEILING constant. When this happens, the frame variable is reset to 0,
        ' and the flicker variable's truth value is changed to the opposite state.
        If frame = CEILING Then
            frame = 0
            If flameIsFlickering Then
                flameIsFlickering = False
            Else
                flameIsFlickering = True
            End If
        Else
            frame = frame + 1
        End If

        Return landerImage

    End Function

    Private Function scaleImage(OldImage As Image, TargetHeight As Integer,
                           TargetWidth As Integer) As Image
        ' Thus function scales an image to fit within a target height and width,
        ' while preserving the aspect ratio of the original image.

        ' First the height and width are calculated by matching the height of the
        ' new bitmap to the targetHeight bound.
        Dim NewHeight As Integer = TargetHeight
        Dim NewWidth As Integer = NewHeight / OldImage.Height * OldImage.Width

        ' If the calculated width exceeds the maximum width allowed, newWidth is set
        ' to the targetWidth bound and newHeight is calculated accordingly.
        If NewWidth > TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = NewWidth / OldImage.Width * OldImage.Height
        End If

        Return New Bitmap(OldImage, NewWidth, NewHeight)

    End Function
End Class
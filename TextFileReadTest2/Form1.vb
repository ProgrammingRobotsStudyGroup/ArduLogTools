Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim fileName As String = ""
        Dim n As Int16 = 10
        Select Case n
            Case 1
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000026.log"
            Case 2
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000030.log"
            Case 3
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000031.log"
            Case 4
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000032.log"
            Case 5
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000033.log"
            Case 6
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000034.log"
            Case 7
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000035.log"
            Case 8
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000036.log"
            Case 9
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000037.log"
            Case 10
                fileName = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000037.log"
        End Select




        Dim line As String = ""
        Dim lineNum As Integer = 0
        Dim minLat As Double = 50
        Dim maxLat As Double = 0
        Dim minLng As Double = 0
        Dim maxLng As Double = -150

        Dim thisLat As Double = 0
        Dim thisLng As Double = 0
        Dim lastLat As Double = 0
        Dim lastLng As Double = 0

        Dim thisX As Integer = 0
        Dim thisY As Integer = 0

        Dim angle As Double = 0

        Dim magXmax As Integer = -500
        Dim magXmin As Integer = 500
        Dim magYmax As Integer = -500
        Dim magYmin As Integer = 500
        Dim mag2Xmax As Integer = -500
        Dim mag2Xmin As Integer = 500
        Dim mag2Ymax As Integer = -500
        Dim mag2Ymin As Integer = 500

        '00000026
        'Dim magXavg As Integer = 16
        'Dim magYavg As Integer = 164
        'Dim mag2Xavg As Integer = 105
        'Dim mag2Yavg As Integer = 284

        '        -271 306
        '        -307 307
        '        -251 337
        '        -319 239

        Dim magXavg As Integer = 17
        Dim magYavg As Integer = 0
        Dim mag2Xavg As Integer = 43
        Dim mag2Yavg As Integer = -40

        Dim deltaLat As Double = 0
        Dim deltaLng As Double = 0

        Dim deltaLatFoot As Double = 0
        Dim deltaLngFoot As Double = 0

        Dim dist As Double = 0
        Dim dist2 As Double = 0





        '        Dim AutoMode As Boolean = False
        Dim AutoMode As Boolean = True



        Using reader As New System.IO.StreamReader(fileName)
            While (Not line Is Nothing) 'And lineNum < 50
                lineNum += 1
                line = reader.ReadLine()
                If Not line Is Nothing Then
                    Dim words As String() = line.Split(New Char() {" "c})


                    'Console.WriteLine(words(0))
                    Select Case words(0)
                        Case "xPOS,"
                            thisLat = CDbl(words(2).Substring(0, words(2).Length - 1))
                            thisLng = CDbl(words(3).Substring(0, words(3).Length - 1))
                            Console.Write("Lng= ")
                            Console.Write(thisLng.ToString)
                            Console.Write(", Lat= ")
                            Console.Write(thisLat.ToString)
                            Console.WriteLine("")

                        Case "AHR2,"
                            lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ====, ")
                            Console.Write(lineNum.ToString)
                            Console.Write(", ====, ")
                            Console.Write(line)

                            Dim qq As New Quaternion(CDbl(words(8).Substring(0, words(8).Length - 1)), CDbl(words(9).Substring(0, words(9).Length - 1)), CDbl(words(10).Substring(0, words(10).Length - 1)), CDbl(words(11).Substring(0, words(11).Length - 1)))
                            Dim eu As EulerAngles = ToEulerAngles(qq)
                            Dim i2 As Double = CDbl(words(9).Substring(0, words(9).Length - 1)) ^ 2
                            Dim j2 As Double = CDbl(words(10).Substring(0, words(10).Length - 1)) ^ 2
                            Dim k2 As Double = CDbl(words(11).Substring(0, words(11).Length - 1)) ^ 2
                            Dim rvec As Double = Math.Sqrt(i2 + j2 + k2)

                            Dim x As Double = CDbl(words(8).Substring(0, words(8).Length - 1)) ' * 180 / Math.PI
                            Dim y As Double = Math.Sqrt(CDbl(words(9).Substring(0, words(9).Length - 1)) ^ 2 + CDbl(words(10).Substring(0, words(10).Length - 1)) ^ 2 + CDbl(words(11).Substring(0, words(11).Length - 1)) ^ 2)
                            Console.Write(", ===eu=, ")
                            Console.Write(eu.ToString)
                            Console.Write(", ===yaw=, ")
                            'Console.Write(eu.Yaw * 180 / Math.PI)
                            Console.Write((360 + eu.Yaw * 180 / Math.PI) Mod 360)

                            'Q length, worked!
                            'Dim l As Double = x ^ 2 + i2 + j2 + k2
                            'Console.Write(", ===QLen=, ")
                            'Console.Write(l)

                            Console.WriteLine(" ")
                            'Console.WriteLine(" ================================================================================================================================ ")

                        Case "NKQ2,"
                            lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ====, ")
                            Console.Write(lineNum.ToString)
                            Console.Write(", ====, ")
                            'Console.Write(line)

                            Console.Write(words(0))
                            Console.Write(words(1))
                            Console.Write(" ==================================================,,,,,, ")
                            Console.Write(words(2))
                            'Console.Write(", ")
                            Console.Write(words(3))
                            'Console.Write(", ")
                            Console.Write(words(4))
                            'Console.Write(", ")
                            Console.Write(words(5))
                            Console.Write(", ")


                            Dim qq As New Quaternion(CDbl(words(2).Substring(0, words(2).Length - 1)), CDbl(words(3).Substring(0, words(3).Length - 1)), CDbl(words(4).Substring(0, words(4).Length - 1)), CDbl(words(5).Substring(0, words(5).Length - 1)))
                            Dim eu As EulerAngles = ToEulerAngles(qq)
                            Dim i2 As Double = CDbl(words(3).Substring(0, words(3).Length - 1)) ^ 2
                            Dim j2 As Double = CDbl(words(4).Substring(0, words(4).Length - 1)) ^ 2
                            Dim k2 As Double = CDbl(words(5).Substring(0, words(5).Length - 1)) ^ 2
                            Dim rvec As Double = Math.Sqrt(i2 + j2 + k2)

                            Dim x As Double = CDbl(words(2).Substring(0, words(2).Length - 1)) ' * 180 / Math.PI
                            Dim y As Double = Math.Sqrt(CDbl(words(3).Substring(0, words(3).Length - 1)) ^ 2 + CDbl(words(4).Substring(0, words(4).Length - 1)) ^ 2 + CDbl(words(5).Substring(0, words(5).Length - 1)) ^ 2)
                            Console.Write(" ===eu=, ")
                            Console.Write(eu.ToString)
                            Console.Write(", ===yaw=, ")
                            'Console.Write(eu.Yaw * 180 / Math.PI)
                            Console.Write((360 + eu.Yaw * 180 / Math.PI) Mod 360)


                            'Q length tests for unit q length.  Checked out great.
                            'Dim l As Double = x ^ 2 + i2 + j2 + k2
                            'Console.Write(", ==================================================================QLen=, ")
                            'Console.Write(l)

                            'CDbl(words(2).Substring(0, words(2).Length - 1))
                            Console.WriteLine(" ")
                            'Console.WriteLine(" ================================================================================================================================ ")

                        Case "MSG,"
                            lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ==== ")
                            Console.Write(lineNum.ToString)
                            Console.Write(" ==== ")
                            Console.Write(line)
                            Console.WriteLine(" ================================================================================================================================ ")

                        Case "xRCOU,"
                            lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ==== ")
                            Console.Write(lineNum.ToString)
                            Console.Write(" ==== ")
                            Console.Write(line)
                            Console.Write(" =========================================== ")
                            Console.Write(words(2))
                            Console.Write(" ==== ")
                            Console.Write(words(4))
                            Console.WriteLine("")

                        Case "MODE,"
                            lineNum += 1
                            If words(2) = "Auto," Then
                                AutoMode = True
                            End If

                            If words(2) = "Manual," Then
                                'AutoMode = False               'debug should be in use
                            End If


                            Console.Write(words(0))
                            Console.Write(" ==== ")
                            Console.Write(lineNum.ToString)
                            Console.Write(" ==== ")
                            Console.WriteLine(line)

                        Case "MAG,"
                            lineNum += 1
                            If AutoMode Then

                                'Get the range of values
                                thisX = CDbl(words(2).Substring(0, words(2).Length - 1))
                                thisY = CDbl(words(3).Substring(0, words(3).Length - 1))

                                If magXmax < thisX Then
                                    magXmax = thisX
                                End If
                                If magXmin > thisX Then
                                    magXmin = thisX
                                End If

                                If magYmax < thisY Then
                                    magYmax = thisY
                                End If
                                If magYmin > thisY Then
                                    magYmin = thisY
                                End If



                                'angle = Math.Atan2(thisX - magXavg, thisY - magYavg)
                                angle = (Math.Atan2(-(thisY - magYavg), thisX - magXavg) + 2 * Math.PI) Mod (2 * Math.PI)


                                Console.Write(words(0))
                                Console.Write("  ====, ")
                                Console.Write(lineNum.ToString)
                                Console.Write(", ====, ")
                                Console.Write(line)
                                Console.Write(",                                                                                                                        mag  ====, ")
                                'Console.Write((angle * 180 / Math.PI).ToString)
                                Console.WriteLine(Format(angle * 180 / Math.PI, "0.0"))

                            End If

                        Case "MAG2,"
                            lineNum += 1
                            If AutoMode Then

                                'Get the range of values
                                thisX = CDbl(words(2).Substring(0, words(2).Length - 1))
                                thisY = CDbl(words(3).Substring(0, words(3).Length - 1))

                                If mag2Xmax < thisX Then
                                    mag2Xmax = thisX
                                End If
                                If mag2Xmin > thisX Then
                                    mag2Xmin = thisX
                                End If

                                If mag2Ymax < thisY Then
                                    mag2Ymax = thisY
                                End If
                                If mag2Ymin > thisY Then
                                    mag2Ymin = thisY
                                End If

                                'angle = Math.Atan2(thisX - mag2Xavg, thisY - mag2Xavg)
                                angle = (Math.Atan2(-(thisY - mag2Yavg), thisX - mag2Xavg) + 2 * Math.PI) Mod (2 * Math.PI)

                                Console.Write(words(0))
                                Console.Write(" ====, ")
                                Console.Write(lineNum.ToString)
                                Console.Write(", ====, ")
                                Console.Write(line)
                                Console.Write(",                                                                                                                        mag2 ====, ")
                                'Console.Write((angle * 180 / Math.PI).ToString)
                                Console.WriteLine(Format(angle * 180 / Math.PI, "0.0"))

                            End If

                        Case "xPOS,"
                            thisLat = CDbl(words(2).Substring(0, words(2).Length - 1))
                            thisLng = CDbl(words(3).Substring(0, words(3).Length - 1))
                            Console.Write("Lng= ")
                            Console.Write(thisLng.ToString)
                            Console.Write(", Lat= ")
                            Console.Write(thisLat.ToString)
                            Console.WriteLine("")


                        Case "POS,"
                            lineNum += 1
                            If AutoMode Then

                                'temp output removal
                                If False Then

                                    Console.Write(words(0))
                                    Console.Write(" ==== ")
                                    Console.Write(lineNum.ToString)

                                    Console.Write(" ==== ")

                                    Console.WriteLine(line)
                                End If

                                'Get the range of values
                                thisLat = CDbl(words(2).Substring(0, words(2).Length - 1))
                                thisLng = CDbl(words(3).Substring(0, words(3).Length - 1))


                                If minLat > thisLat Then
                                    minLat = thisLat
                                End If

                                If maxLat < thisLat Then
                                    maxLat = thisLat
                                End If

                                If minLng > thisLng Then
                                    minLng = thisLng
                                End If

                                If maxLng < thisLng Then
                                    maxLng = thisLng
                                End If


                                'Check travel distance and report at regular distance


                                deltaLat = thisLat - lastLat
                                deltaLng = thisLng - lastLng

                                deltaLatFoot = 4000 * 5280 * Math.Sin(deltaLat * Math.PI / 180)
                                deltaLngFoot = 4000 * 5280 * Math.Sin(deltaLng * Math.PI / 180) / Math.Cos(lastLat * Math.PI / 180)


                                dist2 = deltaLatFoot ^ 2 + deltaLngFoot ^ 2
                                If dist2 > 1 Then
                                    dist = Math.Sqrt(dist2)
                                    angle = ((Math.Atan2(deltaLngFoot, deltaLatFoot) / (Math.PI / 180)) + 180 + 180) Mod 360

                                    Console.Write("deltaLng=, ")
                                    Console.Write(deltaLng.ToString)
                                    Console.Write(", deltaLat=, ")
                                    Console.Write(deltaLat.ToString)
                                    Console.Write(", deltaLngFoot=, ")
                                    Console.Write(deltaLngFoot.ToString)
                                    Console.Write(", deltaLatFoot=, ")
                                    Console.Write(deltaLatFoot.ToString)
                                    Console.Write(",                                                                                                gps heading =, ")
                                    Console.Write(angle.ToString)
                                    'Console.Write(", ==== ")
                                    Console.WriteLine("")

                                    lastLat = thisLat
                                    lastLng = thisLng
                                End If


                            End If

                    End Select
                End If

                'Console.Write(words(3))
                'Console.Write(" ==== ")

            End While
            Console.WriteLine(minLat.ToString)
            Console.WriteLine(maxLat.ToString)
            Console.WriteLine(minLng.ToString)
            Console.WriteLine(maxLng.ToString)

            Console.WriteLine(magXmin.ToString + " " + magXmax.ToString)
            Console.WriteLine(magYmin.ToString + " " + magYmax.ToString)
            Console.WriteLine(mag2Xmin.ToString + " " + mag2Xmax.ToString)
            Console.WriteLine(mag2Ymin.ToString + " " + mag2Ymax.ToString)


            Console.WriteLine("Atan2 math testing")
            Console.WriteLine(Math.Atan2(1, 0) * 180 / Math.PI)
            Console.WriteLine(Math.Atan2(1, 1) * 180 / Math.PI)
            Console.WriteLine(Math.Atan2(0, 1) * 180 / Math.PI)







        End Using

    End Sub

    Public Structure Quaternion
        Implements IEquatable(Of Quaternion)

        Public ReadOnly W, X, Y, Z As Double

        Public Sub New(w As Double, x As Double, y As Double, z As Double)
            'New.x = x
            Me.W = w
            Me.X = x
            Me.Y = y
            Me.Z = z
        End Sub

        Public Overrides Function ToString() As String
            Return $"Q({Me.W}, {Me.X}, {Me.Y}, {Me.Z})"
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj IsNot Quaternion Then Return False
            Return Me.Equals(DirectCast(obj, Quaternion))
        End Function

        Public Overloads Function Equals(other As Quaternion) As Boolean Implements IEquatable(Of Quaternion).Equals
            Return other = Me
        End Function

        Public ReadOnly Property Norm As Double
            Get
                Return Math.Sqrt((Me.W ^ 2) + (Me.X ^ 2) + (Me.Y ^ 2) + (Me.Z ^ 2))
            End Get
        End Property

        Public ReadOnly Property Conjugate As Quaternion
            Get
                Return New Quaternion(Me.W, -Me.X, -Me.Y, -Me.Z)
            End Get
        End Property

#Region "Operators"

        Public Shared Operator =(left As Quaternion, right As Quaternion) As Boolean
            Return left.W = right.W AndAlso
               left.X = right.X AndAlso
               left.Y = right.Y AndAlso
               left.Z = right.Z
        End Operator

        Public Shared Operator <>(left As Quaternion, right As Quaternion) As Boolean
            Return Not left = right
        End Operator

        Public Shared Operator +(q1 As Quaternion, q2 As Quaternion) As Quaternion
            Return New Quaternion(q1.W + q2.W, q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z)
        End Operator

        Public Shared Operator -(q As Quaternion) As Quaternion
            Return New Quaternion(-q.W, -q.X, -q.Y, -q.Z)
        End Operator

        Public Shared Operator *(q1 As Quaternion, q2 As Quaternion) As Quaternion
            Return New Quaternion(
            (q1.W * q2.W) - (q1.X * q2.X) - (q1.Y * q2.Y) - (q1.Z * q2.Z),
            (q1.W * q2.X) + (q1.X * q2.W) + (q1.Y * q2.Z) - (q1.Z * q2.Y),
            (q1.W * q2.Y) - (q1.X * q2.Z) + (q1.Y * q2.W) + (q1.Z * q2.X),
            (q1.W * q2.Z) + (q1.X * q2.Y) - (q1.Y * q2.X) + (q1.Z * q2.W))
        End Operator

#End Region

    End Structure

    Public Structure EulerAngles
        Public Roll, Pitch, Yaw As Double

        Public Sub New(roll As Double, pitch As Double, yaw As Double)
            'New.x = x
            Me.Roll = roll
            Me.Pitch = pitch
            Me.Yaw = yaw
        End Sub

        Public Overrides Function ToString() As String
            Return $"E({Me.Roll}, {Me.Pitch}, {Me.Yaw})"
        End Function

    End Structure

    Function ToEulerAngles(q As Quaternion) As EulerAngles
        Dim angles As New EulerAngles(0, 0, 0)
        'roll (x-axis rotation)
        Dim sinr_cosp As Double = 2 * (q.W * q.X + q.Y * q.Z)
        Dim cosr_cosp As Double = 1 - 2 * (q.X * q.X + q.Y * q.Y)
        angles.Roll = Math.Atan2(sinr_cosp, cosr_cosp)

        'pitch (y-axis rotation)
        Dim sinp As Double = 2 * (q.W * q.Y - q.Z * q.X)

        If (Math.Abs(sinp) >= 1) Then
            angles.Pitch = Math.Sign(sinp) * (Math.PI / 2) 'use 90 degrees If out Of range
        Else
            angles.Pitch = Math.Asin(sinp)
        End If

        'yaw (z-axis rotation)
        Dim siny_cosp As Double = 2 * (q.W * q.Z + q.X * q.Y)
        Dim cosy_cosp As Double = 1 - 2 * (q.Y * q.Y + q.Z * q.Z)
        angles.Yaw = Math.Atan2(siny_cosp, cosy_cosp)

        Return angles

    End Function

    Function ToQuaternion(e As EulerAngles) As Quaternion
        'Quaternion ToQuaternion(Double yaw, Double pitch, Double roll) // yaw(Z), pitch(Y), roll(X)
        '{
        '// Abbreviations for the various angular functions
        Dim cy As Double = Math.Cos(e.Yaw * 0.5)
        Dim sy As Double = Math.Sin(e.Yaw * 0.5)
        Dim cp As Double = Math.Cos(e.Pitch * 0.5)
        Dim sp As Double = Math.Sin(e.Pitch * 0.5)
        Dim cr As Double = Math.Cos(e.Roll * 0.5)
        Dim SR As Double = Math.Sin(e.Roll * 0.5)

        Dim q As New Quaternion(cr * cp * cy + SR * sp * sy, SR * cp * cy - cr * sp * sy, cr * sp * cy + SR * cp * sy, cr * cp * sy - SR * sp * cy)
        'q.W = cr * cp * cy + SR * sp * sy
        'q.X = SR * cp * cy - cr * sp * sy
        'q.Y = cr * sp * cy + SR * cp * sy
        'q.Z = cr * cp * sy - SR * sp * cy

        Return q

    End Function

End Class

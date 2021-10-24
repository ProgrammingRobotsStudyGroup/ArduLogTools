Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileName As String = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000030.log"
        'Dim fileName As String = "C:\Users\steve\OneDrive\Documents\Mission Planner\logs\00000026.log"
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
                        Case "MSG,"
                            lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ==== ")
                            Console.Write(lineNum.ToString)
                            Console.Write(" ==== ")
                            Console.WriteLine(line)

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
                                Console.Write("  ==== ")
                                'Console.Write((angle * 180 / Math.PI).ToString)
                                Console.Write(Format(angle * 180 / Math.PI, "0.0"))
                                Console.Write(" ==== ")
                                Console.Write(lineNum.ToString)
                                Console.Write(" ==== ")
                                Console.WriteLine(line)

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
                                Console.Write(" ==== ")
                                'Console.Write((angle * 180 / Math.PI).ToString)
                                Console.Write(Format(angle * 180 / Math.PI, "0.0"))
                                Console.Write(" ==== ")
                                Console.Write(lineNum.ToString)
                                Console.Write(" ==== ")
                                Console.WriteLine(line)

                            End If

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

                                        Console.Write("deltaLng= ")
                                        Console.Write(deltaLng.ToString)
                                        Console.Write(" deltaLat= ")
                                        Console.Write(deltaLat.ToString)
                                        Console.Write(" deltaLngFoot= ")
                                        Console.Write(deltaLngFoot.ToString)
                                        Console.Write(" deltaLatFoot= ")
                                        Console.Write(deltaLatFoot.ToString)
                                        Console.Write(" angle= ")
                                        Console.Write(angle.ToString)
                                        Console.Write(" ==== ")
                                        Console.WriteLine(" ==== ")

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


        End Using

    End Sub
End Class

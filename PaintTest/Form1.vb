Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Dim r1 As Int16 = 10  'row 1, MAG
    Dim r2 As Int16 = r1 + 40 'row 2, MAG2
    Dim r3 As Int16 = r2 + 40 'row 3, MAG

    Dim c1 As Int16 = 10  'starting column
    Dim p1 As Point
    Dim p2 As Point

    Dim square As New Rectangle(c1, r1, 40, 40)

    Dim mag As Double = 60
    'Dim mag2 As Double

    Dim minlat As Double = 99    '33.2102168       'most south
    Dim maxlat As Double = 0    '33.2102168       'most north
    'Dim maxlng As Double = -111.6178294


    Dim pathminlat As Double = 33.2102168
    Dim pathmaxlat As Double = 33.2107578       'most north
    Dim pathminlng As Double = -111.6182223     'most west
    Dim pathmaxlng As Double = -111.6178294

    '-111.6181051, Lat= 33.210492

    Dim pathsizelat As Double = pathmaxlat - pathminlat
    Dim pathsizelng As Double = pathmaxlng - pathminlng

    Dim wpNoMax As Double = 0
    Dim wpNo As Double = 0
    Dim wpLat As Double = 0
    Dim wpLng As Double = 0

    Dim wpRad As Single = 0
    Dim wp As Point

    Dim mapscale As Double = 4000000  '4000000

    Private Function Earth2Form(lat As Double, lng As Double) As Point

        Earth2Form.Y = -((lat - pathmaxlat) * mapscale)
        Earth2Form.X = 240 + ((lng - pathminlng) * mapscale) * Math.Cos(33.2 * Math.PI / 180)

    End Function




    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Dim AutoMode As Boolean = False

        Dim fileName As String = ""
        Dim n As Int16 = 8
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
        End Select







        Dim line As String = ""
        Dim lastPos As Point
        lastPos.X = 0
        lastPos.Y = 0
        Dim lastLng As Double = 0
        Dim lastLat As Double = 0
        Dim thisLng As Double = 0
        Dim thisLat As Double = 0
        Dim deltaLat As Double = 0
        Dim deltaLng As Double = 0
        Dim pencolor As Boolean = False

        Using reader As New System.IO.StreamReader(fileName)
            While (Not line Is Nothing) 'And lineNum < 50
                line = reader.ReadLine()
                If Not line Is Nothing Then
                    Dim words As String() = line.Split(New Char() {" "c})
                    Select Case words(0)
                        Case "MSG,"
                            'lineNum += 1
                            Console.Write(words(0))
                            Console.Write(" ==== ")
                            'Console.Write(lineNum.ToString)
                            Console.Write(" ==== ")
                            Console.WriteLine(line)

                            If words(2).StartsWith("Miss") Then
                                Console.Write(" ====color change ========================================= ")
                                Console.WriteLine(line)
                                If pencolor Then
                                    pencolor = False
                                Else
                                    pencolor = True
                                End If

                            End If


                            If words(2).StartsWith("Mission Complete") Then
                                Console.Write(" ====Mission Complete turn off recording ========================================= ")
                                Console.WriteLine(line)
                                AutoMode = False
                            End If

                            '




                        Case "POS,"
                            If AutoMode Then
                                thisLat = CDbl(words(2).Substring(0, words(2).Length - 1))
                                thisLng = CDbl(words(3).Substring(0, words(3).Length - 1))
                                deltaLat = thisLat - lastLat
                                deltaLng = thisLng - lastLng

                                If thisLat < minlat Then
                                    minlat = thisLat
                                End If

                                If thisLat > maxlat Then
                                    maxlat = thisLat
                                End If

                                If lastPos.X = 0 Then
                                    lastPos.X = thisLng
                                    lastPos.Y = thisLat
                                    lastLat = thisLat
                                    lastLng = thisLng

                                Else
                                    If Math.Abs(deltaLat) > 0.000001 Or Math.Abs(deltaLng) > 0.000001 Then
                                        Using pen1 As New Pen(Color.Blue)
                                            If pencolor Then
                                                pen1.Color = Color.Red
                                            End If
                                            p1 = Earth2Form(lastLat, lastLng)
                                            p2 = Earth2Form(thisLat, thisLng)
                                            e.Graphics.DrawLine(pen1, p1, p2)
                                        End Using

                                        lastLat = thisLat
                                        lastLng = thisLng
                                        Console.Write("Lng= ")
                                        Console.Write(thisLng.ToString)
                                        Console.Write(", Lat= ")
                                        Console.Write(thisLat.ToString)
                                        'Console.WriteLine("")
                                        Console.Write(", deltaLng= ")
                                        Console.Write(deltaLng.ToString)
                                        Console.Write(", deltaLat= ")
                                        Console.Write(deltaLat.ToString)
                                        Console.Write(", p1= ")
                                        Console.Write(p1.ToString)
                                        Console.Write(", p2= ")
                                        Console.Write(p2.ToString)
                                        Console.WriteLine("")

                                    End If

                                End If

                            End If
                        Case "MODE,"
                            'lineNum += 1
                            If words(2) = "Auto," Then
                                AutoMode = True
                                Console.WriteLine("Automode=true==================================")
                            End If

                            If words(2) = "xManual," Then
                                AutoMode = False               'debug should be in use
                                Console.WriteLine("Automode=false==================================")
                            End If


                            'Console.Write(words(0))
                            'Console.Write(" ==== ")
                            'Console.Write(lineNum.ToString)
                            'Console.Write(" ==== ")
                            'Console.WriteLine(line)

                        Case "PARM,"
                            If words(2) = "WP_RADIUS," Then
                                wpRad = CDbl(words(3))
                                Console.Write("wpRad = ")
                                Console.WriteLine(wpRad.ToString)
                            End If

                        Case "CMD,"
                            wpNo = CDbl(words(3).Substring(0, words(3).Length - 1))

                            If wpNo > wpNoMax Then
                                wpNoMax = wpNo
                                wpLat = CDbl(words(9).Substring(0, words(9).Length - 1))
                                wpLng = CDbl(words(10).Substring(0, words(10).Length - 1))
                                wp = Earth2Form(wpLat, wpLng)
                                Console.Write("wpNoMax = ")
                                Console.WriteLine(wpNoMax.ToString)

                                '35.6 or 42.7

                                Using penwp As New Pen(Color.Blue)
                                    e.Graphics.DrawEllipse(penwp, CSng(wp.X - wpRad * 35.6 * mapscale / 4000000), CSng(wp.Y - wpRad * 35.6 * mapscale / 4000000), CSng(wpRad * 2 * 35.6 * mapscale / 4000000), CSng(wpRad * 2 * 35.6 * mapscale / 4000000))
                                End Using





                            End If


                            'CMD, 156379158, 6, 0, 16, 0, 0, 0, 0, 33.2104508, -111.618062, 0.8, 0
                            'CMD, 156379172, 6, 1, 16, 0, 0, 0, 0, 33.210579, -111.6180803, 100, 3
                            'CMD, 156379185, 6, 2, 16, 0, 0, 0, 0, 33.2106907, -111.6180796, 100, 3
                            'CMD, 156379254, 6, 3, 16, 0, 0, 0, 0, 33.2106872, -111.618205, 100, 3
                            'CMD, 156379267, 6, 4, 16, 0, 0, 0, 0, 33.2105717, -111.6182144, 100, 3
                            'CMD, 156379280, 6, 5, 16, 0, 0, 0, 0, 33.2105728, -111.61814, 100, 3


                    End Select
                End If
            End While
        End Using
        Console.WriteLine("====================")
        Console.Write("==path Lat range==================")
        Console.WriteLine(pathmaxlat - pathminlat)
        Console.Write("==path Lng range==================")
        Console.WriteLine(pathmaxlng - pathminlng)
        Console.WriteLine(e.Graphics.VisibleClipBounds.ToString)
        Console.WriteLine("====================")

        Console.Write("==min Lat ==================")
        Console.WriteLine(minlat)
        Console.Write("==max Lat ==================")
        Console.WriteLine(maxlat)


        'Using pen1 As New Pen(Color.Blue)
        '    e.Graphics.DrawRectangle(pen1, square)
        '    square.Y = r2
        '    e.Graphics.DrawRectangle(pen1, square)
        '    p1.X = c1 + 20
        '    p1.Y = r2 + 20
        '    p2.X = p1.X + 15 * Math.Sin(mag * Math.PI / 180)
        '    p2.Y = p1.Y - 15 * Math.Cos(mag * Math.PI / 180)

        '    e.Graphics.DrawLine(pen1, p1, p2)
        'End Using

        'Using brush1 As New SolidBrush(Color.Blue)
        '    e.Graphics.FillEllipse(brush1, c1 + 17, r2 + 17, 6, 6)

        'End Using


    End Sub
End Class

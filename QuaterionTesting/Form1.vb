Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class Form1
    Dim xv As New Quaternion(0, 1, 0, 0)
    Dim yv As New Quaternion(0, 0, 1, 0)
    Dim zv As New Quaternion(0, 0, 0, 1)
    Dim v As New Quaternion(0, 1, 0, 0)
    Dim q As New Quaternion(0, 0, 0, 1)
    Dim qp As New Quaternion(0, 0, 0, 1)

    Dim ve As New Vector3(0, 0, 1)
    Dim theta As Double = 0
    Dim hthetar As Double = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        qp = q.Conjugate
        'v.Z = 1

        'Test Quaternions creation and multiplication
        Console.Write("q = ")
        Console.WriteLine(q.ToString)
        Console.Write("qp = ")
        Console.WriteLine(qp.ToString)

        Dim r As Quaternion = zv * xv   'Z*X should yield Y = (0,0,1,0)

        Console.Write("xv = ")
        Console.WriteLine(xv.ToString)
        Console.Write("zv = ")
        Console.WriteLine(zv.ToString)
        Console.Write("x*z = ")
        Console.WriteLine(r.ToString)

        'Test rotations using Quaternions
        TextBox1.Text = "Quaternion rotation"
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += Environment.NewLine
        theta = 90
        Console.WriteLine("   theta {0}", Math.Sin(torad(theta)))
        TextBox1.Text += "   rotation theta = " & theta.ToString
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += "   starting point(v) = " & v.ToString
        TextBox1.Text += Environment.NewLine

        ve = New Vector3(0, 0, 1)
        TextBox1.Text += "   rotation vector = " & ve.ToString
        TextBox1.Text += Environment.NewLine

        'q = New Quaternion(Math.Cos(torad(theta) / 2), Math.Sin(torad(theta) / 2), Math.Sin(torad(theta) / 2), Math.Sin(torad(theta) / 2))

        q = New Quaternion(0, ve.X, ve.Y, ve.Z)
        q = q * New Quaternion(1 / q.Norm, 0, 0, 0)

        q = New Quaternion(Math.Cos(torad(theta) / 2), q.X * Math.Sin(torad(theta) / 2), q.Y * Math.Sin(torad(theta) / 2), q.Z * Math.Sin(torad(theta) / 2))

        'q = New Quaternion(Math.Cos(torad(theta) / 2), 0, 0, Math.Sin(torad(theta) / 2))


        q = q * New Quaternion(1 / q.Norm, 0, 0, 0)
        qp = q.Conjugate
        TextBox1.Text += "   rotation quaternion (q) (half angle) = " & q.ToString
        TextBox1.Text += Environment.NewLine

        Console.WriteLine("v = {0}", v.ToString)
        Console.WriteLine("q = {0}", q.ToString)
        Console.WriteLine("qp = {0}", qp.ToString)

        r = (q * v) * qp

        Console.WriteLine("q*v*q' = {0}", r.ToString)

        TextBox1.Text += $"   q*v*q' = {r.ToString}"
        '$"V({Me.X}, {Me.Y}, {Me.Z})"

        '===================================================================================================================
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += Environment.NewLine

        theta = 120
        Console.WriteLine("   theta {0}", Math.Sin(torad(theta)))
        TextBox1.Text += "   rotation theta = " & theta.ToString
        TextBox1.Text += Environment.NewLine
        v = New Quaternion(0, 1, 0, 0)
        TextBox1.Text += "   starting point(v) = " & v.ToString
        TextBox1.Text += Environment.NewLine

        ve = New Vector3(1, 1, 1)
        TextBox1.Text += "   rotation vector = " & ve.ToString
        TextBox1.Text += Environment.NewLine

        q = New Quaternion(0, ve.X, ve.Y, ve.Z)
        q = q * New Quaternion(1 / q.Norm, 0, 0, 0)

        q = New Quaternion(Math.Cos(torad(theta) / 2), q.X * Math.Sin(torad(theta) / 2), q.Y * Math.Sin(torad(theta) / 2), q.Z * Math.Sin(torad(theta) / 2))


        'q = New Quaternion(Math.Cos(torad(theta) / 2), Math.Sin(torad(theta) / 2), Math.Sin(torad(theta) / 2), Math.Sin(torad(theta) / 2))
        'q = New Quaternion(Math.Cos(torad(theta) / 2), Math.Sin(torad(theta) / 2), 0, Math.Sin(torad(theta) / 2))

        'q = New Quaternion(Math.Cos(torad(theta) / 2), 0, 0, Math.Sin(torad(theta) / 2))

        q = q * New Quaternion(1 / q.Norm, 0, 0, 0)
        qp = q.Conjugate

        TextBox1.Text += "   rotation quaternion (q) (half angle) = " & q.ToString
        TextBox1.Text += Environment.NewLine

        Console.WriteLine("v = {0}", v.ToString)
        Console.WriteLine("q = {0}", q.ToString)
        Console.WriteLine("qp = {0}", qp.ToString)

        r = (q * v) * qp

        Console.WriteLine("q*v*q' = {0}", r.ToString)

        TextBox1.Text += $"   q*v*q' = {r.ToString}"
        '$"V({Me.X}, {Me.Y}, {Me.Z})"























        '===================================================================================================================



        'Vector testing
        Dim vv As New Vector3(1, 2, 3)
        Console.Write("vector vv = ")
        Console.WriteLine(vv.ToString)
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += "Vector3 test"
        TextBox1.Text += Environment.NewLine
        TextBox1.Text += "   vector vv = " & vv.ToString

        TextBox1.SelectAll()
        TextBox1.DeselectAll()


    End Sub

    Private Function torad(deg As Double) As Double
        Return deg * Math.PI / 180
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class



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

Public Structure Vector3
    Implements IEquatable(Of Vector3) ', IFormattable

    Public ReadOnly X, Y, Z As Double
#Disable Warning BC40005 ' Member shadows an overridable method in the base type
    Public Function Equals(other As Vector3) As Boolean Implements IEquatable(Of Vector3).Equals
#Enable Warning BC40005 ' Member shadows an overridable method in the base type
        Throw New NotImplementedException()
    End Function

    Public Overrides Function ToString() As String ' Implements IFormattable.ToString       ', formatProvider As IFormatProvider
        '#Enable Warning BC40005 ' Member shadows an overridable method in the base type
        'Throw New NotImplementedException()
        Return $"V({Me.X}, {Me.Y}, {Me.Z})"
    End Function

    Public Sub New(x As Single, y As Single, z As Single)
        Me.X = x
        Me.Y = y
        Me.Z = z

    End Sub

End Structure


﻿Imports System.Runtime.InteropServices
Imports System.Drawing

Partial Public Class PixColormap
    Public ReadOnly Property Array_Bytes As Byte()
        Get
            If IsNothing(Values) Then Return Nothing
            Dim SRC((n * 4) - 1) As Byte : Marshal.Copy(array, SRC, 0, SRC.Length)
            Return SRC
        End Get
    End Property
    Public ReadOnly Property Array_RGBAQ As RGBA_Quad()
        Get
            If IsNothing(Values) Then Return Nothing
            Dim QList As New List(Of RGBA_Quad)
            For i As Integer = 0 To n - 1
                QList.Add(New RGBA_Quad(Values.array + (4 * i)))
            Next
            Return QList.ToArray
        End Get
    End Property
    Public ReadOnly Property Array_Color As Color()
        Get
            If IsNothing(Values) Then Return Nothing
            Dim QList As New List(Of Color)
            For i As Integer = 0 To Array_Bytes.Count - 1 Step 4
                Dim B(3) As Byte : System.Array.Copy(Array_Bytes, i, B, 0, B.Length)
                QList.Add(Color.FromArgb(B(0), B(1), B(2), B(3)))
            Next
            Return QList.ToArray
        End Get
    End Property
End Class

Partial Public Class RGBA_Quad
    ReadOnly Property AsSystemColor
        Get
            Return Color.FromArgb(Values.alpha, Values.red, Values.green, Values.blue)
        End Get
    End Property
    Sub New(ByVal r, ByVal g, ByVal b, ByVal a)
        Values = New Marshal_RGBA_Quad
        Values.red = r
        Values.green = g
        Values.blue = b
        Values.alpha = a
    End Sub
    Public Overrides Function ToString() As String
        Return "R:" & red & " G:" & green & " B:" & blue & " A:" & alpha
    End Function
End Class

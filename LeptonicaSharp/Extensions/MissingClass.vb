﻿Imports System.Runtime.InteropServices

Public Class CQCELL
    Property Pointer As IntPtr
    Sub New(ByVal IntPTR As IntPtr)

    End Sub
End Class
Public Class FILE
    Property Pointer As IntPtr
    Sub New(ByVal IntPTR As IntPtr)

    End Sub
End Class

Public Class UnknownClass
    Property _Pointer As IntPtr
    Public Overrides Function ToString() As String
        Return _Pointer
    End Function
    Sub New(ByVal Pointer As IntPtr)
        _Pointer = Pointer
    End Sub
    ReadOnly Property TryAs_Pix
        Get
            Return New pix(_Pointer)
        End Get
    End Property
    ReadOnly Property TryAs_Pixa
        Get
            Return New Pixa(_Pointer)
        End Get
    End Property
    ReadOnly Property TryAs_Pixaa
        Get
            Return New Pixaa(_Pointer)
        End Get
    End Property
    ReadOnly Property TryAs_RGBA_Quad
        Get
            Return New RGBA_Quad(_Pointer)
        End Get
    End Property
    ReadOnly Property TryAs_Array_Bytes
        Get
            Dim N(100) As Byte
            Marshal.Copy(_Pointer, N, 0, N.Length)
            Return N
        End Get
    End Property
    ReadOnly Property TryAs_Array_IntPTR
        Get
            Dim N(100) As IntPtr
            Dim UKL As New List(Of UnknownClass)
            Marshal.Copy(_Pointer, N, 0, N.Length)
            For Each eintrag In N
                UKL.Add(New UnknownClass(eintrag))
            Next
            Return UKL
        End Get
    End Property
End Class
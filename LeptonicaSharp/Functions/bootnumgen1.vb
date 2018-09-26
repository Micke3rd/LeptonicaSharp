Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\bootnumgen1.c (290, 1)
' l_bootnum_gen1()
' l_bootnum_gen1() as PIXA *
'''  <summary>
''' Call this way
''' PIXA  pixa = l_bootnum_gen1();   (C)
''' Pixa  pixa = l_bootnum_gen1();   (C++)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''   <returns>pixa  of labeled digits</returns>
Public Shared Function l_bootnum_gen1() as Pixa



	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_bootnum_gen1( )
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

End Class

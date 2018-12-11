Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' binexpand.c (67, 1)
' pixExpandBinaryReplicate(pixs, xfact, yfact) as Pix
' pixExpandBinaryReplicate(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' pixExpandBinaryReplicate()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixExpandBinaryReplicate/*"/>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="xfact">[in] - integer scale factor for horiz. replicative expansion</param>
'''  <param name="yfact">[in] - integer scale factor for vertical replicative expansion</param>
'''   <returns>pixd scaled up, or NULL on error</returns>
Public Shared Function pixExpandBinaryReplicate(
				ByVal pixs as Pix, 
				ByVal xfact as Integer, 
				ByVal yfact as Integer) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")
	Dim _Result as IntPtr = Natives.pixExpandBinaryReplicate(pixs.Pointer,   xfact,   yfact)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' binexpand.c (132, 1)
' pixExpandBinaryPower2(pixs, factor) as Pix
' pixExpandBinaryPower2(PIX *, l_int32) as PIX *
'''  <summary>
''' pixExpandBinaryPower2()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixExpandBinaryPower2/*"/>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="factor">[in] - expansion factor: 1, 2, 4, 8, 16</param>
'''   <returns>pixd expanded 1 bpp by replication, or NULL on error</returns>
Public Shared Function pixExpandBinaryPower2(
				ByVal pixs as Pix, 
				ByVal factor as Integer) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")
	Dim _Result as IntPtr = Natives.pixExpandBinaryPower2(pixs.Pointer,   factor)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

End Class



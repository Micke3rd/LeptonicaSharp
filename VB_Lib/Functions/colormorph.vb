Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' colormorph.c (66, 1)
' pixColorMorph(pixs, type, hsize, vsize) as Pix
' pixColorMorph(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' (1) This does the morph operation on each component separately,
'''and recombines the result.<para/>
'''
'''(2) Sel is a brick with all elements being hits.<para/>
'''
'''(3) If hsize = vsize = 1, just returns a copy.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixColorMorph/*"/>
'''  <param name="pixs">[in] - </param>
'''  <param name="type">[in] - L_MORPH_DILATE, L_MORPH_ERODE, L_MORPH_OPEN, or L_MORPH_CLOSE</param>
'''  <param name="hsize">[in] - of Sel must be odd origin implicitly in center</param>
'''  <param name="vsize">[in] - ditto</param>
'''   <returns>pixd</returns>
Public Shared Function pixColorMorph(
				ByVal pixs as Pix, 
				ByVal type as Enumerations.L_MORPH, 
				ByVal hsize as Integer, 
				ByVal vsize as Integer) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixColorMorph(pixs.Pointer,   type,   hsize,   vsize)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

End Class



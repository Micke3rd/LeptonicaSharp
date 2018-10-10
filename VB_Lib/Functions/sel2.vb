Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All


' SRC\sel2.c (92, 1)
' selaAddBasic(sela) as Sela
' selaAddBasic(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds the following sels:<para/>
''' ~ all linear (horiz, vert) brick sels that are<para/>
''' necessary for decomposable sels up to size 63<para/>
''' ~ square brick sels up to size 10<para/>
''' ~ 4 diagonal sels<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddBasic(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddBasic( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (181, 1)
' selaAddHitMiss(sela) as Sela
' selaAddHitMiss(SELA *) as SELA *
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddHitMiss(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddHitMiss( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (319, 1)
' selaAddDwaLinear(sela) as Sela
' selaAddDwaLinear(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds all linear (horizontal, vertical) sels from<para/>
''' 2 to 63 pixels in length, which are the sizes over<para/>
''' which dwa code can be generated.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddDwaLinear(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddDwaLinear( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (361, 1)
' selaAddDwaCombs(sela) as Sela
' selaAddDwaCombs(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds all comb (horizontal, vertical) Sels that are<para/>
''' used in composite linear morphological operations<para/>
''' up to 63 pixels in length, which are the sizes over<para/>
''' which dwa code can be generated.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddDwaCombs(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddDwaCombs( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (423, 1)
' selaAddCrossJunctions(sela, hlsize, mdist, norient, debugflag) as Sela
' selaAddCrossJunctions(SELA *, l_float32, l_float32, l_int32, l_int32) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds hitmiss Sels for the intersection of two lines.<para/>
''' If the lines are very thin, they must be nearly orthogonal<para/>
''' to register.<para/>
''' (2) The number of Sels generated is equal to %norient.<para/>
''' (3) If %norient == 2, this generates 2 Sels of crosses, each with<para/>
''' two perpendicular lines of hits.  One Sel has horizontal and<para/>
''' vertical hits the other has hits along lines at +-45 degrees.<para/>
''' Likewise, if %norient == 3, this generates 3 Sels of crosses<para/>
''' oriented at 30 degrees with each other.<para/>
''' (4) It is suggested that %hlsize be chosen at least 1 greater<para/>
''' than %mdist.  Try values of (%hlsize, %mdist) such as<para/>
''' (6,5), (7,6), (8,7), (9,7), etc.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''  <param name="hlsize">[in] - length of each line of hits from origin</param>
'''  <param name="mdist">[in] - distance of misses from the origin</param>
'''  <param name="norient">[in] - number of orientations max of 8</param>
'''  <param name="debugflag">[in] - 1 for debug output</param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddCrossJunctions(
				 ByVal sela as Sela, 
				 ByVal hlsize as Single, 
				 ByVal mdist as Single, 
				 ByVal norient as Integer, 
				 ByVal debugflag as Integer) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddCrossJunctions( selaPTR, hlsize, mdist, norient, debugflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (548, 1)
' selaAddTJunctions(sela, hlsize, mdist, norient, debugflag) as Sela
' selaAddTJunctions(SELA *, l_float32, l_float32, l_int32, l_int32) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds hitmiss Sels for the T-junction of two lines.<para/>
''' If the lines are very thin, they must be nearly orthogonal<para/>
''' to register.<para/>
''' (2) The number of Sels generated is 4  %norient.<para/>
''' (3) It is suggested that %hlsize be chosen at least 1 greater<para/>
''' than %mdist.  Try values of (%hlsize, %mdist) such as<para/>
''' (6,5), (7,6), (8,7), (9,7), etc.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''  <param name="hlsize">[in] - length of each line of hits from origin</param>
'''  <param name="mdist">[in] - distance of misses from the origin</param>
'''  <param name="norient">[in] - number of orientations max of 8</param>
'''  <param name="debugflag">[in] - 1 for debug output</param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function selaAddTJunctions(
				 ByVal sela as Sela, 
				 ByVal hlsize as Single, 
				 ByVal mdist as Single, 
				 ByVal norient as Integer, 
				 ByVal debugflag as Integer) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.selaAddTJunctions( selaPTR, hlsize, mdist, norient, debugflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (749, 1)
' sela4ccThin(sela) as Sela
' sela4ccThin(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds the 9 basic sels for 4-cc thinning.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function sela4ccThin(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.sela4ccThin( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (790, 1)
' sela8ccThin(sela) as Sela
' sela8ccThin(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds the 9 basic sels for 8-cc thinning.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function sela8ccThin(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.sela8ccThin( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

' SRC\sel2.c (831, 1)
' sela4and8ccThin(sela) as Sela
' sela4and8ccThin(SELA *) as SELA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Adds the 2 basic sels for either 4-cc or 8-cc thinning.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sela">[in][optional] - </param>
'''   <returns>sela with additional sels, or NULL on error</returns>
Public Shared Function sela4and8ccThin(
				 ByVal sela as Sela) as Sela

	Dim selaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sela) Then selaPTR = sela.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.sela4and8ccThin( selaPTR)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sela(_Result)
End Function

End Class

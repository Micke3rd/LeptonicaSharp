Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All


' SRC\quadtree.c (92, 1)
' pixQuadtreeMean(pixs, nlevels, pix_ma, pfpixa) as Integer
' pixQuadtreeMean(PIX *, l_int32, PIX *, FPIXA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned fpixa has %nlevels of fpix, each containing<para/>
''' the mean values at its level.  Level 0 has a<para/>
''' single value level 1 has 4 values level 2 has 16 etc.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/pixQuadtreeMean/*"/>
'''  <param name="pixs">[in] - 8 bpp, no colormap</param>
'''  <param name="nlevels">[in] - in quadtree max allowed depends on image size</param>
'''  <param name="pix_ma">[in] - input mean accumulator can be null</param>
'''  <param name="pfpixa">[out] - mean values in quadtree</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixQuadtreeMean(
				 ByVal pixs as Pix, 
				 ByVal nlevels as Integer, 
				 ByVal pix_ma as Pix, 
				<Out()> ByRef pfpixa as FPixa) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pix_ma) then Throw New ArgumentNullException  ("pix_ma cannot be Nothing")

	Dim pfpixaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pfpixa) Then pfpixaPTR = pfpixa.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixQuadtreeMean( pixs.Pointer, nlevels, pix_ma.Pointer, pfpixaPTR)
	if pfpixaPTR <> IntPtr.Zero then pfpixa = new FPixa(pfpixaPTR)

	Return _Result
End Function

' SRC\quadtree.c (169, 1)
' pixQuadtreeVariance(pixs, nlevels, pix_ma, dpix_msa, pfpixa_v, pfpixa_rv) as Integer
' pixQuadtreeVariance(PIX *, l_int32, PIX *, DPIX *, FPIXA **, FPIXA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned fpixav and fpixarv have %nlevels of fpix,<para/>
''' each containing at the respective levels the variance<para/>
''' and root variance values.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/pixQuadtreeVariance/*"/>
'''  <param name="pixs">[in] - 8 bpp, no colormap</param>
'''  <param name="nlevels">[in] - in quadtree</param>
'''  <param name="pix_ma">[in] - input mean accumulator can be null</param>
'''  <param name="dpix_msa">[in] - input mean square accumulator can be null</param>
'''  <param name="pfpixa_v">[out][optional] - variance values in quadtree</param>
'''  <param name="pfpixa_rv">[out][optional] - root variance values in quadtree</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixQuadtreeVariance(
				 ByVal pixs as Pix, 
				 ByVal nlevels as Integer, 
				 ByVal pix_ma as Pix, 
				 ByVal dpix_msa as DPix, 
				<Out()> Optional ByRef pfpixa_v as FPixa = Nothing, 
				<Out()> Optional ByRef pfpixa_rv as FPixa = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pix_ma) then Throw New ArgumentNullException  ("pix_ma cannot be Nothing")
	If IsNothing (dpix_msa) then Throw New ArgumentNullException  ("dpix_msa cannot be Nothing")

Dim pfpixa_vPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pfpixa_v) Then pfpixa_vPTR = pfpixa_v.Pointer
Dim pfpixa_rvPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pfpixa_rv) Then pfpixa_rvPTR = pfpixa_rv.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixQuadtreeVariance( pixs.Pointer, nlevels, pix_ma.Pointer, dpix_msa.Pointer, pfpixa_vPTR, pfpixa_rvPTR)
	if pfpixa_vPTR <> IntPtr.Zero then pfpixa_v = new FPixa(pfpixa_vPTR)
	if pfpixa_rvPTR <> IntPtr.Zero then pfpixa_rv = new FPixa(pfpixa_rvPTR)

	Return _Result
End Function

' SRC\quadtree.c (265, 1)
' pixMeanInRectangle(pixs, box, pixma, pval) as Integer
' pixMeanInRectangle(PIX *, BOX *, PIX *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This function is intended to be used for many rectangles<para/>
''' on the same image.  It can find the mean within a<para/>
''' rectangle in O(1), independent of the size of the rectangle.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/pixMeanInRectangle/*"/>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="box">[in] - region to compute mean value</param>
'''  <param name="pixma">[in] - mean accumulator</param>
'''  <param name="pval">[out] - mean value</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixMeanInRectangle(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal pixma as Pix, 
				<Out()> ByRef pval as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	If IsNothing (pixma) then Throw New ArgumentNullException  ("pixma cannot be Nothing")

	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixMeanInRectangle( pixs.Pointer, box.Pointer, pixma.Pointer, pval)

	Return _Result
End Function

' SRC\quadtree.c (341, 1)
' pixVarianceInRectangle(pixs, box, pix_ma, dpix_msa, pvar, prvar) as Integer
' pixVarianceInRectangle(PIX *, BOX *, PIX *, DPIX *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This function is intended to be used for many rectangles<para/>
''' on the same image.  It can find the variance and/or the<para/>
''' square root of the variance within a rectangle in O(1),<para/>
''' independent of the size of the rectangle.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/pixVarianceInRectangle/*"/>
'''  <param name="pixs">[in] - 8 bpp</param>
'''  <param name="box">[in] - region to compute variance and/or root variance</param>
'''  <param name="pix_ma">[in] - mean accumulator</param>
'''  <param name="dpix_msa">[in] - mean square accumulator</param>
'''  <param name="pvar">[out][optional] - variance</param>
'''  <param name="prvar">[out][optional] - root variance</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixVarianceInRectangle(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal pix_ma as Pix, 
				 ByVal dpix_msa as DPix, 
				<Out()> Optional ByRef pvar as Single = Nothing, 
				<Out()> Optional ByRef prvar as Single = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	If IsNothing (pix_ma) then Throw New ArgumentNullException  ("pix_ma cannot be Nothing")
	If IsNothing (dpix_msa) then Throw New ArgumentNullException  ("dpix_msa cannot be Nothing")

	If {8}.contains (pixs.d) = false then Throw New ArgumentException ("8 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixVarianceInRectangle( pixs.Pointer, box.Pointer, pix_ma.Pointer, dpix_msa.Pointer, pvar, prvar)

	Return _Result
End Function

' SRC\quadtree.c (449, 1)
' boxaaQuadtreeRegions(w, h, nlevels) as Boxaa
' boxaaQuadtreeRegions(l_int32, l_int32, l_int32) as BOXAA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned boxaa has %nlevels of boxa, each containing<para/>
''' the set of rectangles at that level.  The rectangle at<para/>
''' level 0 is the entire region at level 1 the region is<para/>
''' divided into 4 rectangles, and at level n there are n^4<para/>
''' rectangles.<para/>
''' (2) At each level, the rectangles in the boxa are in "raster"<para/>
''' order, with LR (fast scan) and TB (slow scan).<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/boxaaQuadtreeRegions/*"/>
'''  <param name="w">[in] - size of pix that is being quadtree-ized</param>
'''  <param name="h">[in] - size of pix that is being quadtree-ized</param>
'''  <param name="nlevels">[in] - number of levels in quadtree</param>
'''   <returns>baa for quadtree regions at each level, or NULL on error</returns>
Public Shared Function boxaaQuadtreeRegions(
				 ByVal w as Integer, 
				 ByVal h as Integer, 
				 ByVal nlevels as Integer) as Boxaa

	Dim _Result as IntPtr = LeptonicaSharp.Natives.boxaaQuadtreeRegions( w, h, nlevels)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Boxaa(_Result)
End Function

' SRC\quadtree.c (530, 1)
' quadtreeGetParent(fpixa, level, x, y, pval) as Integer
' quadtreeGetParent(FPIXA *, l_int32, l_int32, l_int32, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Check return value for error.  On error, val is returned as 0.0.<para/>
''' (2) The parent is located at:<para/>
''' level - 1<para/>
''' (x/2, y/2)<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/quadtreeGetParent/*"/>
'''  <param name="fpixa">[in] - mean, variance or root variance</param>
'''  <param name="level">[in] - x, y of current pixel</param>
'''  <param name="pval">[out] - parent pixel value, or 0.0 on error</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function quadtreeGetParent(
				 ByVal fpixa as FPixa, 
				 ByVal level as Integer, 
				 ByVal x as Integer, 
				 ByVal y as Integer, 
				<Out()> ByRef pval as Single) as Integer

	If IsNothing (fpixa) then Throw New ArgumentNullException  ("fpixa cannot be Nothing")

	Dim _Result as Integer = LeptonicaSharp.Natives.quadtreeGetParent( fpixa.Pointer, level, x, y, pval)

	Return _Result
End Function

' SRC\quadtree.c (573, 1)
' quadtreeGetChildren(fpixa, level, x, y, pval00, pval10, pval01, pval11) as Integer
' quadtreeGetChildren(FPIXA *, l_int32, l_int32, l_int32, l_float32 *, l_float32 *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Check return value for error.  On error, all return vals are 0.0.<para/>
''' (2) The returned child pixels are located at:<para/>
''' level + 1<para/>
''' (2x, 2y), (2x+1, 2y), (2x, 2y+1), (2x+1, 2y+1)<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/quadtreeGetChildren/*"/>
'''  <param name="fpixa">[in] - mean, variance or root variance</param>
'''  <param name="level">[in] - x, y of current pixel</param>
'''  <param name="pval00">[out] - four child pixel values</param>
'''  <param name="pval10">[out] - four child pixel values</param>
'''  <param name="pval01">[out] - four child pixel values</param>
'''  <param name="pval11">[out] - four child pixel values</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function quadtreeGetChildren(
				 ByVal fpixa as FPixa, 
				 ByVal level as Integer, 
				 ByVal x as Integer, 
				 ByVal y as Integer, 
				<Out()> ByRef pval00 as Single, 
				<Out()> ByRef pval10 as Single, 
				<Out()> ByRef pval01 as Single, 
				<Out()> ByRef pval11 as Single) as Integer

	If IsNothing (fpixa) then Throw New ArgumentNullException  ("fpixa cannot be Nothing")

	Dim _Result as Integer = LeptonicaSharp.Natives.quadtreeGetChildren( fpixa.Pointer, level, x, y, pval00, pval10, pval01, pval11)

	Return _Result
End Function

' SRC\quadtree.c (619, 1)
' quadtreeMaxLevels(w, h) as Integer
' quadtreeMaxLevels(l_int32, l_int32) as l_int32
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The criterion for maxlevels is that the subdivision not<para/>
''' go down below the single pixel level.  The 1.5 factor<para/>
''' is intended to keep any rectangle from accidentally<para/>
''' having zero dimension due to integer truncation.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/quadtreeMaxLevels/*"/>
'''  <param name="w">[in] - dimensions of image</param>
'''  <param name="h">[in] - dimensions of image</param>
'''   <returns>maxlevels maximum number of levels allowed, or -1 on error</returns>
Public Shared Function quadtreeMaxLevels(
				 ByVal w as Integer, 
				 ByVal h as Integer) as Integer

	Dim _Result as Integer = LeptonicaSharp.Natives.quadtreeMaxLevels( w, h)

	Return _Result
End Function

' SRC\quadtree.c (654, 1)
' fpixaDisplayQuadtree(fpixa, factor, fontsize) as Pix
' fpixaDisplayQuadtree(FPIXA *, l_int32, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The mean and root variance fall naturally in the 8 bpp range,<para/>
''' but the variance is typically outside the range.  This<para/>
''' function displays 8 bpp pix clipped to 255, so the image<para/>
''' pixels will mostly be 255 (white).<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="IncludeComments.xml" path="Comments/fpixaDisplayQuadtree/*"/>
'''  <param name="fpixa">[in] - mean, variance or root variance</param>
'''  <param name="factor">[in] - replication factor at lowest level</param>
'''  <param name="fontsize">[in] - 4, ... 20</param>
'''   <returns>pixd 8 bpp, mosaic of quadtree images, or NULL on error</returns>
Public Shared Function fpixaDisplayQuadtree(
				 ByVal fpixa as FPixa, 
				 ByVal factor as Integer, 
				 ByVal fontsize as Integer) as Pix

	If IsNothing (fpixa) then Throw New ArgumentNullException  ("fpixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.fpixaDisplayQuadtree( fpixa.Pointer, factor, fontsize)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class

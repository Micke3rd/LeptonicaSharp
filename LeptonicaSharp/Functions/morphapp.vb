Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\morphapp.c (108, 1)
' pixExtractBoundary()
' pixExtractBoundary(PIX *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Extracts the fg or bg boundary pixels for each component.
''' Components are assumed to end at the boundary of pixs.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="type">[in] - 0 for background pixels; 1 for foreground pixels</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixExtractBoundary(
				ByVal pixs as Pix, 
				ByVal type as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp") ' All Functions - All Parameters - CommentCheck


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixExtractBoundary( pixs.Pointer, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (148, 1)
' pixMorphSequenceMasked()
' pixMorphSequenceMasked(PIX *, PIX *, const char *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This applies the morph sequence to the image, but only allows
''' changes in pixs for pixels under the background of pixm.
''' (5) If pixm is NULL, this is just pixMorphSequence().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="pixm">[in][optional] - 1 bpp mask</param>
'''  <param name="sequence">[in] - string specifying sequence of operations</param>
'''  <param name="dispsep">[in] - horizontal separation in pixels between successive displays; use zero to suppress display</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixMorphSequenceMasked(
				ByVal pixs as Pix, 
				ByVal sequence as String, 
				ByVal dispsep as Integer, 
				Optional ByVal pixm as Pix = Nothing) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (sequence) then Throw New ArgumentNullException  ("sequence cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp") ' All Functions - All Parameters - CommentCheck

	Dim pixmPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixm) Then pixmPTR = pixm.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMorphSequenceMasked( pixs.Pointer, pixmPTR, sequence, dispsep)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (195, 1)
' pixMorphSequenceByComponent()
' pixMorphSequenceByComponent(PIX *, const char *, l_int32, l_int32, l_int32, BOXA **) as PIX *
'''  <summary>
''' Notes
''' (1) See pixMorphSequence() for composing operation sequences.
''' (2) This operates separately on each c.c. in the input pix.
''' (3) The dilation does NOT increase the c.c. size; it is clipped
''' to the size of the original c.c.   This is necessary to
''' keep the c.c. independent after the operation.
''' (4) You can specify that the width and/or height must equal
''' or exceed a minimum size for the operation to take place.
''' (5) Use NULL for boxa to avoid returning the boxa.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="sequence">[in] - string specifying sequence</param>
'''  <param name="connectivity">[in] - 4 or 8</param>
'''  <param name="minw">[in] - minimum width to consider; use 0 or 1 for any width</param>
'''  <param name="minh">[in] - minimum height to consider; use 0 or 1 for any height</param>
'''  <param name="pboxa">[out][optional] - return boxa of c.c. in pixs</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixMorphSequenceByComponent(
				ByVal pixs as Pix, 
				ByVal sequence as String, 
				ByVal connectivity as Integer, 
				ByVal minw as Integer, 
				ByVal minh as Integer, 
				Optional ByRef pboxa as Boxa = Nothing) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (sequence) then Throw New ArgumentNullException  ("sequence cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp") ' All Functions - All Parameters - CommentCheck

Dim pboxaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxa) Then pboxaPTR = pboxa.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMorphSequenceByComponent( pixs.Pointer, sequence, connectivity, minw, minh, pboxaPTR)
	If  _Result = IntPtr.Zero then Return Nothing
	if pboxaPTR <> IntPtr.Zero then pboxa = new Boxa(pboxaPTR)

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (265, 1)
' pixaMorphSequenceByComponent()
' pixaMorphSequenceByComponent(PIXA *, const char *, l_int32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) See pixMorphSequence() for composing operation sequences.
''' (2) This operates separately on each c.c. in the input pixa.
''' (3) You can specify that the width and/or height must equal
''' or exceed a minimum size for the operation to take place.
''' (4) The input pixa should have a boxa giving the locations
''' of the pix components.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - of 1 bpp pix</param>
'''  <param name="sequence">[in] - string specifying sequence</param>
'''  <param name="minw">[in] - minimum width to consider; use 0 or 1 for any width</param>
'''  <param name="minh">[in] - minimum height to consider; use 0 or 1 for any height</param>
'''   <returns>pixad, or NULL on error</returns>
Public Shared Function pixaMorphSequenceByComponent(
				ByVal pixas as Pixa, 
				ByVal sequence as String, 
				ByVal minw as Integer, 
				ByVal minh as Integer) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")
	If IsNothing (sequence) then Throw New ArgumentNullException  ("sequence cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaMorphSequenceByComponent( pixas.Pointer, sequence, minw, minh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\morphapp.c (348, 1)
' pixMorphSequenceByRegion()
' pixMorphSequenceByRegion(PIX *, PIX *, const char *, l_int32, l_int32, l_int32, BOXA **) as PIX *
'''  <summary>
''' Notes
''' (1) See pixMorphCompSequence() for composing operation sequences.
''' (2) This operates separately on the region in pixs corresponding
''' to each c.c. in the mask pixm.  It differs from
''' pixMorphSequenceByComponent() in that the latter does not have
''' a pixm (mask), but instead operates independently on each
''' component in pixs.
''' (3) Dilation will NOT increase the region size; the result
''' is clipped to the size of the mask region.  This is necessary
''' to make regions independent after the operation.
''' (4) You can specify that the width and/or height of a region must
''' equal or exceed a minimum size for the operation to take place.
''' (5) Use NULL for %pboxa to avoid returning the boxa.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="pixm">[in] - mask specifying regions</param>
'''  <param name="sequence">[in] - string specifying sequence</param>
'''  <param name="connectivity">[in] - 4 or 8, used on mask</param>
'''  <param name="minw">[in] - minimum width to consider; use 0 or 1 for any width</param>
'''  <param name="minh">[in] - minimum height to consider; use 0 or 1 for any height</param>
'''  <param name="pboxa">[out][optional] - return boxa of c.c. in pixm</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixMorphSequenceByRegion(
				ByVal pixs as Pix, 
				ByVal pixm as Pix, 
				ByVal sequence as String, 
				ByVal connectivity as Integer, 
				ByVal minw as Integer, 
				ByVal minh as Integer, 
				Optional ByRef pboxa as Boxa = Nothing) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixm) then Throw New ArgumentNullException  ("pixm cannot be Nothing")
	If IsNothing (sequence) then Throw New ArgumentNullException  ("sequence cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp") ' All Functions - All Parameters - CommentCheck

Dim pboxaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxa) Then pboxaPTR = pboxa.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMorphSequenceByRegion( pixs.Pointer, pixm.Pointer, sequence, connectivity, minw, minh, pboxaPTR)
	If  _Result = IntPtr.Zero then Return Nothing
	if pboxaPTR <> IntPtr.Zero then pboxa = new Boxa(pboxaPTR)

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (427, 1)
' pixaMorphSequenceByRegion()
' pixaMorphSequenceByRegion(PIX *, PIXA *, const char *, l_int32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) See pixMorphSequence() for composing operation sequences.
''' (2) This operates separately on each region in the input pixs
''' defined by the components in pixam.
''' (3) You can specify that the width and/or height of a mask
''' component must equal or exceed a minimum size for the
''' operation to take place.
''' (4) The input pixam should have a boxa giving the locations
''' of the regions in pixs.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="pixam">[in] - of 1 bpp mask elements</param>
'''  <param name="sequence">[in] - string specifying sequence</param>
'''  <param name="minw">[in] - minimum width to consider; use 0 or 1 for any width</param>
'''  <param name="minh">[in] - minimum height to consider; use 0 or 1 for any height</param>
'''   <returns>pixad, or NULL on error</returns>
Public Shared Function pixaMorphSequenceByRegion(
				ByVal pixs as Pix, 
				ByVal pixam as Pixa, 
				ByVal sequence as String, 
				ByVal minw as Integer, 
				ByVal minh as Integer) as Pixa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixam) then Throw New ArgumentNullException  ("pixam cannot be Nothing")
	If IsNothing (sequence) then Throw New ArgumentNullException  ("sequence cannot be Nothing")
	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp") ' All Functions - All Parameters - CommentCheck


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaMorphSequenceByRegion( pixs.Pointer, pixam.Pointer, sequence, minw, minh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\morphapp.c (502, 1)
' pixUnionOfMorphOps()
' pixUnionOfMorphOps(PIX *, SELA *, l_int32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - binary</param>
'''  <param name="sela">[in] - </param>
'''  <param name="type">[in] - L_MORPH_DILATE, etc.</param>
'''   <returns>pixd union of the specified morphological operation on pixs for each Sel in the Sela, or NULL on error</returns>
Public Shared Function pixUnionOfMorphOps(
				ByVal pixs as Pix, 
				ByVal sela as Sela, 
				ByVal type as Enumerations.L_MORPH) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (sela) then Throw New ArgumentNullException  ("sela cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixUnionOfMorphOps( pixs.Pointer, sela.Pointer, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (555, 1)
' pixIntersectionOfMorphOps()
' pixIntersectionOfMorphOps(PIX *, SELA *, l_int32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - binary</param>
'''  <param name="sela">[in] - </param>
'''  <param name="type">[in] - L_MORPH_DILATE, etc.</param>
'''   <returns>pixd intersection of the specified morphological operation on pixs for each Sel in the Sela, or NULL on error</returns>
Public Shared Function pixIntersectionOfMorphOps(
				ByVal pixs as Pix, 
				ByVal sela as Sela, 
				ByVal type as Enumerations.L_MORPH) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (sela) then Throw New ArgumentNullException  ("sela cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixIntersectionOfMorphOps( pixs.Pointer, sela.Pointer, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (613, 1)
' pixSelectiveConnCompFill()
' pixSelectiveConnCompFill(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - binary</param>
'''  <param name="connectivity">[in] - 4 or 8</param>
'''  <param name="minw">[in] - minimum width to consider; use 0 or 1 for any width</param>
'''  <param name="minh">[in] - minimum height to consider; use 0 or 1 for any height</param>
'''   <returns>pix with holes filled in selected c.c., or NULL on error</returns>
Public Shared Function pixSelectiveConnCompFill(
				ByVal pixs as Pix, 
				ByVal connectivity as Integer, 
				ByVal minw as Integer, 
				ByVal minh as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixSelectiveConnCompFill( pixs.Pointer, connectivity, minw, minh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (684, 1)
' pixRemoveMatchedPattern()
' pixRemoveMatchedPattern(PIX *, PIX *, PIX *, l_int32, l_int32, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This is in-place.
''' (2) You can use various functions in selgen to create a Sel
''' that is used to generate pixe from pixs.
''' (3) This function is applied after pixe has been computed.
''' It finds the centroid of each c.c., and subtracts
''' (the appropriately dilated version of) pixp, with the center
''' of the Sel used to align pixp with pixs.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input image, 1 bpp</param>
'''  <param name="pixp">[in] - pattern to be removed from image, 1 bpp</param>
'''  <param name="pixe">[in] - image after erosion by Sel that approximates pixp, 1 bpp</param>
'''  <param name="x0">[in] - center of Sel</param>
'''  <param name="y0">[in] - center of Sel</param>
'''  <param name="dsize">[in] - number of pixels on each side by which pixp is dilated before being subtracted from pixs; valid values are {0, 1, 2, 3, 4}</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixRemoveMatchedPattern(
				ByVal pixs as Pix, 
				ByVal pixp as Pix, 
				ByVal pixe as Pix, 
				ByVal x0 as Integer, 
				ByVal y0 as Integer, 
				ByVal dsize as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixp) then Throw New ArgumentNullException  ("pixp cannot be Nothing")
	If IsNothing (pixe) then Throw New ArgumentNullException  ("pixe cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixRemoveMatchedPattern( pixs.Pointer, pixp.Pointer, pixe.Pointer, x0, y0, dsize)

	Return _Result
End Function

' SRC\morphapp.c (789, 1)
' pixDisplayMatchedPattern()
' pixDisplayMatchedPattern(PIX *, PIX *, PIX *, l_int32, l_int32, l_uint32, l_float32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) A 4 bpp colormapped image is generated.
''' (2) If scale LT= 1.0, do scale to gray for the output, and threshold
''' to nlevels of gray.
''' (3) You can use various functions in selgen to create a Sel
''' that will generate pixe from pixs.
''' (4) This function is applied after pixe has been computed.
''' It finds the centroid of each c.c., and colors the output
''' pixels using pixp (appropriately aligned) as a stencil.
''' Alignment is done using the origin of the Sel and the
''' centroid of the eroded image to place the stencil pixp.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input image, 1 bpp</param>
'''  <param name="pixp">[in] - pattern to be removed from image, 1 bpp</param>
'''  <param name="pixe">[in] - image after erosion by Sel that approximates pixp, 1 bpp</param>
'''  <param name="x0">[in] - center of Sel</param>
'''  <param name="y0">[in] - center of Sel</param>
'''  <param name="color">[in] - to paint the matched patterns; 0xrrggbb00</param>
'''  <param name="scale">[in] - reduction factor for output pixd</param>
'''  <param name="nlevels">[in] - if scale LT 1.0, threshold to this number of levels</param>
'''   <returns>pixd 8 bpp, colormapped, or NULL on error</returns>
Public Shared Function pixDisplayMatchedPattern(
				ByVal pixs as Pix, 
				ByVal pixp as Pix, 
				ByVal pixe as Pix, 
				ByVal x0 as Integer, 
				ByVal y0 as Integer, 
				ByVal color as UInteger, 
				ByVal scale as Single, 
				ByVal nlevels as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixp) then Throw New ArgumentNullException  ("pixp cannot be Nothing")
	If IsNothing (pixe) then Throw New ArgumentNullException  ("pixe cannot be Nothing")
	If IsNothing (color) then Throw New ArgumentNullException  ("color cannot be Nothing")
	If IsNothing (scale) then Throw New ArgumentNullException  ("scale cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixDisplayMatchedPattern( pixs.Pointer, pixp.Pointer, pixe.Pointer, x0, y0, color, scale, nlevels)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (901, 1)
' pixaExtendByMorph()
' pixaExtendByMorph(PIXA *, l_int32, l_int32, SEL *, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) This dilates or erodes every pix in %pixas, iteratively,
''' using the input Sel (or, if null, a 2x2 Sel by default),
''' and puts the results in %pixad.
''' (2) If %niters LT= 0, this is a no-op; it returns a clone of pixas.
''' (3) If %include == 1, the output %pixad contains all the pix
''' in %pixas.  Otherwise, it doesn't, but pixaJoin() can be
''' used later to join pixas with pixad.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - </param>
'''  <param name="type">[in] - L_MORPH_DILATE, L_MORPH_ERODE</param>
'''  <param name="niters">[in] - </param>
'''  <param name="sel">[in] - used for dilation, erosion; uses 2x2 if null</param>
'''  <param name="include">[in] - 1 to include a copy of the input pixas in pixad; 0 to omit</param>
'''   <returns>pixad   with derived pix, using all iterations, or NULL on error</returns>
Public Shared Function pixaExtendByMorph(
				ByVal pixas as Pixa, 
				ByVal type as Enumerations.L_MORPH, 
				ByVal niters as Integer, 
				ByVal sel as Sel, 
				ByVal include as Integer) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")
	If IsNothing (sel) then Throw New ArgumentNullException  ("sel cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaExtendByMorph( pixas.Pointer, type, niters, sel.Pointer, include)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\morphapp.c (973, 1)
' pixaExtendByScaling()
' pixaExtendByScaling(PIXA *, NUMA *, l_int32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) This scales every pix in %pixas by each factor in %nasc.
''' and puts the results in %pixad.
''' (2) If %include == 1, the output %pixad contains all the pix
''' in %pixas.  Otherwise, it doesn't, but pixaJoin() can be
''' used later to join pixas with pixad.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - </param>
'''  <param name="nasc">[in] - numa of scaling factors</param>
'''  <param name="type">[in] - L_HORIZ, L_VERT, L_BOTH_DIRECTIONS</param>
'''  <param name="include">[in] - 1 to include a copy of the input pixas in pixad; 0 to omit</param>
'''   <returns>pixad   with derived pix, using all scalings, or NULL on error</returns>
Public Shared Function pixaExtendByScaling(
				ByVal pixas as Pixa, 
				ByVal nasc as Numa, 
				ByVal type as Enumerations.L_direction, 
				ByVal include as Integer) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")
	If IsNothing (nasc) then Throw New ArgumentNullException  ("nasc cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaExtendByScaling( pixas.Pointer, nasc.Pointer, type, include)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\morphapp.c (1041, 1)
' pixSeedfillMorph()
' pixSeedfillMorph(PIX *, PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This is in general a very inefficient method for filling
''' from a seed into a mask.  Use it for a small number of iterations,
''' but if you expect more than a few iterations, use
''' pixSeedfillBinary().
''' (2) We use a 3x3 brick SEL for 8-cc filling and a 3x3 plus SEL for 4-cc.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - seed</param>
'''  <param name="pixm">[in] - mask</param>
'''  <param name="maxiters">[in] - use 0 to go to completion</param>
'''  <param name="connectivity">[in] - 4 or 8</param>
'''   <returns>pixd after filling into the mask or NULL on error</returns>
Public Shared Function pixSeedfillMorph(
				ByVal pixs as Pix, 
				ByVal pixm as Pix, 
				ByVal maxiters as Integer, 
				ByVal connectivity as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixm) then Throw New ArgumentNullException  ("pixm cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixSeedfillMorph( pixs.Pointer, pixm.Pointer, maxiters, connectivity)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (1103, 1)
' pixRunHistogramMorph()
' pixRunHistogramMorph(PIX *, l_int32, l_int32, l_int32) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="runtype">[in] - L_RUN_OFF, L_RUN_ON</param>
'''  <param name="direction">[in] - L_HORIZ, L_VERT</param>
'''  <param name="maxsize">[in] - size of largest runlength counted</param>
'''   <returns>numa of run-lengths</returns>
Public Shared Function pixRunHistogramMorph(
				ByVal pixs as Pix, 
				ByVal runtype as Enumerations.L_RUN_O, 
				ByVal direction as Enumerations.L_direction, 
				ByVal maxsize as Integer) as Numa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRunHistogramMorph( pixs.Pointer, runtype, direction, maxsize)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\morphapp.c (1203, 1)
' pixTophat()
' pixTophat(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Sel is a brick with all elements being hits
''' (2) If hsize = vsize = 1, returns an image with all 0 data.
''' (3) The L_TOPHAT_WHITE flag emphasizes small bright regions,
''' whereas the L_TOPHAT_BLACK flag emphasizes small dark regions.
''' The L_TOPHAT_WHITE tophat can be accomplished by doing a
''' L_TOPHAT_BLACK tophat on the inverse, or v.v.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="hsize">[in] - of Sel; must be odd; origin implicitly in center</param>
'''  <param name="vsize">[in] - ditto</param>
'''  <param name="type">[in] - L_TOPHAT_WHITE image - opening L_TOPHAT_BLACK closing - image</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixTophat(
				ByVal pixs as Pix, 
				ByVal hsize as Integer, 
				ByVal vsize as Integer, 
				ByVal type as Enumerations.L_TOPHAT) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixTophat( pixs.Pointer, hsize, vsize, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (1303, 1)
' pixHDome()
' pixHDome(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) It is more efficient to use a connectivity of 4 for the fill.
''' (2) This fills bumps to some level, and extracts the unfilled
''' part of the bump.  To extract the troughs of basins, first
''' invert pixs and then apply pixHDome().
''' (3) It is useful to compare the HDome operation with the TopHat.
''' The latter extracts peaks or valleys that have a width
''' not exceeding the size of the structuring element used
''' in the opening or closing, rsp.  The height of the peak is
''' irrelevant.  By contrast, for the HDome, the gray seedfill
''' is used to extract all peaks that have a height not exceeding
''' a given value, regardless of their width!
''' (4) Slightly more precisely, suppose you set 'height' = 40.
''' Then all bumps in pixs with a height greater than or equal
''' to 40 become, in pixd, bumps with a max value of exactly 40.
''' All shorter bumps have a max value in pixd equal to the height
''' of the bump.
''' (5) The method the filling mask, pixs, is the image whose peaks
''' are to be extracted.  The height of a peak is the distance
''' between the top of the peak and the highest "leak" to the
''' outside -- think of a sombrero, where the leak occurs
''' at the highest point on the rim.
''' (a) Generate a seed, pixd, by subtracting some value, p, from
''' each pixel in the filling mask, pixs.  The value p is
''' the 'height' input to this function.
''' (b) Fill in pixd starting with this seed, clipping by pixs,
''' in the way described in seedfillGrayLow().  The filling
''' stops before the peaks in pixs are filled.
''' For peaks that have a height GT p, pixd is filled to
''' the level equal to the (top-of-the-peak - p).
''' For peaks of height LT p, the peak is left unfilled
''' from its highest saddle point (the leak to the outside).
''' (c) Subtract the filled seed (pixd) from the filling mask (pixs).
''' Note that in this procedure, everything is done starting
''' with the filling mask, pixs.
''' (6) For segmentation, the resulting image, pixd, can be thresholded
''' and used as a seed for another filling operation.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp, filling mask</param>
'''  <param name="height">[in] - of seed below the filling maskhdome; must be GT= 0</param>
'''  <param name="connectivity">[in] - 4 or 8</param>
'''   <returns>pixd 8 bpp, or NULL on error</returns>
Public Shared Function pixHDome(
				ByVal pixs as Pix, 
				ByVal height as Integer, 
				ByVal connectivity as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixHDome( pixs.Pointer, height, connectivity)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (1359, 1)
' pixFastTophat()
' pixFastTophat(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) Don't be fooled. This is NOT a tophat.  It is a tophat-like
''' operation, where the result is similar to what you'd get
''' if you used an erosion instead of an opening, or a dilation
''' instead of a closing.
''' (2) Instead of opening or closing at full resolution, it does
''' a fast downscale/minmax operation, then a quick small smoothing
''' at low res, a replicative expansion of the "background"
''' to full res, and finally a removal of the background level
''' from the input image.  The smoothing step may not be important.
''' (3) It does not remove noise as well as a tophat, but it is
''' 5 to 10 times faster.
''' If you need the preciseness of the tophat, don't use this.
''' (4) The L_TOPHAT_WHITE flag emphasizes small bright regions,
''' whereas the L_TOPHAT_BLACK flag emphasizes small dark regions.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="xsize">[in] - width of max/min op, smoothing; any integer GT= 1</param>
'''  <param name="ysize">[in] - height of max/min op, smoothing; any integer GT= 1</param>
'''  <param name="type">[in] - L_TOPHAT_WHITE image - min L_TOPHAT_BLACK max - image</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixFastTophat(
				ByVal pixs as Pix, 
				ByVal xsize as Integer, 
				ByVal ysize as Integer, 
				ByVal type as Enumerations.L_TOPHAT) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixFastTophat( pixs.Pointer, xsize, ysize, type)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (1421, 1)
' pixMorphGradient()
' pixMorphGradient(PIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="hsize">[in] - of Sel; must be odd; origin implicitly in center</param>
'''  <param name="vsize">[in] - ditto</param>
'''  <param name="smoothing">[in] - half-width of convolution smoothing filter. The width is (2  smoothing + 1, so 0 is no-op.</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixMorphGradient(
				ByVal pixs as Pix, 
				ByVal hsize as Integer, 
				ByVal vsize as Integer, 
				ByVal smoothing as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMorphGradient( pixs.Pointer, hsize, vsize, smoothing)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\morphapp.c (1475, 1)
' pixaCentroids()
' pixaCentroids(PIXA *) as PTA *
'''  <summary>
''' Notes
''' (1) An error message is returned if any pix has something other
''' than 1 bpp or 8 bpp depth, and the centroid from that pix
''' is saved as (0, 0).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of components 1 or 8 bpp</param>
'''   <returns>pta of centroids relative to the UL corner of each pix, or NULL on error</returns>
Public Shared Function pixaCentroids(
				ByVal pixa as Pixa) as Pta

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaCentroids( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pta(_Result)
End Function

' SRC\morphapp.c (1527, 1)
' pixCentroid()
' pixCentroid(PIX *, l_int32 *, l_int32 *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' Notes
''' (1) Any table not passed in will be made internally and destroyed
''' after use.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pix">[in] - 1 or 8 bpp</param>
'''  <param name="centtab">[in][optional] - table for finding centroids; can be null</param>
'''  <param name="sumtab">[in][optional] - table for finding pixel sums; can be null</param>
'''  <param name="pxave">[out] - coordinates of centroid, relative to the UL corner of the pix</param>
'''  <param name="pyave">[out] - coordinates of centroid, relative to the UL corner of the pix</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixCentroid(
				ByVal pix as Pix, 
				ByRef pxave as Single(), 
				ByRef pyave as Single(), 
				Optional ByVal centtab as Integer() = Nothing, 
				Optional ByVal sumtab as Integer() = Nothing) as Integer

	If IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixCentroid( pix.Pointer, centtab, sumtab, pxave, pyave)

	Return _Result
End Function

End Class

Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All


' SRC\pix5.c (130, 1)
' pixaFindDimensions(pixa, pnaw, pnah) as Integer
' pixaFindDimensions(PIXA *, NUMA **, NUMA **) as l_ok
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - </param>
'''  <param name="pnaw">[out][optional] - numa of pix widths</param>
'''  <param name="pnah">[out][optional] - numa of pix heights</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixaFindDimensions(
				 ByVal pixa as Pixa, 
				<Out()> Optional ByRef pnaw as Numa = Nothing, 
				<Out()> Optional ByRef pnah as Numa = Nothing) as Integer

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

Dim pnawPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaw) Then pnawPTR = pnaw.Pointer
Dim pnahPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnah) Then pnahPTR = pnah.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixaFindDimensions( pixa.Pointer, pnawPTR, pnahPTR)
	if pnawPTR <> IntPtr.Zero then pnaw = new Numa(pnawPTR)
	if pnahPTR <> IntPtr.Zero then pnah = new Numa(pnahPTR)

	Return _Result
End Function

' SRC\pix5.c (180, 1)
' pixFindAreaPerimRatio(pixs, tab, pfract) as Integer
' pixFindAreaPerimRatio(PIX *, l_int32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The area is the number of fg pixels that are not on the<para/>
''' boundary (i.e., are not 8-connected to a bg pixel), and the<para/>
''' perimeter is the number of fg boundary pixels.  Returns<para/>
''' 0.0 if there are no fg pixels.<para/>
''' (2) This function is retained because clients are using it.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be NULL</param>
'''  <param name="pfract">[out] - area/perimeter ratio</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindAreaPerimRatio(
				 ByVal pixs as Pix, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pfract as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindAreaPerimRatio( pixs.Pointer, tab, pfract)

	Return _Result
End Function

' SRC\pix5.c (231, 1)
' pixaFindPerimToAreaRatio(pixa) as Numa
' pixaFindPerimToAreaRatio(PIXA *) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''   <returns>na   of perimeter/arear ratio for each pix, or NULL on error</returns>
Public Shared Function pixaFindPerimToAreaRatio(
				 ByVal pixa as Pixa) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindPerimToAreaRatio( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (281, 1)
' pixFindPerimToAreaRatio(pixs, tab, pfract) as Integer
' pixFindPerimToAreaRatio(PIX *, l_int32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The perimeter is the number of fg boundary pixels, and the<para/>
''' area is the number of fg pixels.  This returns 0.0 if<para/>
''' there are no fg pixels.<para/>
''' (2) Unlike pixFindAreaPerimRatio(), this uses the full set of<para/>
''' fg pixels for the area, and the ratio is taken in the opposite<para/>
''' order.<para/>
''' (3) This is typically used for a single connected component.<para/>
''' This always has a value  is lower = 1.0, and if the average distance<para/>
''' of a fg pixel from the nearest bg pixel is d, this has<para/>
''' a value ~1/d.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be NULL</param>
'''  <param name="pfract">[out] - perimeter/area ratio</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindPerimToAreaRatio(
				 ByVal pixs as Pix, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pfract as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindPerimToAreaRatio( pixs.Pointer, tab, pfract)

	Return _Result
End Function

' SRC\pix5.c (335, 1)
' pixaFindPerimSizeRatio(pixa) as Numa
' pixaFindPerimSizeRatio(PIXA *) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components.<para/>
''' (2) This has a minimum value for a circle of pi/4 a value for<para/>
''' a rectangle component of approx. 1.0 and a value much larger<para/>
''' than 1.0 for a component with a highly irregular boundary.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''   <returns>na   of fg perimeter/(2(w+h)) ratio for each pix, or NULL on error</returns>
Public Shared Function pixaFindPerimSizeRatio(
				 ByVal pixa as Pixa) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindPerimSizeRatio( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (385, 1)
' pixFindPerimSizeRatio(pixs, tab, pratio) as Integer
' pixFindPerimSizeRatio(PIX *, l_int32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) We take the 'size' as twice the sum of the width and<para/>
''' height of pixs, and the perimeter is the number of fg<para/>
''' boundary pixels.  We use the fg pixels of the boundary<para/>
''' because the pix may be clipped to the boundary, so an<para/>
''' erosion is required to count all boundary pixels.<para/>
''' (2) This has a large value for dendritic, fractal-like components<para/>
''' with highly irregular boundaries.<para/>
''' (3) This is typically used for a single connected component.<para/>
''' It has a value of about 1.0 for rectangular components with<para/>
''' relatively smooth boundaries.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be NULL</param>
'''  <param name="pratio">[out] - perimeter/size ratio</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindPerimSizeRatio(
				 ByVal pixs as Pix, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pratio as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindPerimSizeRatio( pixs.Pointer, tab, pratio)

	Return _Result
End Function

' SRC\pix5.c (431, 1)
' pixaFindAreaFraction(pixa) as Numa
' pixaFindAreaFraction(PIXA *) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''   <returns>na  of area fractions for each pix, or NULL on error</returns>
Public Shared Function pixaFindAreaFraction(
				 ByVal pixa as Pixa) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindAreaFraction( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (474, 1)
' pixFindAreaFraction(pixs, tab, pfract) as Integer
' pixFindAreaFraction(PIX *, l_int32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This finds the ratio of the number of fg pixels to the<para/>
''' size of the pix (w  h).  It is typically used for a<para/>
''' single connected component.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be NULL</param>
'''  <param name="pfract">[out] - fg area/size ratio</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindAreaFraction(
				 ByVal pixs as Pix, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pfract as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindAreaFraction( pixs.Pointer, tab, pfract)

	Return _Result
End Function

' SRC\pix5.c (522, 1)
' pixaFindAreaFractionMasked(pixa, pixm, debug) as Numa
' pixaFindAreaFractionMasked(PIXA *, PIX *, l_int32) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components, which has an associated<para/>
''' boxa giving the location of the components relative<para/>
''' to the mask origin.<para/>
''' (2) The debug flag displays in green and red the masked and<para/>
''' unmasked parts of the image from which pixa was derived.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''  <param name="pixm">[in] - mask image</param>
'''  <param name="debug">[in] - 1 for output, 0 to suppress</param>
'''   <returns>na of ratio masked/total fractions for each pix, or NULL on error</returns>
Public Shared Function pixaFindAreaFractionMasked(
				 ByVal pixa as Pixa, 
				 ByVal pixm as Pix, 
				 Optional ByVal debug as DebugOnOff = DebugOnOff.DebugOn) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")
	If IsNothing (pixm) then Throw New ArgumentNullException  ("pixm cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindAreaFractionMasked( pixa.Pointer, pixm.Pointer, debug)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (601, 1)
' pixFindAreaFractionMasked(pixs, box, pixm, tab, pfract) as Integer
' pixFindAreaFractionMasked(PIX *, BOX *, PIX *, l_int32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This finds the ratio of the number of masked fg pixels<para/>
''' in pixs to the total number of fg pixels in pixs.<para/>
''' It is typically used for a single connected component.<para/>
''' If there are no fg pixels, this returns a ratio of 0.0.<para/>
''' (2) The box gives the location of the pix relative to that<para/>
''' of the UL corner of the mask.  Therefore, the rasterop<para/>
''' is performed with the pix translated to its location<para/>
''' (x, y) in the mask before ANDing.<para/>
''' If box == NULL, the UL corners of pixs and pixm are aligned.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp, typically a single component</param>
'''  <param name="box">[in][optional] - for pixs relative to pixm</param>
'''  <param name="pixm">[in] - 1 bpp mask, typically over the entire image from which the component pixs was extracted</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be NULL</param>
'''  <param name="pfract">[out] - fg area/size ratio</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindAreaFractionMasked(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal pixm as Pix, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pfract as Single) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixm) then Throw New ArgumentNullException  ("pixm cannot be Nothing")

	Dim boxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(box) Then boxPTR = box.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindAreaFractionMasked( pixs.Pointer, boxPTR, pixm.Pointer, tab, pfract)

	Return _Result
End Function

' SRC\pix5.c (660, 1)
' pixaFindWidthHeightRatio(pixa) as Numa
' pixaFindWidthHeightRatio(PIXA *) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''   <returns>na of width/height ratios for each pix, or NULL on error</returns>
Public Shared Function pixaFindWidthHeightRatio(
				 ByVal pixa as Pixa) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindWidthHeightRatio( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (696, 1)
' pixaFindWidthHeightProduct(pixa) as Numa
' pixaFindWidthHeightProduct(PIXA *) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is typically used for a pixa consisting of<para/>
''' 1 bpp connected components.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - of 1 bpp pix</param>
'''   <returns>na of widthheight products for each pix, or NULL on error</returns>
Public Shared Function pixaFindWidthHeightProduct(
				 ByVal pixa as Pixa) as Numa

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaFindWidthHeightProduct( pixa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (736, 1)
' pixFindOverlapFraction(pixs1, pixs2, x2, y2, tab, pratio, pnoverlap) as Integer
' pixFindOverlapFraction(PIX *, PIX *, l_int32, l_int32, l_int32 *, l_float32 *, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The UL corner of pixs2 is placed at (x2, y2) in pixs1.<para/>
''' (2) This measure is similar to the correlation.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs1">[in] - 1 bpp</param>
'''  <param name="pixs2">[in] - 1 bpp</param>
'''  <param name="x2">[in] - location in pixs1 of UL corner of pixs2</param>
'''  <param name="y2">[in] - location in pixs1 of UL corner of pixs2</param>
'''  <param name="tab">[in][optional] - pixel sum table, can be null</param>
'''  <param name="pratio">[out] - ratio fg intersection to fg union</param>
'''  <param name="pnoverlap">[out][optional] - number of overlapping pixels</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixFindOverlapFraction(
				 ByVal pixs1 as Pix, 
				 ByVal pixs2 as Pix, 
				 ByVal x2 as Integer, 
				 ByVal y2 as Integer, 
				 ByVal tab as Integer(), 
				<Out()> ByRef pratio as Single, 
				<Out()> Optional ByRef pnoverlap as Integer = Nothing) as Integer

	If IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
	If IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")

	If {1}.contains (pixs1.d) = false then Throw New ArgumentException ("1 bpp")
	If {1}.contains (pixs2.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFindOverlapFraction( pixs1.Pointer, pixs2.Pointer, x2, y2, tab, pratio, pnoverlap)

	Return _Result
End Function

' SRC\pix5.c (803, 1)
' pixFindRectangleComps(pixs, dist, minw, minh) as Boxa
' pixFindRectangleComps(PIX *, l_int32, l_int32, l_int32) as BOXA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This applies the function pixConformsToRectangle() to<para/>
''' each 8-c.c. in pixs, and returns a boxa containing the<para/>
''' regions of all components that are conforming.<para/>
''' (2) Conforming components must satisfy both the size constraint<para/>
''' given by %minsize and the slop in conforming to a rectangle<para/>
''' determined by %dist.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="dist">[in] - max distance allowed between bounding box and nearest foreground pixel within it</param>
'''  <param name="minw">[in] - minimum size in each direction as a requirement for a conforming rectangle</param>
'''  <param name="minh">[in] - minimum size in each direction as a requirement for a conforming rectangle</param>
'''   <returns>boxa of components that conform, or NULL on error</returns>
Public Shared Function pixFindRectangleComps(
				 ByVal pixs as Pix, 
				 ByVal dist as Integer, 
				 ByVal minw as Integer, 
				 ByVal minh as Integer) as Boxa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixFindRectangleComps( pixs.Pointer, dist, minw, minh)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Boxa(_Result)
End Function

' SRC\pix5.c (883, 1)
' pixConformsToRectangle(pixs, box, dist, pconforms) as Integer
' pixConformsToRectangle(PIX *, BOX *, l_int32, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) There are several ways to test if a connected component has<para/>
''' an essentially rectangular boundary, such as:<para/>
''' a. Fraction of fill into the bounding box<para/>
''' b. Max-min distance of fg pixel from periphery of bounding box<para/>
''' c. Max depth of bg intrusions into component within bounding box<para/>
''' The weakness of (a) is that it is highly sensitive to holes<para/>
''' within the c.c.  The weakness of (b) is that it can have<para/>
''' arbitrarily large intrusions into the c.c.  Method (c) tests<para/>
''' the integrity of the outer boundary of the c.c., with respect<para/>
''' to the enclosing bounding box, so we use it.<para/>
''' (2) This tests if the connected component within the box conforms<para/>
''' to the box at all points on the periphery within %dist.<para/>
''' Inside, at a distance from the box boundary that is greater<para/>
''' than %dist, we don't care about the pixels in the c.c.<para/>
''' (3) We can think of the conforming condition as follows:<para/>
''' No pixel inside a distance %dist from the boundary<para/>
''' can connect to the boundary through a path through the bg.<para/>
''' To implement this, we need to do a flood fill.  We can go<para/>
''' either from inside toward the boundary, or the other direction.<para/>
''' It's easiest to fill from the boundary, and then verify that<para/>
''' there are no filled pixels farther than %dist from the boundary.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="box">[in][optional] - if null, use the entire pixs</param>
'''  <param name="dist">[in] - max distance allowed between bounding box and nearest foreground pixel within it</param>
'''  <param name="pconforms">[out] - 0 (false) if not conforming 1 (true) if conforming</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixConformsToRectangle(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal dist as Integer, 
				<Out()> ByRef pconforms as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim boxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(box) Then boxPTR = box.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixConformsToRectangle( pixs.Pointer, boxPTR, dist, pconforms)

	Return _Result
End Function

' SRC\pix5.c (950, 1)
' pixClipRectangles(pixs, boxa) as Pixa
' pixClipRectangles(PIX *, BOXA *) as PIXA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned pixa includes the actual regions clipped out from<para/>
''' the input pixs.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="boxa">[in] - requested clipping regions</param>
'''   <returns>pixa consisting of requested regions, or NULL on error</returns>
Public Shared Function pixClipRectangles(
				 ByVal pixs as Pix, 
				 ByVal boxa as Boxa) as Pixa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixClipRectangles( pixs.Pointer, boxa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\pix5.c (1016, 1)
' pixClipRectangle(pixs, box, pboxc) as Pix
' pixClipRectangle(PIX *, BOX *, BOX **) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' This should be simple, but there are choices to be made.<para/>
''' The box is defined relative to the pix coordinates.  However,<para/>
''' if the box is not contained within the pix, we have two choices:<para/>
''' (1) clip the box to the pix<para/>
''' (2) make a new pix equal to the full box dimensions,<para/>
''' but let rasterop do the clipping and positioning<para/>
''' of the src with respect to the dest<para/>
''' Choice (2) immediately brings up the problem of what pixel values<para/>
''' to use that were not taken from the src.  For example, on a grayscale<para/>
''' image, do you want the pixels not taken from the src to be black<para/>
''' or white or something else?  To implement choice 2, one needs to<para/>
''' specify the color of these extra pixels.<para/>
''' So we adopt (1), and clip the box first, if necessary,<para/>
''' before making the dest pix and doing the rasterop.  But there<para/>
''' is another issue to consider.  If you want to paste the<para/>
''' clipped pix back into pixs, it must be properly aligned, and<para/>
''' it is necessary to use the clipped box for alignment.<para/>
''' Accordingly, this function has a third (optional) argument, which is<para/>
''' the input box clipped to the src pix.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - </param>
'''  <param name="box">[in] - requested clipping region const</param>
'''  <param name="pboxc">[out][optional] - actual box of clipped region</param>
'''   <returns>clipped pix, or NULL on error or if rectangle doesn't intersect pixs</returns>
Public Shared Function pixClipRectangle(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				<Out()> Optional ByRef pboxc as Box = Nothing) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")

Dim pboxcPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxc) Then pboxcPTR = pboxc.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixClipRectangle( pixs.Pointer, box.Pointer, pboxcPTR)
	If  _Result = IntPtr.Zero then Return Nothing
	if pboxcPTR <> IntPtr.Zero then pboxc = new Box(pboxcPTR)

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1089, 1)
' pixClipMasked(pixs, pixm, x, y, outval) as Pix
' pixClipMasked(PIX *, PIX *, l_int32, l_int32, l_uint32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If pixs has a colormap, it is preserved in pixd.<para/>
''' (2) The depth of pixd is the same as that of pixs.<para/>
''' (3) If the depth of pixs is 1, use %outval = 0 for white background<para/>
''' and 1 for black otherwise, use the max value for white<para/>
''' and 0 for black.  If pixs has a colormap, the max value for<para/>
''' %outval is 0xffffffff otherwise, it is 2^d - 1.<para/>
''' (4) When using 1 bpp pixs, this is a simple clip and<para/>
''' blend operation.  For example, if both pix1 and pix2 are<para/>
''' black text on white background, and you want to OR the<para/>
''' fg on the two images, let pixm be the inverse of pix2.<para/>
''' Then the operation takes all of pix1 that's in the bg of<para/>
''' pix2, and for the remainder (which are the pixels<para/>
''' corresponding to the fg of the pix2), paint them black<para/>
''' (1) in pix1.  The function call looks like<para/>
''' pixClipMasked(pix2, pixInvert(pix1, pix1), x, y, 1)<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1, 2, 4, 8, 16, 32 bpp colormap ok</param>
'''  <param name="pixm">[in] - clipping mask, 1 bpp</param>
'''  <param name="x">[in] - origin of clipping mask relative to pixs</param>
'''  <param name="y">[in] - origin of clipping mask relative to pixs</param>
'''  <param name="outval">[in] - val to use for pixels that are outside the mask</param>
'''   <returns>pixd, clipped pix or NULL on error or if pixm doesn't intersect pixs</returns>
Public Shared Function pixClipMasked(
				 ByVal pixs as Pix, 
				 ByVal pixm as Pix, 
				 ByVal x as Integer, 
				 ByVal y as Integer, 
				 ByVal outval as UInteger) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (pixm) then Throw New ArgumentNullException  ("pixm cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixClipMasked( pixs.Pointer, pixm.Pointer, x, y, outval)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1151, 1)
' pixCropToMatch(pixs1, pixs2, ppixd1, ppixd2) as Integer
' pixCropToMatch(PIX *, PIX *, PIX **, PIX **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This resizes pixs1 and/or pixs2 by cropping at the right<para/>
''' and bottom, so that they're the same size.<para/>
''' (2) If a pix doesn't need to be cropped, a clone is returned.<para/>
''' (3) Note: the images are implicitly aligned to the UL corner.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs1">[in] - any depth, colormap OK</param>
'''  <param name="pixs2">[in] - any depth, colormap OK</param>
'''  <param name="ppixd1">[out] - may be a clone</param>
'''  <param name="ppixd2">[out] - may be a clone</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixCropToMatch(
				 ByVal pixs1 as Pix, 
				 ByVal pixs2 as Pix, 
				<Out()> ByRef ppixd1 as Pix, 
				<Out()> ByRef ppixd2 as Pix) as Integer

	If IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
	If IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")

	Dim ppixd1PTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd1) Then ppixd1PTR = ppixd1.Pointer
	Dim ppixd2PTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd2) Then ppixd2PTR = ppixd2.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixCropToMatch( pixs1.Pointer, pixs2.Pointer, ppixd1PTR, ppixd2PTR)
	if ppixd1PTR <> IntPtr.Zero then ppixd1 = new Pix(ppixd1PTR)
	if ppixd2PTR <> IntPtr.Zero then ppixd2 = new Pix(ppixd2PTR)

	Return _Result
End Function

' SRC\pix5.c (1194, 1)
' pixCropToSize(pixs, w, h) as Pix
' pixCropToSize(PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If either w or h is smaller than the corresponding dimension<para/>
''' of pixs, this returns a cropped image otherwise it returns<para/>
''' a clone of pixs.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - any depth, colormap OK</param>
'''  <param name="w">[in] - max dimensions of cropped image</param>
'''  <param name="h">[in] - max dimensions of cropped image</param>
'''   <returns>pixd cropped if necessary or NULL on error.</returns>
Public Shared Function pixCropToSize(
				 ByVal pixs as Pix, 
				 ByVal w as Integer, 
				 ByVal h as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixCropToSize( pixs.Pointer, w, h)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1248, 1)
' pixResizeToMatch(pixs, pixt, w, h) as Pix
' pixResizeToMatch(PIX *, PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This resizes pixs to make pixd, without scaling, by either<para/>
''' cropping or extending separately in both width and height.<para/>
''' Extension is done by replicating the last row or column.<para/>
''' This is useful in a situation where, due to scaling<para/>
''' operations, two images that are expected to be the<para/>
''' same size can differ slightly in each dimension.<para/>
''' (2) You can use either an existing pixt or specify<para/>
''' both %w and %h.  If pixt is defined, the values<para/>
''' in %w and %h are ignored.<para/>
''' (3) If pixt is larger than pixs (or if w and/or d is larger<para/>
''' than the dimension of pixs, replicate the outer row and<para/>
''' column of pixels in pixs into pixd.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1, 2, 4, 8, 16, 32 bpp colormap ok</param>
'''  <param name="pixt">[in]can be null - we use only the size</param>
'''  <param name="w">[in] - ignored if pixt is defined</param>
'''  <param name="h">[in] - ignored if pixt is defined</param>
'''   <returns>pixd resized to match or NULL on error</returns>
Public Shared Function pixResizeToMatch(
				 ByVal pixs as Pix, 
				 ByVal pixt as Pix, 
				 ByVal w as Integer, 
				 ByVal h as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim pixtPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pixt) Then pixtPTR = pixt.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixResizeToMatch( pixs.Pointer, pixtPTR, w, h)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1329, 1)
' pixMakeFrameMask(w, h, hf1, hf2, vf1, vf2) as Pix
' pixMakeFrameMask(l_int32, l_int32, l_float32, l_float32, l_float32, l_float32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This makes an arbitrary 1-component mask with a centered fg<para/>
''' frame, which can have both an inner and an outer boundary.<para/>
''' All input fractional distances are measured from the image<para/>
''' border to the frame boundary, in units of the image half-width<para/>
''' for hf1 and hf2 and the image half-height for vf1 and vf2.<para/>
''' The distances to the outer frame boundary are given by hf1<para/>
''' and vf1 to the inner frame boundary, by hf2 and vf2.<para/>
''' Input fractions are thus in [0.0 ... 1.0], with hf1  is lower = hf2<para/>
''' and vf1  is lower = vf2.  Horizontal and vertical frame widths are<para/>
''' thus independently specified.<para/>
''' (2) Special cases:<para/>
''' full fg mask: hf1 = vf1 = 0.0, hf2 = vf2 = 1.0.<para/>
''' empty fg (zero width) mask: set  hf1 = hf2  and vf1 = vf2.<para/>
''' fg rectangle with no hole: set hf2 = vf2 = 1.0.<para/>
''' frame touching outer boundary: set hf1 = vf1 = 0.0.<para/>
''' (3) The vertical thickness of the horizontal mask parts<para/>
''' is 0.5  (vf2 - vf1)  h.  The horizontal thickness of the<para/>
''' vertical mask parts is 0.5  (hf2 - hf1)  w.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="w">[in] - dimensions of output 1 bpp pix</param>
'''  <param name="h">[in] - dimensions of output 1 bpp pix</param>
'''  <param name="hf1">[in] - horizontal fraction of half-width at outer frame bdry</param>
'''  <param name="hf2">[in] - horizontal fraction of half-width at inner frame bdry</param>
'''  <param name="vf1">[in] - vertical fraction of half-width at outer frame bdry</param>
'''  <param name="vf2">[in] - vertical fraction of half-width at inner frame bdry</param>
'''   <returns>pixd 1 bpp, or NULL on error.</returns>
Public Shared Function pixMakeFrameMask(
				 ByVal w as Integer, 
				 ByVal h as Integer, 
				 ByVal hf1 as Single, 
				 ByVal hf2 as Single, 
				 ByVal vf1 as Single, 
				 ByVal vf2 as Single) as Pix

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMakeFrameMask( w, h, hf1, hf2, vf1, vf2)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1395, 1)
' pixMakeCoveringOfRectangles(pixs, maxiters) as Pix
' pixMakeCoveringOfRectangles(PIX *, l_int32) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This iteratively finds the bounding boxes of the connected<para/>
''' components and generates a mask from them.  Two iterations<para/>
''' should suffice for most situations.<para/>
''' (2) Returns an empty pix if %pixs is empty.<para/>
''' (3) If there are many small components in proximity, it may<para/>
''' be useful to merge them with a morphological closing before<para/>
''' calling this one.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="maxiters">[in] - max iterations: use 0 to iterate to completion</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixMakeCoveringOfRectangles(
				 ByVal pixs as Pix, 
				 ByVal maxiters as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixMakeCoveringOfRectangles( pixs.Pointer, maxiters)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (1468, 1)
' pixFractionFgInMask(pix1, pix2, pfract) as Integer
' pixFractionFgInMask(PIX *, PIX *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This gives the fraction of fg pixels in pix1 that are in<para/>
''' the intersection (i.e., under the fg) of pix2:<para/>
''' |1  and  2|/|1|, where |...| means the number of fg pixels.<para/>
''' Note that this is different from the situation where<para/>
''' pix1 and pix2 are reversed.<para/>
''' (2) Both pix1 and pix2 are registered to the UL corners.  A warning<para/>
''' is issued if pix1 and pix2 have different sizes.<para/>
''' (3) This can also be used to find the fraction of fg pixels in pix1<para/>
''' that are NOT under the fg of pix2: 1.0 - |1  and  2|/|1|<para/>
''' (4) If pix1 or pix2 are empty, this returns %fract = 0.0.<para/>
''' (5) For example, pix2 could be a frame around the outside of the<para/>
''' image, made from pixMakeFrameMask().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pix1">[in] - 1 bpp</param>
'''  <param name="pix2">[in] - 1 bpp</param>
'''  <param name="pfract">[out] - fraction of fg pixels in 1 that are aligned with the fg of 2</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function pixFractionFgInMask(
				 ByVal pix1 as Pix, 
				 ByVal pix2 as Pix, 
				<Out()> ByRef pfract as Single) as Integer

	If IsNothing (pix1) then Throw New ArgumentNullException  ("pix1 cannot be Nothing")
	If IsNothing (pix2) then Throw New ArgumentNullException  ("pix2 cannot be Nothing")

	If {1}.contains (pix1.d) = false then Throw New ArgumentException ("1 bpp")
	If {1}.contains (pix2.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixFractionFgInMask( pix1.Pointer, pix2.Pointer, pfract)

	Return _Result
End Function

' SRC\pix5.c (1524, 1)
' pixClipToForeground(pixs, ppixd, pbox) as Integer
' pixClipToForeground(PIX *, PIX **, BOX **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) At least one of { and pixd,  and box} must be specified.<para/>
''' (2) If there are no fg pixels, the returned ptrs are null.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="ppixd">[out][optional] - clipped pix returned</param>
'''  <param name="pbox">[out][optional] - bounding box</param>
'''   <returns>0 if OK 1 on error or if there are no fg pixels</returns>
Public Shared Function pixClipToForeground(
				 ByVal pixs as Pix, 
				<Out()> Optional ByRef ppixd as Pix = Nothing, 
				<Out()> Optional ByRef pbox as Box = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

Dim ppixdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd) Then ppixdPTR = ppixd.Pointer
Dim pboxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pbox) Then pboxPTR = pbox.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixClipToForeground( pixs.Pointer, ppixdPTR, pboxPTR)
	if ppixdPTR <> IntPtr.Zero then ppixd = new Pix(ppixdPTR)
	if pboxPTR <> IntPtr.Zero then pbox = new Box(pboxPTR)

	Return _Result
End Function

' SRC\pix5.c (1624, 1)
' pixTestClipToForeground(pixs, pcanclip) as Integer
' pixTestClipToForeground(PIX *, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) This is a lightweight test to determine if a 1 bpp image<para/>
''' can be further cropped without loss of fg pixels.<para/>
''' If it cannot, canclip is set to 0.<para/>
''' (2) It does not test for the existence of any fg pixels.<para/>
''' If there are no fg pixels, it will return %canclip = 1.<para/>
''' Check the output of the subsequent call to pixClipToForeground().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="pcanclip">[out] - 1 if fg does not extend to all four edges</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function pixTestClipToForeground(
				 ByVal pixs as Pix, 
				<Out()> ByRef pcanclip as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim _Result as Integer = LeptonicaSharp.Natives.pixTestClipToForeground( pixs.Pointer, pcanclip)

	Return _Result
End Function

' SRC\pix5.c (1696, 1)
' pixClipBoxToForeground(pixs, boxs, ppixd, pboxd) as Integer
' pixClipBoxToForeground(PIX *, BOX *, PIX **, BOX **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) At least one of { and pixd,  and boxd} must be specified.<para/>
''' (2) If there are no fg pixels, the returned ptrs are null.<para/>
''' (3) Do not use  and pixs for the 3rd arg or  and boxs for the 4th arg<para/>
''' this will leak memory.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="boxs">[in][optional] - use full image if null</param>
'''  <param name="ppixd">[out][optional] - clipped pix returned</param>
'''  <param name="pboxd">[out][optional] - bounding box</param>
'''   <returns>0 if OK 1 on error or if there are no fg pixels</returns>
Public Shared Function pixClipBoxToForeground(
				 ByVal pixs as Pix, 
				 Optional ByVal boxs as Box = Nothing, 
				<Out()> Optional ByRef ppixd as Pix = Nothing, 
				<Out()> Optional ByRef pboxd as Box = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim boxsPTR As IntPtr = IntPtr.Zero : If Not IsNothing(boxs) Then boxsPTR = boxs.Pointer
Dim ppixdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd) Then ppixdPTR = ppixd.Pointer
Dim pboxdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxd) Then pboxdPTR = pboxd.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixClipBoxToForeground( pixs.Pointer, boxsPTR, ppixdPTR, pboxdPTR)
	if ppixdPTR <> IntPtr.Zero then ppixd = new Pix(ppixdPTR)
	if pboxdPTR <> IntPtr.Zero then pboxd = new Box(pboxdPTR)

	Return _Result
End Function

' SRC\pix5.c (1762, 1)
' pixScanForForeground(pixs, box, scanflag, ploc) as Integer
' pixScanForForeground(PIX *, BOX *, l_int32, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If there are no fg pixels, the position is set to 0.<para/>
''' Caller must check the return value!<para/>
''' (2) Use %box == NULL to scan from edge of pixs<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="box">[in][optional] - within which the search is conducted</param>
'''  <param name="scanflag">[in] - direction of scan e.g., L_FROM_LEFT</param>
'''  <param name="ploc">[out] - location in scan direction of first black pixel</param>
'''   <returns>0 if OK 1 on error or if no fg pixels are found</returns>
Public Shared Function pixScanForForeground(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal scanflag as Enumerations.L_scan_direction, 
				<Out()> ByRef ploc as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim boxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(box) Then boxPTR = box.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixScanForForeground( pixs.Pointer, boxPTR, scanflag, ploc)

	Return _Result
End Function

' SRC\pix5.c (1878, 1)
' pixClipBoxToEdges(pixs, boxs, lowthresh, highthresh, maxwidth, factor, ppixd, pboxd) as Integer
' pixClipBoxToEdges(PIX *, BOX *, l_int32, l_int32, l_int32, l_int32, PIX **, BOX **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) At least one of { and pixd,  and boxd} must be specified.<para/>
''' (2) If there are no fg pixels, the returned ptrs are null.<para/>
''' (3) This function attempts to locate rectangular "image" regions<para/>
''' of high-density fg pixels, that have well-defined edges<para/>
''' on the four sides.<para/>
''' (4) Edges are searched for on each side, iterating in order<para/>
''' from left, right, top and bottom.  As each new edge is<para/>
''' found, the search box is resized to use that location.<para/>
''' Once an edge is found, it is held.  If no more edges<para/>
''' are found in one iteration, the search fails.<para/>
''' (5) See pixScanForEdge() for usage of the thresholds and %maxwidth.<para/>
''' (6) The thresholds must be at least 1, and the low threshold<para/>
''' cannot be larger than the high threshold.<para/>
''' (7) If the low and high thresholds are both 1, this is equivalent<para/>
''' to pixClipBoxToForeground().<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="boxs">[in][optional] - use full image if null</param>
'''  <param name="lowthresh">[in] - threshold to choose clipping location</param>
'''  <param name="highthresh">[in] - threshold required to find an edge</param>
'''  <param name="maxwidth">[in] - max allowed width between low and high thresh locs</param>
'''  <param name="factor">[in] - sampling factor along pixel counting direction</param>
'''  <param name="ppixd">[out][optional] - clipped pix returned</param>
'''  <param name="pboxd">[out][optional] - bounding box</param>
'''   <returns>0 if OK 1 on error or if a fg edge is not found from all four sides.</returns>
Public Shared Function pixClipBoxToEdges(
				 ByVal pixs as Pix, 
				 ByVal boxs as Box, 
				 ByVal lowthresh as Integer, 
				 ByVal highthresh as Integer, 
				 ByVal maxwidth as Integer, 
				 ByVal factor as Integer, 
				<Out()> Optional ByRef ppixd as Pix = Nothing, 
				<Out()> Optional ByRef pboxd as Box = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim boxsPTR As IntPtr = IntPtr.Zero : If Not IsNothing(boxs) Then boxsPTR = boxs.Pointer
Dim ppixdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixd) Then ppixdPTR = ppixd.Pointer
Dim pboxdPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxd) Then pboxdPTR = pboxd.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixClipBoxToEdges( pixs.Pointer, boxsPTR, lowthresh, highthresh, maxwidth, factor, ppixdPTR, pboxdPTR)
	if ppixdPTR <> IntPtr.Zero then ppixd = new Pix(ppixdPTR)
	if pboxdPTR <> IntPtr.Zero then pboxd = new Box(pboxdPTR)

	Return _Result
End Function

' SRC\pix5.c (2008, 1)
' pixScanForEdge(pixs, box, lowthresh, highthresh, maxwidth, factor, scanflag, ploc) as Integer
' pixScanForEdge(PIX *, BOX *, l_int32, l_int32, l_int32, l_int32, l_int32, l_int32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If there are no fg pixels, the position is set to 0.<para/>
''' Caller must check the return value!<para/>
''' (2) Use %box == NULL to scan from edge of pixs<para/>
''' (3) As the scan progresses, the location where the sum of<para/>
''' pixels equals or excees %lowthresh is noted (loc).  The<para/>
''' scan is stopped when the sum of pixels equals or exceeds<para/>
''' %highthresh.  If the scan distance between loc and that<para/>
''' point does not exceed %maxwidth, an edge is found and<para/>
''' its position is taken to be loc.  %maxwidth implicitly<para/>
''' sets a minimum on the required gradient of the edge.<para/>
''' (4) The thresholds must be at least 1, and the low threshold<para/>
''' cannot be larger than the high threshold.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp</param>
'''  <param name="box">[in][optional] - within which the search is conducted</param>
'''  <param name="lowthresh">[in] - threshold to choose clipping location</param>
'''  <param name="highthresh">[in] - threshold required to find an edge</param>
'''  <param name="maxwidth">[in] - max allowed width between low and high thresh locs</param>
'''  <param name="factor">[in] - sampling factor along pixel counting direction</param>
'''  <param name="scanflag">[in] - direction of scan e.g., L_FROM_LEFT</param>
'''  <param name="ploc">[out] - location in scan direction of first black pixel</param>
'''   <returns>0 if OK 1 on error or if the edge is not found</returns>
Public Shared Function pixScanForEdge(
				 ByVal pixs as Pix, 
				 ByVal box as Box, 
				 ByVal lowthresh as Integer, 
				 ByVal highthresh as Integer, 
				 ByVal maxwidth as Integer, 
				 ByVal factor as Integer, 
				 ByVal scanflag as Enumerations.L_scan_direction, 
				<Out()> ByRef ploc as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	If {1}.contains (pixs.d) = false then Throw New ArgumentException ("1 bpp")

	Dim boxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(box) Then boxPTR = box.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixScanForEdge( pixs.Pointer, boxPTR, lowthresh, highthresh, maxwidth, factor, scanflag, ploc)

	Return _Result
End Function

' SRC\pix5.c (2189, 1)
' pixExtractOnLine(pixs, x1, y1, x2, y2, factor) as Numa
' pixExtractOnLine(PIX *, l_int32, l_int32, l_int32, l_int32, l_int32) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) Input end points are clipped to the pix.<para/>
''' (2) If the line is either horizontal, or closer to horizontal<para/>
''' than to vertical, the points will be extracted from left<para/>
''' to right in the pix.  Likewise, if the line is vertical,<para/>
''' or closer to vertical than to horizontal, the points will<para/>
''' be extracted from top to bottom.<para/>
''' (3) Can be used with numaCountReverals(), for example, to<para/>
''' characterize the intensity smoothness along a line.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp or 8 bpp no colormap</param>
'''  <param name="x1">[in] - one end point for line</param>
'''  <param name="y1">[in] - one end point for line</param>
'''  <param name="x2">[in] - another end pt for line</param>
'''  <param name="y2">[in] - another end pt for line</param>
'''  <param name="factor">[in] - sampling  is greater = 1</param>
'''   <returns>na of pixel values along line, or NULL on error.</returns>
Public Shared Function pixExtractOnLine(
				 ByVal pixs as Pix, 
				 ByVal x1 as Integer, 
				 ByVal y1 as Integer, 
				 ByVal x2 as Integer, 
				 ByVal y2 as Integer, 
				 ByVal factor as Integer) as Numa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixExtractOnLine( pixs.Pointer, x1, y1, x2, y2, factor)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (2309, 1)
' pixAverageOnLine(pixs, x1, y1, x2, y2, factor) as Single
' pixAverageOnLine(PIX *, l_int32, l_int32, l_int32, l_int32, l_int32) as l_float32
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The line must be either horizontal or vertical, so either<para/>
''' y1 == y2 (horizontal) or x1 == x2 (vertical).<para/>
''' (2) If horizontal, x1 must be  is lower = x2.<para/>
''' If vertical, y1 must be  is lower = y2.<para/>
''' characterize the intensity smoothness along a line.<para/>
''' (3) Input end points are clipped to the pix.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 1 bpp or 8 bpp no colormap</param>
'''  <param name="x1">[in] - starting pt for line</param>
'''  <param name="y1">[in] - starting pt for line</param>
'''  <param name="x2">[in] - end pt for line</param>
'''  <param name="y2">[in] - end pt for line</param>
'''  <param name="factor">[in] - sampling  is greater = 1</param>
'''   <returns>average of pixel values along line, or NULL on error.</returns>
Public Shared Function pixAverageOnLine(
				 ByVal pixs as Pix, 
				 ByVal x1 as Integer, 
				 ByVal y1 as Integer, 
				 ByVal x2 as Integer, 
				 ByVal y2 as Integer, 
				 ByVal factor as Integer) as Single

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as Single = LeptonicaSharp.Natives.pixAverageOnLine( pixs.Pointer, x1, y1, x2, y2, factor)

	Return _Result
End Function

' SRC\pix5.c (2408, 1)
' pixAverageIntensityProfile(pixs, fract, dir, first, last, factor1, factor2) as Numa
' pixAverageIntensityProfile(PIX *, l_float32, l_int32, l_int32, l_int32, l_int32, l_int32) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If d != 1 bpp, colormaps are removed and the result<para/>
''' is converted to 8 bpp.<para/>
''' (2) If %dir == L_HORIZONTAL_LINE, the intensity is averaged<para/>
''' along each horizontal raster line (sampled by %factor1),<para/>
''' and the profile is the array of these averages in the<para/>
''' vertical direction between %first and %last raster lines,<para/>
''' and sampled by %factor2.<para/>
''' (3) If %dir == L_VERTICAL_LINE, the intensity is averaged<para/>
''' along each vertical line (sampled by %factor1),<para/>
''' and the profile is the array of these averages in the<para/>
''' horizontal direction between %first and %last columns,<para/>
''' and sampled by %factor2.<para/>
''' (4) The averages are measured over the central %fract of the image.<para/>
''' Use %fract == 1.0 to average across the entire width or height.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - any depth colormap OK</param>
'''  <param name="fract">[in] - fraction of image width or height to be used</param>
'''  <param name="dir">[in] - averaging direction: L_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
'''  <param name="first">[in] - last span of rows or columns to measure</param>
'''  <param name="factor1">[in] - sampling along fast scan direction  is greater = 1</param>
'''  <param name="factor2">[in] - sampling along slow scan direction  is greater = 1</param>
'''   <returns>na of reversal profile, or NULL on error.</returns>
Public Shared Function pixAverageIntensityProfile(
				 ByVal pixs as Pix, 
				 ByVal fract as Single, 
				 ByVal dir as Enumerations.L_LINE, 
				 ByVal first as Integer, 
				 ByVal last as Integer, 
				 ByVal factor1 as Integer, 
				 ByVal factor2 as Integer) as Numa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixAverageIntensityProfile( pixs.Pointer, fract, dir, first, last, factor1, factor2)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (2523, 1)
' pixReversalProfile(pixs, fract, dir, first, last, minreversal, factor1, factor2) as Numa
' pixReversalProfile(PIX *, l_float32, l_int32, l_int32, l_int32, l_int32, l_int32, l_int32) as NUMA *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If d != 1 bpp, colormaps are removed and the result<para/>
''' is converted to 8 bpp.<para/>
''' (2) If %dir == L_HORIZONTAL_LINE, the the reversals are counted<para/>
''' along each horizontal raster line (sampled by %factor1),<para/>
''' and the profile is the array of these sums in the<para/>
''' vertical direction between %first and %last raster lines,<para/>
''' and sampled by %factor2.<para/>
''' (3) If %dir == L_VERTICAL_LINE, the the reversals are counted<para/>
''' along each vertical column (sampled by %factor1),<para/>
''' and the profile is the array of these sums in the<para/>
''' horizontal direction between %first and %last columns,<para/>
''' and sampled by %factor2.<para/>
''' (4) For each row or column, the reversals are summed over the<para/>
''' central %fract of the image.  Use %fract == 1.0 to sum<para/>
''' across the entire width (of row) or height (of column).<para/>
''' (5) %minreversal is the relative change in intensity that is<para/>
''' required to resolve peaks and valleys.  A typical number for<para/>
''' locating text in 8 bpp might be 50.  For 1 bpp, minreversal<para/>
''' must be 1.<para/>
''' (6) The reversal profile is simply the number of reversals<para/>
''' in a row or column, vs the row or column index.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - any depth colormap OK</param>
'''  <param name="fract">[in] - fraction of image width or height to be used</param>
'''  <param name="dir">[in] - profile direction: L_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
'''  <param name="first">[in] - span of rows or columns to measure</param>
'''  <param name="last">[in] - span of rows or columns to measure</param>
'''  <param name="minreversal">[in] - minimum change in intensity to trigger a reversal</param>
'''  <param name="factor1">[in] - sampling along raster line (fast scan)  is greater = 1</param>
'''  <param name="factor2">[in] - sampling of raster lines (slow scan)  is greater = 1</param>
'''   <returns>na of reversal profile, or NULL on error.</returns>
Public Shared Function pixReversalProfile(
				 ByVal pixs as Pix, 
				 ByVal fract as Single, 
				 ByVal dir as Enumerations.L_LINE, 
				 ByVal first as Integer, 
				 ByVal last as Integer, 
				 ByVal minreversal as Integer, 
				 ByVal factor1 as Integer, 
				 ByVal factor2 as Integer) as Numa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixReversalProfile( pixs.Pointer, fract, dir, first, last, minreversal, factor1, factor2)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\pix5.c (2632, 1)
' pixWindowedVarianceOnLine(pixs, dir, loc, c1, c2, size, pnad) as Integer
' pixWindowedVarianceOnLine(PIX *, l_int32, l_int32, l_int32, l_int32, l_int32, NUMA **) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The returned variance array traverses the line starting<para/>
''' from the smallest coordinate, min(c1,c2).<para/>
''' (2) Line end points are clipped to pixs.<para/>
''' (3) The reference point for the variance calculation is the center of<para/>
''' the window.  Therefore, the numa start parameter from<para/>
''' pixExtractOnLine() is incremented by %size/2,<para/>
''' to align the variance values with the pixel coordinate.<para/>
''' (4) The square root of the variance is the RMS deviation from the mean.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp no colormap</param>
'''  <param name="dir">[in] - L_HORIZONTAL_LINE or L_VERTICAL_LINE</param>
'''  <param name="loc">[in] - location of the constant coordinate for the line</param>
'''  <param name="c1">[in] - end point coordinates for the line</param>
'''  <param name="c2">[in] - end point coordinates for the line</param>
'''  <param name="size">[in] - window size must be  is greater  1</param>
'''  <param name="pnad">[out] - windowed square root of variance</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function pixWindowedVarianceOnLine(
				 ByVal pixs as Pix, 
				 ByVal dir as Enumerations.L_LINE, 
				 ByVal loc as Integer, 
				 ByVal c1 as Integer, 
				 ByVal c2 as Integer, 
				 ByVal size as Integer, 
				<Out()> ByRef pnad as Numa) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim pnadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnad) Then pnadPTR = pnad.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixWindowedVarianceOnLine( pixs.Pointer, dir, loc, c1, c2, size, pnadPTR)
	if pnadPTR <> IntPtr.Zero then pnad = new Numa(pnadPTR)

	Return _Result
End Function

' SRC\pix5.c (2750, 1)
' pixMinMaxNearLine(pixs, x1, y1, x2, y2, dist, direction, pnamin, pnamax, pminave, pmaxave) as Integer
' pixMinMaxNearLine(PIX *, l_int32, l_int32, l_int32, l_int32, l_int32, l_int32, NUMA **, NUMA **, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) If the line is more horizontal than vertical, the values<para/>
''' are computed for [x1, x2], and the pixels are taken<para/>
''' below and/or above the local y-value.  Otherwise, the<para/>
''' values are computed for [y1, y2] and the pixels are taken<para/>
''' to the left and/or right of the local x value.<para/>
''' (2) %direction specifies which side (or both sides) of the<para/>
''' line are scanned for min and max values.<para/>
''' (3) There are two ways to tell if the returned values of min<para/>
''' and max averages are valid: the returned values cannot be<para/>
''' negative and the function must return 0.<para/>
''' (4) All accessed pixels are clipped to the pix.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp no colormap</param>
'''  <param name="x1">[in] - starting pt for line</param>
'''  <param name="y1">[in] - starting pt for line</param>
'''  <param name="x2">[in] - end pt for line</param>
'''  <param name="y2">[in] - end pt for line</param>
'''  <param name="dist">[in] - distance to search from line in each direction</param>
'''  <param name="direction">[in] - L_SCAN_NEGATIVE, L_SCAN_POSITIVE, L_SCAN_BOTH</param>
'''  <param name="pnamin">[out][optional] - minimum values</param>
'''  <param name="pnamax">[out][optional] - maximum values</param>
'''  <param name="pminave">[out][optional] - average of minimum values</param>
'''  <param name="pmaxave">[out][optional] - average of maximum values</param>
'''   <returns>0 if OK 1 on error or if there are no sampled points within the image.</returns>
Public Shared Function pixMinMaxNearLine(
				 ByVal pixs as Pix, 
				 ByVal x1 as Integer, 
				 ByVal y1 as Integer, 
				 ByVal x2 as Integer, 
				 ByVal y2 as Integer, 
				 ByVal dist as Integer, 
				 ByVal direction as Enumerations.L_scan_direction, 
				<Out()> Optional ByRef pnamin as Numa = Nothing, 
				<Out()> Optional ByRef pnamax as Numa = Nothing, 
				<Out()> Optional ByRef pminave as Single = Nothing, 
				<Out()> Optional ByRef pmaxave as Single = Nothing) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

Dim pnaminPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnamin) Then pnaminPTR = pnamin.Pointer
Dim pnamaxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnamax) Then pnamaxPTR = pnamax.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixMinMaxNearLine( pixs.Pointer, x1, y1, x2, y2, dist, direction, pnaminPTR, pnamaxPTR, pminave, pmaxave)
	if pnaminPTR <> IntPtr.Zero then pnamin = new Numa(pnaminPTR)
	if pnamaxPTR <> IntPtr.Zero then pnamax = new Numa(pnamaxPTR)

	Return _Result
End Function

' SRC\pix5.c (2873, 1)
' pixRankRowTransform(pixs) as Pix
' pixRankRowTransform(PIX *) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The time is O(n) in the number of pixels and runs about<para/>
''' 100 Mpixels/sec on a 3 GHz machine.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp no colormap</param>
'''   <returns>pixd with pixels sorted in each row, from min to max value</returns>
Public Shared Function pixRankRowTransform(
				 ByVal pixs as Pix) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRankRowTransform( pixs.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\pix5.c (2926, 1)
' pixRankColumnTransform(pixs) as Pix
' pixRankColumnTransform(PIX *) as PIX *
'''  <summary>
''' <para/>
''' Notes:<para/>
''' (1) The time is O(n) in the number of pixels and runs about<para/>
''' 50 Mpixels/sec on a 3 GHz machine.<para/>
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - 8 bpp no colormap</param>
'''   <returns>pixd with pixels sorted in each column, from min to max value</returns>
Public Shared Function pixRankColumnTransform(
				 ByVal pixs as Pix) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixRankColumnTransform( pixs.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

End Class

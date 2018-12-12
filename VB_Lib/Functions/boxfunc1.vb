Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' boxfunc1.c (99, 1)
' boxContains(box1, box2, presult) as Integer
' boxContains(BOX *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxContains()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxContains/*"/>
'''  <param name="box1">[in] - </param>
'''  <param name="box2">[in] - </param>
'''  <param name="presult">[out] - 1 if box2 is entirely contained within box1, and 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxContains(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()>  ByRef presult as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxContains(box1.Pointer, box2.Pointer,   presult)
	
	return _Result
End Function

' boxfunc1.c (130, 1)
' boxIntersects(box1, box2, presult) as Integer
' boxIntersects(BOX *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxIntersects()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxIntersects/*"/>
'''  <param name="box1">[in] - </param>
'''  <param name="box2">[in] - </param>
'''  <param name="presult">[out] - 1 if any part of box2 is contained in box1, and 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxIntersects(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()>  ByRef presult as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxIntersects(box1.Pointer, box2.Pointer,   presult)
	
	return _Result
End Function

' boxfunc1.c (172, 1)
' boxaContainedInBox(boxas, box) as Boxa
' boxaContainedInBox(BOXA *, BOX *) as BOXA *
'''  <summary>
''' (1) All boxes in boxa that are entirely outside box are removed.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaContainedInBox/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="box">[in] - for containment</param>
'''   <returns>boxad boxa with all boxes in boxas that are entirely contained in box, or NULL on error</returns>
Public Shared Function boxaContainedInBox(
				ByVal boxas as Boxa, 
				ByVal box as Box) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
		if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaContainedInBox(boxas.Pointer, box.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (210, 1)
' boxaContainedInBoxCount(boxa, box, pcount) as Integer
' boxaContainedInBoxCount(BOXA *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxaContainedInBoxCount()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaContainedInBoxCount/*"/>
'''  <param name="boxa">[in] - </param>
'''  <param name="box">[in] - for selecting contained boxes in %boxa</param>
'''  <param name="pcount">[out] - number of boxes intersecting the box</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaContainedInBoxCount(
				ByVal boxa as Boxa, 
				ByVal box as Box, 
				<Out()>  ByRef pcount as Integer) as Integer


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
		if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as Integer = Natives.boxaContainedInBoxCount(boxa.Pointer, box.Pointer,   pcount)
	
	return _Result
End Function

' boxfunc1.c (249, 1)
' boxaContainedInBoxa(boxa1, boxa2, pcontained) as Integer
' boxaContainedInBoxa(BOXA *, BOXA *, l_int32 *) as l_ok
'''  <summary>
''' boxaContainedInBoxa()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaContainedInBoxa/*"/>
'''  <param name="boxa1">[in] - </param>
'''  <param name="boxa2">[in] - </param>
'''  <param name="pcontained">[out] - 1 if every box in boxa2 is contained in some box in boxa1 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaContainedInBoxa(
				ByVal boxa1 as Boxa, 
				ByVal boxa2 as Boxa, 
				<Out()>  ByRef pcontained as Integer) as Integer


if IsNothing (boxa1) then Throw New ArgumentNullException  ("boxa1 cannot be Nothing")
		if IsNothing (boxa2) then Throw New ArgumentNullException  ("boxa2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxaContainedInBoxa(boxa1.Pointer, boxa2.Pointer,   pcontained)
	
	return _Result
End Function

' boxfunc1.c (302, 1)
' boxaIntersectsBox(boxas, box) as Boxa
' boxaIntersectsBox(BOXA *, BOX *) as BOXA *
'''  <summary>
''' (1) All boxes in boxa that intersect with box (i.e., are completely
'''or partially contained in box) are retained.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaIntersectsBox/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="box">[in] - for intersecting</param>
'''   <returns>boxad boxa with all boxes in boxas that intersect box, or NULL on error</returns>
Public Shared Function boxaIntersectsBox(
				ByVal boxas as Boxa, 
				ByVal box as Box) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
		if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaIntersectsBox(boxas.Pointer, box.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (340, 1)
' boxaIntersectsBoxCount(boxa, box, pcount) as Integer
' boxaIntersectsBoxCount(BOXA *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxaIntersectsBoxCount()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaIntersectsBoxCount/*"/>
'''  <param name="boxa">[in] - </param>
'''  <param name="box">[in] - for selecting intersecting boxes in %boxa</param>
'''  <param name="pcount">[out] - number of boxes intersecting the box</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaIntersectsBoxCount(
				ByVal boxa as Boxa, 
				ByVal box as Box, 
				<Out()>  ByRef pcount as Integer) as Integer


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
		if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as Integer = Natives.boxaIntersectsBoxCount(boxa.Pointer, box.Pointer,   pcount)
	
	return _Result
End Function

' boxfunc1.c (385, 1)
' boxaClipToBox(boxas, box) as Boxa
' boxaClipToBox(BOXA *, BOX *) as BOXA *
'''  <summary>
''' (1) All boxes in boxa not intersecting with box are removed, and
'''the remaining boxes are clipped to box.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaClipToBox/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="box">[in] - for clipping</param>
'''   <returns>boxad boxa with boxes in boxas clipped to box, or NULL on error</returns>
Public Shared Function boxaClipToBox(
				ByVal boxas as Boxa, 
				ByVal box as Box) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
		if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaClipToBox(boxas.Pointer, box.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (442, 1)
' boxaCombineOverlaps(boxas, pixadb) as Boxa
' boxaCombineOverlaps(BOXA *, PIXA *) as BOXA *
'''  <summary>
''' (1) If there are no overlapping boxes, it simply returns a copy
'''of %boxas.<para/>
'''
'''(2) Input an empty %pixadb, using pixaCreate(0), for debug output.
'''The output gives 2 visualizations of the boxes per iteration
'''boxes in red before, and added boxes in green after. Note that
'''all pixels in the red boxes are contained in the green ones.<para/>
'''
'''(3) The alternative method of painting each rectangle and finding
'''the 4-connected components gives a different result in
'''general, because two non-overlapping (but touching)
'''rectangles, when rendered, are 4-connected and will be joined.<para/>
'''
'''(4) A bad case computationally is to have n boxes, none of which
'''overlap.  Then you have one iteration with O(n^2) compares.
'''This is still faster than painting each rectangle and finding
'''the bounding boxes of the connected components, even for
'''thousands of rectangles.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaCombineOverlaps/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="pixadb">[in,out] - debug output</param>
'''   <returns>boxad where each set of boxes in boxas that overlap are combined into a single bounding box in boxad, or NULL on error.</returns>
Public Shared Function boxaCombineOverlaps(
				ByVal boxas as Boxa, 
				ByRef pixadb as Pixa) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim pixadbPtr as IntPtr = IntPtr.Zero : If Not IsNothing(pixadb) Then pixadbPtr = pixadb.Pointer

	Dim _Result as IntPtr = Natives.boxaCombineOverlaps(boxas.Pointer,  pixadbPtr)
	
	if pixadbPtr = IntPtr.Zero then pixadb = Nothing else pixadb = new Pixa(pixadbPtr)
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (536, 1)
' boxaCombineOverlapsInPair(boxas1, boxas2, pboxad1, pboxad2, pixadb) as Integer
' boxaCombineOverlapsInPair(BOXA *, BOXA *, BOXA **, BOXA **, PIXA *) as l_ok
'''  <summary>
''' (1) One of three things happens to each box in %boxa1 and %boxa2:
'''it gets absorbed into a larger box that it overlaps with
'''it absorbs a smaller (by area) box that it overlaps with
'''and gets larger, using the bounding region of the 2 boxes
'''it is unchanged (including absorbing smaller boxes that
'''are contained within it).<para/>
'''
'''(2) If all the boxes from one of the input boxa are absorbed, this
'''returns an empty boxa.<para/>
'''
'''(3) Input an empty %pixadb, using pixaCreate(0), for debug output<para/>
'''
'''(4) This is useful if different operations are to be carried out
'''on possibly overlapping rectangular regions, and it is desired
'''to have only one operation on any rectangular region.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaCombineOverlapsInPair/*"/>
'''  <param name="boxas1">[in] - input boxa1</param>
'''  <param name="boxas2">[in] - input boxa2</param>
'''  <param name="pboxad1">[out] - output boxa1</param>
'''  <param name="pboxad2">[out] - output boxa2</param>
'''  <param name="pixadb">[in,out] - debug output</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaCombineOverlapsInPair(
				ByVal boxas1 as Boxa, 
				ByVal boxas2 as Boxa, 
				<Out()>  ByRef pboxad1 as Boxa, 
				<Out()>  ByRef pboxad2 as Boxa, 
				ByRef pixadb as Pixa) as Integer


if IsNothing (boxas1) then Throw New ArgumentNullException  ("boxas1 cannot be Nothing")
		if IsNothing (boxas2) then Throw New ArgumentNullException  ("boxas2 cannot be Nothing")
	Dim pboxad1Ptr as IntPtr = IntPtr.Zero
	Dim pboxad2Ptr as IntPtr = IntPtr.Zero
	Dim pixadbPtr as IntPtr = IntPtr.Zero : If Not IsNothing(pixadb) Then pixadbPtr = pixadb.Pointer

	Dim _Result as Integer = Natives.boxaCombineOverlapsInPair(boxas1.Pointer, boxas2.Pointer, pboxad1Ptr, pboxad2Ptr,  pixadbPtr)
	
	if pboxad1Ptr = IntPtr.Zero then pboxad1 = Nothing else pboxad1 = new Boxa(pboxad1Ptr)
	if pboxad2Ptr = IntPtr.Zero then pboxad2 = Nothing else pboxad2 = new Boxa(pboxad2Ptr)
	if pixadbPtr = IntPtr.Zero then pixadb = Nothing else pixadb = new Pixa(pixadbPtr)
	return _Result
End Function

' boxfunc1.c (674, 1)
' boxOverlapRegion(box1, box2) as Box
' boxOverlapRegion(BOX *, BOX *) as BOX *
'''  <summary>
''' (1) This is the geometric intersection of the two rectangles.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxOverlapRegion/*"/>
'''  <param name="box1">[in] - two boxes</param>
'''  <param name="box2">[in] - two boxes</param>
'''   <returns>box of overlap region between input boxes, or NULL if no overlap or on error</returns>
Public Shared Function boxOverlapRegion(
				ByVal box1 as Box, 
				ByVal box2 as Box) as Box


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxOverlapRegion(box1.Pointer, box2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (716, 1)
' boxBoundingRegion(box1, box2) as Box
' boxBoundingRegion(BOX *, BOX *) as BOX *
'''  <summary>
''' (1) This is the geometric union of the two rectangles.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxBoundingRegion/*"/>
'''  <param name="box1">[in] - two boxes</param>
'''  <param name="box2">[in] - two boxes</param>
'''   <returns>box of bounding region containing the input boxes, or NULL on error</returns>
Public Shared Function boxBoundingRegion(
				ByVal box1 as Box, 
				ByVal box2 as Box) as Box


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxBoundingRegion(box1.Pointer, box2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (756, 1)
' boxOverlapFraction(box1, box2, pfract) as Integer
' boxOverlapFraction(BOX *, BOX *, l_float32 *) as l_ok
'''  <summary>
''' (1) The result depends on the order of the input boxes,
'''because the overlap is taken as a fraction of box2.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxOverlapFraction/*"/>
'''  <param name="box1">[in] - two boxes</param>
'''  <param name="box2">[in] - two boxes</param>
'''  <param name="pfract">[out] - the fraction of box2 overlapped by box1</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function boxOverlapFraction(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()>  ByRef pfract as Single) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxOverlapFraction(box1.Pointer, box2.Pointer,   pfract)
	
	return _Result
End Function

' boxfunc1.c (792, 1)
' boxOverlapArea(box1, box2, parea) as Integer
' boxOverlapArea(BOX *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxOverlapArea()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxOverlapArea/*"/>
'''  <param name="box1">[in] - two boxes</param>
'''  <param name="box2">[in] - two boxes</param>
'''  <param name="parea">[out] - the number of pixels in the overlap</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function boxOverlapArea(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()>  ByRef parea as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxOverlapArea(box1.Pointer, box2.Pointer,   parea)
	
	return _Result
End Function

' boxfunc1.c (853, 1)
' boxaHandleOverlaps(boxas, op, range, min_overlap, max_ratio, pnamap) as Boxa
' boxaHandleOverlaps(BOXA *, l_int32, l_int32, l_float32, l_float32, NUMA **) as BOXA *
'''  <summary>
''' (1) For all n(n-1)/2 box pairings, if two boxes overlap, either:
'''(a) op == L_COMBINE: get the bounding region for the two,
'''replace the larger with the bounding region, and remove
'''the smaller of the two, or
'''(b) op == L_REMOVE_SMALL: just remove the smaller.<para/>
'''
'''(2) If boxas is 2D sorted, range can be small, but if it is
'''not spatially sorted, range should be large to allow all
'''pairwise comparisons to be made.<para/>
'''
'''(3) The %min_overlap parameter allows ignoring small overlaps.
'''If %min_overlap == 1.0, only boxes fully contained in larger
'''boxes can be considered for removal if %min_overlap == 0.0,
'''this constraint is ignored.<para/>
'''
'''(4) The %max_ratio parameter allows ignoring overlaps between
'''boxes that are not too different in size.  If %max_ratio == 0.0,
'''no boxes can be removed if %max_ratio == 1.0, this constraint
'''is ignored.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaHandleOverlaps/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="op">[in] - L_COMBINE, L_REMOVE_SMALL</param>
'''  <param name="range">[in] - is greater  0, forward distance over which overlaps are checked</param>
'''  <param name="min_overlap">[in] - minimum fraction of smaller box required for overlap to count 0.0 to ignore</param>
'''  <param name="max_ratio">[in] - maximum fraction of small/large areas for overlap to count 1.0 to ignore</param>
'''  <param name="pnamap">[out][optional] - combining map</param>
'''   <returns>boxad, or NULL on error.</returns>
Public Shared Function boxaHandleOverlaps(
				ByVal boxas as Boxa, 
				ByVal op as Enumerations.L_hling_overlapping_bounding_boxes_in_boxa, 
				ByVal range as Integer, 
				ByVal min_overlap as Single, 
				ByVal max_ratio as Single, 
				<Out()> Optional  ByRef pnamap as Numa = Nothing) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim pnamapPtr as IntPtr = IntPtr.Zero

	Dim _Result as IntPtr = Natives.boxaHandleOverlaps(boxas.Pointer,   op,   range,   min_overlap,   max_ratio, pnamapPtr)
	
	if pnamapPtr = IntPtr.Zero then pnamap = Nothing else pnamap = new Numa(pnamapPtr)
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (973, 1)
' boxSeparationDistance(box1, box2, ph_sep, pv_sep) as Integer
' boxSeparationDistance(BOX *, BOX *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' (1) This measures horizontal and vertical separation of the
'''two boxes.  If the boxes are touching but have no pixels
'''in common, the separation is 0.  If the boxes overlap by
'''a distance d, the returned separation is -d.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxSeparationDistance/*"/>
'''  <param name="box1">[in] - two boxes, in any order</param>
'''  <param name="box2">[in] - two boxes, in any order</param>
'''  <param name="ph_sep">[out][optional] - horizontal separation</param>
'''  <param name="pv_sep">[out][optional] - vertical separation</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxSeparationDistance(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()> Optional  ByRef ph_sep as Integer = 0, 
				<Out()> Optional  ByRef pv_sep as Integer = 0) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxSeparationDistance(box1.Pointer, box2.Pointer,   ph_sep,   pv_sep)
	
	return _Result
End Function

' boxfunc1.c (1029, 1)
' boxCompareSize(box1, box2, type, prel) as Integer
' boxCompareSize(BOX *, BOX *, l_int32, l_int32 *) as l_ok
'''  <summary>
''' (1) We're re-using the SORT enum for these comparisons.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxCompareSize/*"/>
'''  <param name="box1">[in] - </param>
'''  <param name="box2">[in] - </param>
'''  <param name="type">[in] - L_SORT_BY_WIDTH, L_SORT_BY_HEIGHT, L_SORT_BY_MAX_DIMENSION, L_SORT_BY_PERIMETER, L_SORT_BY_AREA,</param>
'''  <param name="prel">[out] - 1 if box1  is greater  box2, 0 if the same, -1 if box1  is smaller box2</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxCompareSize(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				ByVal type as Enumerations.L_SORT_BY, 
				<Out()>  ByRef prel as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxCompareSize(box1.Pointer, box2.Pointer,   type,   prel)
	
	return _Result
End Function

' boxfunc1.c (1080, 1)
' boxContainsPt(box, x, y, pcontains) as Integer
' boxContainsPt(BOX *, l_float32, l_float32, l_int32 *) as l_ok
'''  <summary>
''' boxContainsPt()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxContainsPt/*"/>
'''  <param name="box">[in] - </param>
'''  <param name="x">[in] - a point</param>
'''  <param name="y">[in] - a point</param>
'''  <param name="pcontains">[out] - 1 if box contains point 0 otherwise</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function boxContainsPt(
				ByVal box as Box, 
				ByVal x as Single, 
				ByVal y as Single, 
				<Out()>  ByRef pcontains as Integer) as Integer


if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as Integer = Natives.boxContainsPt(box.Pointer,   x,   y,   pcontains)
	
	return _Result
End Function

' boxfunc1.c (1115, 1)
' boxaGetNearestToPt(boxa, x, y) as Box
' boxaGetNearestToPt(BOXA *, l_int32, l_int32) as BOX *
'''  <summary>
''' (1) Uses euclidean distance between centroid and point.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaGetNearestToPt/*"/>
'''  <param name="boxa">[in] - </param>
'''  <param name="x">[in] - point</param>
'''  <param name="y">[in] - point</param>
'''   <returns>box with centroid closest to the given point [x,y], or NULL if no boxes in boxa</returns>
Public Shared Function boxaGetNearestToPt(
				ByVal boxa as Boxa, 
				ByVal x as Integer, 
				ByVal y as Integer) as Box


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaGetNearestToPt(boxa.Pointer,   x,   y)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (1167, 1)
' boxaGetNearestToLine(boxa, x, y) as Box
' boxaGetNearestToLine(BOXA *, l_int32, l_int32) as BOX *
'''  <summary>
''' (1) For a horizontal line at some value y, get the minimum of the
'''distance |yc - y| from the box centroid yc value to y
'''likewise minimize |xc - x| for a vertical line at x.<para/>
'''
'''(2) Input y  is smaller 0, x greater or equal 0 to indicate a vertical line at x, and
'''x  is smaller 0, y greater or equal 0 for a horizontal line at y.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaGetNearestToLine/*"/>
'''  <param name="boxa">[in] - </param>
'''  <param name="x">[in] - (y = -1 for vertical line x = -1 for horiz line)</param>
'''  <param name="y">[in] - (y = -1 for vertical line x = -1 for horiz line)</param>
'''   <returns>box with centroid closest to the given line, or NULL if no boxes in boxa</returns>
Public Shared Function boxaGetNearestToLine(
				ByVal boxa as Boxa, 
				ByVal x as Integer, 
				ByVal y as Integer) as Box


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaGetNearestToLine(boxa.Pointer,   x,   y)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (1224, 1)
' boxaFindNearestBoxes(boxa, dist_select, range, pnaaindex, pnaadist) as Integer
' boxaFindNearestBoxes(BOXA *, l_int32, l_int32, NUMAA **, NUMAA **) as l_ok
'''  <summary>
''' (1) See boxaGetNearestByDirection() for usage of %dist_select
'''and %range.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaFindNearestBoxes/*"/>
'''  <param name="boxa">[in] - either unsorted, or 2D sorted in LR/TB scan order</param>
'''  <param name="dist_select">[in] - L_NON_NEGATIVE, L_ALL</param>
'''  <param name="range">[in] - search distance from box i use 0 to search entire boxa (e.g., if it's not 2D sorted)</param>
'''  <param name="pnaaindex">[out] - for each box in %boxa, contains a numa of 4 box indices (per direction) of the nearest box</param>
'''  <param name="pnaadist">[out] - for each box in %boxa, this contains a numa</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaFindNearestBoxes(
				ByVal boxa as Boxa, 
				ByVal dist_select as Enumerations.L_value_, 
				ByVal range as Integer, 
				<Out()>  ByRef pnaaindex as Numaa, 
				<Out()>  ByRef pnaadist as Numaa) as Integer


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
	Dim pnaaindexPtr as IntPtr = IntPtr.Zero
	Dim pnaadistPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.boxaFindNearestBoxes(boxa.Pointer,   dist_select,   range, pnaaindexPtr, pnaadistPtr)
	
	if pnaaindexPtr = IntPtr.Zero then pnaaindex = Nothing else pnaaindex = new Numaa(pnaaindexPtr)
	if pnaadistPtr = IntPtr.Zero then pnaadist = Nothing else pnaadist = new Numaa(pnaadistPtr)
	return _Result
End Function

' boxfunc1.c (1305, 1)
' boxaGetNearestByDirection(boxa, i, dir, dist_select, range, pindex, pdist) as Integer
' boxaGetNearestByDirection(BOXA *, l_int32, l_int32, l_int32, l_int32, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' (1) For efficiency, use a LR/TD sorted %boxa, which can be
'''made by flattening a 2D sorted boxaa.  In that case,
'''%range can be some positive integer like 50.<para/>
'''
'''(2) If boxes overlap, the distance will be  is smaller 0.  Use %dist_select
'''to determine if these should count or not.  If L_ALL, then
'''one box will match as the nearest to another in 2 or more
'''directions.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaGetNearestByDirection/*"/>
'''  <param name="boxa">[in] - either unsorted, or 2D sorted in LR/TB scan order</param>
'''  <param name="i">[in] - box we test against</param>
'''  <param name="dir">[in] - direction to look: L_FROM_LEFT, L_FROM_RIGHT, L_FROM_TOP, L_FROM_BOT</param>
'''  <param name="dist_select">[in] - L_NON_NEGATIVE, L_ALL</param>
'''  <param name="range">[in] - search distance from box i use 0 to search entire boxa (e.g., if it's not 2D sorted)</param>
'''  <param name="pindex">[out] - index in boxa of nearest box with overlapping coordinates in the indicated direction -1 if there is no box</param>
'''  <param name="pdist">[out] - distance of the nearest box in the indicated direction 100000 if no box</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaGetNearestByDirection(
				ByVal boxa as Boxa, 
				ByVal i as Integer, 
				ByVal dir as Integer, 
				ByVal dist_select as Enumerations.L_value_, 
				ByVal range as Integer, 
				<Out()>  ByRef pindex as Integer, 
				<Out()>  ByRef pdist as Integer) as Integer


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
	Dim _Result as Integer = Natives.boxaGetNearestByDirection(boxa.Pointer,   i,   dir,   dist_select,   range,   pindex,   pdist)
	
	return _Result
End Function

' boxfunc1.c (1444, 1)
' boxGetCenter(box, pcx, pcy) as Integer
' boxGetCenter(BOX *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' boxGetCenter()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxGetCenter/*"/>
'''  <param name="box">[in] - </param>
'''  <param name="pcx">[out] - location of center of box</param>
'''  <param name="pcy">[out] - location of center of box</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxGetCenter(
				ByVal box as Box, 
				<Out()>  ByRef pcx as Single, 
				<Out()>  ByRef pcy as Single) as Integer


if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as Integer = Natives.boxGetCenter(box.Pointer,   pcx,   pcy)
	
	return _Result
End Function

' boxfunc1.c (1485, 1)
' boxIntersectByLine(box, x, y, slope, px1, py1, px2, py2, pn) as Integer
' boxIntersectByLine(BOX *, l_int32, l_int32, l_float32, l_int32 *, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' (1) If the intersection is at only one point (a corner), the
'''coordinates are returned in (x1, y1).<para/>
'''
'''(2) Represent a vertical line by one with a large but finite slope.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxIntersectByLine/*"/>
'''  <param name="box">[in] - </param>
'''  <param name="x">[in] - point that line goes through</param>
'''  <param name="y">[in] - point that line goes through</param>
'''  <param name="slope">[in] - of line</param>
'''  <param name="px1">[out] - 1st point of intersection with box</param>
'''  <param name="py1">[out] - 1st point of intersection with box</param>
'''  <param name="px2">[out] - 2nd point of intersection with box</param>
'''  <param name="py2">[out] - 2nd point of intersection with box</param>
'''  <param name="pn">[out] - number of points of intersection</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxIntersectByLine(
				ByVal box as Box, 
				ByVal x as Integer, 
				ByVal y as Integer, 
				ByVal slope as Single, 
				<Out()>  ByRef px1 as Integer, 
				<Out()>  ByRef py1 as Integer, 
				<Out()>  ByRef px2 as Integer, 
				<Out()>  ByRef py2 as Integer, 
				<Out()>  ByRef pn as Integer) as Integer


if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as Integer = Natives.boxIntersectByLine(box.Pointer,   x,   y,   slope,   px1,   py1,   px2,   py2,   pn)
	
	return _Result
End Function

' boxfunc1.c (1587, 1)
' boxClipToRectangle(box, wi, hi) as Box
' boxClipToRectangle(BOX *, l_int32, l_int32) as BOX *
'''  <summary>
''' (1) This can be used to clip a rectangle to an image.
'''The clipping rectangle is assumed to have a UL corner at (0, 0),
'''and a LR corner at (wi - 1, hi - 1).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxClipToRectangle/*"/>
'''  <param name="box">[in] - </param>
'''  <param name="wi">[in] - rectangle representing image</param>
'''  <param name="hi">[in] - rectangle representing image</param>
'''   <returns>part of box within given rectangle, or NULL on error or if box is entirely outside the rectangle</returns>
Public Shared Function boxClipToRectangle(
				ByVal box as Box, 
				ByVal wi as Integer, 
				ByVal hi as Integer) as Box


if IsNothing (box) then Throw New ArgumentNullException  ("box cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxClipToRectangle(box.Pointer,   wi,   hi)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (1644, 1)
' boxClipToRectangleParams(box, w, h, pxstart, pystart, pxend, pyend, pbw, pbh) as Integer
' boxClipToRectangleParams(BOX *, l_int32, l_int32, l_int32 *, l_int32 *, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' (1) The return value should be checked.  If it is 1, the
'''returned parameter values are bogus.<para/>
'''
'''(2) This simplifies the selection of pixel locations within
'''a given rectangle:
'''for (i = ystart i  is smaller yend i++ {
'''...
'''for (j = xstart j  is smaller xend j++ {
'''....
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxClipToRectangleParams/*"/>
'''  <param name="box">[in][optional] - requested box can be null</param>
'''  <param name="w">[in] - clipping box size typ. the size of an image</param>
'''  <param name="h">[in] - clipping box size typ. the size of an image</param>
'''  <param name="pxstart">[out] - start x coordinate</param>
'''  <param name="pystart">[out] - start y coordinate</param>
'''  <param name="pxend">[out] - one pixel beyond clipping box</param>
'''  <param name="pyend">[out] - one pixel beyond clipping box</param>
'''  <param name="pbw">[out][optional] - clipped width</param>
'''  <param name="pbh">[out][optional] - clipped height</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function boxClipToRectangleParams(
				ByVal box as Box, 
				ByVal w as Integer, 
				ByVal h as Integer, 
				<Out()>  ByRef pxstart as Integer, 
				<Out()>  ByRef pystart as Integer, 
				<Out()>  ByRef pxend as Integer, 
				<Out()>  ByRef pyend as Integer, 
				<Out()> Optional  ByRef pbw as Integer = 0, 
				<Out()> Optional  ByRef pbh as Integer = 0) as Integer


	Dim boxPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(box) Then boxPtr = box.Pointer

	Dim _Result as Integer = Natives.boxClipToRectangleParams(boxPtr,   w,   h,   pxstart,   pystart,   pxend,   pyend,   pbw,   pbh)
	
	return _Result
End Function

' boxfunc1.c (1706, 1)
' boxRelocateOneSide(boxd, boxs, loc, sideflag) as Box
' boxRelocateOneSide(BOX *, BOX *, l_int32, l_int32) as BOX *
'''  <summary>
''' (1) Set boxd == NULL to get new box boxd == boxs for in-place
'''or otherwise to resize existing boxd.<para/>
'''
'''(2) For usage, suggest one of these:
'''boxd = boxRelocateOneSide(NULL, boxs, ...) // new
'''boxRelocateOneSide(boxs, boxs, ...)  // in-place
'''boxRelocateOneSide(boxd, boxs, ...)  // other
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxRelocateOneSide/*"/>
'''  <param name="boxd">[in][optional] - this can be null, equal to boxs, or different from boxs</param>
'''  <param name="boxs">[in] - starting box to have one side relocated</param>
'''  <param name="loc">[in] - new location of the side that is changing</param>
'''  <param name="sideflag">[in] - L_FROM_LEFT, etc., indicating the side that moves</param>
'''   <returns>boxd, or NULL on error or if the computed boxd has width or height smaller or equal 0.</returns>
Public Shared Function boxRelocateOneSide(
				ByVal boxd as Box, 
				ByVal boxs as Box, 
				ByVal loc as Integer, 
				ByVal sideflag as Integer) as Box


if IsNothing (boxs) then Throw New ArgumentNullException  ("boxs cannot be Nothing")
	Dim boxdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(boxd) Then boxdPtr = boxd.Pointer

	Dim _Result as IntPtr = Natives.boxRelocateOneSide(boxdPtr, boxs.Pointer,   loc,   sideflag)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (1750, 1)
' boxaAdjustSides(boxas, delleft, delright, deltop, delbot) as Boxa
' boxaAdjustSides(BOXA *, l_int32, l_int32, l_int32, l_int32) as BOXA *
'''  <summary>
''' (1) New box dimensions are cropped at left and top to x greater or equal 0 and y greater or equal 0.<para/>
'''
'''(2) If the width or height of a box goes to 0, we generate a box with
'''w == 1 and h == 1, as a placeholder.<para/>
'''
'''(3) See boxAdjustSides().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaAdjustSides/*"/>
'''  <param name="boxas">[in] - </param>
'''  <param name="delleft">[in] - changes in location of each side for each box</param>
'''  <param name="delright">[in] - changes in location of each side for each box</param>
'''  <param name="deltop">[in] - changes in location of each side for each box</param>
'''  <param name="delbot">[in] - changes in location of each side for each box</param>
'''   <returns>boxad, or NULL on error</returns>
Public Shared Function boxaAdjustSides(
				ByVal boxas as Boxa, 
				ByVal delleft as Integer, 
				ByVal delright as Integer, 
				ByVal deltop as Integer, 
				ByVal delbot as Integer) as Boxa


if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaAdjustSides(boxas.Pointer,   delleft,   delright,   deltop,   delbot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (1807, 1)
' boxAdjustSides(boxd, boxs, delleft, delright, deltop, delbot) as Box
' boxAdjustSides(BOX *, BOX *, l_int32, l_int32, l_int32, l_int32) as BOX *
'''  <summary>
''' (1) Set boxd == NULL to get new box boxd == boxs for in-place
'''or otherwise to resize existing boxd.<para/>
'''
'''(2) For usage, suggest one of these:
'''boxd = boxAdjustSides(NULL, boxs, ...) // new
'''boxAdjustSides(boxs, boxs, ...)  // in-place
'''boxAdjustSides(boxd, boxs, ...)  // other<para/>
'''
'''(3) New box dimensions are cropped at left and top to x greater or equal 0 and y greater or equal 0.<para/>
'''
'''(4) For example, to expand in-place by 20 pixels on each side, use
'''boxAdjustSides(box, box, -20, 20, -20, 20)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxAdjustSides/*"/>
'''  <param name="boxd">[in][optional] - this can be null, equal to boxs, or different from boxs</param>
'''  <param name="boxs">[in] - starting box to have sides adjusted</param>
'''  <param name="delleft">[in] - changes in location of each side</param>
'''  <param name="delright">[in] - changes in location of each side</param>
'''  <param name="deltop">[in] - changes in location of each side</param>
'''  <param name="delbot">[in] - changes in location of each side</param>
'''   <returns>boxd, or NULL on error or if the computed boxd has width or height smaller or equal 0.</returns>
Public Shared Function boxAdjustSides(
				ByVal boxd as Box, 
				ByVal boxs as Box, 
				ByVal delleft as Integer, 
				ByVal delright as Integer, 
				ByVal deltop as Integer, 
				ByVal delbot as Integer) as Box


if IsNothing (boxs) then Throw New ArgumentNullException  ("boxs cannot be Nothing")
	Dim boxdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(boxd) Then boxdPtr = boxd.Pointer

	Dim _Result as IntPtr = Natives.boxAdjustSides(boxdPtr, boxs.Pointer,   delleft,   delright,   deltop,   delbot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Box(_Result)
End Function

' boxfunc1.c (1859, 1)
' boxaSetSide(boxad, boxas, side, val, thresh) as Boxa
' boxaSetSide(BOXA *, BOXA *, l_int32, l_int32, l_int32) as BOXA *
'''  <summary>
''' (1) Sets the given side of each box.  Use boxad == NULL for a new
'''boxa, and boxad == boxas for in-place.<para/>
'''
'''(2) Use one of these:
'''boxad = boxaSetSide(NULL, boxas, ...) // new
'''boxaSetSide(boxas, boxas, ...)  // in-place
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaSetSide/*"/>
'''  <param name="boxad">[in] - use NULL to get a new one same as boxas for in-place</param>
'''  <param name="boxas">[in] - </param>
'''  <param name="side">[in] - L_SET_LEFT, L_SET_RIGHT, L_SET_TOP, L_SET_BOT</param>
'''  <param name="val">[in] - location to set for given side, for each box</param>
'''  <param name="thresh">[in] - min abs difference to cause resetting to %val</param>
'''   <returns>boxad, or NULL on error</returns>
Public Shared Function boxaSetSide(
				ByVal boxad as Boxa, 
				ByVal boxas as Boxa, 
				ByVal side as Enumerations.L_box_size_adjustment_location, 
				ByVal val as Integer, 
				ByVal thresh as Integer) as Boxa


if IsNothing (boxad) then Throw New ArgumentNullException  ("boxad cannot be Nothing")
		if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaSetSide(boxad.Pointer, boxas.Pointer,   side,   val,   thresh)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (1932, 1)
' boxaAdjustWidthToTarget(boxad, boxas, sides, target, thresh) as Boxa
' boxaAdjustWidthToTarget(BOXA *, BOXA *, l_int32, l_int32, l_int32) as BOXA *
'''  <summary>
''' (1) Conditionally adjusts the width of each box, by moving
'''the indicated edges (left and/or right) if the width differs
'''by %thresh or more from %target.<para/>
'''
'''(2) Use boxad == NULL for a new boxa, and boxad == boxas for in-place.
'''Use one of these:
'''boxad = boxaAdjustWidthToTarget(NULL, boxas, ...) // new
'''boxaAdjustWidthToTarget(boxas, boxas, ...)  // in-place
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaAdjustWidthToTarget/*"/>
'''  <param name="boxad">[in] - use NULL to get a new one same as boxas for in-place</param>
'''  <param name="boxas">[in] - </param>
'''  <param name="sides">[in] - L_ADJUST_LEFT, L_ADJUST_RIGHT, L_ADJUST_LEFT_AND_RIGHT</param>
'''  <param name="target">[in] - target width if differs by more than thresh</param>
'''  <param name="thresh">[in] - min abs difference in width to cause adjustment</param>
'''   <returns>boxad, or NULL on error</returns>
Public Shared Function boxaAdjustWidthToTarget(
				ByVal boxad as Boxa, 
				ByVal boxas as Boxa, 
				ByVal sides as Enumerations.L_box_size_adjustment_location, 
				ByVal target as Integer, 
				ByVal thresh as Integer) as Boxa


if IsNothing (boxad) then Throw New ArgumentNullException  ("boxad cannot be Nothing")
		if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaAdjustWidthToTarget(boxad.Pointer, boxas.Pointer,   sides,   target,   thresh)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (1999, 1)
' boxaAdjustHeightToTarget(boxad, boxas, sides, target, thresh) as Boxa
' boxaAdjustHeightToTarget(BOXA *, BOXA *, l_int32, l_int32, l_int32) as BOXA *
'''  <summary>
''' (1) Conditionally adjusts the height of each box, by moving
'''the indicated edges (top and/or bot) if the height differs
'''by %thresh or more from %target.<para/>
'''
'''(2) Use boxad == NULL for a new boxa, and boxad == boxas for in-place.
'''Use one of these:
'''boxad = boxaAdjustHeightToTarget(NULL, boxas, ...) // new
'''boxaAdjustHeightToTarget(boxas, boxas, ...)  // in-place
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaAdjustHeightToTarget/*"/>
'''  <param name="boxad">[in] - use NULL to get a new one</param>
'''  <param name="boxas">[in] - </param>
'''  <param name="sides">[in] - L_ADJUST_TOP, L_ADJUST_BOT, L_ADJUST_TOP_AND_BOT</param>
'''  <param name="target">[in] - target height if differs by more than thresh</param>
'''  <param name="thresh">[in] - min abs difference in height to cause adjustment</param>
'''   <returns>boxad, or NULL on error</returns>
Public Shared Function boxaAdjustHeightToTarget(
				ByVal boxad as Boxa, 
				ByVal boxas as Boxa, 
				ByVal sides as Enumerations.L_box_size_adjustment_location, 
				ByVal target as Integer, 
				ByVal thresh as Integer) as Boxa


if IsNothing (boxad) then Throw New ArgumentNullException  ("boxad cannot be Nothing")
		if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaAdjustHeightToTarget(boxad.Pointer, boxas.Pointer,   sides,   target,   thresh)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

' boxfunc1.c (2057, 1)
' boxEqual(box1, box2, psame) as Integer
' boxEqual(BOX *, BOX *, l_int32 *) as l_ok
'''  <summary>
''' boxEqual()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxEqual/*"/>
'''  <param name="box1">[in] - </param>
'''  <param name="box2">[in] - </param>
'''  <param name="psame">[out] - 1 if equal 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxEqual(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				<Out()>  ByRef psame as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxEqual(box1.Pointer, box2.Pointer,   psame)
	
	return _Result
End Function

' boxfunc1.c (2104, 1)
' boxaEqual(boxa1, boxa2, maxdist, pnaindex, psame) as Integer
' boxaEqual(BOXA *, BOXA *, l_int32, NUMA **, l_int32 *) as l_ok
'''  <summary>
''' (1) The two boxa are the "same" if they contain the same
'''boxes and each box is within %maxdist of its counterpart
'''in their positions within the boxa.  This allows for
'''small rearrangements.  Use 0 for maxdist if the boxa
'''must be identical.<para/>
'''
'''(2) This applies only to geometry and ordering refcounts
'''are not considered.<para/>
'''
'''(3) %maxdist allows some latitude in the ordering of the boxes.
'''For the boxa to be the "same", corresponding boxes must
'''be within %maxdist of each other.  Note that for large
'''%maxdist, we should use a hash function for efficiency.<para/>
'''
'''(4) naindex[i] gives the position of the box in boxa2 that
'''corresponds to box i in boxa1.  It is only returned if the
'''boxa are equal.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaEqual/*"/>
'''  <param name="boxa1">[in] - </param>
'''  <param name="boxa2">[in] - </param>
'''  <param name="maxdist">[in] - </param>
'''  <param name="pnaindex">[out][optional] - index array of correspondences</param>
'''  <param name="psame">[out] - (1 if equal 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaEqual(
				ByVal boxa1 as Boxa, 
				ByVal boxa2 as Boxa, 
				ByVal maxdist as Integer, 
				<Out()>  ByRef pnaindex as Numa, 
				<Out()>  ByRef psame as Integer) as Integer


if IsNothing (boxa1) then Throw New ArgumentNullException  ("boxa1 cannot be Nothing")
		if IsNothing (boxa2) then Throw New ArgumentNullException  ("boxa2 cannot be Nothing")
	Dim pnaindexPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.boxaEqual(boxa1.Pointer, boxa2.Pointer,   maxdist, pnaindexPtr,   psame)
	
	if pnaindexPtr = IntPtr.Zero then pnaindex = Nothing else pnaindex = new Numa(pnaindexPtr)
	return _Result
End Function

' boxfunc1.c (2183, 1)
' boxSimilar(box1, box2, leftdiff, rightdiff, topdiff, botdiff, psimilar) as Integer
' boxSimilar(BOX *, BOX *, l_int32, l_int32, l_int32, l_int32, l_int32 *) as l_ok
'''  <summary>
''' (1) The values of leftdiff (etc) are the maximum allowed deviations
'''between the locations of the left (etc) sides.  If any side
'''pairs differ by more than this amount, the boxes are not similar.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxSimilar/*"/>
'''  <param name="box1">[in] - </param>
'''  <param name="box2">[in] - </param>
'''  <param name="leftdiff">[in] - </param>
'''  <param name="rightdiff">[in] - </param>
'''  <param name="topdiff">[in] - </param>
'''  <param name="botdiff">[in] - </param>
'''  <param name="psimilar">[out] - 1 if similar 0 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxSimilar(
				ByVal box1 as Box, 
				ByVal box2 as Box, 
				ByVal leftdiff as Integer, 
				ByVal rightdiff as Integer, 
				ByVal topdiff as Integer, 
				ByVal botdiff as Integer, 
				<Out()>  ByRef psimilar as Integer) as Integer


if IsNothing (box1) then Throw New ArgumentNullException  ("box1 cannot be Nothing")
		if IsNothing (box2) then Throw New ArgumentNullException  ("box2 cannot be Nothing")
	Dim _Result as Integer = Natives.boxSimilar(box1.Pointer, box2.Pointer,   leftdiff,   rightdiff,   topdiff,   botdiff,   psimilar)
	
	return _Result
End Function

' boxfunc1.c (2238, 1)
' boxaSimilar(boxa1, boxa2, leftdiff, rightdiff, topdiff, botdiff, debug, psimilar, pnasim) as Integer
' boxaSimilar(BOXA *, BOXA *, l_int32, l_int32, l_int32, l_int32, l_int32, l_int32 *, NUMA **) as l_ok
'''  <summary>
''' (1) See boxSimilar() for parameter usage.<para/>
'''
'''(2) Corresponding boxes are taken in order in the two boxa.<para/>
'''
'''(3) %nasim is an indicator array with a (0/1) for each box pair.<para/>
'''
'''(4) With %nasim or debug == 1, boxes continue to be tested
'''after failure.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaSimilar/*"/>
'''  <param name="boxa1">[in] - </param>
'''  <param name="boxa2">[in] - </param>
'''  <param name="leftdiff">[in] - </param>
'''  <param name="rightdiff">[in] - </param>
'''  <param name="topdiff">[in] - </param>
'''  <param name="botdiff">[in] - </param>
'''  <param name="debug">[in] - output details of non-similar boxes</param>
'''  <param name="psimilar">[out] - 1 if similar 0 otherwise</param>
'''  <param name="pnasim">[out][optional] - na containing 1 if similar else 0</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaSimilar(
				ByVal boxa1 as Boxa, 
				ByVal boxa2 as Boxa, 
				ByVal leftdiff as Integer, 
				ByVal rightdiff as Integer, 
				ByVal topdiff as Integer, 
				ByVal botdiff as Integer, 
				ByVal debug as Enumerations.DebugOnOff, 
				<Out()>  ByRef psimilar as Integer, 
				<Out()> Optional  ByRef pnasim as Numa = Nothing) as Integer


if IsNothing (boxa1) then Throw New ArgumentNullException  ("boxa1 cannot be Nothing")
		if IsNothing (boxa2) then Throw New ArgumentNullException  ("boxa2 cannot be Nothing")
	Dim pnasimPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.boxaSimilar(boxa1.Pointer, boxa2.Pointer,   leftdiff,   rightdiff,   topdiff,   botdiff,   debug,   psimilar, pnasimPtr)
	
	if pnasimPtr = IntPtr.Zero then pnasim = Nothing else pnasim = new Numa(pnasimPtr)
	return _Result
End Function

' boxfunc1.c (2312, 1)
' boxaJoin(boxad, boxas, istart, iend) as Integer
' boxaJoin(BOXA *, BOXA *, l_int32, l_int32) as l_ok
'''  <summary>
''' (1) This appends a clone of each indicated box in boxas to boxad<para/>
'''
'''(2) istart  is smaller 0 is taken to mean 'read from the start' (istart = 0)<para/>
'''
'''(3) iend  is smaller 0 means 'read to the end'<para/>
'''
'''(4) if boxas == NULL or has no boxes, this is a no-op.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaJoin/*"/>
'''  <param name="boxad">[in] - dest boxa add to this one</param>
'''  <param name="boxas">[in] - source boxa add from this one</param>
'''  <param name="istart">[in] - starting index in boxas</param>
'''  <param name="iend">[in] - ending index in boxas use -1 to cat all</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaJoin(
				ByVal boxad as Boxa, 
				ByVal boxas as Boxa, 
				ByVal istart as Integer, 
				ByVal iend as Integer) as Integer


if IsNothing (boxad) then Throw New ArgumentNullException  ("boxad cannot be Nothing")
		if IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	Dim _Result as Integer = Natives.boxaJoin(boxad.Pointer, boxas.Pointer,   istart,   iend)
	
	return _Result
End Function

' boxfunc1.c (2361, 1)
' boxaaJoin(baad, baas, istart, iend) as Integer
' boxaaJoin(BOXAA *, BOXAA *, l_int32, l_int32) as l_ok
'''  <summary>
''' (1) This appends a clone of each indicated boxa in baas to baad<para/>
'''
'''(2) istart  is smaller 0 is taken to mean 'read from the start' (istart = 0)<para/>
'''
'''(3) iend  is smaller 0 means 'read to the end'<para/>
'''
'''(4) if baas == NULL, this is a no-op.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaaJoin/*"/>
'''  <param name="baad">[in] - dest boxaa add to this one</param>
'''  <param name="baas">[in] - source boxaa add from this one</param>
'''  <param name="istart">[in] - starting index in baas</param>
'''  <param name="iend">[in] - ending index in baas use -1 to cat all</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaaJoin(
				ByVal baad as Boxaa, 
				ByVal baas as Boxaa, 
				ByVal istart as Integer, 
				ByVal iend as Integer) as Integer


if IsNothing (baad) then Throw New ArgumentNullException  ("baad cannot be Nothing")
		if IsNothing (baas) then Throw New ArgumentNullException  ("baas cannot be Nothing")
	Dim _Result as Integer = Natives.boxaaJoin(baad.Pointer, baas.Pointer,   istart,   iend)
	
	return _Result
End Function

' boxfunc1.c (2411, 1)
' boxaSplitEvenOdd(boxa, fillflag, pboxae, pboxao) as Integer
' boxaSplitEvenOdd(BOXA *, l_int32, BOXA **, BOXA **) as l_ok
'''  <summary>
''' (1) If %fillflag == 1, boxae has copies of the even boxes
'''in their original location, and nvalid boxes are placed
'''in the odd array locations.  And v.v.<para/>
'''
'''(2) If %fillflag == 0, boxae has only copies of the even boxes.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaSplitEvenOdd/*"/>
'''  <param name="boxa">[in] - </param>
'''  <param name="fillflag">[in] - 1 to put invalid boxes in place 0 to omit</param>
'''  <param name="pboxae">[out] - save even and odd boxes in their separate boxa, setting the other type to invalid boxes.</param>
'''  <param name="pboxao">[out] - save even and odd boxes in their separate boxa, setting the other type to invalid boxes.</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function boxaSplitEvenOdd(
				ByVal boxa as Boxa, 
				ByVal fillflag as Integer, 
				<Out()>  ByRef pboxae as Boxa, 
				<Out()>  ByRef pboxao as Boxa) as Integer


if IsNothing (boxa) then Throw New ArgumentNullException  ("boxa cannot be Nothing")
	Dim pboxaePtr as IntPtr = IntPtr.Zero
	Dim pboxaoPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.boxaSplitEvenOdd(boxa.Pointer,   fillflag, pboxaePtr, pboxaoPtr)
	
	if pboxaePtr = IntPtr.Zero then pboxae = Nothing else pboxae = new Boxa(pboxaePtr)
	if pboxaoPtr = IntPtr.Zero then pboxao = Nothing else pboxao = new Boxa(pboxaoPtr)
	return _Result
End Function

' boxfunc1.c (2475, 1)
' boxaMergeEvenOdd(boxae, boxao, fillflag) as Boxa
' boxaMergeEvenOdd(BOXA *, BOXA *, l_int32) as BOXA *
'''  <summary>
''' (1) This is essentially the inverse of boxaSplitEvenOdd().
'''Typically, boxae and boxao were generated by boxaSplitEvenOdd(),
'''and the value of %fillflag needs to be the same in both calls.<para/>
'''
'''(2) If %fillflag == 1, both boxae and boxao are of the same size
'''otherwise boxae may have one more box than boxao.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/boxaMergeEvenOdd/*"/>
'''  <param name="boxae">[in] - boxes to go in even positions in merged boxa</param>
'''  <param name="boxao">[in] - boxes to go in odd positions in merged boxa</param>
'''  <param name="fillflag">[in] - 1 if there are invalid boxes in placeholders</param>
'''   <returns>boxad merged, or NULL on error</returns>
Public Shared Function boxaMergeEvenOdd(
				ByVal boxae as Boxa, 
				ByVal boxao as Boxa, 
				ByVal fillflag as Integer) as Boxa


if IsNothing (boxae) then Throw New ArgumentNullException  ("boxae cannot be Nothing")
		if IsNothing (boxao) then Throw New ArgumentNullException  ("boxao cannot be Nothing")
	Dim _Result as IntPtr = Natives.boxaMergeEvenOdd(boxae.Pointer, boxao.Pointer,   fillflag)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Boxa(_Result)
End Function

End Class



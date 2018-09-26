Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\recogident.c (158, 1)
' recogIdentifyMultiple()
' recogIdentifyMultiple(L_RECOG *, PIX *, l_int32, l_int32, BOXA **, PIXA **, PIX **, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This filters the input pixa and calls recogIdentifyPixa()
''' (2) Splitting is relatively slow, because it tries to match all
''' character templates to all locations.  This step can be skipped.
''' (3) An attempt is made to order the (optionally) returned images
''' and boxes in 2-dimensional sorted order.  These can then
''' be used to aggregate identified characters into numbers or words.
''' One typically wants the pixa, which contains a boxa of the
''' extracted subimages.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - with training finished</param>
'''  <param name="pixs">[in] - containing typically a small number of characters</param>
'''  <param name="minh">[in] - remove shorter components; use 0 for default</param>
'''  <param name="skipsplit">[in] - 1 to skip the splitting step</param>
'''  <param name="pboxa">[out][optional] - locations of identified components</param>
'''  <param name="ppixa">[out][optional] - images of identified components</param>
'''  <param name="ppixdb">[out][optional] - debug pix inputs and best fits</param>
'''  <param name="debugsplit">[in] - 1 returns pix split debugging images</param>
'''   <returns>0 if OK; 1 if nothing is found; 2 for other errors.</returns>
Public Shared Function recogIdentifyMultiple(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				ByVal minh as Integer, 
				ByVal skipsplit as Integer, 
				ByVal debugsplit as Integer, 
				Optional ByRef pboxa as Boxa = Nothing, 
				Optional ByRef ppixa as Pixa = Nothing, 
				Optional ByRef ppixdb as Pix = Nothing) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

Dim pboxaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxa) Then pboxaPTR = pboxa.Pointer
Dim ppixaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixa) Then ppixaPTR = ppixa.Pointer
Dim ppixdbPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixdb) Then ppixdbPTR = ppixdb.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogIdentifyMultiple( recog.Pointer, pixs.Pointer, minh, skipsplit, pboxaPTR, ppixaPTR, ppixdbPTR, debugsplit)
	if pboxaPTR <> IntPtr.Zero then pboxa = new Boxa(pboxaPTR)
	if ppixaPTR <> IntPtr.Zero then ppixa = new Pixa(ppixaPTR)
	if ppixdbPTR <> IntPtr.Zero then ppixdb = new Pix(ppixdbPTR)

	Return _Result
End Function

' SRC\recogident.c (246, 1)
' recogSplitIntoCharacters()
' recogSplitIntoCharacters(L_RECOG *, PIX *, l_int32, l_int32, BOXA **, PIXA **, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This can be given an image that has an arbitrary number
''' of text characters.  It optionally splits connected
''' components based on document image decoding in recogDecode().
''' The returned pixa includes the boxes from which the
''' (possibly split) components are extracted.
''' (2) After noise filtering, the resulting components are put in
''' row-major (2D) order, and the smaller of overlapping
''' components are removed if they satisfy conditions of
''' relative size and fractional overlap.
''' (3) Note that the splitting function uses unscaled templates
''' and does not bother returning the class results and scores.
''' These are more accurately found later using the scaled templates.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - </param>
'''  <param name="pixs">[in] - 1 bpp, contains only mostly deskewed text</param>
'''  <param name="minh">[in] - remove shorter components; use 0 for default</param>
'''  <param name="skipsplit">[in] - 1 to skip the splitting step</param>
'''  <param name="pboxa">[out] - character bounding boxes</param>
'''  <param name="ppixa">[out] - character images</param>
'''  <param name="debug">[in] - 1 for results written to pixadb_split</param>
'''   <returns>0 if OK, 1 on error or if no components are returned</returns>
Public Shared Function recogSplitIntoCharacters(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				ByVal minh as Integer, 
				ByVal skipsplit as Integer, 
				ByRef pboxa as Boxa, 
				ByRef ppixa as Pixa, 
				Optional ByVal debug as DebugOnOff = DebugOnOff.DebugOn) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim pboxaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxa) Then pboxaPTR = pboxa.Pointer
	Dim ppixaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixa) Then ppixaPTR = ppixa.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogSplitIntoCharacters( recog.Pointer, pixs.Pointer, minh, skipsplit, pboxaPTR, ppixaPTR, debug)
	if pboxaPTR <> IntPtr.Zero then pboxa = new Boxa(pboxaPTR)
	if ppixaPTR <> IntPtr.Zero then ppixa = new Pixa(ppixaPTR)

	Return _Result
End Function

' SRC\recogident.c (401, 1)
' recogCorrelationBestRow()
' recogCorrelationBestRow(L_RECOG *, PIX *, BOXA **, NUMA **, NUMA **, SARRAY **, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) Supervises character matching for (in general) a c.c with
''' multiple touching characters.  Finds the best match greedily.
''' Rejects small parts that are left over after splitting.
''' (2) Matching is to the average, and without character scaling.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - with LUT's pre-computed</param>
'''  <param name="pixs">[in] - typically of multiple touching characters, 1 bpp</param>
'''  <param name="pboxa">[out] - bounding boxs of best fit character</param>
'''  <param name="pnascore">[out][optional] - correlation scores</param>
'''  <param name="pnaindex">[out][optional] - indices of classes</param>
'''  <param name="psachar">[out][optional] - array of character strings</param>
'''  <param name="debug">[in] - 1 for results written to pixadb_split</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function recogCorrelationBestRow(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				ByRef pboxa as Boxa, 
				Optional ByRef pnascore as Numa = Nothing, 
				Optional ByRef pnaindex as Numa = Nothing, 
				Optional ByRef psachar as Sarray = Nothing, 
				Optional ByVal debug as DebugOnOff = DebugOnOff.DebugOn) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim pboxaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pboxa) Then pboxaPTR = pboxa.Pointer
Dim pnascorePTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnascore) Then pnascorePTR = pnascore.Pointer
Dim pnaindexPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaindex) Then pnaindexPTR = pnaindex.Pointer
Dim psacharPTR As IntPtr = IntPtr.Zero : If Not IsNothing(psachar) Then psacharPTR = psachar.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogCorrelationBestRow( recog.Pointer, pixs.Pointer, pboxaPTR, pnascorePTR, pnaindexPTR, psacharPTR, debug)
	if pboxaPTR <> IntPtr.Zero then pboxa = new Boxa(pboxaPTR)
	if pnascorePTR <> IntPtr.Zero then pnascore = new Numa(pnascorePTR)
	if pnaindexPTR <> IntPtr.Zero then pnaindex = new Numa(pnaindexPTR)
	if psacharPTR <> IntPtr.Zero then psachar = new Sarray(psacharPTR)

	Return _Result
End Function

' SRC\recogident.c (583, 1)
' recogCorrelationBestChar()
' recogCorrelationBestChar(L_RECOG *, PIX *, BOX **, l_float32 *, l_int32 *, char **, PIX **) as l_ok
'''  <summary>
''' Notes
''' (1) Basic matching character splitter.  Finds the best match among
''' all templates to some region of the image.  This can result
''' in splitting the image into two parts.  This is "image decoding"
''' without dynamic programming, because we don't use a setwidth
''' and compute the best matching score for the entire image.
''' (2) Matching is to the average templates, without character scaling.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - with LUT's pre-computed</param>
'''  <param name="pixs">[in] - can be of multiple touching characters, 1 bpp</param>
'''  <param name="pbox">[out] - bounding box of best fit character</param>
'''  <param name="pscore">[out] - correlation score</param>
'''  <param name="pindex">[out][optional] - index of class</param>
'''  <param name="pcharstr">[out][optional] - character string of class</param>
'''  <param name="ppixdb">[out][optional] - debug pix showing input and best fit</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function recogCorrelationBestChar(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				ByRef pbox as Box, 
				ByRef pscore as Single(), 
				Optional ByRef pindex as Integer = Nothing, 
				Optional ByRef pcharstr as String() = Nothing, 
				Optional ByRef ppixdb as Pix = Nothing) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

	Dim pboxPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pbox) Then pboxPTR = pbox.Pointer
Dim pcharstrPTR As IntPtr = pcharstrPTR = Marshal.AllocHGlobal(Marshal.sizeOf(pcharstr.toArray))
Dim ppixdbPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixdb) Then ppixdbPTR = ppixdb.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogCorrelationBestChar( recog.Pointer, pixs.Pointer, pboxPTR, pscore, pindex, pcharstrPTR, ppixdbPTR)
	if pboxPTR <> IntPtr.Zero then pbox = new Box(pboxPTR)
	if ppixdbPTR <> IntPtr.Zero then ppixdb = new Pix(ppixdbPTR)

	Return _Result
End Function

' SRC\recogident.c (878, 1)
' recogIdentifyPixa()
' recogIdentifyPixa(L_RECOG *, PIXA *, PIX **) as l_ok
'''  <summary>
''' Notes
''' (1) This should be called by recogIdentifyMuliple(), which
''' binarizes and splits characters before sending %pixa here.
''' (2) This calls recogIdentifyPix(), which does the same operation
''' on each pix in %pixa, and optionally returns the arrays
''' of results (scores, class index and character string)
''' for the best correlation match.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - </param>
'''  <param name="pixa">[in] - of 1 bpp images to match</param>
'''  <param name="ppixdb">[out][optional] - pix showing inputs and best fits</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function recogIdentifyPixa(
				ByVal recog as L_Recog, 
				ByVal pixa as Pixa, 
				Optional ByRef ppixdb as Pix = Nothing) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")

Dim ppixdbPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixdb) Then ppixdbPTR = ppixdb.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogIdentifyPixa( recog.Pointer, pixa.Pointer, ppixdbPTR)
	if ppixdbPTR <> IntPtr.Zero then ppixdb = new Pix(ppixdbPTR)

	Return _Result
End Function

' SRC\recogident.c (971, 1)
' recogIdentifyPix()
' recogIdentifyPix(L_RECOG *, PIX *, PIX **) as l_ok
'''  <summary>
''' Notes
''' (1) Basic recognition function for a single character.
''' (2) If templ_use == L_USE_ALL_TEMPLATES, which is the default
''' situation, matching is attempted to every bitmap in the recog,
''' and the identify of the best match is returned.
''' (3) For finding outliers, templ_use == L_USE_AVERAGE_TEMPLATES, and
''' matching is only attemplted to the averaged bitmaps.  For this
''' case, the index of the bestsample is meaningless (0 is returned
''' if requested).
''' (4) The score is related to the confidence (probability of correct
''' identification), in that a higher score is correlated with
''' a higher probability.  However, the actual relation between
''' the correlation (score) and the probability is not known;
''' we call this a "score" because "confidence" can be misinterpreted
''' as an actual probability.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - with LUT's pre-computed</param>
'''  <param name="pixs">[in] - of a single character, 1 bpp</param>
'''  <param name="ppixdb">[out][optional] - debug pix showing input and best fit</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function recogIdentifyPix(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				Optional ByRef ppixdb as Pix = Nothing) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")

Dim ppixdbPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixdb) Then ppixdbPTR = ppixdb.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.recogIdentifyPix( recog.Pointer, pixs.Pointer, ppixdbPTR)
	if ppixdbPTR <> IntPtr.Zero then ppixdb = new Pix(ppixdbPTR)

	Return _Result
End Function

' SRC\recogident.c (1120, 1)
' recogSkipIdentify()
' recogSkipIdentify(L_RECOG *) as l_ok
'''  <summary>
''' Notes
''' (1) This just writes a "dummy" result with 0 score and empty
''' string id into the rch.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function recogSkipIdentify(
				ByVal recog as L_Recog) as Integer

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.recogSkipIdentify( recog.Pointer)

	Return _Result
End Function

' SRC\recogident.c (1168, 1)
' rchaDestroy()
' rchaDestroy(L_RCHA **) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="prcha">[in,out] - to be nulled</param>
Public Shared Sub rchaDestroy(
				ByRef prcha as L_Rcha)


	Dim prchaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(prcha) Then prchaPTR = prcha.Pointer

	LeptonicaSharp.Natives.rchaDestroy( prchaPTR)
	if prchaPTR <> IntPtr.Zero then prcha = new L_Rcha(prchaPTR)

End Sub

' SRC\recogident.c (1242, 1)
' rchDestroy()
' rchDestroy(L_RCH **) as void
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="prch">[in,out] - to be nulled</param>
Public Shared Sub rchDestroy(
				ByRef prch as L_Rch)


	Dim prchPTR As IntPtr = IntPtr.Zero : If Not IsNothing(prch) Then prchPTR = prch.Pointer

	LeptonicaSharp.Natives.rchDestroy( prchPTR)
	if prchPTR <> IntPtr.Zero then prch = new L_Rch(prchPTR)

End Sub

' SRC\recogident.c (1281, 1)
' rchaExtract()
' rchaExtract(L_RCHA *, NUMA **, NUMA **, SARRAY **, NUMA **, NUMA **, NUMA **, NUMA **) as l_ok
'''  <summary>
''' Notes
''' (1) This returns clones of the number and string arrays.  They must
''' be destroyed by the caller.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="rcha">[in] - </param>
'''  <param name="pnaindex">[out][optional] - indices of best templates</param>
'''  <param name="pnascore">[out][optional] - correl scores of best templates</param>
'''  <param name="psatext">[out][optional] - character strings of best templates</param>
'''  <param name="pnasample">[out][optional] - indices of best samples</param>
'''  <param name="pnaxloc">[out][optional] - x-locations of templates</param>
'''  <param name="pnayloc">[out][optional] - y-locations of templates</param>
'''  <param name="pnawidth">[out][optional] - widths of best templates</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function rchaExtract(
				ByVal rcha as L_Rcha, 
				Optional ByRef pnaindex as Numa = Nothing, 
				Optional ByRef pnascore as Numa = Nothing, 
				Optional ByRef psatext as Sarray = Nothing, 
				Optional ByRef pnasample as Numa = Nothing, 
				Optional ByRef pnaxloc as Numa = Nothing, 
				Optional ByRef pnayloc as Numa = Nothing, 
				Optional ByRef pnawidth as Numa = Nothing) as Integer

	If IsNothing (rcha) then Throw New ArgumentNullException  ("rcha cannot be Nothing")

Dim pnaindexPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaindex) Then pnaindexPTR = pnaindex.Pointer
Dim pnascorePTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnascore) Then pnascorePTR = pnascore.Pointer
Dim psatextPTR As IntPtr = IntPtr.Zero : If Not IsNothing(psatext) Then psatextPTR = psatext.Pointer
Dim pnasamplePTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnasample) Then pnasamplePTR = pnasample.Pointer
Dim pnaxlocPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaxloc) Then pnaxlocPTR = pnaxloc.Pointer
Dim pnaylocPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnayloc) Then pnaylocPTR = pnayloc.Pointer
Dim pnawidthPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnawidth) Then pnawidthPTR = pnawidth.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.rchaExtract( rcha.Pointer, pnaindexPTR, pnascorePTR, psatextPTR, pnasamplePTR, pnaxlocPTR, pnaylocPTR, pnawidthPTR)
	if pnaindexPTR <> IntPtr.Zero then pnaindex = new Numa(pnaindexPTR)
	if pnascorePTR <> IntPtr.Zero then pnascore = new Numa(pnascorePTR)
	if psatextPTR <> IntPtr.Zero then psatext = new Sarray(psatextPTR)
	if pnasamplePTR <> IntPtr.Zero then pnasample = new Numa(pnasamplePTR)
	if pnaxlocPTR <> IntPtr.Zero then pnaxloc = new Numa(pnaxlocPTR)
	if pnaylocPTR <> IntPtr.Zero then pnayloc = new Numa(pnaylocPTR)
	if pnawidthPTR <> IntPtr.Zero then pnawidth = new Numa(pnawidthPTR)

	Return _Result
End Function

' SRC\recogident.c (1327, 1)
' rchExtract()
' rchExtract(L_RCH *, l_int32 *, l_float32 *, char **, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="rch">[in] - </param>
'''  <param name="pindex">[out][optional] - index of best template</param>
'''  <param name="pscore">[out][optional] - correlation score of best template</param>
'''  <param name="ptext">[out][optional] - character string of best template</param>
'''  <param name="psample">[out][optional] - index of best sample</param>
'''  <param name="pxloc">[out][optional] - x-location of template</param>
'''  <param name="pyloc">[out][optional] - y-location of template</param>
'''  <param name="pwidth">[out][optional] - width of best template</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function rchExtract(
				ByVal rch as L_Rch, 
				Optional ByRef pindex as Integer = Nothing, 
				Optional ByRef pscore as Single() = Nothing, 
				Optional ByRef ptext as String() = Nothing, 
				Optional ByRef psample as Integer = Nothing, 
				Optional ByRef pxloc as Integer = Nothing, 
				Optional ByRef pyloc as Integer = Nothing, 
				Optional ByRef pwidth as Integer = Nothing) as Integer

	If IsNothing (rch) then Throw New ArgumentNullException  ("rch cannot be Nothing")

Dim ptextPTR As IntPtr = ptextPTR = Marshal.AllocHGlobal(Marshal.sizeOf(ptext.toArray))

	Dim _Result as Integer = LeptonicaSharp.Natives.rchExtract( rch.Pointer, pindex, pscore, ptextPTR, psample, pxloc, pyloc, pwidth)

	Return _Result
End Function

' SRC\recogident.c (1415, 1)
' recogProcessToIdentify()
' recogProcessToIdentify(L_RECOG *, PIX *, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This is a lightweight operation to insure that the input
''' image is 1 bpp, properly cropped, and padded on each side.
''' If bpp GT 1, the image is thresholded.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - with LUT's pre-computed</param>
'''  <param name="pixs">[in] - typ. single character, possibly d GT 1 and uncropped</param>
'''  <param name="pad">[in] - extra pixels added to left and right sides</param>
'''   <returns>pixd 1 bpp, clipped to foreground, or NULL if there are no fg pixels or on error.</returns>
Public Shared Function recogProcessToIdentify(
				ByVal recog as L_Recog, 
				ByVal pixs as Pix, 
				ByVal pad as Integer) as Pix

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.recogProcessToIdentify( recog.Pointer, pixs.Pointer, pad)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\recogident.c (1628, 1)
' recogExtractNumbers()
' recogExtractNumbers(L_RECOG *, BOXA *, l_float32, l_int32, BOXAA **, NUMAA **) as SARRAY *
'''  <summary>
''' Notes
''' (1) This extracts digit data after recogaIdentifyMultiple() or
''' lower-level identification has taken place.
''' (2) Each string in the returned sa contains a sequence of ascii
''' digits in a number.
''' (3) The horizontal distance between boxes (limited by %spacethresh)
''' is the negative of the horizontal overlap.
''' (4) Components with a score less than %scorethresh, which may
''' be hyphens or other small characters, will signal the
''' end of the current sequence of digits in the number.  A typical
''' value for %scorethresh is 0.60.
''' (5) We allow two digits to be combined if these conditions apply
''' (a) the first is to the left of the second
''' (b) the second has a horizontal separation less than %spacethresh
''' (c) the vertical overlap GT= 0 (vertical separation LT 0)
''' (d) both have a score that exceeds %scorethresh
''' (6) Each numa in the optionally returned naa contains the digit
''' scores of a number.  Each boxa in the optionally returned baa
''' contains the bounding boxes of the digits in the number.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="recog">[in] - </param>
'''  <param name="boxas">[in] - location of components</param>
'''  <param name="scorethresh">[in] - min score for which we accept a component</param>
'''  <param name="spacethresh">[in] - max horizontal distance allowed between digits, use -1 for default</param>
'''  <param name="pbaa">[out][optional] - bounding boxes of identified numbers</param>
'''  <param name="pnaa">[out][optional] - scores of identified digits</param>
'''   <returns>sa of identified numbers, or NULL on error</returns>
Public Shared Function recogExtractNumbers(
				ByVal recog as L_Recog, 
				ByVal boxas as Boxa, 
				ByVal scorethresh as Single, 
				ByVal spacethresh as Integer, 
				Optional ByRef pbaa as Boxaa = Nothing, 
				Optional ByRef pnaa as Numaa = Nothing) as Sarray

	If IsNothing (recog) then Throw New ArgumentNullException  ("recog cannot be Nothing")
	If IsNothing (boxas) then Throw New ArgumentNullException  ("boxas cannot be Nothing")
	If IsNothing (scorethresh) then Throw New ArgumentNullException  ("scorethresh cannot be Nothing")

Dim pbaaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pbaa) Then pbaaPTR = pbaa.Pointer
Dim pnaaPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pnaa) Then pnaaPTR = pnaa.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.recogExtractNumbers( recog.Pointer, boxas.Pointer, scorethresh, spacethresh, pbaaPTR, pnaaPTR)
	If  _Result = IntPtr.Zero then Return Nothing
	if pbaaPTR <> IntPtr.Zero then pbaa = new Boxaa(pbaaPTR)
	if pnaaPTR <> IntPtr.Zero then pnaa = new Numaa(pnaaPTR)

	Return  new Sarray(_Result)
End Function

' SRC\recogident.c (1761, 1)
' showExtractNumbers()
' showExtractNumbers(PIX *, SARRAY *, BOXAA *, NUMAA *, PIX **) as PIXA *
'''  <summary>
''' Notes
''' (1) This is a debugging routine on digit identification; e.g.
''' recogIdentifyMultiple(recog, pixs, 0, 1, boxa, NULL, NULL, 0);
''' sa = recogExtractNumbers(recog, boxa, 0.8, -1, baa, naa);
''' pixa = showExtractNumbers(pixs, sa, baa, naa, NULL);
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input 1 bpp image</param>
'''  <param name="sa">[in] - recognized text strings</param>
'''  <param name="baa">[in] - boxa array for location of characters in each string</param>
'''  <param name="naa">[in] - numa array for scores of characters in each string</param>
'''  <param name="ppixdb">[out][optional] - input pixs with identified chars outlined</param>
'''   <returns>pixa   of identified strings with text and scores, or NULL on error</returns>
Public Shared Function showExtractNumbers(
				ByVal pixs as Pix, 
				ByVal sa as Sarray, 
				ByVal baa as Boxaa, 
				ByVal naa as Numaa, 
				Optional ByRef ppixdb as Pix = Nothing) as Pixa

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")
	If IsNothing (baa) then Throw New ArgumentNullException  ("baa cannot be Nothing")
	If IsNothing (naa) then Throw New ArgumentNullException  ("naa cannot be Nothing")

Dim ppixdbPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ppixdb) Then ppixdbPTR = ppixdb.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.showExtractNumbers( pixs.Pointer, sa.Pointer, baa.Pointer, naa.Pointer, ppixdbPTR)
	If  _Result = IntPtr.Zero then Return Nothing
	if ppixdbPTR <> IntPtr.Zero then ppixdb = new Pix(ppixdbPTR)

	Return  new Pixa(_Result)
End Function

End Class

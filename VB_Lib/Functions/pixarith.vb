Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' pixarith.c (115, 1)
' pixAddConstantGray(pixs, val) as Integer
' pixAddConstantGray(PIX *, l_int32) as l_ok
'''  <summary>
''' (1) In-place operation.<para/>
'''
'''(2) No clipping for 32 bpp.<para/>
'''
'''(3) For 8 and 16 bpp, if val  is greater  0 the result is clipped
'''to 0xff and 0xffff, rsp.<para/>
'''
'''(4) For 8 and 16 bpp, if val  is smaller 0 the result is clipped to 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixAddConstantGray/*"/>
'''  <param name="pixs">[in] - 8, 16 or 32 bpp</param>
'''  <param name="val">[in] - amount to add to each pixel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixAddConstantGray(
				ByVal pixs as Pix, 
				ByVal val as Integer) as Integer


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as Integer = Natives.pixAddConstantGray(pixs.Pointer,   val)
	
	return _Result
End Function

' pixarith.c (186, 1)
' pixMultConstantGray(pixs, val) as Integer
' pixMultConstantGray(PIX *, l_float32) as l_ok
'''  <summary>
''' (1) In-place operation val must be greater or equal 0.<para/>
'''
'''(2) No clipping for 32 bpp.<para/>
'''
'''(3) For 8 and 16 bpp, the result is clipped to 0xff and 0xffff, rsp.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixMultConstantGray/*"/>
'''  <param name="pixs">[in] - 8, 16 or 32 bpp</param>
'''  <param name="val">[in] - greater or equal 0.0 amount to multiply by each pixel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixMultConstantGray(
				ByVal pixs as Pix, 
				ByVal val as Single) as Integer


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as Integer = Natives.pixMultConstantGray(pixs.Pointer,   val)
	
	return _Result
End Function

' pixarith.c (261, 1)
' pixAddGray(pixd, pixs1, pixs2) as Pix
' pixAddGray(PIX *, PIX *, PIX *) as PIX *
'''  <summary>
''' (1) Arithmetic addition of two 8, 16 or 32 bpp images.<para/>
'''
'''(2) For 8 and 16 bpp, we do explicit clipping to 0xff and 0xffff,
'''respectively.<para/>
'''
'''(3) Alignment is to UL corner.<para/>
'''
'''(4) There are 3 cases.  The result can go to a new dest,
'''in-place to pixs1, or to an existing input dest:
'''pixd == null: (src1 + src2) to new pixd
'''pixd == pixs1:  (src1 + src2) to src1  (in-place)
'''pixd != pixs1:  (src1 + src2) to input pixd<para/>
'''
'''(5) pixs2 must be different from both pixd and pixs1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixAddGray/*"/>
'''  <param name="pixd">[in][optional] - this can be null, equal to pixs1, or different from pixs1</param>
'''  <param name="pixs1">[in] - can be == to pixd</param>
'''  <param name="pixs2">[in] - </param>
'''   <returns>pixd always</returns>
Public Shared Function pixAddGray(
				ByVal pixd as Pix, 
				ByVal pixs1 as Pix, 
				ByVal pixs2 as Pix) as Pix


if IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
		if IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")
	Dim pixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(pixd) Then pixdPtr = pixd.Pointer

	Dim _Result as IntPtr = Natives.pixAddGray(pixdPtr, pixs1.Pointer, pixs2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (353, 1)
' pixSubtractGray(pixd, pixs1, pixs2) as Pix
' pixSubtractGray(PIX *, PIX *, PIX *) as PIX *
'''  <summary>
''' (1) Arithmetic subtraction of two 8, 16 or 32 bpp images.<para/>
'''
'''(2) Source pixs2 is always subtracted from source pixs1.<para/>
'''
'''(3) Do explicit clipping to 0.<para/>
'''
'''(4) Alignment is to UL corner.<para/>
'''
'''(5) There are 3 cases.  The result can go to a new dest,
'''in-place to pixs1, or to an existing input dest:
'''(a) pixd == null (src1 - src2) to new pixd
'''(b) pixd == pixs1  (src1 - src2) to src1  (in-place)
'''(d) pixd != pixs1  (src1 - src2) to input pixd<para/>
'''
'''(6) pixs2 must be different from both pixd and pixs1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixSubtractGray/*"/>
'''  <param name="pixd">[in][optional] - this can be null, equal to pixs1, or different from pixs1</param>
'''  <param name="pixs1">[in] - can be == to pixd</param>
'''  <param name="pixs2">[in] - </param>
'''   <returns>pixd always</returns>
Public Shared Function pixSubtractGray(
				ByVal pixd as Pix, 
				ByVal pixs1 as Pix, 
				ByVal pixs2 as Pix) as Pix


if IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
		if IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")
	Dim pixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(pixd) Then pixdPtr = pixd.Pointer

	Dim _Result as IntPtr = Natives.pixSubtractGray(pixdPtr, pixs1.Pointer, pixs2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (442, 1)
' pixThresholdToValue(pixd, pixs, threshval, setval) as Pix
' pixThresholdToValue(PIX *, PIX *, l_int32, l_int32) as PIX *
'''  <summary>
''' ~ operation can be in-place (pixs == pixd) or to a new pixd
'''~ if setval  is greater  threshval, sets pixels with a value greater or equal threshval to setval
'''~ if setval  is smaller threshval, sets pixels with a value smaller or equal threshval to setval
'''~ if setval == threshval, no-op
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixThresholdToValue/*"/>
'''  <param name="pixd">[in][optional] - if not null, must be equal to pixs</param>
'''  <param name="pixs">[in] - 8, 16, 32 bpp</param>
'''  <param name="threshval">[in] - </param>
'''  <param name="setval">[in] - </param>
'''   <returns>pixd always</returns>
Public Shared Function pixThresholdToValue(
				ByVal pixd as Pix, 
				ByVal pixs as Pix, 
				ByVal threshval as Integer, 
				ByVal setval as Integer) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim pixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(pixd) Then pixdPtr = pixd.Pointer

	Dim _Result as IntPtr = Natives.pixThresholdToValue(pixdPtr, pixs.Pointer,   threshval,   setval)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (551, 1)
' pixInitAccumulate(w, h, offset) as Pix
' pixInitAccumulate(l_int32, l_int32, l_uint32) as PIX *
'''  <summary>
''' (1) The offset must be greater or equal 0.<para/>
'''
'''(2) The offset is used so that we can do arithmetic
'''with negative number results on l_uint32 data it
'''prevents the l_uint32 data from going negative.<para/>
'''
'''(3) Because we use l_int32 intermediate data results,
'''these should never exceed the max of l_int32 (0x7fffffff).
'''We do not permit the offset to be above 0x40000000,
'''which is half way between 0 and the max of l_int32.<para/>
'''
'''(4) The same offset should be used for initialization,
'''multiplication by a constant, and final extraction!<para/>
'''
'''(5) If you're only adding positive values, offset can be 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixInitAccumulate/*"/>
'''  <param name="w">[in] - of accumulate array</param>
'''  <param name="h">[in] - of accumulate array</param>
'''  <param name="offset">[in] - initialize the 32 bpp to have this value not more than 0x40000000</param>
'''   <returns>pixd 32 bpp, or NULL on error</returns>
Public Shared Function pixInitAccumulate(
				ByVal w as Integer, 
				ByVal h as Integer, 
				ByVal offset as UInteger) as Pix


	Dim _Result as IntPtr = Natives.pixInitAccumulate(  w,   h,   offset)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (585, 1)
' pixFinalAccumulate(pixs, offset, depth) as Pix
' pixFinalAccumulate(PIX *, l_uint32, l_int32) as PIX *
'''  <summary>
''' (1) The offset must be greater or equal 0 and should not exceed 0x40000000.<para/>
'''
'''(2) The offset is subtracted from the src 32 bpp image<para/>
'''
'''(3) For 8 bpp dest, the result is clipped to [0, 0xff]<para/>
'''
'''(4) For 16 bpp dest, the result is clipped to [0, 0xffff]
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixFinalAccumulate/*"/>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="offset">[in] - same as used for initialization</param>
'''  <param name="depth">[in] - 8, 16 or 32 bpp, of destination</param>
'''   <returns>pixd 8, 16 or 32 bpp, or NULL on error</returns>
Public Shared Function pixFinalAccumulate(
				ByVal pixs as Pix, 
				ByVal offset as UInteger, 
				ByVal depth as Integer) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixFinalAccumulate(pixs.Pointer,   offset,   depth)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (662, 1)
' pixFinalAccumulateThreshold(pixs, offset, threshold) as Pix
' pixFinalAccumulateThreshold(PIX *, l_uint32, l_uint32) as PIX *
'''  <summary>
''' (1) The offset must be greater or equal 0 and should not exceed 0x40000000.<para/>
'''
'''(2) The offset is subtracted from the src 32 bpp image
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixFinalAccumulateThreshold/*"/>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="offset">[in] - same as used for initialization</param>
'''  <param name="threshold">[in] - values less than this are set in the destination</param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function pixFinalAccumulateThreshold(
				ByVal pixs as Pix, 
				ByVal offset as UInteger, 
				ByVal threshold as UInteger) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixFinalAccumulateThreshold(pixs.Pointer,   offset,   threshold)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (719, 1)
' pixAccumulate(pixd, pixs, op) as Integer
' pixAccumulate(PIX *, PIX *, l_int32) as l_ok
'''  <summary>
''' (1) This adds or subtracts each pixs value from pixd.<para/>
'''
'''(2) This clips to the minimum of pixs and pixd, so they
'''do not need to be the same size.<para/>
'''
'''(3) The alignment is to the origin [UL corner] of pixs [and] pixd.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixAccumulate/*"/>
'''  <param name="pixd">[in] - 32 bpp</param>
'''  <param name="pixs">[in] - 1, 8, 16 or 32 bpp</param>
'''  <param name="op">[in] - L_ARITH_ADD or L_ARITH_SUBTRACT</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function pixAccumulate(
				ByVal pixd as Pix, 
				ByVal pixs as Pix, 
				ByVal op as Enumerations.L_arithmetic_logical_operator) as Integer


if IsNothing (pixd) then Throw New ArgumentNullException  ("pixd cannot be Nothing")
		if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as Integer = Natives.pixAccumulate(pixd.Pointer, pixs.Pointer,   op)
	
	return _Result
End Function

' pixarith.c (818, 1)
' pixMultConstAccumulate(pixs, factor, offset) as Integer
' pixMultConstAccumulate(PIX *, l_float32, l_uint32) as l_ok
'''  <summary>
''' (1) The offset must be greater or equal 0 and should not exceed 0x40000000.<para/>
'''
'''(2) This multiplies each pixel, relative to offset, by the input factor<para/>
'''
'''(3) The result is returned with the offset back in place.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixMultConstAccumulate/*"/>
'''  <param name="pixs">[in] - 32 bpp</param>
'''  <param name="factor">[in] - </param>
'''  <param name="offset">[in] - same as used for initialization</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function pixMultConstAccumulate(
				ByVal pixs as Pix, 
				ByVal factor as Single, 
				ByVal offset as UInteger) as Integer


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as Integer = Natives.pixMultConstAccumulate(pixs.Pointer,   factor,   offset)
	
	return _Result
End Function

' pixarith.c (872, 1)
' pixAbsDifference(pixs1, pixs2) as Pix
' pixAbsDifference(PIX *, PIX *) as PIX *
'''  <summary>
''' (1) The depth of pixs1 and pixs2 must be equal.<para/>
'''
'''(2) Clips computation to the min size, aligning the UL corners<para/>
'''
'''(3) For 8 and 16 bpp, assumes one gray component.<para/>
'''
'''(4) For 32 bpp, assumes 3 color components, and ignores the
'''LSB of each word (the alpha channel)<para/>
'''
'''(5) Computes the absolute value of the difference between
'''each component value.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixAbsDifference/*"/>
'''  <param name="pixs1">[in] - both either 8 or 16 bpp gray, or 32 bpp RGB</param>
'''  <param name="pixs2">[in] - both either 8 or 16 bpp gray, or 32 bpp RGB</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixAbsDifference(
				ByVal pixs1 as Pix, 
				ByVal pixs2 as Pix) as Pix


if IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
		if IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixAbsDifference(pixs1.Pointer, pixs2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (969, 1)
' pixAddRGB(pixs1, pixs2) as Pix
' pixAddRGB(PIX *, PIX *) as PIX *
'''  <summary>
''' (1) Clips computation to the minimum size, aligning the UL corners.<para/>
'''
'''(2) Removes any colormap to RGB, and ignores the LSB of each
'''pixel word (the alpha channel).<para/>
'''
'''(3) Adds each component value, pixelwise, clipping to 255.<para/>
'''
'''(4) This is useful to combine two images where most of the
'''pixels are essentially black, such as in pixPerceptualDiff().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixAddRGB/*"/>
'''  <param name="pixs1">[in] - 32 bpp RGB, or colormapped</param>
'''  <param name="pixs2">[in] - 32 bpp RGB, or colormapped</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function pixAddRGB(
				ByVal pixs1 as Pix, 
				ByVal pixs2 as Pix) as Pix


if IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
		if IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixAddRGB(pixs1.Pointer, pixs2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (1054, 1)
' pixMinOrMax(pixd, pixs1, pixs2, type) as Pix
' pixMinOrMax(PIX *, PIX *, PIX *, l_int32) as PIX *
'''  <summary>
''' (1) This gives the min or max of two images, component-wise.<para/>
'''
'''(2) The depth can be 8 or 16 bpp for 1 component, and 32 bpp
'''for a 3 component image.  For 32 bpp, ignore the LSB
'''of each word (the alpha channel)<para/>
'''
'''(3) There are 3 cases:
'''~  if pixd == null, Min(src1, src2) to new pixd
'''~  if pixd == pixs1,  Min(src1, src2) to src1  (in-place)
'''~  if pixd != pixs1,  Min(src1, src2) to input pixd
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixMinOrMax/*"/>
'''  <param name="pixd">[in][optional] - destination: this can be null, equal to pixs1, or different from pixs1</param>
'''  <param name="pixs1">[in] - can be == to pixd</param>
'''  <param name="pixs2">[in] - </param>
'''  <param name="type">[in] - L_CHOOSE_MIN, L_CHOOSE_MAX</param>
'''   <returns>pixd always</returns>
Public Shared Function pixMinOrMax(
				ByVal pixd as Pix, 
				ByVal pixs1 as Pix, 
				ByVal pixs2 as Pix, 
				ByVal type as Enumerations.L_CHOOSE_M) as Pix


if IsNothing (pixs1) then Throw New ArgumentNullException  ("pixs1 cannot be Nothing")
		if IsNothing (pixs2) then Throw New ArgumentNullException  ("pixs2 cannot be Nothing")
	Dim pixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(pixd) Then pixdPtr = pixd.Pointer

	Dim _Result as IntPtr = Natives.pixMinOrMax(pixdPtr, pixs1.Pointer, pixs2.Pointer,   type)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (1155, 1)
' pixMaxDynamicRange(pixs, type) as Pix
' pixMaxDynamicRange(PIX *, l_int32) as PIX *
'''  <summary>
''' (1) Scales pixel values to fit maximally within the dest 8 bpp pixd<para/>
'''
'''(2) Assumes the source 'pixels' are a 1-component scalar.  For
'''a 32 bpp source, each pixel is treated as a single number --
'''not as a 3-component rgb pixel value.<para/>
'''
'''(3) Uses a LUT for log scaling.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixMaxDynamicRange/*"/>
'''  <param name="pixs">[in] - 4, 8, 16 or 32 bpp source</param>
'''  <param name="type">[in] - L_LINEAR_SCALE or L_LOG_SCALE</param>
'''   <returns>pixd 8 bpp, or NULL on error</returns>
Public Shared Function pixMaxDynamicRange(
				ByVal pixs as Pix, 
				ByVal type as Enumerations.L_L_SCALE) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixMaxDynamicRange(pixs.Pointer,   type)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (1343, 1)
' pixMaxDynamicRangeRGB(pixs, type) as Pix
' pixMaxDynamicRangeRGB(PIX *, l_int32) as PIX *
'''  <summary>
''' (1) Scales pixel values to fit maximally within a 32 bpp dest pixd<para/>
'''
'''(2) All color components are scaled with the same factor, based
'''on the maximum r,g or b component in the image.  This should
'''not be used if the 32-bit value is a single number (e.g., a
'''count in a histogram generated by pixMakeHistoHS()).<para/>
'''
'''(3) Uses a LUT for log scaling.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixMaxDynamicRangeRGB/*"/>
'''  <param name="pixs">[in] - 32 bpp rgb source</param>
'''  <param name="type">[in] - L_LINEAR_SCALE or L_LOG_SCALE</param>
'''   <returns>pixd 32 bpp, or NULL on error</returns>
Public Shared Function pixMaxDynamicRangeRGB(
				ByVal pixs as Pix, 
				ByVal type as Enumerations.L_L_SCALE) as Pix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.pixMaxDynamicRangeRGB(pixs.Pointer,   type)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' pixarith.c (1430, 1)
' linearScaleRGBVal(sval, factor) as UInteger
' linearScaleRGBVal(l_uint32, l_float32) as l_uint32
'''  <summary>
''' (1) %factor must be chosen to be not greater than (255 / maxcomp),
'''where maxcomp is the maximum value of the pixel components.
'''Otherwise, the product will overflow a uint8.  In use, factor
'''is the same for all pixels in a pix.<para/>
'''
'''(2) No scaling is performed on the transparency ("A") component.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/linearScaleRGBVal/*"/>
'''  <param name="sval">[in] - 32-bit rgb pixel value</param>
'''  <param name="factor">[in] - multiplication factor on each component</param>
'''   <returns>dval  linearly scaled version of %sval</returns>
Public Shared Function linearScaleRGBVal(
				ByVal sval as UInteger, 
				ByVal factor as Single) as UInteger


	Dim _Result as UInteger = Natives.linearScaleRGBVal(  sval,   factor)
	
	return _Result
End Function

' pixarith.c (1463, 1)
' logScaleRGBVal(sval, tab, factor) as UInteger
' logScaleRGBVal(l_uint32, l_float32 *, l_float32) as l_uint32
'''  <summary>
''' (1) %tab is made with makeLogBase2Tab().<para/>
'''
'''(2) %factor must be chosen to be not greater than
'''255.0 / log[base2](maxcomp), where maxcomp is the maximum
'''value of the pixel components.  Otherwise, the product
'''will overflow a uint8.  In use, factor is the same for
'''all pixels in a pix.<para/>
'''
'''(3) No scaling is performed on the transparency ("A") component.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/logScaleRGBVal/*"/>
'''  <param name="sval">[in] - 32-bit rgb pixel value</param>
'''  <param name="tab">[in] - 256 entry log-base-2 table</param>
'''  <param name="factor">[in] - multiplication factor on each component</param>
'''   <returns>dval  log scaled version of %sval</returns>
Public Shared Function logScaleRGBVal(
				ByVal sval as UInteger, 
				ByVal tab as Single(), 
				ByVal factor as Single) as UInteger


if IsNothing (tab) then Throw New ArgumentNullException  ("tab cannot be Nothing")
	Dim _Result as UInteger = Natives.logScaleRGBVal(  sval,   tab,   factor)
	
	return _Result
End Function

' pixarith.c (1488, 1)
' makeLogBase2Tab() as Single()
' makeLogBase2Tab() as l_float32 *
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/makeLogBase2Tab/*"/>
'''   <returns></returns>
Public Shared Function makeLogBase2Tab() as Single()


	Dim _Result as Single() = Natives.makeLogBase2Tab()
	
	return _Result
End Function

' pixarith.c (1515, 1)
' getLogBase2(val, logtab) as Single
' getLogBase2(l_int32, l_float32 *) as l_float32
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/getLogBase2/*"/>
'''   <returns></returns>
Public Shared Function getLogBase2(
				ByVal val as Integer, 
				ByVal logtab as Single()) as Single


if IsNothing (logtab) then Throw New ArgumentNullException  ("logtab cannot be Nothing")
	Dim _Result as Single = Natives.getLogBase2(  val,   logtab)
	
	return _Result
End Function

End Class



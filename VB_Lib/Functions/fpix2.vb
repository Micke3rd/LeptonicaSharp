Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' fpix2.c (124, 1)
' pixConvertToFPix(pixs, ncomps) as FPix
' pixConvertToFPix(PIX *, l_int32) as FPIX *
'''  <summary>
''' (1) If colormapped, remove to grayscale.<para/>
'''
'''(2) If 32 bpp and %ncomps == 3, this is RGB convert to luminance.
'''In all other cases the src image is treated as having a single
'''component of pixel values.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixConvertToFPix/*"/>
'''  <param name="pixs">[in] - 1, 2, 4, 8, 16 or 32 bpp</param>
'''  <param name="ncomps">[in] - number of components: 3 for RGB, 1 otherwise</param>
'''   <returns>fpix, or NULL on error</returns>
Public Shared Function pixConvertToFPix(
				ByVal pixs as Pix, 
				ByVal ncomps as Integer) as FPix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
If {1,2,4,8,16,32}.contains (pixs.d) = false then Throw New ArgumentException ("1, 2, 4, 8, 16 or 32 bpp")
	Dim _Result as IntPtr = Natives.pixConvertToFPix(pixs.Pointer,   ncomps)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (217, 1)
' pixConvertToDPix(pixs, ncomps) as DPix
' pixConvertToDPix(PIX *, l_int32) as DPIX *
'''  <summary>
''' (1) If colormapped, remove to grayscale.<para/>
'''
'''(2) If 32 bpp and %ncomps == 3, this is RGB convert to luminance.
'''In all other cases the src image is treated as having a single
'''component of pixel values.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixConvertToDPix/*"/>
'''  <param name="pixs">[in] - 1, 2, 4, 8, 16 or 32 bpp</param>
'''  <param name="ncomps">[in] - number of components: 3 for RGB, 1 otherwise</param>
'''   <returns>dpix, or NULL on error</returns>
Public Shared Function pixConvertToDPix(
				ByVal pixs as Pix, 
				ByVal ncomps as Integer) as DPix


if IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
If {1,2,4,8,16,32}.contains (pixs.d) = false then Throw New ArgumentException ("1, 2, 4, 8, 16 or 32 bpp")
	Dim _Result as IntPtr = Natives.pixConvertToDPix(pixs.Pointer,   ncomps)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new DPix(_Result)
End Function

' fpix2.c (318, 1)
' fpixConvertToPix(fpixs, outdepth, negvals, errorflag) as Pix
' fpixConvertToPix(FPIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' (1) Use %outdepth = 0 to programmatically determine the
'''output depth.  If no values are greater than 255,
'''it will set outdepth = 8 otherwise to 16 or 32.<para/>
'''
'''(2) Because we are converting a float to an unsigned int
'''with a specified dynamic range (8, 16 or 32 bits), errors
'''can occur.  If errorflag == TRUE, output the number
'''of values out of range, both negative and positive.<para/>
'''
'''(3) If a pixel value is positive and out of range, clip to
'''the maximum value represented at the outdepth of 8, 16
'''or 32 bits.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixConvertToPix/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="outdepth">[in] - 0, 8, 16 or 32 bpp</param>
'''  <param name="negvals">[in] - L_CLIP_TO_ZERO, L_TAKE_ABSVAL</param>
'''  <param name="errorflag">[in] - 1 to output error stats 0 otherwise</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function fpixConvertToPix(
				ByVal fpixs as FPix, 
				ByVal outdepth as Integer, 
				ByVal negvals as Enumerations.L_hling_negative_values_in_conversion_to_unsigned_int, 
				ByVal errorflag as Integer) as Pix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixConvertToPix(fpixs.Pointer,   outdepth,   negvals,   errorflag)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' fpix2.c (422, 1)
' fpixDisplayMaxDynamicRange(fpixs) as Pix
' fpixDisplayMaxDynamicRange(FPIX *) as PIX *
'''  <summary>
''' fpixDisplayMaxDynamicRange()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixDisplayMaxDynamicRange/*"/>
'''  <param name="fpixs">[in] - </param>
'''   <returns>pixd 8 bpp, or NULL on error</returns>
Public Shared Function fpixDisplayMaxDynamicRange(
				ByVal fpixs as FPix) as Pix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixDisplayMaxDynamicRange(fpixs.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' fpix2.c (479, 1)
' fpixConvertToDPix(fpix) as DPix
' fpixConvertToDPix(FPIX *) as DPIX *
'''  <summary>
''' fpixConvertToDPix()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixConvertToDPix/*"/>
'''  <param name="fpix">[in] - </param>
'''   <returns>dpix, or NULL on error</returns>
Public Shared Function fpixConvertToDPix(
				ByVal fpix as FPix) as DPix


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixConvertToDPix(fpix.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new DPix(_Result)
End Function

' fpix2.c (537, 1)
' dpixConvertToPix(dpixs, outdepth, negvals, errorflag) as Pix
' dpixConvertToPix(DPIX *, l_int32, l_int32, l_int32) as PIX *
'''  <summary>
''' (1) Use %outdepth = 0 to programmatically determine the
'''output depth.  If no values are greater than 255,
'''it will set outdepth = 8 otherwise to 16 or 32.<para/>
'''
'''(2) Because we are converting a float to an unsigned int
'''with a specified dynamic range (8, 16 or 32 bits), errors
'''can occur.  If errorflag == TRUE, output the number
'''of values out of range, both negative and positive.<para/>
'''
'''(3) If a pixel value is positive and out of range, clip to
'''the maximum value represented at the outdepth of 8, 16
'''or 32 bits.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixConvertToPix/*"/>
'''  <param name="dpixs">[in] - </param>
'''  <param name="outdepth">[in] - 0, 8, 16 or 32 bpp</param>
'''  <param name="negvals">[in] - L_CLIP_TO_ZERO, L_TAKE_ABSVAL</param>
'''  <param name="errorflag">[in] - 1 to output error stats 0 otherwise</param>
'''   <returns>pixd, or NULL on error</returns>
Public Shared Function dpixConvertToPix(
				ByVal dpixs as DPix, 
				ByVal outdepth as Integer, 
				ByVal negvals as Enumerations.L_hling_negative_values_in_conversion_to_unsigned_int, 
				ByVal errorflag as Integer) as Pix


if IsNothing (dpixs) then Throw New ArgumentNullException  ("dpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.dpixConvertToPix(dpixs.Pointer,   outdepth,   negvals,   errorflag)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' fpix2.c (641, 1)
' dpixConvertToFPix(dpix) as FPix
' dpixConvertToFPix(DPIX *) as FPIX *
'''  <summary>
''' dpixConvertToFPix()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixConvertToFPix/*"/>
'''  <param name="dpix">[in] - </param>
'''   <returns>fpix, or NULL on error</returns>
Public Shared Function dpixConvertToFPix(
				ByVal dpix as DPix) as FPix


if IsNothing (dpix) then Throw New ArgumentNullException  ("dpix cannot be Nothing")
	Dim _Result as IntPtr = Natives.dpixConvertToFPix(dpix.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (689, 1)
' fpixGetMin(fpix, pminval, pxminloc, pyminloc) as Integer
' fpixGetMin(FPIX *, l_float32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' fpixGetMin()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixGetMin/*"/>
'''  <param name="fpix">[in] - </param>
'''  <param name="pminval">[out][optional] - min value</param>
'''  <param name="pxminloc">[out][optional] - x location of min</param>
'''  <param name="pyminloc">[out][optional] - y location of min</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function fpixGetMin(
				ByVal fpix as FPix, 
				<Out()> Optional  ByRef pminval as Single = 0f, 
				<Out()> Optional  ByRef pxminloc as Integer = 0, 
				<Out()> Optional  ByRef pyminloc as Integer = 0) as Integer


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as Integer = Natives.fpixGetMin(fpix.Pointer,   pminval,   pxminloc,   pyminloc)
	
	return _Result
End Function

' fpix2.c (742, 1)
' fpixGetMax(fpix, pmaxval, pxmaxloc, pymaxloc) as Integer
' fpixGetMax(FPIX *, l_float32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' fpixGetMax()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixGetMax/*"/>
'''  <param name="fpix">[in] - </param>
'''  <param name="pmaxval">[out][optional] - max value</param>
'''  <param name="pxmaxloc">[out][optional] - x location of max</param>
'''  <param name="pymaxloc">[out][optional] - y location of max</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function fpixGetMax(
				ByVal fpix as FPix, 
				<Out()> Optional  ByRef pmaxval as Single = 0f, 
				<Out()> Optional  ByRef pxmaxloc as Integer = 0, 
				<Out()> Optional  ByRef pymaxloc as Integer = 0) as Integer


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as Integer = Natives.fpixGetMax(fpix.Pointer,   pmaxval,   pxmaxloc,   pymaxloc)
	
	return _Result
End Function

' fpix2.c (795, 1)
' dpixGetMin(dpix, pminval, pxminloc, pyminloc) as Integer
' dpixGetMin(DPIX *, l_float64 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' dpixGetMin()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixGetMin/*"/>
'''  <param name="dpix">[in] - </param>
'''  <param name="pminval">[out][optional] - min value</param>
'''  <param name="pxminloc">[out][optional] - x location of min</param>
'''  <param name="pyminloc">[out][optional] - y location of min</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function dpixGetMin(
				ByVal dpix as DPix, 
				<Out()> Optional  ByRef pminval as Double() = nothing, 
				<Out()> Optional  ByRef pxminloc as Integer = 0, 
				<Out()> Optional  ByRef pyminloc as Integer = 0) as Integer


if IsNothing (dpix) then Throw New ArgumentNullException  ("dpix cannot be Nothing")
	Dim _Result as Integer = Natives.dpixGetMin(dpix.Pointer,   pminval,   pxminloc,   pyminloc)
	
	return _Result
End Function

' fpix2.c (848, 1)
' dpixGetMax(dpix, pmaxval, pxmaxloc, pymaxloc) as Integer
' dpixGetMax(DPIX *, l_float64 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' dpixGetMax()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixGetMax/*"/>
'''  <param name="dpix">[in] - </param>
'''  <param name="pmaxval">[out][optional] - max value</param>
'''  <param name="pxmaxloc">[out][optional] - x location of max</param>
'''  <param name="pymaxloc">[out][optional] - y location of max</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function dpixGetMax(
				ByVal dpix as DPix, 
				<Out()> Optional  ByRef pmaxval as Double() = nothing, 
				<Out()> Optional  ByRef pxmaxloc as Integer = 0, 
				<Out()> Optional  ByRef pymaxloc as Integer = 0) as Integer


if IsNothing (dpix) then Throw New ArgumentNullException  ("dpix cannot be Nothing")
	Dim _Result as Integer = Natives.dpixGetMax(dpix.Pointer,   pmaxval,   pxmaxloc,   pymaxloc)
	
	return _Result
End Function

' fpix2.c (915, 1)
' fpixScaleByInteger(fpixs, factor) as FPix
' fpixScaleByInteger(FPIX *, l_int32) as FPIX *
'''  <summary>
''' (1) The width wd of fpixd is related to ws of fpixs by:
'''wd = factor  (ws - 1) + 1 (and ditto for the height)
'''We avoid special-casing boundary pixels in the interpolation
'''by constructing fpixd by inserting (factor - 1) interpolated
'''pixels between each pixel in fpixs.  Then
'''wd = ws + (ws - 1)  (factor - 1)  (same as above)
'''This also has the advantage that if we subsample by %factor,
'''throwing out all the interpolated pixels, we regain the
'''original low resolution fpix.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixScaleByInteger/*"/>
'''  <param name="fpixs">[in] - low resolution, subsampled</param>
'''  <param name="factor">[in] - scaling factor</param>
'''   <returns>fpixd interpolated result, or NULL on error</returns>
Public Shared Function fpixScaleByInteger(
				ByVal fpixs as FPix, 
				ByVal factor as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixScaleByInteger(fpixs.Pointer,   factor)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1007, 1)
' dpixScaleByInteger(dpixs, factor) as DPix
' dpixScaleByInteger(DPIX *, l_int32) as DPIX *
'''  <summary>
''' (1) The width wd of dpixd is related to ws of dpixs by:
'''wd = factor  (ws - 1) + 1 (and ditto for the height)
'''We avoid special-casing boundary pixels in the interpolation
'''by constructing fpixd by inserting (factor - 1) interpolated
'''pixels between each pixel in fpixs.  Then
'''wd = ws + (ws - 1)  (factor - 1)  (same as above)
'''This also has the advantage that if we subsample by %factor,
'''throwing out all the interpolated pixels, we regain the
'''original low resolution dpix.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixScaleByInteger/*"/>
'''  <param name="dpixs">[in] - low resolution, subsampled</param>
'''  <param name="factor">[in] - scaling factor</param>
'''   <returns>dpixd interpolated result, or NULL on error</returns>
Public Shared Function dpixScaleByInteger(
				ByVal dpixs as DPix, 
				ByVal factor as Integer) as DPix


if IsNothing (dpixs) then Throw New ArgumentNullException  ("dpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.dpixScaleByInteger(dpixs.Pointer,   factor)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new DPix(_Result)
End Function

' fpix2.c (1104, 1)
' fpixLinearCombination(fpixd, fpixs1, fpixs2, a, b) as FPix
' fpixLinearCombination(FPIX *, FPIX *, FPIX *, l_float32, l_float32) as FPIX *
'''  <summary>
''' (1) Computes pixelwise linear combination: a  src1 + b  src2<para/>
'''
'''(2) Alignment is to UL corner.<para/>
'''
'''(3) There are 3 cases.  The result can go to a new dest,
'''in-place to fpixs1, or to an existing input dest:
'''fpixd == null: (src1 + src2) to new fpixd
'''fpixd == fpixs1:  (src1 + src2) to src1  (in-place)
'''fpixd != fpixs1: (src1 + src2) to input fpixd<para/>
'''
'''(4) fpixs2 must be different from both fpixd and fpixs1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixLinearCombination/*"/>
'''  <param name="fpixd">[in][optional] - this can be null, equal to fpixs1, or different from fpixs1</param>
'''  <param name="fpixs1">[in] - can be == to fpixd</param>
'''  <param name="fpixs2">[in] - </param>
'''  <param name="a">[in] - multiplication factors on fpixs1 and fpixs2, rsp.</param>
'''  <param name="b">[in] - multiplication factors on fpixs1 and fpixs2, rsp.</param>
'''   <returns>fpixd always</returns>
Public Shared Function fpixLinearCombination(
				ByVal fpixd as FPix, 
				ByVal fpixs1 as FPix, 
				ByVal fpixs2 as FPix, 
				ByVal a as Single, 
				ByVal b as Single) as FPix


if IsNothing (fpixs1) then Throw New ArgumentNullException  ("fpixs1 cannot be Nothing")
		if IsNothing (fpixs2) then Throw New ArgumentNullException  ("fpixs2 cannot be Nothing")
	Dim fpixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(fpixd) Then fpixdPtr = fpixd.Pointer

	Dim _Result as IntPtr = Natives.fpixLinearCombination(fpixdPtr, fpixs1.Pointer, fpixs2.Pointer,   a,   b)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1163, 1)
' fpixAddMultConstant(fpix, addc, multc) as Integer
' fpixAddMultConstant(FPIX *, l_float32, l_float32) as l_ok
'''  <summary>
''' (1) This is an in-place operation.<para/>
'''
'''(2) It can be used to multiply each pixel by a constant,
'''and also to add a constant to each pixel.  Multiplication
'''is done first.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAddMultConstant/*"/>
'''  <param name="fpix">[in] - </param>
'''  <param name="addc">[in] - use 0.0 to skip the operation</param>
'''  <param name="multc">[in] - use 1.0 to skip the operation</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function fpixAddMultConstant(
				ByVal fpix as FPix, 
				ByVal addc as Single, 
				ByVal multc as Single) as Integer


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as Integer = Natives.fpixAddMultConstant(fpix.Pointer,   addc,   multc)
	
	return _Result
End Function

' fpix2.c (1223, 1)
' dpixLinearCombination(dpixd, dpixs1, dpixs2, a, b) as DPix
' dpixLinearCombination(DPIX *, DPIX *, DPIX *, l_float32, l_float32) as DPIX *
'''  <summary>
''' (1) Computes pixelwise linear combination: a  src1 + b  src2<para/>
'''
'''(2) Alignment is to UL corner.<para/>
'''
'''(3) There are 3 cases.  The result can go to a new dest,
'''in-place to dpixs1, or to an existing input dest:
'''dpixd == null: (src1 + src2) to new dpixd
'''dpixd == dpixs1:  (src1 + src2) to src1  (in-place)
'''dpixd != dpixs1: (src1 + src2) to input dpixd<para/>
'''
'''(4) dpixs2 must be different from both dpixd and dpixs1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixLinearCombination/*"/>
'''  <param name="dpixd">[in][optional] - this can be null, equal to dpixs1, or different from dpixs1</param>
'''  <param name="dpixs1">[in] - can be == to dpixd</param>
'''  <param name="dpixs2">[in] - </param>
'''  <param name="a">[in] - multiplication factors on dpixs1 and dpixs2, rsp.</param>
'''  <param name="b">[in] - multiplication factors on dpixs1 and dpixs2, rsp.</param>
'''   <returns>dpixd always</returns>
Public Shared Function dpixLinearCombination(
				ByVal dpixd as DPix, 
				ByVal dpixs1 as DPix, 
				ByVal dpixs2 as DPix, 
				ByVal a as Single, 
				ByVal b as Single) as DPix


if IsNothing (dpixs1) then Throw New ArgumentNullException  ("dpixs1 cannot be Nothing")
		if IsNothing (dpixs2) then Throw New ArgumentNullException  ("dpixs2 cannot be Nothing")
	Dim dpixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(dpixd) Then dpixdPtr = dpixd.Pointer

	Dim _Result as IntPtr = Natives.dpixLinearCombination(dpixdPtr, dpixs1.Pointer, dpixs2.Pointer,   a,   b)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new DPix(_Result)
End Function

' fpix2.c (1282, 1)
' dpixAddMultConstant(dpix, addc, multc) as Integer
' dpixAddMultConstant(DPIX *, l_float64, l_float64) as l_ok
'''  <summary>
''' (1) This is an in-place operation.<para/>
'''
'''(2) It can be used to multiply each pixel by a constant,
'''and also to add a constant to each pixel.  Multiplication
'''is done first.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixAddMultConstant/*"/>
'''  <param name="dpix">[in] - </param>
'''  <param name="addc">[in] - use 0.0 to skip the operation</param>
'''  <param name="multc">[in] - use 1.0 to skip the operation</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function dpixAddMultConstant(
				ByVal dpix as DPix, 
				ByVal addc as Double, 
				ByVal multc as Double) as Integer


if IsNothing (dpix) then Throw New ArgumentNullException  ("dpix cannot be Nothing")
	Dim _Result as Integer = Natives.dpixAddMultConstant(dpix.Pointer,   addc,   multc)
	
	return _Result
End Function

' fpix2.c (1329, 1)
' fpixSetAllArbitrary(fpix, inval) as Integer
' fpixSetAllArbitrary(FPIX *, l_float32) as l_ok
'''  <summary>
''' fpixSetAllArbitrary()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixSetAllArbitrary/*"/>
'''  <param name="fpix">[in] - </param>
'''  <param name="inval">[in] - to set at each pixel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function fpixSetAllArbitrary(
				ByVal fpix as FPix, 
				ByVal inval as Single) as Integer


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as Integer = Natives.fpixSetAllArbitrary(fpix.Pointer,   inval)
	
	return _Result
End Function

' fpix2.c (1360, 1)
' dpixSetAllArbitrary(dpix, inval) as Integer
' dpixSetAllArbitrary(DPIX *, l_float64) as l_ok
'''  <summary>
''' dpixSetAllArbitrary()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/dpixSetAllArbitrary/*"/>
'''  <param name="dpix">[in] - </param>
'''  <param name="inval">[in] - to set at each pixel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function dpixSetAllArbitrary(
				ByVal dpix as DPix, 
				ByVal inval as Double) as Integer


if IsNothing (dpix) then Throw New ArgumentNullException  ("dpix cannot be Nothing")
	Dim _Result as Integer = Natives.dpixSetAllArbitrary(dpix.Pointer,   inval)
	
	return _Result
End Function

' fpix2.c (1399, 1)
' fpixAddBorder(fpixs, left, right, top, bot) as FPix
' fpixAddBorder(FPIX *, l_int32, l_int32, l_int32, l_int32) as FPIX *
'''  <summary>
''' (1) Adds border of '0' 32-bit pixels
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAddBorder/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="left">[in] - pixels on each side to be added</param>
'''  <param name="right">[in] - pixels on each side to be added</param>
'''  <param name="top">[in] - pixels on each side to be added</param>
'''  <param name="bot">[in] - pixels on each side to be added</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAddBorder(
				ByVal fpixs as FPix, 
				ByVal left as Integer, 
				ByVal right as Integer, 
				ByVal top as Integer, 
				ByVal bot as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAddBorder(fpixs.Pointer,   left,   right,   top,   bot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1435, 1)
' fpixRemoveBorder(fpixs, left, right, top, bot) as FPix
' fpixRemoveBorder(FPIX *, l_int32, l_int32, l_int32, l_int32) as FPIX *
'''  <summary>
''' fpixRemoveBorder()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixRemoveBorder/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="left">[in] - pixels on each side to be removed</param>
'''  <param name="right">[in] - pixels on each side to be removed</param>
'''  <param name="top">[in] - pixels on each side to be removed</param>
'''  <param name="bot">[in] - pixels on each side to be removed</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixRemoveBorder(
				ByVal fpixs as FPix, 
				ByVal left as Integer, 
				ByVal right as Integer, 
				ByVal top as Integer, 
				ByVal bot as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixRemoveBorder(fpixs.Pointer,   left,   right,   top,   bot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1479, 1)
' fpixAddMirroredBorder(fpixs, left, right, top, bot) as FPix
' fpixAddMirroredBorder(FPIX *, l_int32, l_int32, l_int32, l_int32) as FPIX *
'''  <summary>
''' (1) See pixAddMirroredBorder() for situations of usage.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAddMirroredBorder/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="left">[in] - pixels on each side to be added</param>
'''  <param name="right">[in] - pixels on each side to be added</param>
'''  <param name="top">[in] - pixels on each side to be added</param>
'''  <param name="bot">[in] - pixels on each side to be added</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAddMirroredBorder(
				ByVal fpixs as FPix, 
				ByVal left as Integer, 
				ByVal right as Integer, 
				ByVal top as Integer, 
				ByVal bot as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAddMirroredBorder(fpixs.Pointer,   left,   right,   top,   bot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1526, 1)
' fpixAddContinuedBorder(fpixs, left, right, top, bot) as FPix
' fpixAddContinuedBorder(FPIX *, l_int32, l_int32, l_int32, l_int32) as FPIX *
'''  <summary>
''' (1) This adds pixels on each side whose values are equal to
'''the value on the closest boundary pixel.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAddContinuedBorder/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="left">[in] - pixels on each side to be added</param>
'''  <param name="right">[in] - pixels on each side to be added</param>
'''  <param name="top">[in] - pixels on each side to be added</param>
'''  <param name="bot">[in] - pixels on each side to be added</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAddContinuedBorder(
				ByVal fpixs as FPix, 
				ByVal left as Integer, 
				ByVal right as Integer, 
				ByVal top as Integer, 
				ByVal bot as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAddContinuedBorder(fpixs.Pointer,   left,   right,   top,   bot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1571, 1)
' fpixAddSlopeBorder(fpixs, left, right, top, bot) as FPix
' fpixAddSlopeBorder(FPIX *, l_int32, l_int32, l_int32, l_int32) as FPIX *
'''  <summary>
''' (1) This adds pixels on each side whose values have a normal
'''derivative equal to the normal derivative at the boundary
'''of fpixs.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAddSlopeBorder/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="left">[in] - pixels on each side to be added</param>
'''  <param name="right">[in] - pixels on each side to be added</param>
'''  <param name="top">[in] - pixels on each side to be added</param>
'''  <param name="bot">[in] - pixels on each side to be added</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAddSlopeBorder(
				ByVal fpixs as FPix, 
				ByVal left as Integer, 
				ByVal right as Integer, 
				ByVal top as Integer, 
				ByVal bot as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAddSlopeBorder(fpixs.Pointer,   left,   right,   top,   bot)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1660, 1)
' fpixRasterop(fpixd, dx, dy, dw, dh, fpixs, sx, sy) as Integer
' fpixRasterop(FPIX *, l_int32, l_int32, l_int32, l_int32, FPIX *, l_int32, l_int32) as l_ok
'''  <summary>
''' (1) This is similar in structure to pixRasterop(), except
'''it only allows copying from the source into the destination.
'''For that reason, no op code is necessary.  Additionally,
'''all pixels are 32 bit words (float values), which makes
'''the copy very simple.<para/>
'''
'''(2) Clipping of both src and dest fpix are done automatically.<para/>
'''
'''(3) This allows in-place copying, without checking to see if
'''the result is valid:  use for in-place with caution!
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixRasterop/*"/>
'''  <param name="fpixd">[in] - dest fpix</param>
'''  <param name="dx">[in] - x val of UL corner of dest rectangle</param>
'''  <param name="dy">[in] - y val of UL corner of dest rectangle</param>
'''  <param name="dw">[in] - width of dest rectangle</param>
'''  <param name="dh">[in] - height of dest rectangle</param>
'''  <param name="fpixs">[in] - src fpix</param>
'''  <param name="sx">[in] - x val of UL corner of src rectangle</param>
'''  <param name="sy">[in] - y val of UL corner of src rectangle</param>
'''   <returns>0 if OK 1 on error.</returns>
Public Shared Function fpixRasterop(
				ByVal fpixd as FPix, 
				ByVal dx as Integer, 
				ByVal dy as Integer, 
				ByVal dw as Integer, 
				ByVal dh as Integer, 
				ByVal fpixs as FPix, 
				ByVal sx as Integer, 
				ByVal sy as Integer) as Integer


if IsNothing (fpixd) then Throw New ArgumentNullException  ("fpixd cannot be Nothing")
		if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as Integer = Natives.fpixRasterop(fpixd.Pointer,   dx,   dy,   dw,   dh, fpixs.Pointer,   sx,   sy)
	
	return _Result
End Function

' fpix2.c (1760, 1)
' fpixRotateOrth(fpixs, quads) as FPix
' fpixRotateOrth(FPIX *, l_int32) as FPIX *
'''  <summary>
''' fpixRotateOrth()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixRotateOrth/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="quads">[in] - 0-3 number of 90 degree cw rotations</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixRotateOrth(
				ByVal fpixs as FPix, 
				ByVal quads as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixRotateOrth(fpixs.Pointer,   quads)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1806, 1)
' fpixRotate180(fpixd, fpixs) as FPix
' fpixRotate180(FPIX *, FPIX *) as FPIX *
'''  <summary>
''' (1) This does a 180 rotation of the image about the center,
'''which is equivalent to a left-right flip about a vertical
'''line through the image center, followed by a top-bottom
'''flip about a horizontal line through the image center.<para/>
'''
'''(2) There are 3 cases for input:
'''(a) fpixd == null (creates a new fpixd)
'''(b) fpixd == fpixs (in-place operation)
'''(c) fpixd != fpixs (existing fpixd)<para/>
'''
'''(3) For clarity, use these three patterns, respectively:
'''(a) fpixd = fpixRotate180(NULL, fpixs)
'''(b) fpixRotate180(fpixs, fpixs)
'''(c) fpixRotate180(fpixd, fpixs)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixRotate180/*"/>
'''  <param name="fpixd">[in][optional] - can be null, equal to fpixs, or different from fpixs</param>
'''  <param name="fpixs">[in] - </param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixRotate180(
				ByVal fpixd as FPix, 
				ByVal fpixs as FPix) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim fpixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(fpixd) Then fpixdPtr = fpixd.Pointer

	Dim _Result as IntPtr = Natives.fpixRotate180(fpixdPtr, fpixs.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1839, 1)
' fpixRotate90(fpixs, direction) as FPix
' fpixRotate90(FPIX *, l_int32) as FPIX *
'''  <summary>
''' (1) This does a 90 degree rotation of the image about the center,
'''either cw or ccw, returning a new pix.<para/>
'''
'''(2) The direction must be either 1 (cw) or -1 (ccw).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixRotate90/*"/>
'''  <param name="fpixs">[in] - </param>
'''  <param name="direction">[in] - 1 = clockwise,  -1 = counter-clockwise</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixRotate90(
				ByVal fpixs as FPix, 
				ByVal direction as Integer) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixRotate90(fpixs.Pointer,   direction)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1912, 1)
' fpixFlipLR(fpixd, fpixs) as FPix
' fpixFlipLR(FPIX *, FPIX *) as FPIX *
'''  <summary>
''' (1) This does a left-right flip of the image, which is
'''equivalent to a rotation out of the plane about a
'''vertical line through the image center.<para/>
'''
'''(2) There are 3 cases for input:
'''(a) fpixd == null (creates a new fpixd)
'''(b) fpixd == fpixs (in-place operation)
'''(c) fpixd != fpixs (existing fpixd)<para/>
'''
'''(3) For clarity, use these three patterns, respectively:
'''(a) fpixd = fpixFlipLR(NULL, fpixs)
'''(b) fpixFlipLR(fpixs, fpixs)
'''(c) fpixFlipLR(fpixd, fpixs)<para/>
'''
'''(4) If an existing fpixd is not the same size as fpixs, the
'''image data will be reallocated.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixFlipLR/*"/>
'''  <param name="fpixd">[in][optional] - can be null, equal to fpixs, or different from fpixs</param>
'''  <param name="fpixs">[in] - </param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixFlipLR(
				ByVal fpixd as FPix, 
				ByVal fpixs as FPix) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim fpixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(fpixd) Then fpixdPtr = fpixd.Pointer

	Dim _Result as IntPtr = Natives.fpixFlipLR(fpixdPtr, fpixs.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (1973, 1)
' fpixFlipTB(fpixd, fpixs) as FPix
' fpixFlipTB(FPIX *, FPIX *) as FPIX *
'''  <summary>
''' (1) This does a top-bottom flip of the image, which is
'''equivalent to a rotation out of the plane about a
'''horizontal line through the image center.<para/>
'''
'''(2) There are 3 cases for input:
'''(a) fpixd == null (creates a new fpixd)
'''(b) fpixd == fpixs (in-place operation)
'''(c) fpixd != fpixs (existing fpixd)<para/>
'''
'''(3) For clarity, use these three patterns, respectively:
'''(a) fpixd = fpixFlipTB(NULL, fpixs)
'''(b) fpixFlipTB(fpixs, fpixs)
'''(c) fpixFlipTB(fpixd, fpixs)<para/>
'''
'''(4) If an existing fpixd is not the same size as fpixs, the
'''image data will be reallocated.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixFlipTB/*"/>
'''  <param name="fpixd">[in][optional] - can be null, equal to fpixs, or different from fpixs</param>
'''  <param name="fpixs">[in] - </param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixFlipTB(
				ByVal fpixd as FPix, 
				ByVal fpixs as FPix) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
	Dim fpixdPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(fpixd) Then fpixdPtr = fpixd.Pointer

	Dim _Result as IntPtr = Natives.fpixFlipTB(fpixdPtr, fpixs.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (2035, 1)
' fpixAffinePta(fpixs, ptad, ptas, border, inval) as FPix
' fpixAffinePta(FPIX *, PTA *, PTA *, l_int32, l_float32) as FPIX *
'''  <summary>
''' (1) If %border  is greater  0, all four sides are extended by that distance,
'''and removed after the transformation is finished.  Pixels
'''that would be brought in to the trimmed result from outside
'''the extended region are assigned %inval.  The purpose of
'''extending the image is to avoid such assignments.<para/>
'''
'''(2) On the other hand, you may want to give all pixels that
'''are brought in from outside fpixs a specific value.  In that
'''case, set %border == 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAffinePta/*"/>
'''  <param name="fpixs">[in] - 8 bpp</param>
'''  <param name="ptad">[in] - 4 pts of final coordinate space</param>
'''  <param name="ptas">[in] - 4 pts of initial coordinate space</param>
'''  <param name="border">[in] - size of extension with constant normal derivative</param>
'''  <param name="inval">[in] - value brought in typ. 0</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAffinePta(
				ByVal fpixs as FPix, 
				ByVal ptad as Pta, 
				ByVal ptas as Pta, 
				ByVal border as Integer, 
				ByVal inval as Single) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
		if IsNothing (ptad) then Throw New ArgumentNullException  ("ptad cannot be Nothing")
		if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAffinePta(fpixs.Pointer, ptad.Pointer, ptas.Pointer,   border,   inval)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (2092, 1)
' fpixAffine(fpixs, vc, inval) as FPix
' fpixAffine(FPIX *, l_float32 *, l_float32) as FPIX *
'''  <summary>
''' fpixAffine()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixAffine/*"/>
'''  <param name="fpixs">[in] - 8 bpp</param>
'''  <param name="vc">[in] - vector of 8 coefficients for projective transformation</param>
'''  <param name="inval">[in] - value brought in typ. 0</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixAffine(
				ByVal fpixs as FPix, 
				ByVal vc as Single(), 
				ByVal inval as Single) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
		if IsNothing (vc) then Throw New ArgumentNullException  ("vc cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixAffine(fpixs.Pointer,   vc,   inval)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (2154, 1)
' fpixProjectivePta(fpixs, ptad, ptas, border, inval) as FPix
' fpixProjectivePta(FPIX *, PTA *, PTA *, l_int32, l_float32) as FPIX *
'''  <summary>
''' (1) If %border  is greater  0, all four sides are extended by that distance,
'''and removed after the transformation is finished.  Pixels
'''that would be brought in to the trimmed result from outside
'''the extended region are assigned %inval.  The purpose of
'''extending the image is to avoid such assignments.<para/>
'''
'''(2) On the other hand, you may want to give all pixels that
'''are brought in from outside fpixs a specific value.  In that
'''case, set %border == 0.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixProjectivePta/*"/>
'''  <param name="fpixs">[in] - 8 bpp</param>
'''  <param name="ptad">[in] - 4 pts of final coordinate space</param>
'''  <param name="ptas">[in] - 4 pts of initial coordinate space</param>
'''  <param name="border">[in] - size of extension with constant normal derivative</param>
'''  <param name="inval">[in] - value brought in typ. 0</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixProjectivePta(
				ByVal fpixs as FPix, 
				ByVal ptad as Pta, 
				ByVal ptas as Pta, 
				ByVal border as Integer, 
				ByVal inval as Single) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
		if IsNothing (ptad) then Throw New ArgumentNullException  ("ptad cannot be Nothing")
		if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixProjectivePta(fpixs.Pointer, ptad.Pointer, ptas.Pointer,   border,   inval)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (2211, 1)
' fpixProjective(fpixs, vc, inval) as FPix
' fpixProjective(FPIX *, l_float32 *, l_float32) as FPIX *
'''  <summary>
''' fpixProjective()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixProjective/*"/>
'''  <param name="fpixs">[in] - 8 bpp</param>
'''  <param name="vc">[in] - vector of 8 coefficients for projective transformation</param>
'''  <param name="inval">[in] - value brought in typ. 0</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function fpixProjective(
				ByVal fpixs as FPix, 
				ByVal vc as Single(), 
				ByVal inval as Single) as FPix


if IsNothing (fpixs) then Throw New ArgumentNullException  ("fpixs cannot be Nothing")
		if IsNothing (vc) then Throw New ArgumentNullException  ("vc cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixProjective(fpixs.Pointer,   vc,   inval)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

' fpix2.c (2269, 1)
' linearInterpolatePixelFloat(datas, w, h, x, y, inval, pval) as Integer
' linearInterpolatePixelFloat(l_float32 *, l_int32, l_int32, l_float32, l_float32, l_float32, l_float32 *) as l_ok
'''  <summary>
''' (1) This is a standard linear interpolation function.  It is
'''equivalent to area weighting on each component, and
'''avoids "jaggies" when rendering sharp edges.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/linearInterpolatePixelFloat/*"/>
'''  <param name="datas">[in] - ptr to beginning of float image data</param>
'''  <param name="w">[in] - of image</param>
'''  <param name="h">[in] - of image</param>
'''  <param name="x">[in] - floating pt location for evaluation</param>
'''  <param name="y">[in] - floating pt location for evaluation</param>
'''  <param name="inval">[in] - float value brought in from the outside when the input x,y location is outside the image</param>
'''  <param name="pval">[out] - interpolated float value</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function linearInterpolatePixelFloat(
				ByVal datas as Single(), 
				ByVal w as Integer, 
				ByVal h as Integer, 
				ByVal x as Single, 
				ByVal y as Single, 
				ByVal inval as Single, 
				<Out()>  ByRef pval as Single) as Integer


if IsNothing (datas) then Throw New ArgumentNullException  ("datas cannot be Nothing")
	Dim _Result as Integer = Natives.linearInterpolatePixelFloat(  datas,   w,   h,   x,   y,   inval,   pval)
	
	return _Result
End Function

' fpix2.c (2333, 1)
' fpixThresholdToPix(fpix, thresh) as Pix
' fpixThresholdToPix(FPIX *, l_float32) as PIX *
'''  <summary>
''' (1) For all values of fpix that are smaller or equal thresh, sets the pixel
'''in pixd to 1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/fpixThresholdToPix/*"/>
'''  <param name="fpix">[in] - </param>
'''  <param name="thresh">[in] - </param>
'''   <returns>pixd 1 bpp, or NULL on error</returns>
Public Shared Function fpixThresholdToPix(
				ByVal fpix as FPix, 
				ByVal thresh as Single) as Pix


if IsNothing (fpix) then Throw New ArgumentNullException  ("fpix cannot be Nothing")
	Dim _Result as IntPtr = Natives.fpixThresholdToPix(fpix.Pointer,   thresh)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' fpix2.c (2391, 1)
' pixComponentFunction(pix, rnum, gnum, bnum, rdenom, gdenom, bdenom) as FPix
' pixComponentFunction(PIX *, l_float32, l_float32, l_float32, l_float32, l_float32, l_float32) as FPIX *
'''  <summary>
''' (1) This stores a function of the component values of each
'''input pixel in %fpixd.<para/>
'''
'''(2) The function is a ratio of linear combinations of component values.
'''There are two special cases for denominator coefficients:
'''(a) The denominator is 1.0: input 0 for all denominator coefficients
'''(b) Only one component is used in the denominator: input 1.0
'''for that denominator component and 0.0 for the other two.<para/>
'''
'''(3) If the denominator is 0, multiply by an arbitrary number that
'''is much larger than 1.  Choose 256 "arbitrarily".
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/pixComponentFunction/*"/>
'''  <param name="pix">[in] - 32 bpp rgb</param>
'''  <param name="rnum">[in] - coefficients for numerator</param>
'''  <param name="gnum">[in] - coefficients for numerator</param>
'''  <param name="bnum">[in] - coefficients for numerator</param>
'''  <param name="rdenom">[in] - coefficients for denominator</param>
'''  <param name="gdenom">[in] - coefficients for denominator</param>
'''  <param name="bdenom">[in] - coefficients for denominator</param>
'''   <returns>fpixd, or NULL on error</returns>
Public Shared Function pixComponentFunction(
				ByVal pix as Pix, 
				ByVal rnum as Single, 
				ByVal gnum as Single, 
				ByVal bnum as Single, 
				ByVal rdenom as Single, 
				ByVal gdenom as Single, 
				ByVal bdenom as Single) as FPix


if IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")
If {32}.contains (pix.d) = false then Throw New ArgumentException ("32 bpp rgb")
	Dim _Result as IntPtr = Natives.pixComponentFunction(pix.Pointer,   rnum,   gnum,   bnum,   rdenom,   gdenom,   bdenom)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new FPix(_Result)
End Function

End Class



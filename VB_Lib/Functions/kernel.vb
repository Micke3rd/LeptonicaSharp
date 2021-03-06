Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' kernel.c (106, 1)
' kernelCreate(height, width) as L_Kernel
' kernelCreate(l_int32, l_int32) as L_KERNEL *
'''  <summary>
''' (1) kernelCreate() initializes all values to 0.<para/>
'''
'''(2) After this call, (cy,cx) and nonzero data values must be
'''assigned.<para/>
'''
'''(2) The number of kernel elements must be less than 2^29.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelCreate/*"/>
'''  <param name="height">[in] - </param>
'''  <param name="width">[in] - </param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function kernelCreate(
				ByVal height as Integer, 
				ByVal width as Integer) as L_Kernel


	Dim _Result as IntPtr = Natives.kernelCreate(  height,   width)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (144, 1)
' kernelDestroy(pkel) as Object
' kernelDestroy(L_KERNEL **) as void
'''  <summary>
''' kernelDestroy()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelDestroy/*"/>
'''  <param name="pkel">[in,out] - to be nulled</param>
Public Shared Sub kernelDestroy(
				ByRef pkel as L_Kernel)


	Dim pkelPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(pkel) Then pkelPtr = pkel.Pointer

	Natives.kernelDestroy( pkelPtr)
	
	if pkelPtr = IntPtr.Zero then pkel = Nothing else pkel = new L_Kernel(pkelPtr)
End Sub

' kernel.c (175, 1)
' kernelCopy(kels) as L_Kernel
' kernelCopy(L_KERNEL *) as L_KERNEL *
'''  <summary>
''' kernelCopy()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelCopy/*"/>
'''  <param name="kels">[in] - source kernel</param>
'''   <returns>keld copy of kels, or NULL on error</returns>
Public Shared Function kernelCopy(
				ByVal kels as L_Kernel) as L_Kernel


if IsNothing (kels) then Throw New ArgumentNullException  ("kels cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelCopy(kels.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (211, 1)
' kernelGetElement(kel, row, col, pval) as Integer
' kernelGetElement(L_KERNEL *, l_int32, l_int32, l_float32 *) as l_ok
'''  <summary>
''' kernelGetElement()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelGetElement/*"/>
'''  <param name="kel">[in] - </param>
'''  <param name="row">[in] - </param>
'''  <param name="col">[in] - </param>
'''  <param name="pval">[out] - </param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function kernelGetElement(
				ByVal kel as L_Kernel, 
				ByVal row as Integer, 
				ByVal col as Integer, 
				<Out()>  ByRef pval as Single) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelGetElement(kel.Pointer,   row,   col,   pval)
	
	return _Result
End Function

' kernel.c (243, 1)
' kernelSetElement(kel, row, col, val) as Integer
' kernelSetElement(L_KERNEL *, l_int32, l_int32, l_float32) as l_ok
'''  <summary>
''' kernelSetElement()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelSetElement/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="row">[in] - </param>
'''  <param name="col">[in] - </param>
'''  <param name="val">[in] - </param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function kernelSetElement(
				ByVal kel as L_Kernel, 
				ByVal row as Integer, 
				ByVal col as Integer, 
				ByVal val as Single) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelSetElement(kel.Pointer,   row,   col,   val)
	
	return _Result
End Function

' kernel.c (270, 1)
' kernelGetParameters(kel, psy, psx, pcy, pcx) as Integer
' kernelGetParameters(L_KERNEL *, l_int32 *, l_int32 *, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' kernelGetParameters()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelGetParameters/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="psy">[out][optional] - each can be null</param>
'''  <param name="psx">[out][optional] - each can be null</param>
'''  <param name="pcy">[out][optional] - each can be null</param>
'''  <param name="pcx">[out][optional] - each can be null</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function kernelGetParameters(
				ByVal kel as L_Kernel, 
				<Out()> Optional  ByRef psy as Integer = 0, 
				<Out()> Optional  ByRef psx as Integer = 0, 
				<Out()> Optional  ByRef pcy as Integer = 0, 
				<Out()> Optional  ByRef pcx as Integer = 0) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelGetParameters(kel.Pointer,   psy,   psx,   pcy,   pcx)
	
	return _Result
End Function

' kernel.c (300, 1)
' kernelSetOrigin(kel, cy, cx) as Integer
' kernelSetOrigin(L_KERNEL *, l_int32, l_int32) as l_ok
'''  <summary>
''' kernelSetOrigin()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelSetOrigin/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="cy">[in] - </param>
'''  <param name="cx">[in] - </param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function kernelSetOrigin(
				ByVal kel as L_Kernel, 
				ByVal cy as Integer, 
				ByVal cx as Integer) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelSetOrigin(kel.Pointer,   cy,   cx)
	
	return _Result
End Function

' kernel.c (322, 1)
' kernelGetSum(kel, psum) as Integer
' kernelGetSum(L_KERNEL *, l_float32 *) as l_ok
'''  <summary>
''' kernelGetSum()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelGetSum/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="psum">[out] - sum of all kernel values</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function kernelGetSum(
				ByVal kel as L_Kernel, 
				<Out()>  ByRef psum as Single) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelGetSum(kel.Pointer,   psum)
	
	return _Result
End Function

' kernel.c (354, 1)
' kernelGetMinMax(kel, pmin, pmax) as Integer
' kernelGetMinMax(L_KERNEL *, l_float32 *, l_float32 *) as l_ok
'''  <summary>
''' kernelGetMinMax()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelGetMinMax/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="pmin">[out][optional] - minimum value</param>
'''  <param name="pmax">[out][optional] - maximum value</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function kernelGetMinMax(
				ByVal kel as L_Kernel, 
				<Out()> Optional  ByRef pmin as Single = 0f, 
				<Out()> Optional  ByRef pmax as Single = 0f) as Integer


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelGetMinMax(kel.Pointer,   pmin,   pmax)
	
	return _Result
End Function

' kernel.c (410, 1)
' kernelNormalize(kels, normsum) as L_Kernel
' kernelNormalize(L_KERNEL *, l_float32) as L_KERNEL *
'''  <summary>
''' (1) If the sum of kernel elements is close to 0, do not
'''try to calculate the normalized kernel.  Instead,
'''return a copy of the input kernel, with a warning.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelNormalize/*"/>
'''  <param name="kels">[in] - source kel, to be normalized</param>
'''  <param name="normsum">[in] - desired sum of elements in keld</param>
'''   <returns>keld normalized version of kels, or NULL on error or if sum of elements is very close to 0)</returns>
Public Shared Function kernelNormalize(
				ByVal kels as L_Kernel, 
				ByVal normsum as Single) as L_Kernel


if IsNothing (kels) then Throw New ArgumentNullException  ("kels cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelNormalize(kels.Pointer,   normsum)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (456, 1)
' kernelInvert(kels) as L_Kernel
' kernelInvert(L_KERNEL *) as L_KERNEL *
'''  <summary>
''' (1) For convolution, the kernel is spatially inverted before
'''a "correlation" operation is done between the kernel and the image.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelInvert/*"/>
'''  <param name="kels">[in] - source kel, to be inverted</param>
'''   <returns>keld spatially inverted, about the origin, or NULL on error</returns>
Public Shared Function kernelInvert(
				ByVal kels as L_Kernel) as L_Kernel


if IsNothing (kels) then Throw New ArgumentNullException  ("kels cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelInvert(kels.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (499, 1)
' create2dFloatArray(sy, sx) as List(of Single())
' create2dFloatArray(l_int32, l_int32) as l_float32 **
'''  <summary>
''' (1) The array[sy][sx] is indexed in standard "matrix notation",
'''with the row index first.<para/>
'''
'''(2) The caller kernelCreate() limits the size to  is smaller 2^29 pixels.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/create2dFloatArray/*"/>
'''  <param name="sy">[in] - rows == height</param>
'''  <param name="sx">[in] - columns == width</param>
'''   <returns>doubly indexed array i.e., an array of sy row pointers, each of which points to an array of sx floats</returns>
Public Shared Function create2dFloatArray(
				ByVal sy as Integer, 
				ByVal sx as Integer) as List(of Single())


	Dim _Result as IntPtr = Natives.create2dFloatArray(  sy,   sx)
	
	Dim PTRArr(1) As IntPtr
	Marshal.Copy(_Result, PTRArr, 0, PTRArr.Length)
	Dim B As New List(Of Single())
	For Each eintrag In PTRArr
	   Dim SingleLST(1) As Single
	   Marshal.Copy(eintrag, SingleLST, 0, SingleLST.Count)
	   B.Add(SingleLST)
	Next
	return B
End Function

' kernel.c (526, 1)
' kernelRead(fname) as L_Kernel
' kernelRead(const char *) as L_KERNEL *
'''  <summary>
''' kernelRead()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelRead/*"/>
'''  <param name="fname">[in] - filename</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function kernelRead(
				ByVal fname as String) as L_Kernel


if IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")
If My.Computer.Filesystem.FileExists (fname) = false then 
	   Throw New ArgumentException ("File is missing")
	End If
	Dim _Result as IntPtr = Natives.kernelRead(  fname)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (555, 1)
' kernelReadStream(fp) as L_Kernel
' kernelReadStream(FILE *) as L_KERNEL *
'''  <summary>
''' kernelReadStream()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelReadStream/*"/>
'''  <param name="fp">[in] - file stream</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function kernelReadStream(
				ByVal fp as FILE) as L_Kernel


if IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelReadStream(fp.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (598, 1)
' kernelWrite(fname, kel) as Integer
' kernelWrite(const char *, L_KERNEL *) as l_ok
'''  <summary>
''' kernelWrite()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelWrite/*"/>
'''  <param name="fname">[in] - output file</param>
'''  <param name="kel">[in] - kernel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function kernelWrite(
				ByVal fname as String, 
				ByVal kel as L_Kernel) as Integer


if IsNothing (fname) then Throw New ArgumentNullException  ("fname cannot be Nothing")
		if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelWrite(  fname, kel.Pointer)
	
	return _Result
End Function

' kernel.c (627, 1)
' kernelWriteStream(fp, kel) as Integer
' kernelWriteStream(FILE *, L_KERNEL *) as l_ok
'''  <summary>
''' kernelWriteStream()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelWriteStream/*"/>
'''  <param name="fp">[in] - file stream</param>
'''  <param name="kel">[in] - </param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function kernelWriteStream(
				ByVal fp as FILE, 
				ByVal kel as L_Kernel) as Integer


if IsNothing (fp) then Throw New ArgumentNullException  ("fp cannot be Nothing")
		if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as Integer = Natives.kernelWriteStream(fp.Pointer, kel.Pointer)
	
	return _Result
End Function

' kernel.c (679, 1)
' kernelCreateFromString(h, w, cy, cx, kdata) as L_Kernel
' kernelCreateFromString(l_int32, l_int32, l_int32, l_int32, const char *) as L_KERNEL *
'''  <summary>
''' (1) The data is an array of chars, in row-major order, giving
'''space separated integers in the range [-255 ... 255].<para/>
'''
'''(2) The only other formatting limitation is that you must
'''leave space between the last number in each row and
'''the double-quote.  If possible, it's also nice to have each
'''line in the string represent a line in the kernel e.g.,
'''static const char kdata =
'''" 20 50 20 "
'''" 70  140 70 "
'''" 20 50 20 "
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelCreateFromString/*"/>
'''  <param name="h">[in] - height, width</param>
'''  <param name="w">[in] - height, width</param>
'''  <param name="cy">[in] - origin</param>
'''  <param name="cx">[in] - origin</param>
'''  <param name="kdata">[in] - </param>
'''   <returns>kernel of the given size, or NULL on error</returns>
Public Shared Function kernelCreateFromString(
				ByVal h as Integer, 
				ByVal w as Integer, 
				ByVal cy as Integer, 
				ByVal cx as Integer, 
				ByVal kdata as String) as L_Kernel


if IsNothing (kdata) then Throw New ArgumentNullException  ("kdata cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelCreateFromString(  h,   w,   cy,   cx,   kdata)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (765, 1)
' kernelCreateFromFile(filename) as L_Kernel
' kernelCreateFromFile(const char *) as L_KERNEL *
'''  <summary>
''' (1) The file contains, in the following order:
'''~ Any number of comment lines starting with '#' are ignored
'''~ The height and width of the kernel
'''~ The y and x values of the kernel origin
'''~ The kernel data, formatted as lines of numbers (integers
'''or floats) for the kernel values in row-major order,
'''and with no other punctuation.
'''(Note: this differs from kernelCreateFromString(),
'''where each line must begin and end with a double-quote
'''to tell the compiler it's part of a string.)
'''~ The kernel specification ends when a blank line,
'''a comment line, or the end of file is reached.<para/>
'''
'''(2) All lines must be left-justified.<para/>
'''
'''(3) See kernelCreateFromString() for a description of the string
'''format for the kernel data.  As an example, here are the lines
'''of a valid kernel description file  In the file, all lines
'''are left-justified:
'''\code
'''# small 3x3 kernel
'''3 3
'''1 1
'''25.5 51  24.3
'''70.2  146.3  73.4
'''20 50.9  18.4
'''\endcode
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelCreateFromFile/*"/>
'''  <param name="filename">[in] - </param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function kernelCreateFromFile(
				ByVal filename as String) as L_Kernel


if IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
If My.Computer.Filesystem.FileExists (filename) = false then 
	   Throw New ArgumentException ("File is missing")
	End If
	Dim _Result as IntPtr = Natives.kernelCreateFromFile(  filename)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (865, 1)
' kernelCreateFromPix(pix, cy, cx) as L_Kernel
' kernelCreateFromPix(PIX *, l_int32, l_int32) as L_KERNEL *
'''  <summary>
''' (1) The origin must be positive and within the dimensions of the pix.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelCreateFromPix/*"/>
'''  <param name="pix">[in] - </param>
'''  <param name="cy">[in] - origin of kernel</param>
'''  <param name="cx">[in] - origin of kernel</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function kernelCreateFromPix(
				ByVal pix as Pix, 
				ByVal cy as Integer, 
				ByVal cx as Integer) as L_Kernel


if IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelCreateFromPix(pix.Pointer,   cy,   cx)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (926, 1)
' kernelDisplayInPix(kel, size, gthick) as Pix
' kernelDisplayInPix(L_KERNEL *, l_int32, l_int32) as PIX *
'''  <summary>
''' (1) This gives a visual representation of a kernel.<para/>
'''
'''(2) There are two modes of display:
'''(a) Grid lines of minimum width 2, surrounding regions
'''representing kernel elements of minimum size 17,
'''with a "plus" mark at the kernel origin, or
'''(b) A pix without grid lines and using 1 pixel per kernel element.<para/>
'''
'''(3) For both cases, the kernel absolute value is displayed,
'''normalized such that the maximum absolute value is 255.<para/>
'''
'''(4) Large 2D separable kernels should be used for convolution
'''with two 1D kernels.  However, for the bilateral filter,
'''the computation time is independent of the size of the
'''2D content kernel.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/kernelDisplayInPix/*"/>
'''  <param name="kel">[in] - kernel</param>
'''  <param name="size">[in] - of grid interiors odd either 1 or a minimum size of 17 is enforced</param>
'''  <param name="gthick">[in] - grid thickness either 0 or a minimum size of 2 is enforced</param>
'''   <returns>pix display of kernel, or NULL on error</returns>
Public Shared Function kernelDisplayInPix(
				ByVal kel as L_Kernel, 
				ByVal size as Integer, 
				ByVal gthick as Integer) as Pix


if IsNothing (kel) then Throw New ArgumentNullException  ("kel cannot be Nothing")
	Dim _Result as IntPtr = Natives.kernelDisplayInPix(kel.Pointer,   size,   gthick)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pix(_Result)
End Function

' kernel.c (1040, 1)
' parseStringForNumbers(str, seps) as Numa
' parseStringForNumbers(const char *, const char *) as NUMA *
'''  <summary>
''' (1) The numbers can be ints or floats.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/parseStringForNumbers/*"/>
'''  <param name="str">[in] - string containing numbers not changed</param>
'''  <param name="seps">[in] - string of characters that can be used between ints</param>
'''   <returns>numa of numbers found, or NULL on error</returns>
Public Shared Function parseStringForNumbers(
				ByVal str as String, 
				ByVal seps as String) as Numa


if IsNothing (str) then Throw New ArgumentNullException  ("str cannot be Nothing")
		if IsNothing (seps) then Throw New ArgumentNullException  ("seps cannot be Nothing")
	Dim _Result as IntPtr = Natives.parseStringForNumbers(  str,   seps)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Numa(_Result)
End Function

' kernel.c (1092, 1)
' makeFlatKernel(height, width, cy, cx) as L_Kernel
' makeFlatKernel(l_int32, l_int32, l_int32, l_int32) as L_KERNEL *
'''  <summary>
''' (1) This is the same low-pass filtering kernel that is used
'''in the block convolution functions.<para/>
'''
'''(2) The kernel origin (%cy, %cx) is typically placed as near
'''the center of the kernel as possible.  If height and
'''width are odd, then using cy = height / 2 and
'''cx = width / 2 places the origin at the exact center.<para/>
'''
'''(3) This returns a normalized kernel.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/makeFlatKernel/*"/>
'''  <param name="height">[in] - </param>
'''  <param name="width">[in] - </param>
'''  <param name="cy">[in] - origin of kernel</param>
'''  <param name="cx">[in] - origin of kernel</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function makeFlatKernel(
				ByVal height as Integer, 
				ByVal width as Integer, 
				ByVal cy as Integer, 
				ByVal cx as Integer) as L_Kernel


	Dim _Result as IntPtr = Natives.makeFlatKernel(  height,   width,   cy,   cx)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (1137, 1)
' makeGaussianKernel(halfheight, halfwidth, stdev, max) as L_Kernel
' makeGaussianKernel(l_int32, l_int32, l_float32, l_float32) as L_KERNEL *
'''  <summary>
''' (1) The kernel size (sx, sy) = (2  halfwidth + 1, 2  halfheight + 1).<para/>
'''
'''(2) The kernel center (cx, cy) = (halfwidth, halfheight).<para/>
'''
'''(3) The halfwidth and halfheight are typically equal, and
'''are typically several times larger than the standard deviation.<para/>
'''
'''(4) If pixConvolve() is invoked with normalization (the sum of
'''kernel elements = 1.0), use 1.0 for max (or any number that's
'''not too small or too large).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/makeGaussianKernel/*"/>
'''  <param name="halfheight">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="halfwidth">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="stdev">[in] - standard deviation</param>
'''  <param name="max">[in] - value at (cx,cy)</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function makeGaussianKernel(
				ByVal halfheight as Integer, 
				ByVal halfwidth as Integer, 
				ByVal stdev as Single, 
				ByVal max as Single) as L_Kernel


	Dim _Result as IntPtr = Natives.makeGaussianKernel(  halfheight,   halfwidth,   stdev,   max)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

' kernel.c (1191, 1)
' makeGaussianKernelSep(halfheight, halfwidth, stdev, max, pkelx, pkely) as Integer
' makeGaussianKernelSep(l_int32, l_int32, l_float32, l_float32, L_KERNEL **, L_KERNEL **) as l_ok
'''  <summary>
''' (1) See makeGaussianKernel() for description of input parameters.<para/>
'''
'''(2) These kernels are constructed so that the result of both
'''normalized and un-normalized convolution will be the same
'''as when convolving with pixConvolve() using the full kernel.<para/>
'''
'''(3) The trick for the un-normalized convolution is to have the
'''product of the two kernel elemets at (cx,cy) be equal to max,
'''not max2.  That's why the max for kely is 1.0.  If instead
'''we use sqrt(max) for both, the results are slightly less
'''accurate, when compared to using the full kernel in
'''makeGaussianKernel().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/makeGaussianKernelSep/*"/>
'''  <param name="halfheight">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="halfwidth">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="stdev">[in] - standard deviation</param>
'''  <param name="max">[in] - value at (cx,cy)</param>
'''  <param name="pkelx">[out] - x part of kernel</param>
'''  <param name="pkely">[out] - y part of kernel</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function makeGaussianKernelSep(
				ByVal halfheight as Integer, 
				ByVal halfwidth as Integer, 
				ByVal stdev as Single, 
				ByVal max as Single, 
				<Out()>  ByRef pkelx as L_Kernel, 
				<Out()>  ByRef pkely as L_Kernel) as Integer


	Dim pkelxPtr as IntPtr = IntPtr.Zero
	Dim pkelyPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.makeGaussianKernelSep(  halfheight,   halfwidth,   stdev,   max, pkelxPtr, pkelyPtr)
	
	if pkelxPtr = IntPtr.Zero then pkelx = Nothing else pkelx = new L_Kernel(pkelxPtr)
	if pkelyPtr = IntPtr.Zero then pkely = Nothing else pkely = new L_Kernel(pkelyPtr)
	return _Result
End Function

' kernel.c (1236, 1)
' makeDoGKernel(halfheight, halfwidth, stdev, ratio) as L_Kernel
' makeDoGKernel(l_int32, l_int32, l_float32, l_float32) as L_KERNEL *
'''  <summary>
''' (1) The DoG (difference of gaussians) is a wavelet mother
'''function with null total sum.  By subtracting two blurred
'''versions of the image, it acts as a bandpass filter for
'''frequencies passed by the narrow gaussian but stopped
'''by the wide one.See:
'''http://en.wikipedia.org/wiki/Difference_of_Gaussians<para/>
'''
'''(2) The kernel size (sx, sy) = (2  halfwidth + 1, 2  halfheight + 1).<para/>
'''
'''(3) The kernel center (cx, cy) = (halfwidth, halfheight).<para/>
'''
'''(4) The halfwidth and halfheight are typically equal, and
'''are typically several times larger than the standard deviation.<para/>
'''
'''(5) The ratio is the ratio of standard deviations of the wide
'''to narrow gaussian.  It must be greater or equal 1.0 1.0 is a no-op.<para/>
'''
'''(6) Because the kernel is a null sum, it must be invoked without
'''normalization in pixConvolve().
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/makeDoGKernel/*"/>
'''  <param name="halfheight">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="halfwidth">[in] - sx = 2  halfwidth + 1, etc</param>
'''  <param name="stdev">[in] - standard deviation of narrower gaussian</param>
'''  <param name="ratio">[in] - of stdev for wide filter to stdev for narrow one</param>
'''   <returns>kernel, or NULL on error</returns>
Public Shared Function makeDoGKernel(
				ByVal halfheight as Integer, 
				ByVal halfwidth as Integer, 
				ByVal stdev as Single, 
				ByVal ratio as Single) as L_Kernel


	Dim _Result as IntPtr = Natives.makeDoGKernel(  halfheight,   halfwidth,   stdev,   ratio)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Kernel(_Result)
End Function

End Class



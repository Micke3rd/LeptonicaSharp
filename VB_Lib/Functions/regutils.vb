Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' regutils.c (119, 1)
' regTestSetup(argc, argv, prp) as Integer
' regTestSetup(l_int32, char **, L_REGPARAMS **) as l_ok
'''  <summary>
''' (1) Call this function with the args to the reg test.  The first arg
'''is the name of the reg test.  There are three cases:
'''Case 1:
'''There is either only one arg, or the second arg is "compare".
'''This is the mode in which you run a regression test
'''(or a set of them), looking for failures and logging
'''the results to a file.  The output, which includes
'''logging of all reg test failures plus a SUCCESS or
'''FAILURE summary for each test, is appended to the file
'''"/tmp/lept/reg_results.txt.  For this case, as in Case 2,
'''the display field in rp is set to FALSE, preventing
'''image display.
'''Case 2:
'''The second arg is "generate".  This will cause
'''generation of new golden files for the reg test.
'''The results of the reg test are not recorded, and
'''the display field in rp is set to FALSE.
'''Case 3:
'''The second arg is "display".  The test will run and
'''files will be written.  Comparisons with golden files
'''will not be carried out, so the only notion of success
'''or failure is with tests that do not involve golden files.
'''The display field in rp is TRUE, and this is used by
'''pixDisplayWithTitle().<para/>
'''
'''(2) See regutils.h for examples of usage.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestSetup/*"/>
'''  <param name="argc">[in] - from invocation can be either 1 or 2</param>
'''  <param name="argv">[in] - to regtest: %argv[1] is one of these: "generate", "compare", "display"</param>
'''  <param name="prp">[out] - all regression params</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function regTestSetup(
				ByVal argc as Integer, 
				ByVal argv as String(), 
				<Out()>  ByRef prp as L_RegParams) as Integer


if IsNothing (argv) then Throw New ArgumentNullException  ("argv cannot be Nothing")
	Dim argvPtr as IntPtr = 	Marshal.AllocHGlobal(Marshal.SizeOf(argv))
	Dim prpPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.regTestSetup(  argc,   argvPtr, prpPtr)
	
	if prpPtr = IntPtr.Zero then prp = Nothing else prp = new L_RegParams(prpPtr)
	return _Result
End Function

' regutils.c (208, 1)
' regTestCleanup(rp) as Integer
' regTestCleanup(L_REGPARAMS *) as l_ok
'''  <summary>
''' (1) This copies anything written to the temporary file to the
'''output file /tmp/lept/reg_results.txt.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCleanup/*"/>
'''  <param name="rp">[in] - regression test parameters</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function regTestCleanup(
				ByVal rp as L_RegParams) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCleanup(rp.Pointer)
	
	return _Result
End Function

' regutils.c (271, 1)
' regTestCompareValues(rp, val1, val2, delta) as Integer
' regTestCompareValues(L_REGPARAMS *, l_float32, l_float32, l_float32) as l_ok
'''  <summary>
''' regTestCompareValues()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCompareValues/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="val1">[in] - typ. the golden value</param>
'''  <param name="val2">[in] - typ. the value computed</param>
'''  <param name="delta">[in] - allowed max absolute difference</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestCompareValues(
				ByVal rp as L_RegParams, 
				ByVal val1 as Single, 
				ByVal val2 as Single, 
				ByVal delta as Single) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCompareValues(rp.Pointer,   val1,   val2,   delta)
	
	return _Result
End Function

' regutils.c (315, 1)
' regTestCompareStrings(rp, string1, bytes1, string2, bytes2) as Integer
' regTestCompareStrings(L_REGPARAMS *, l_uint8 *, size_t, l_uint8 *, size_t) as l_ok
'''  <summary>
''' regTestCompareStrings()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCompareStrings/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="string1">[in] - typ. the expected string</param>
'''  <param name="bytes1">[in] - size of string1</param>
'''  <param name="string2">[in] - typ. the computed string</param>
'''  <param name="bytes2">[in] - size of string2</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestCompareStrings(
				ByVal rp as L_RegParams, 
				ByVal string1 as Byte(), 
				ByVal bytes1 as UInteger, 
				ByVal string2 as Byte(), 
				ByVal bytes2 as UInteger) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (string1) then Throw New ArgumentNullException  ("string1 cannot be Nothing")
		if IsNothing (string2) then Throw New ArgumentNullException  ("string2 cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCompareStrings(rp.Pointer,   string1,   bytes1,   string2,   bytes2)
	
	return _Result
End Function

' regutils.c (381, 1)
' regTestComparePix(rp, pix1, pix2) as Integer
' regTestComparePix(L_REGPARAMS *, PIX *, PIX *) as l_ok
'''  <summary>
''' (1) This function compares two pix for equality.  On failure,
'''this writes to stderr.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestComparePix/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="pix1">[in] - to be tested for equality</param>
'''  <param name="pix2">[in] - to be tested for equality</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestComparePix(
				ByVal rp as L_RegParams, 
				ByVal pix1 as Pix, 
				ByVal pix2 as Pix) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (pix1) then Throw New ArgumentNullException  ("pix1 cannot be Nothing")
		if IsNothing (pix2) then Throw New ArgumentNullException  ("pix2 cannot be Nothing")
	Dim _Result as Integer = Natives.regTestComparePix(rp.Pointer, pix1.Pointer, pix2.Pointer)
	
	return _Result
End Function

' regutils.c (441, 1)
' regTestCompareSimilarPix(rp, pix1, pix2, mindiff, maxfract, printstats) as Integer
' regTestCompareSimilarPix(L_REGPARAMS *, PIX *, PIX *, l_int32, l_float32, l_int32) as l_ok
'''  <summary>
''' (1) This function compares two pix for near equality.  On failure,
'''this writes to stderr.<para/>
'''
'''(2) The pix are similar if the fraction of non-conforming pixels
'''does not exceed %maxfract.  Pixels are non-conforming if
'''the difference in pixel values equals or exceeds %mindiff.
'''Typical values might be %mindiff = 15 and %maxfract = 0.01.<para/>
'''
'''(3) The input images must have the same size and depth.  The
'''pixels for comparison are typically subsampled from the images.<para/>
'''
'''(4) Normally, use %printstats = 0.  In debugging mode, to see
'''the relation between %mindiff and the minimum value of
'''%maxfract for success, set this to 1.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCompareSimilarPix/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="pix1">[in] - to be tested for near equality</param>
'''  <param name="pix2">[in] - to be tested for near equality</param>
'''  <param name="mindiff">[in] - minimum pixel difference to be counted  is greater  0</param>
'''  <param name="maxfract">[in] - maximum fraction of pixels allowed to have diff greater than or equal to mindiff</param>
'''  <param name="printstats">[in] - use 1 to print normalized histogram to stderr</param>
'''   <returns>0 if OK, 1 on error a failure in similarity comparison is not an error</returns>
Public Shared Function regTestCompareSimilarPix(
				ByVal rp as L_RegParams, 
				ByVal pix1 as Pix, 
				ByVal pix2 as Pix, 
				ByVal mindiff as Integer, 
				ByVal maxfract as Single, 
				ByVal printstats as Integer) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (pix1) then Throw New ArgumentNullException  ("pix1 cannot be Nothing")
		if IsNothing (pix2) then Throw New ArgumentNullException  ("pix2 cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCompareSimilarPix(rp.Pointer, pix1.Pointer, pix2.Pointer,   mindiff,   maxfract,   printstats)
	
	return _Result
End Function

' regutils.c (504, 1)
' regTestCheckFile(rp, localname) as Integer
' regTestCheckFile(L_REGPARAMS *, const char *) as l_ok
'''  <summary>
''' (1) This function does one of three things, depending on the mode:
'''"generate": makes a "golden" file as a copy %localname.
'''"compare": compares %localname contents with the golden file
'''"display": makes the %localname file but does no comparison<para/>
'''
'''(2) The canonical format of the golden filenames is:
'''/tmp/lept/golden/[root of main name]_golden.[index].
'''[ext of localname]
'''e.g.,
'''/tmp/lept/golden/maze_golden.0.png
'''It is important to add an extension to the local name, because
'''the extension is added to the name of the golden file.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCheckFile/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="localname">[in] - name of output file from reg test</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestCheckFile(
				ByVal rp as L_RegParams, 
				ByVal localname as String) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (localname) then Throw New ArgumentNullException  ("localname cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCheckFile(rp.Pointer,   localname)
	
	return _Result
End Function

' regutils.c (611, 1)
' regTestCompareFiles(rp, index1, index2) as Integer
' regTestCompareFiles(L_REGPARAMS *, l_int32, l_int32) as l_ok
'''  <summary>
''' (1) This only does something in "compare" mode.<para/>
'''
'''(2) The canonical format of the golden filenames is:
'''/tmp/lept/golden/[root of main name]_golden.[index].
'''[ext of localname]
'''e.g.,
'''/tmp/lept/golden/maze_golden.0.png
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestCompareFiles/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="index1">[in] - of one output file from reg test</param>
'''  <param name="index2">[in] - of another output file from reg test</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestCompareFiles(
				ByVal rp as L_RegParams, 
				ByVal index1 as Integer, 
				ByVal index2 as Integer) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
	Dim _Result as Integer = Natives.regTestCompareFiles(rp.Pointer,   index1,   index2)
	
	return _Result
End Function

' regutils.c (704, 1)
' regTestWritePixAndCheck(rp, pix, format) as Integer
' regTestWritePixAndCheck(L_REGPARAMS *, PIX *, l_int32) as l_ok
'''  <summary>
''' (1) This function makes it easy to write the pix in a numbered
'''sequence of files, and either to:
'''(a) write the golden file ("generate" arg to regression test)
'''(b) make a local file and "compare" with the golden file
'''(c) make a local file and "display" the results<para/>
'''
'''(2) The canonical format of the local filename is:
'''/tmp/lept/regout/[root of main name].[count].[format extension]
'''e.g., for scale_reg,
'''/tmp/lept/regout/scale.0.png
'''The golden file name mirrors this in the usual way.<para/>
'''
'''(3) The check is done between the written files, which requires
'''the files to be identical. The exception is for GIF, which
'''only requires that all pixels in the decoded pix are identical.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestWritePixAndCheck/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="pix">[in] - to be written</param>
'''  <param name="format">[in] - of output pix</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestWritePixAndCheck(
				ByVal rp as L_RegParams, 
				ByVal pix as Pix, 
				ByVal format as Enumerations.IFF) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (pix) then Throw New ArgumentNullException  ("pix cannot be Nothing")
	Dim _Result as Integer = Natives.regTestWritePixAndCheck(rp.Pointer, pix.Pointer,   format)
	
	return _Result
End Function

' regutils.c (770, 1)
' regTestWriteDataAndCheck(rp, data, nbytes, ext) as Integer
' regTestWriteDataAndCheck(L_REGPARAMS *, void *, size_t, const char *) as l_ok
'''  <summary>
''' (1) This function makes it easy to write data in a numbered
'''sequence of files, and either to:
'''(a) write the golden file ("generate" arg to regression test)
'''(b) make a local file and "compare" with the golden file
'''(c) make a local file and "display" the results<para/>
'''
'''(2) The canonical format of the local filename is:
'''/tmp/lept/regout/[root of main name].[count].[ext]
'''e.g., for the first boxaa in quadtree_reg,
'''/tmp/lept/regout/quadtree.0.baa
'''The golden file name mirrors this in the usual way.<para/>
'''
'''(3) The data can be anything.  It is most useful for serialized
'''output of data, such as boxa, pta, etc.<para/>
'''
'''(4) The file extension is arbitrary.  It is included simply
'''to make the content type obvious when examining written files.<para/>
'''
'''(5) The check is done between the written files, which requires
'''the files to be identical.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestWriteDataAndCheck/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="data">[in] - to be written</param>
'''  <param name="nbytes">[in] - of data to be written</param>
'''  <param name="ext">[in] - filename extension (e.g.: "ba", "pta")</param>
'''   <returns>0 if OK, 1 on error a failure in comparison is not an error</returns>
Public Shared Function regTestWriteDataAndCheck(
				ByVal rp as L_RegParams, 
				ByVal data as Object, 
				ByVal nbytes as UInteger, 
				ByVal ext as String) as Integer


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
		if IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")
		if IsNothing (ext) then Throw New ArgumentNullException  ("ext cannot be Nothing")
		Dim dataPtr as IntPtr = 	Marshal.AllocHGlobal(0)
	If TypeOf (data) Is IntPtr Then dataPtr = data
	If TypeOf (data) Is Byte() Then
	   Dim cdata = CType(data, Byte())
	   dataPtr = Marshal.AllocHGlobal(cdata.Length - 1)
	   Marshal.Copy(cdata, 0, dataPtr, cdata.Length)
	End If
	If Not IsNothing(data.GetType.GetProperty("data")) Then
	  Dim cdata = CType(data.data, Byte())
	  dataPtr = Marshal.AllocHGlobal(cdata.Length - 1)
	  Marshal.Copy(cdata, 0, dataPtr, cdata.Length)
	End If

	Dim _Result as Integer = Natives.regTestWriteDataAndCheck(rp.Pointer,   dataPtr,   nbytes,   ext)
	
	Marshal.FreeHGlobal(dataPtr)
	return _Result
End Function

' regutils.c (821, 1)
' regTestGenLocalFilename(rp, index, format) as String
' regTestGenLocalFilename(L_REGPARAMS *, l_int32, l_int32) as char *
'''  <summary>
''' (1) This is used to get the name of a file in the regout
'''subdirectory, that has been made and is used to test against
'''the golden file.  You can either specify a particular index
'''value, or with %index == -1, this returns the most recently
'''written file.  The latter case lets you read a pix from a
'''file that has just been written with regTestWritePixAndCheck(),
'''which is useful for testing formatted read/write functions.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/regTestGenLocalFilename/*"/>
'''  <param name="rp">[in] - regtest parameters</param>
'''  <param name="index">[in] - use -1 for current index</param>
'''  <param name="format">[in] - of image e.g., IFF_PNG</param>
'''   <returns>filename if OK, or NULL on error</returns>
Public Shared Function regTestGenLocalFilename(
				ByVal rp as L_RegParams, 
				ByVal index as Integer, 
				ByVal format as Enumerations.IFF) as String


if IsNothing (rp) then Throw New ArgumentNullException  ("rp cannot be Nothing")
	Dim _Result as String = Natives.regTestGenLocalFilename(rp.Pointer,   index,   format)
	
	return _Result
End Function

End Class



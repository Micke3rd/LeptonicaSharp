Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\stringcode.c (156, 1)
' strcodeCreate()
' strcodeCreate(l_int32) as L_STRCODE *
'''  <summary>
''' Notes
''' (1) This struct exists to build two files containing code for
''' any number of data objects.  The two files are named
''' autogen.[fileno].c
''' autogen.[fileno].h
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="fileno">[in] - integer that labels the two output files</param>
'''   <returns>initialized L_StrCode, or NULL on error</returns>
Public Shared Function strcodeCreate(
				ByVal fileno as Integer) as L_StrCode



	Dim _Result as IntPtr = LeptonicaSharp.Natives.strcodeCreate( fileno)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_StrCode(_Result)
End Function

' SRC\stringcode.c (223, 1)
' strcodeCreateFromFile()
' strcodeCreateFromFile(const char *, l_int32, const char *) as l_ok
'''  <summary>
''' Notes
''' (1) The %filein has one filename on each line.
''' Comment lines begin with "#".
''' (2) The output is 2 files
''' autogen.[fileno].c
''' autogen.[fileno].h
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filein">[in] - containing filenames of serialized data</param>
'''  <param name="fileno">[in] - integer that labels the two output files</param>
'''  <param name="outdir">[in][optional] - if null, files are made in /tmp/lept/auto</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function strcodeCreateFromFile(
				ByVal filein as String, 
				ByVal fileno as Integer, 
				ByVal outdir as String) as Integer

	If IsNothing (filein) then Throw New ArgumentNullException  ("filein cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.strcodeCreateFromFile( filein, fileno, outdir)

	Return _Result
End Function

' SRC\stringcode.c (289, 1)
' strcodeGenerate()
' strcodeGenerate(L_STRCODE *, const char *, const char *) as l_ok
'''  <summary>
''' Notes
''' (1) The generated function name is
''' l_autodecode_[fileno]()
''' where [fileno] is the index label for the pair of output files.
''' (2) To deserialize this data, the function is called with the
''' argument 'ifunc', which increments each time strcodeGenerate()
''' is called.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="strcode">[in] - for accumulating data</param>
'''  <param name="filein">[in] - input file with serialized data</param>
'''  <param name="type">[in] - of data; use the typedef string</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function strcodeGenerate(
				ByVal strcode as L_StrCode, 
				ByVal filein as String, 
				ByVal type as String) as Integer

	If IsNothing (strcode) then Throw New ArgumentNullException  ("strcode cannot be Nothing")
	If IsNothing (filein) then Throw New ArgumentNullException  ("filein cannot be Nothing")
	If IsNothing (type) then Throw New ArgumentNullException  ("type cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.strcodeGenerate( strcode.Pointer, filein, type)

	Return _Result
End Function

' SRC\stringcode.c (336, 1)
' strcodeFinalize()
' strcodeFinalize(L_STRCODE **, const char *) as l_int32
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pstrcode">[in,out] - destroys after .c and .h files have been generated</param>
'''  <param name="outdir">[in][optional] - if NULL, files are made in /tmp/lept/auto</param>
'''   <returns>void</returns>
Public Shared Function strcodeFinalize(
				ByRef pstrcode as L_StrCode, 
				ByVal outdir as String) as Integer


	Dim pstrcodePTR As IntPtr = IntPtr.Zero : If Not IsNothing(pstrcode) Then pstrcodePTR = pstrcode.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.strcodeFinalize( pstrcodePTR, outdir)
	if pstrcodePTR <> IntPtr.Zero then pstrcode = new L_StrCode(pstrcodePTR)

	Return _Result
End Function

' SRC\stringcode.c (525, 1)
' l_getStructStrFromFile()
' l_getStructStrFromFile(const char *, l_int32, char **) as l_int32
'''  <summary>
''' Notes
''' (1) For example, if %field == L_STR_NAME, and the file is a serialized
''' pixa, this will return "Pixa", the name of the struct.
''' (2) Caller must free the returned string.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="filename">[in] - </param>
'''  <param name="field">[in] - (L_STR_TYPE, L_STR_NAME, L_STR_READER, L_STR_MEMREADER)</param>
'''  <param name="pstr">[out] - struct string for this file</param>
'''   <returns>0 if found, 1 on error.</returns>
Public Shared Function l_getStructStrFromFile(
				ByVal filename as String, 
				ByVal field as Enumerations.L_STR, 
				ByRef pstr as String()) as Integer

	If IsNothing (filename) then Throw New ArgumentNullException  ("filename cannot be Nothing")
	If My.Computer.Filesystem.Fileexists (filename) = false then Throw New ArgumentException ("File is missing")

Dim pstrPTR As IntPtr = pstrPTR = Marshal.AllocHGlobal(Marshal.sizeOf(pstr.toArray))

	Dim _Result as Integer = LeptonicaSharp.Natives.l_getStructStrFromFile( filename, field, pstrPTR)

	Return _Result
End Function

End Class

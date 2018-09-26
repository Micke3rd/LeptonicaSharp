Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\sarray2.c (95, 1)
' sarraySort()
' sarraySort(SARRAY *, SARRAY *, l_int32) as SARRAY *
'''  <summary>
''' Notes
''' (1) Set saout = sain for in-place; otherwise, set naout = NULL.
''' (2) Shell sort, modified from KR, 2nd edition, p.62.
''' Slow but simple O(n logn) sort.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="saout">[in] - output sarray; can be NULL or equal to sain</param>
'''  <param name="sain">[in] - input sarray</param>
'''  <param name="sortorder">[in] - L_SORT_INCREASING or L_SORT_DECREASING</param>
'''   <returns>saout output sarray, sorted by ascii value, or NULL on error</returns>
Public Shared Function sarraySort(
				ByVal saout as Sarray, 
				ByVal sain as Sarray, 
				ByVal sortorder as Enumerations.L_SORT_CREASING) as Sarray

	If IsNothing (saout) then Throw New ArgumentNullException  ("saout cannot be Nothing")
	If IsNothing (sain) then Throw New ArgumentNullException  ("sain cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarraySort( saout.Pointer, sain.Pointer, sortorder)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (145, 1)
' sarraySortByIndex()
' sarraySortByIndex(SARRAY *, NUMA *) as SARRAY *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sain">[in] - </param>
'''  <param name="naindex">[in] - na that maps from the new sarray to the input sarray</param>
'''   <returns>saout sorted, or NULL on error</returns>
Public Shared Function sarraySortByIndex(
				ByVal sain as Sarray, 
				ByVal naindex as Numa) as Sarray

	If IsNothing (sain) then Throw New ArgumentNullException  ("sain cannot be Nothing")
	If IsNothing (naindex) then Throw New ArgumentNullException  ("naindex cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarraySortByIndex( sain.Pointer, naindex.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (185, 1)
' stringCompareLexical()
' stringCompareLexical(const char *, const char *) as l_int32
'''  <summary>
''' Notes
''' (1) If the lexical values are identical, return a 0, to
''' indicate that no swapping is required to sort the strings.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="str1">[in] - </param>
'''  <param name="str2">[in] - </param>
'''   <returns>1 if str1 GT str2 lexically; 0 otherwise</returns>
Public Shared Function stringCompareLexical(
				ByVal str1 as String, 
				ByVal str2 as String) as Integer

	If IsNothing (str1) then Throw New ArgumentNullException  ("str1 cannot be Nothing")
	If IsNothing (str2) then Throw New ArgumentNullException  ("str2 cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.stringCompareLexical( str1, str2)

	Return _Result
End Function

' SRC\sarray2.c (237, 1)
' sarrayUnionByAset()
' sarrayUnionByAset(SARRAY *, SARRAY *) as SARRAY *
'''  <summary>
''' Notes
''' (1) Duplicates are removed from the concatenation of the two arrays.
''' (2) The key for each string is a 64-bit hash.
''' (2) Algorithm Concatenate the two sarrays.  Then build a set,
''' using hashed strings as keys.  As the set is built, first do
''' a find; if not found, add the key to the set and add the string
''' to the output sarray.  This is O(nlogn).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa1">[in] - </param>
'''  <param name="sa2">[in] - </param>
'''   <returns>sad with the union of the string set, or NULL on error</returns>
Public Shared Function sarrayUnionByAset(
				ByVal sa1 as Sarray, 
				ByVal sa2 as Sarray) as Sarray

	If IsNothing (sa1) then Throw New ArgumentNullException  ("sa1 cannot be Nothing")
	If IsNothing (sa2) then Throw New ArgumentNullException  ("sa2 cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarrayUnionByAset( sa1.Pointer, sa2.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (277, 1)
' sarrayRemoveDupsByAset()
' sarrayRemoveDupsByAset(SARRAY *) as SARRAY *
'''  <summary>
''' Notes
''' (1) This is O(nlogn), considerably slower than
''' sarrayRemoveDupsByHash() for large string arrays.
''' (2) The key for each string is a 64-bit hash.
''' (3) Build a set, using hashed strings as keys.  As the set is
''' built, first do a find; if not found, add the key to the
''' set and add the string to the output sarray.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sas">[in] - </param>
'''   <returns>sad with duplicates removed, or NULL on error</returns>
Public Shared Function sarrayRemoveDupsByAset(
				ByVal sas as Sarray) as Sarray

	If IsNothing (sas) then Throw New ArgumentNullException  ("sas cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarrayRemoveDupsByAset( sas.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (328, 1)
' sarrayIntersectionByAset()
' sarrayIntersectionByAset(SARRAY *, SARRAY *) as SARRAY *
'''  <summary>
''' Notes
''' (1) Algorithm put the larger sarray into a set, using the string
''' hashes as the key values.  Then run through the smaller sarray,
''' building an output sarray and a second set from the strings
''' in the larger array if a string is in the first set but
''' not in the second, add the string to the output sarray and hash
''' it into the second set.  The second set is required to make
''' sure only one instance of each string is put into the output sarray.
''' This is O(mlogn), {m,n} = sizes of {smaller,larger} input arrays.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa1">[in] - </param>
'''  <param name="sa2">[in] - </param>
'''   <returns>sad with the intersection of the string set, or NULL on error</returns>
Public Shared Function sarrayIntersectionByAset(
				ByVal sa1 as Sarray, 
				ByVal sa2 as Sarray) as Sarray

	If IsNothing (sa1) then Throw New ArgumentNullException  ("sa1 cannot be Nothing")
	If IsNothing (sa2) then Throw New ArgumentNullException  ("sa2 cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarrayIntersectionByAset( sa1.Pointer, sa2.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (379, 1)
' l_asetCreateFromSarray()
' l_asetCreateFromSarray(SARRAY *) as L_ASET *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa">[in] - </param>
'''   <returns>set using a string hash into a uint64 as the key</returns>
Public Shared Function l_asetCreateFromSarray(
				ByVal sa as Sarray) as L_Rbtree

	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_asetCreateFromSarray( sa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_Rbtree(_Result)
End Function

' SRC\sarray2.c (431, 1)
' sarrayRemoveDupsByHash()
' sarrayRemoveDupsByHash(SARRAY *, SARRAY **, L_DNAHASH **) as l_ok
'''  <summary>
''' Notes
''' (1) Generates a sarray with unique values.
''' (2) The dnahash is built up with sad to assure uniqueness.
''' It can be used to find if a string is in the set
''' sarrayFindValByHash(sad, dahash, str, index)
''' (3) The hash of the string location is simple and fast.  It scales
''' up with the number of buckets to insure a fairly random
''' bucket selection input strings.
''' (4) This is faster than sarrayRemoveDupsByAset(), because the
''' bucket lookup is O(n), although there is a double-loop
''' lookup within the dna in each bucket.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sas">[in] - </param>
'''  <param name="psad">[out] - unique set of strings; duplicates removed</param>
'''  <param name="pdahash">[out][optional] - dnahash used for lookup</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function sarrayRemoveDupsByHash(
				ByVal sas as Sarray, 
				ByRef psad as Sarray, 
				Optional ByRef pdahash as L_DnaHash = Nothing) as Integer

	If IsNothing (sas) then Throw New ArgumentNullException  ("sas cannot be Nothing")

	Dim psadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(psad) Then psadPTR = psad.Pointer
Dim pdahashPTR As IntPtr = IntPtr.Zero : If Not IsNothing(pdahash) Then pdahashPTR = pdahash.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.sarrayRemoveDupsByHash( sas.Pointer, psadPTR, pdahashPTR)
	if psadPTR <> IntPtr.Zero then psad = new Sarray(psadPTR)
	if pdahashPTR <> IntPtr.Zero then pdahash = new L_DnaHash(pdahashPTR)

	Return _Result
End Function

' SRC\sarray2.c (488, 1)
' sarrayIntersectionByHash()
' sarrayIntersectionByHash(SARRAY *, SARRAY *) as SARRAY *
'''  <summary>
''' Notes
''' (1) This is faster than sarrayIntersectionByAset(), because the
''' bucket lookup is O(n).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa1">[in] - </param>
'''  <param name="sa2">[in] - </param>
'''   <returns>sad intersection of the strings, or NULL on error</returns>
Public Shared Function sarrayIntersectionByHash(
				ByVal sa1 as Sarray, 
				ByVal sa2 as Sarray) as Sarray

	If IsNothing (sa1) then Throw New ArgumentNullException  ("sa1 cannot be Nothing")
	If IsNothing (sa2) then Throw New ArgumentNullException  ("sa2 cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarrayIntersectionByHash( sa1.Pointer, sa2.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (563, 1)
' sarrayFindStringByHash()
' sarrayFindStringByHash(SARRAY *, L_DNAHASH *, const char *, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) Fast lookup in dnaHash associated with a sarray, to see if a
''' random string %str is already stored in the hash table.
''' (2) We use a strong hash function to minimize the chance that
''' two different strings hash to the same key value.
''' (3) We select the number of buckets to be about 5% of the size
''' of the input sarray, so that when fully populated, each
''' bucket (dna) will have about 20 entries, each being an index
''' into sa.  In lookup, after hashing to the key, and then
''' again to the bucket, we traverse the bucket (dna), using the
''' index into sa to check if %str has been found before.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa">[in] - </param>
'''  <param name="dahash">[in] - built from sa</param>
'''  <param name="str">[in] - arbitrary string</param>
'''  <param name="pindex">[out] - index into %sa if %str is in %sa; -1 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function sarrayFindStringByHash(
				ByVal sa as Sarray, 
				ByVal dahash as L_DnaHash, 
				ByVal str as String, 
				ByRef pindex as Integer) as Integer

	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")
	If IsNothing (dahash) then Throw New ArgumentNullException  ("dahash cannot be Nothing")
	If IsNothing (str) then Throw New ArgumentNullException  ("str cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.sarrayFindStringByHash( sa.Pointer, dahash.Pointer, str, pindex)

	Return _Result
End Function

' SRC\sarray2.c (609, 1)
' l_dnaHashCreateFromSarray()
' l_dnaHashCreateFromSarray(SARRAY *) as L_DNAHASH *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa">[in] - </param>
'''   <returns>dahash, or NULL on error</returns>
Public Shared Function l_dnaHashCreateFromSarray(
				ByVal sa as Sarray) as L_DnaHash

	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.l_dnaHashCreateFromSarray( sa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new L_DnaHash(_Result)
End Function

' SRC\sarray2.c (648, 1)
' sarrayGenerateIntegers()
' sarrayGenerateIntegers(l_int32) as SARRAY *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="n">[in] - </param>
'''   <returns>sa  (of printed numbers, 1 - n, or NULL on error</returns>
Public Shared Function sarrayGenerateIntegers(
				ByVal n as Integer) as Sarray



	Dim _Result as IntPtr = LeptonicaSharp.Natives.sarrayGenerateIntegers( n)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\sarray2.c (688, 1)
' sarrayLookupCSKV()
' sarrayLookupCSKV(SARRAY *, const char *, char **) as l_ok
'''  <summary>
''' Notes
''' (1) The input %sa can have other strings that are not in
''' comma-separated key-value format.  These will be ignored.
''' (2) This returns a copy of the first value string in %sa whose
''' key string matches the input %keystring.
''' (3) White space is not ignored; all white space before the ','
''' is used for the keystring in matching.  This allows the
''' key and val strings to have white space (e.g., multiple words).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="sa">[in] - (of strings, each being a comma-separated pair of strings, the first being a key and the second a value)</param>
'''  <param name="keystring">[in] - (an input string to match with each key in %sa</param>
'''  <param name="pvalstring">[out] - (the returned value string corresponding to the input key string, if found; otherwise NULL)</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function sarrayLookupCSKV(
				ByVal sa as Sarray, 
				ByVal keystring as String, 
				ByRef pvalstring as String()) as Integer

	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")
	If IsNothing (keystring) then Throw New ArgumentNullException  ("keystring cannot be Nothing")

Dim pvalstringPTR As IntPtr = pvalstringPTR = Marshal.AllocHGlobal(Marshal.sizeOf(pvalstring.toArray))

	Dim _Result as Integer = LeptonicaSharp.Natives.sarrayLookupCSKV( sa.Pointer, keystring, pvalstringPTR)

	Return _Result
End Function

End Class

Imports LeptonicaSharp.Enumerations
Imports System.Runtime.InteropServices

Public Partial Class _All

' ptafunc2.c (89, 1)
' ptaSort(ptas, sorttype, sortorder, pnaindex) as Pta
' ptaSort(PTA *, l_int32, l_int32, NUMA **) as PTA *
'''  <summary>
''' ptaSort()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaSort/*"/>
'''  <param name="ptas">[in] - </param>
'''  <param name="sorttype">[in] - L_SORT_BY_X, L_SORT_BY_Y</param>
'''  <param name="sortorder">[in] - L_SORT_INCREASING, L_SORT_DECREASING</param>
'''  <param name="pnaindex">[out][optional] - index of sorted order into original array</param>
'''   <returns>ptad sorted version of ptas, or NULL on error</returns>
Public Shared Function ptaSort(
				ByVal ptas as Pta, 
				ByVal sorttype as Enumerations.L_SORT_BY, 
				ByVal sortorder as Enumerations.L_SORT_CREASING, 
				<Out()> Optional  ByRef pnaindex as Numa = Nothing) as Pta


if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim pnaindexPtr as IntPtr = IntPtr.Zero

	Dim _Result as IntPtr = Natives.ptaSort(ptas.Pointer,   sorttype,   sortorder, pnaindexPtr)
	
	if pnaindexPtr = IntPtr.Zero then pnaindex = Nothing else pnaindex = new Numa(pnaindexPtr)
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (132, 1)
' ptaGetSortIndex(ptas, sorttype, sortorder, pnaindex) as Integer
' ptaGetSortIndex(PTA *, l_int32, l_int32, NUMA **) as l_ok
'''  <summary>
''' ptaGetSortIndex()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaGetSortIndex/*"/>
'''  <param name="ptas">[in] - </param>
'''  <param name="sorttype">[in] - L_SORT_BY_X, L_SORT_BY_Y</param>
'''  <param name="sortorder">[in] - L_SORT_INCREASING, L_SORT_DECREASING</param>
'''  <param name="pnaindex">[out] - index of sorted order into original array</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function ptaGetSortIndex(
				ByVal ptas as Pta, 
				ByVal sorttype as Enumerations.L_SORT_BY, 
				ByVal sortorder as Enumerations.L_SORT_CREASING, 
				<Out()>  ByRef pnaindex as Numa) as Integer


if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim pnaindexPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.ptaGetSortIndex(ptas.Pointer,   sorttype,   sortorder, pnaindexPtr)
	
	if pnaindexPtr = IntPtr.Zero then pnaindex = Nothing else pnaindex = new Numa(pnaindexPtr)
	return _Result
End Function

' ptafunc2.c (182, 1)
' ptaSortByIndex(ptas, naindex) as Pta
' ptaSortByIndex(PTA *, NUMA *) as PTA *
'''  <summary>
''' ptaSortByIndex()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaSortByIndex/*"/>
'''  <param name="ptas">[in] - </param>
'''  <param name="naindex">[in] - na that maps from the new pta to the input pta</param>
'''   <returns>ptad sorted, or NULL on  error</returns>
Public Shared Function ptaSortByIndex(
				ByVal ptas as Pta, 
				ByVal naindex as Numa) as Pta


if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
		if IsNothing (naindex) then Throw New ArgumentNullException  ("naindex cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaSortByIndex(ptas.Pointer, naindex.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (218, 1)
' ptaaSortByIndex(ptaas, naindex) as Ptaa
' ptaaSortByIndex(PTAA *, NUMA *) as PTAA *
'''  <summary>
''' ptaaSortByIndex()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaaSortByIndex/*"/>
'''  <param name="ptaas">[in] - </param>
'''  <param name="naindex">[in] - na that maps from the new ptaa to the input ptaa</param>
'''   <returns>ptaad sorted, or NULL on error</returns>
Public Shared Function ptaaSortByIndex(
				ByVal ptaas as Ptaa, 
				ByVal naindex as Numa) as Ptaa


if IsNothing (ptaas) then Throw New ArgumentNullException  ("ptaas cannot be Nothing")
		if IsNothing (naindex) then Throw New ArgumentNullException  ("naindex cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaaSortByIndex(ptaas.Pointer, naindex.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Ptaa(_Result)
End Function

' ptafunc2.c (257, 1)
' ptaGetRankValue(pta, fract, ptasort, sorttype, pval) as Integer
' ptaGetRankValue(PTA *, l_float32, PTA *, l_int32, l_float32 *) as l_ok
'''  <summary>
''' ptaGetRankValue()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaGetRankValue/*"/>
'''  <param name="pta">[in] - </param>
'''  <param name="fract">[in] - use 0.0 for smallest, 1.0 for largest</param>
'''  <param name="ptasort">[in][optional] - version of %pta sorted by %sorttype</param>
'''  <param name="sorttype">[in] - L_SORT_BY_X, L_SORT_BY_Y</param>
'''  <param name="pval">[out] - [and]rankval: the x or y value at %fract</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function ptaGetRankValue(
				ByVal pta as Pta, 
				ByVal fract as Single, 
				ByVal ptasort as Pta, 
				ByVal sorttype as Enumerations.L_SORT_BY, 
				<Out()>  ByRef pval as Single) as Integer


if IsNothing (pta) then Throw New ArgumentNullException  ("pta cannot be Nothing")
	Dim ptasortPtr as IntPtr = IntPtr.Zero : 	If Not IsNothing(ptasort) Then ptasortPtr = ptasort.Pointer

	Dim _Result as Integer = Natives.ptaGetRankValue(pta.Pointer,   fract, ptasortPtr,   sorttype,   pval)
	
	return _Result
End Function

' ptafunc2.c (317, 1)
' ptaUnionByAset(pta1, pta2) as Pta
' ptaUnionByAset(PTA *, PTA *) as PTA *
'''  <summary>
''' (1) See sarrayRemoveDupsByAset() for the approach.<para/>
'''
'''(2) The key is a 64-bit hash from the (x,y) pair.<para/>
'''
'''(3) This is slower than ptaUnionByHash(), mostly because of the
'''nlogn sort to build up the rbtree.  Do not use for large
'''numbers of points (say,  is greater  1M).<para/>
'''
'''(4) The Aset() functions use the sorted l_Aset, which is just
'''an rbtree in disguise.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaUnionByAset/*"/>
'''  <param name="pta1">[in] - </param>
'''  <param name="pta2">[in] - </param>
'''   <returns>ptad with the union of the set of points, or NULL on error</returns>
Public Shared Function ptaUnionByAset(
				ByVal pta1 as Pta, 
				ByVal pta2 as Pta) as Pta


if IsNothing (pta1) then Throw New ArgumentNullException  ("pta1 cannot be Nothing")
		if IsNothing (pta2) then Throw New ArgumentNullException  ("pta2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaUnionByAset(pta1.Pointer, pta2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (354, 1)
' ptaRemoveDupsByAset(ptas) as Pta
' ptaRemoveDupsByAset(PTA *) as PTA *
'''  <summary>
''' (1) This is slower than ptaRemoveDupsByHash(), mostly because
'''of the nlogn sort to build up the rbtree.  Do not use for
'''large numbers of points (say,  is greater  1M).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaRemoveDupsByAset/*"/>
'''  <param name="ptas">[in] - assumed to be integer values</param>
'''   <returns>ptad with duplicates removed, or NULL on error</returns>
Public Shared Function ptaRemoveDupsByAset(
				ByVal ptas as Pta) as Pta


if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaRemoveDupsByAset(ptas.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (401, 1)
' ptaIntersectionByAset(pta1, pta2) as Pta
' ptaIntersectionByAset(PTA *, PTA *) as PTA *
'''  <summary>
''' (1) See sarrayIntersectionByAset() for the approach.<para/>
'''
'''(2) The key is a 64-bit hash from the (x,y) pair.<para/>
'''
'''(3) This is slower than ptaIntersectionByHash(), mostly because
'''of the nlogn sort to build up the rbtree.  Do not use for
'''large numbers of points (say,  is greater  1M).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaIntersectionByAset/*"/>
'''  <param name="pta1">[in] - </param>
'''  <param name="pta2">[in] - </param>
'''   <returns>ptad intersection of the point sets, or NULL on error</returns>
Public Shared Function ptaIntersectionByAset(
				ByVal pta1 as Pta, 
				ByVal pta2 as Pta) as Pta


if IsNothing (pta1) then Throw New ArgumentNullException  ("pta1 cannot be Nothing")
		if IsNothing (pta2) then Throw New ArgumentNullException  ("pta2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaIntersectionByAset(pta1.Pointer, pta2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (451, 1)
' l_asetCreateFromPta(pta) as L_Rbtree
' l_asetCreateFromPta(PTA *) as L_ASET *
'''  <summary>
''' l_asetCreateFromPta()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/l_asetCreateFromPta/*"/>
'''  <param name="pta">[in] - </param>
'''   <returns>set using a 64-bit hash of (x,y) as the key</returns>
Public Shared Function l_asetCreateFromPta(
				ByVal pta as Pta) as L_Rbtree


if IsNothing (pta) then Throw New ArgumentNullException  ("pta cannot be Nothing")
	Dim _Result as IntPtr = Natives.l_asetCreateFromPta(pta.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_Rbtree(_Result)
End Function

' ptafunc2.c (493, 1)
' ptaUnionByHash(pta1, pta2) as Pta
' ptaUnionByHash(PTA *, PTA *) as PTA *
'''  <summary>
''' (1) This is faster than ptaUnionByAset(), because the
'''bucket lookup is O(n).  It should be used if the pts are
'''integers (e.g., representing pixel positions).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaUnionByHash/*"/>
'''  <param name="pta1">[in] - </param>
'''  <param name="pta2">[in] - </param>
'''   <returns>ptad with the union of the set of points, or NULL on error</returns>
Public Shared Function ptaUnionByHash(
				ByVal pta1 as Pta, 
				ByVal pta2 as Pta) as Pta


if IsNothing (pta1) then Throw New ArgumentNullException  ("pta1 cannot be Nothing")
		if IsNothing (pta2) then Throw New ArgumentNullException  ("pta2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaUnionByHash(pta1.Pointer, pta2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (543, 1)
' ptaRemoveDupsByHash(ptas, pptad, pdahash) as Integer
' ptaRemoveDupsByHash(PTA *, PTA **, L_DNAHASH **) as l_ok
'''  <summary>
''' (1) Generates a pta with unique values.<para/>
'''
'''(2) The dnahash is built up with ptad to assure uniqueness.
'''It can be used to find if a point is in the set:
'''ptaFindPtByHash(ptad, dahash, x, y, [and]index)<para/>
'''
'''(3) The hash of the (x,y) location is simple and fast.  It scales
'''up with the number of buckets to insure a fairly random
'''bucket selection for adjacent points.<para/>
'''
'''(4) A Dna is used rather than a Numa because we need accurate
'''representation of 32-bit integers that are indices into ptas.
'''Integer to float to integer conversion makes errors for
'''integers larger than 10M.<para/>
'''
'''(5) This is faster than ptaRemoveDupsByAset(), because the
'''bucket lookup is O(n), although there is a double-loop
'''lookup within the dna in each bucket.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaRemoveDupsByHash/*"/>
'''  <param name="ptas">[in] - assumed to be integer values</param>
'''  <param name="pptad">[out] - unique set of pts duplicates removed</param>
'''  <param name="pdahash">[out][optional] - dnahash used for lookup</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function ptaRemoveDupsByHash(
				ByVal ptas as Pta, 
				<Out()>  ByRef pptad as Pta, 
				<Out()> Optional  ByRef pdahash as L_DnaHash = Nothing) as Integer


if IsNothing (ptas) then Throw New ArgumentNullException  ("ptas cannot be Nothing")
	Dim pptadPtr as IntPtr = IntPtr.Zero
	Dim pdahashPtr as IntPtr = IntPtr.Zero

	Dim _Result as Integer = Natives.ptaRemoveDupsByHash(ptas.Pointer, pptadPtr, pdahashPtr)
	
	if pptadPtr = IntPtr.Zero then pptad = Nothing else pptad = new Pta(pptadPtr)
	if pdahashPtr = IntPtr.Zero then pdahash = Nothing else pdahash = new L_DnaHash(pdahashPtr)
	return _Result
End Function

' ptafunc2.c (600, 1)
' ptaIntersectionByHash(pta1, pta2) as Pta
' ptaIntersectionByHash(PTA *, PTA *) as PTA *
'''  <summary>
''' (1) This is faster than ptaIntersectionByAset(), because the
'''bucket lookup is O(n).  It should be used if the pts are
'''integers (e.g., representing pixel positions).
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaIntersectionByHash/*"/>
'''  <param name="pta1">[in] - </param>
'''  <param name="pta2">[in] - </param>
'''   <returns>ptad intersection of the point sets, or NULL on error</returns>
Public Shared Function ptaIntersectionByHash(
				ByVal pta1 as Pta, 
				ByVal pta2 as Pta) as Pta


if IsNothing (pta1) then Throw New ArgumentNullException  ("pta1 cannot be Nothing")
		if IsNothing (pta2) then Throw New ArgumentNullException  ("pta2 cannot be Nothing")
	Dim _Result as IntPtr = Natives.ptaIntersectionByHash(pta1.Pointer, pta2.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new Pta(_Result)
End Function

' ptafunc2.c (674, 1)
' ptaFindPtByHash(pta, dahash, x, y, pindex) as Integer
' ptaFindPtByHash(PTA *, L_DNAHASH *, l_int32, l_int32, l_int32 *) as l_ok
'''  <summary>
''' (1) Fast lookup in dnaHash associated with a pta, to see if a
'''random point (x,y) is already stored in the hash table.<para/>
'''
'''(2) We use a strong hash function to minimize the chance that
'''two different points hash to the same key value.<para/>
'''
'''(3) We select the number of buckets to be about 5% of the size
'''of the input %pta, so that when fully populated, each
'''bucket (dna) will have about 20 entries, each being an index
'''into %pta.  In lookup, after hashing to the key, and then
'''again to the bucket, we traverse the bucket (dna), using the
'''index into %pta to check if the point (x,y) has been found before.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/ptaFindPtByHash/*"/>
'''  <param name="pta">[in] - </param>
'''  <param name="dahash">[in] - built from pta</param>
'''  <param name="x">[in] - arbitrary points</param>
'''  <param name="y">[in] - arbitrary points</param>
'''  <param name="pindex">[out] - index into pta if (x,y) is in pta -1 otherwise</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function ptaFindPtByHash(
				ByVal pta as Pta, 
				ByVal dahash as L_DnaHash, 
				ByVal x as Integer, 
				ByVal y as Integer, 
				<Out()>  ByRef pindex as Integer) as Integer


if IsNothing (pta) then Throw New ArgumentNullException  ("pta cannot be Nothing")
		if IsNothing (dahash) then Throw New ArgumentNullException  ("dahash cannot be Nothing")
	Dim _Result as Integer = Natives.ptaFindPtByHash(pta.Pointer, dahash.Pointer,   x,   y,   pindex)
	
	return _Result
End Function

' ptafunc2.c (720, 1)
' l_dnaHashCreateFromPta(pta) as L_DnaHash
' l_dnaHashCreateFromPta(PTA *) as L_DNAHASH *
'''  <summary>
''' l_dnaHashCreateFromPta()
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/l_dnaHashCreateFromPta/*"/>
'''  <param name="pta">[in] - </param>
'''   <returns>dahash, or NULL on error</returns>
Public Shared Function l_dnaHashCreateFromPta(
				ByVal pta as Pta) as L_DnaHash


if IsNothing (pta) then Throw New ArgumentNullException  ("pta cannot be Nothing")
	Dim _Result as IntPtr = Natives.l_dnaHashCreateFromPta(pta.Pointer)
	
	If _Result = IntPtr.Zero then Return Nothing
	return  new L_DnaHash(_Result)
End Function

End Class



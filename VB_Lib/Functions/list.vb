Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _All

' SRC\list.c (236, 1)
' listDestroy(phead) as Object
' listDestroy(DLLIST **) as void
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This only destroys the cons cells.  Before destroying
''' the list, it is necessary to remove all data and set the
''' data pointers in each cons cell to NULL.<para/>
''' 
''' (2) listDestroy() will give a warning message for each data
''' ptr that is not NULL.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listDestroy/*"/>
'''  <param name="phead">[in,out] - to be nulled head of list</param>
Public Shared Sub listDestroy(
				 ByRef phead as DoubleLinkedList)

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer

	LeptonicaSharp.Natives.listDestroy( pheadPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

End Sub

' SRC\list.c (277, 1)
' listAddToHead(phead, data) as Integer
' listAddToHead(DLLIST **, void *) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This makes a new cell, attaches the data, and adds the
''' cell to the head of the list.<para/>
''' 
''' (2) When consing from NULL, be sure to initialize head to NULL
''' before calling this function.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listAddToHead/*"/>
'''  <param name="phead">[in,out][optional] - input head</param>
'''  <param name="data">[in] - void ptr, to be added</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function listAddToHead(
				 ByRef phead as DoubleLinkedList, 
				 ByVal data as Object) as Integer

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")

Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer
	Dim dataPtr As IntPtr = IntPtr.Zero
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

	Dim _Result as Integer = LeptonicaSharp.Natives.listAddToHead( pheadPTR, dataPTR)
Marshal.FreeHGlobal(dataPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return _Result
End Function

' SRC\list.c (331, 1)
' listAddToTail(phead, ptail, data) as Integer
' listAddToTail(DLLIST **, DLLIST **, void *) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This makes a new cell, attaches the data, and adds the
''' cell to the tail of the list.<para/>
''' 
''' (2) [and]head is input to allow the list to be "cons'd" up from NULL.<para/>
''' 
''' (3) [and]tail is input to allow the tail to be updated
''' for efficient sequential operation with this function.<para/>
''' 
''' (4) We assume that if phead and/or ptail are not NULL,
''' then they are valid addresses.  Therefore:
''' (a) when consing from NULL, be sure to initialize both
''' head and tail to NULL.
''' (b) when tail == NULL for an existing list, the tail
''' will be found and updated.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listAddToTail/*"/>
'''  <param name="phead">[in,out] - [may be updated], can be NULL</param>
'''  <param name="ptail">[in,out] - [updated], can be NULL</param>
'''  <param name="data">[in] - void ptr, to be hung on tail cons cell</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function listAddToTail(
				 ByRef phead as DoubleLinkedList, 
				 ByRef ptail as DoubleLinkedList, 
				 ByVal data as Object) as Integer

	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer
	Dim ptailPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ptail) Then ptailPTR = ptail.Pointer
	Dim dataPtr As IntPtr = IntPtr.Zero
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

	Dim _Result as Integer = LeptonicaSharp.Natives.listAddToTail( pheadPTR, ptailPTR, dataPTR)
Marshal.FreeHGlobal(dataPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)
If ptailPTR = IntPtr.Zero Then ptail = Nothing
If ptailPTR <> IntPtr.Zero Then ptail = New DoubleLinkedList(ptailPTR)

	Return _Result
End Function

' SRC\list.c (394, 1)
' listInsertBefore(phead, elem, data) as Integer
' listInsertBefore(DLLIST **, DLLIST *, void *) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This can be called on a null list, in which case both
''' head and elem must be null.<para/>
''' 
''' (2) If you are searching through a list, looking for a condition
''' to add an element, you can do something like this:
''' \code
''' L_BEGIN_LIST_FORWARD(head, elem)
'''  is smalleridentify an elem to insert before is greater 
''' listInsertBefore([and]head, elem, data)
''' L_END_LIST
''' \endcode
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listInsertBefore/*"/>
'''  <param name="phead">[in,out][optional] - input head</param>
'''  <param name="elem">[in] - list element to be inserted in front of must be NULL if head is NULL</param>
'''  <param name="data">[in] - void  address, to be added</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function listInsertBefore(
				 ByRef phead as DoubleLinkedList, 
				 ByVal elem as DoubleLinkedList, 
				 ByVal data as Object) as Integer

	If IsNothing (elem) then Throw New ArgumentNullException  ("elem cannot be Nothing")
	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")

Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer
	Dim dataPtr As IntPtr = IntPtr.Zero
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

	Dim _Result as Integer = LeptonicaSharp.Natives.listInsertBefore( pheadPTR, elem.Pointer, dataPTR)
Marshal.FreeHGlobal(dataPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return _Result
End Function

' SRC\list.c (459, 1)
' listInsertAfter(phead, elem, data) as Integer
' listInsertAfter(DLLIST **, DLLIST *, void *) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This can be called on a null list, in which case both
''' head and elem must be null.  The head is included
''' in the call to allow "consing" up from NULL.<para/>
''' 
''' (2) If you are searching through a list, looking for a condition
''' to add an element, you can do something like this:
''' \code
''' L_BEGIN_LIST_FORWARD(head, elem)
'''  is smalleridentify an elem to insert after is greater 
''' listInsertAfter([and]head, elem, data)
''' L_END_LIST
''' \endcode
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listInsertAfter/*"/>
'''  <param name="phead">[in,out][optional] - input head</param>
'''  <param name="elem">[in] - list element to be inserted after must be NULL if head is NULL</param>
'''  <param name="data">[in] - void  ptr, to be added</param>
'''   <returns>0 if OK 1 on error</returns>
Public Shared Function listInsertAfter(
				 ByRef phead as DoubleLinkedList, 
				 ByVal elem as DoubleLinkedList, 
				 ByVal data as Object) as Integer

	If IsNothing (elem) then Throw New ArgumentNullException  ("elem cannot be Nothing")
	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")

Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer
	Dim dataPtr As IntPtr = IntPtr.Zero
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

	Dim _Result as Integer = LeptonicaSharp.Natives.listInsertAfter( pheadPTR, elem.Pointer, dataPTR)
Marshal.FreeHGlobal(dataPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return _Result
End Function

' SRC\list.c (514, 1)
' listRemoveElement(phead, elem) as Object
' listRemoveElement(DLLIST **, DLLIST *) as void *
'''  <summary>
''' Notes:<para/>
''' 
''' (1) in ANSI C, it is not necessary to cast return to actual type e.g.,
''' pix = listRemoveElement([and]head, elem)
''' but in ANSI C++, it is necessary to do the cast:
''' pix = (Pix )listRemoveElement([and]head, elem)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listRemoveElement/*"/>
'''  <param name="phead">[in,out] - [can be changed] input head</param>
'''  <param name="elem">[in] - list element to be removed</param>
'''   <returns>data  void struct on cell</returns>
Public Shared Function listRemoveElement(
				 ByRef phead as DoubleLinkedList, 
				 ByVal elem as DoubleLinkedList) as Object

	If IsNothing (elem) then Throw New ArgumentNullException  ("elem cannot be Nothing")

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.listRemoveElement( pheadPTR, elem.Pointer)

	Dim B(1) As Byte : Marshal.Copy(_Result, B, 0, B.Length)
If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return B
End Function

' SRC\list.c (566, 1)
' listRemoveFromHead(phead) as Object
' listRemoveFromHead(DLLIST **) as void *
'''  <summary>
''' Notes:<para/>
''' 
''' (1) in ANSI C, it is not necessary to cast return to actual type e.g.,
''' pix = listRemoveFromHead([and]head)
''' but in ANSI C++, it is necessary to do the cast e.g.,
''' pix = (Pix )listRemoveFromHead([and]head)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listRemoveFromHead/*"/>
'''  <param name="phead">[in,out] - head of list [to be updated]</param>
'''   <returns>data  void struct on cell, or NULL on error</returns>
Public Shared Function listRemoveFromHead(
				 ByRef phead as DoubleLinkedList) as Object

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.listRemoveFromHead( pheadPTR)

	Dim B(1) As Byte : Marshal.Copy(_Result, B, 0, B.Length)
If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return B
End Function

' SRC\list.c (614, 1)
' listRemoveFromTail(phead, ptail) as Object
' listRemoveFromTail(DLLIST **, DLLIST **) as void *
'''  <summary>
''' Notes:<para/>
''' 
''' (1) We include [and]head so that it can be set to NULL if
''' if the only element in the list is removed.<para/>
''' 
''' (2) The function is relying on the fact that if tail is
''' not NULL, then is is a valid address.  You can use
''' this function with tail == NULL for an existing list, in
''' which case  the tail is found and updated, and the
''' removed element is returned.<para/>
''' 
''' (3) In ANSI C, it is not necessary to cast return to actual type e.g.,
''' pix = listRemoveFromTail([and]head, [and]tail)
''' but in ANSI C++, it is necessary to do the cast e.g.,
''' pix = (Pix )listRemoveFromTail([and]head, [and]tail)
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listRemoveFromTail/*"/>
'''  <param name="phead">[in,out] - [may be changed], head must NOT be NULL</param>
'''  <param name="ptail">[in,out] - [always updated], tail may be NULL</param>
'''   <returns>data  void struct on cell or NULL on error</returns>
Public Shared Function listRemoveFromTail(
				 ByRef phead as DoubleLinkedList, 
				 ByRef ptail as DoubleLinkedList) as Object

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer
	Dim ptailPTR As IntPtr = IntPtr.Zero : If Not IsNothing(ptail) Then ptailPTR = ptail.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.listRemoveFromTail( pheadPTR, ptailPTR)

	Dim B(1) As Byte : Marshal.Copy(_Result, B, 0, B.Length)
If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)
If ptailPTR = IntPtr.Zero Then ptail = Nothing
If ptailPTR <> IntPtr.Zero Then ptail = New DoubleLinkedList(ptailPTR)

	Return B
End Function

' SRC\list.c (668, 1)
' listFindElement(head, data) as DoubleLinkedList
' listFindElement(DLLIST *, void *) as DLLIST *
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This returns a ptr to the cell, which is still embedded in
''' the list.<para/>
''' 
''' (2) This handle and the attached data have not been copied or
''' reference counted, so they must not be destroyed.  This
''' violates our basic rule that every handle returned from a
''' function is owned by that function and must be destroyed,
''' but if rules aren't there to be broken, why have them?
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listFindElement/*"/>
'''  <param name="head">[in] - list head</param>
'''  <param name="data">[in] - void  address, to be searched for</param>
'''   <returns>cell  the containing cell, or NULL if not found or on error</returns>
Public Shared Function listFindElement(
				 ByVal head as DoubleLinkedList, 
				 ByVal data as Object) as DoubleLinkedList

	If IsNothing (head) then Throw New ArgumentNullException  ("head cannot be Nothing")
	If IsNothing (data) then Throw New ArgumentNullException  ("data cannot be Nothing")

	Dim dataPtr As IntPtr = IntPtr.Zero
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

	Dim _Result as IntPtr = LeptonicaSharp.Natives.listFindElement( head.Pointer, dataPTR)
Marshal.FreeHGlobal(dataPTR)

	If  _Result = IntPtr.Zero then Return Nothing

	Return  new DoubleLinkedList(_Result)
End Function

' SRC\list.c (696, 1)
' listFindTail(head) as DoubleLinkedList
' listFindTail(DLLIST *) as DLLIST *
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listFindTail/*"/>
'''  <param name="head">[in] - </param>
'''   <returns>tail, or NULL on error</returns>
Public Shared Function listFindTail(
				 ByVal head as DoubleLinkedList) as DoubleLinkedList

	If IsNothing (head) then Throw New ArgumentNullException  ("head cannot be Nothing")

	Dim _Result as IntPtr = LeptonicaSharp.Natives.listFindTail( head.Pointer)

	If  _Result = IntPtr.Zero then Return Nothing

	Return  new DoubleLinkedList(_Result)
End Function

' SRC\list.c (721, 1)
' listGetCount(head) as Integer
' listGetCount(DLLIST *) as l_int32
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listGetCount/*"/>
'''  <param name="head">[in] - of list</param>
'''   <returns>number of elements 0 if no list or on error</returns>
Public Shared Function listGetCount(
				 ByVal head as DoubleLinkedList) as Integer

	If IsNothing (head) then Throw New ArgumentNullException  ("head cannot be Nothing")

	Dim _Result as Integer = LeptonicaSharp.Natives.listGetCount( head.Pointer)


	Return _Result
End Function

' SRC\list.c (751, 1)
' listReverse(phead) as Integer
' listReverse(DLLIST **) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) This reverses the list in-place.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listReverse/*"/>
'''  <param name="phead">[in,out] - [may be changed] list head</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function listReverse(
				 ByRef phead as DoubleLinkedList) as Integer

	Dim pheadPTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead) Then pheadPTR = phead.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.listReverse( pheadPTR)

If pheadPTR = IntPtr.Zero Then phead = Nothing
If pheadPTR <> IntPtr.Zero Then phead = New DoubleLinkedList(pheadPTR)

	Return _Result
End Function

' SRC\list.c (788, 1)
' listJoin(phead1, phead2) as Integer
' listJoin(DLLIST **, DLLIST **) as l_ok
'''  <summary>
''' Notes:<para/>
''' 
''' (1) The concatenated list is returned with head1 as the new head.<para/>
''' 
''' (2) Both input ptrs must exist, though either can have the value NULL.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <include file="..\CHM_Help\IncludeComments.xml" path="Comments/listJoin/*"/>
'''  <param name="phead1">[in,out] - [may be changed] head of first list</param>
'''  <param name="phead2">[in,out] - to be nulled head of second list</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function listJoin(
				 ByRef phead1 as DoubleLinkedList, 
				 ByRef phead2 as DoubleLinkedList) as Integer

	Dim phead1PTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead1) Then phead1PTR = phead1.Pointer
	Dim phead2PTR As IntPtr = IntPtr.Zero : If Not IsNothing(phead2) Then phead2PTR = phead2.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.listJoin( phead1PTR, phead2PTR)

If phead1PTR = IntPtr.Zero Then phead1 = Nothing
If phead1PTR <> IntPtr.Zero Then phead1 = New DoubleLinkedList(phead1PTR)
If phead2PTR = IntPtr.Zero Then phead2 = Nothing
If phead2PTR <> IntPtr.Zero Then phead2 = New DoubleLinkedList(phead2PTR)

	Return _Result
End Function

End Class

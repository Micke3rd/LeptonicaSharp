Imports System.Runtime.InteropServices
Imports LeptonicaSharp.Enumerations
Partial Public Class _AllFunctions


' SRC\textops.c (115, 1)
' pixAddSingleTextblock()
' pixAddSingleTextblock(PIX *, L_BMF *, const char *, l_uint32, l_int32, l_int32 *) as PIX *
'''  <summary>
''' Notes
''' (1) This function paints a set of lines of text over an image.
''' If %location is L_ADD_ABOVE or L_ADD_BELOW, the pix size
''' is expanded with a border and rendered over the border.
''' (2) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' (3) If textstr == NULL, use the text field in the pix.
''' (4) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
''' (5) Typical usage is for labelling a pix with some text data.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input pix; colormap ok</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="textstr">[in][optional] - text string to be added</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="location">[in] - L_ADD_ABOVE, L_ADD_AT_TOP, L_ADD_AT_BOT, L_ADD_BELOW</param>
'''  <param name="poverflow">[out][optional] - 1 if text overflows allocated region and is clipped; 0 otherwise</param>
'''   <returns>pixd new pix with rendered text, or either a copy or NULL on error</returns>
Public Shared Function pixAddSingleTextblock(
				ByVal pixs as Pix, 
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal val as UInteger, 
				ByVal location as Enumerations.L_ADD, 
				ByRef poverflow as Integer) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixAddSingleTextblock( pixs.Pointer, bmf.Pointer, textstr, val, location, poverflow)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\textops.c (270, 1)
' pixAddTextlines()
' pixAddTextlines(PIX *, L_BMF *, const char *, l_uint32, l_int32) as PIX *
'''  <summary>
''' Notes
''' (1) This function expands an image as required to paint one or
''' more lines of text adjacent to the image.  If %bmf == NULL,
''' this returns a copy.  If above or below, the lines are
''' centered with respect to the image; if left or right, they
''' are left justified.
''' (2) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' (3) If textstr == NULL, use the text field in the pix.  The
''' text field contains one or most "lines" of text, where newlines
''' are used as line separators.
''' (4) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
''' (5) Typical usage is for labelling a pix with some text data.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input pix; colormap ok</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="textstr">[in][optional] - text string to be added</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="location">[in] - L_ADD_ABOVE, L_ADD_BELOW, L_ADD_LEFT, L_ADD_RIGHT</param>
'''   <returns>pixd new pix with rendered text, or either a copy or NULL on error</returns>
Public Shared Function pixAddTextlines(
				ByVal pixs as Pix, 
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal val as UInteger, 
				ByVal location as Enumerations.L_ADD) as Pix

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixAddTextlines( pixs.Pointer, bmf.Pointer, textstr, val, location)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pix(_Result)
End Function

' SRC\textops.c (431, 1)
' pixSetTextblock()
' pixSetTextblock(PIX *, L_BMF *, const char *, l_uint32, l_int32, l_int32, l_int32, l_int32, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) This function paints a set of lines of text over an image.
''' (2) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' The last two hex digits are 00 (byte value 0), assigned to
''' the A component.  Note that, as usual, RGBA proceeds from
''' left to right in the order from MSB to LSB (see pix.h
''' for details).
''' (3) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input image</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="textstr">[in] - block text string to be set</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="x0">[in] - left edge for each line of text</param>
'''  <param name="y0">[in] - baseline location for the first text line</param>
'''  <param name="wtext">[in] - max width of each line of generated text</param>
'''  <param name="firstindent">[in] - indentation of first line, in x-widths</param>
'''  <param name="poverflow">[out][optional] - 0 if text is contained in input pix; 1 if it is clipped</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixSetTextblock(
				ByVal pixs as Pix, 
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal val as UInteger, 
				ByVal x0 as Integer, 
				ByVal y0 as Integer, 
				ByVal wtext as Integer, 
				ByVal firstindent as Integer, 
				ByRef poverflow as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixSetTextblock( pixs.Pointer, bmf.Pointer, textstr, val, x0, y0, wtext, firstindent, poverflow)

	Return _Result
End Function

' SRC\textops.c (544, 1)
' pixSetTextline()
' pixSetTextline(PIX *, L_BMF *, const char *, l_uint32, l_int32, l_int32, l_int32 *, l_int32 *) as l_ok
'''  <summary>
''' Notes
''' (1) This function paints a line of text over an image.
''' (2) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' The last two hex digits are 00 (byte value 0), assigned to
''' the A component.  Note that, as usual, RGBA proceeds from
''' left to right in the order from MSB to LSB (see pix.h
''' for details).
''' (3) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixs">[in] - input image</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="textstr">[in] - text string to be set on the line</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="x0">[in] - left edge for first char</param>
'''  <param name="y0">[in] - baseline location for all text on line</param>
'''  <param name="pwidth">[out][optional] - width of generated text</param>
'''  <param name="poverflow">[out][optional] - 0 if text is contained in input pix; 1 if it is clipped</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function pixSetTextline(
				ByVal pixs as Pix, 
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal val as UInteger, 
				ByVal x0 as Integer, 
				ByVal y0 as Integer, 
				ByRef pwidth as Integer, 
				ByRef poverflow as Integer) as Integer

	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.pixSetTextline( pixs.Pointer, bmf.Pointer, textstr, val, x0, y0, pwidth, poverflow)

	Return _Result
End Function

' SRC\textops.c (641, 1)
' pixaAddTextNumber()
' pixaAddTextNumber(PIXA *, L_BMF *, NUMA *, l_uint32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) Typical usage is for labelling each pix in a pixa with a number.
''' (2) This function paints numbers external to each pix, in a position
''' given by %location.  In all cases, the pix is expanded on
''' on side and the number is painted over white in the added region.
''' (3) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' (4) If na == NULL, number each pix sequentially, starting with 1.
''' (5) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - input pixa; colormap ok</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="na">[in][optional] - number array; use 1 ... n if null</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="location">[in] - L_ADD_ABOVE, L_ADD_BELOW, L_ADD_LEFT, L_ADD_RIGHT</param>
'''   <returns>pixad new pixa with rendered numbers, or NULL on error</returns>
Public Shared Function pixaAddTextNumber(
				ByVal pixas as Pixa, 
				ByVal bmf as L_Bmf, 
				ByVal na as Numa, 
				ByVal val as UInteger, 
				ByVal location as Enumerations.L_ADD) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")

	Dim naPTR As IntPtr = IntPtr.Zero : If Not IsNothing(na) Then naPTR = na.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaAddTextNumber( pixas.Pointer, bmf.Pointer, naPTR, val, location)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\textops.c (710, 1)
' pixaAddTextlines()
' pixaAddTextlines(PIXA *, L_BMF *, SARRAY *, l_uint32, l_int32) as PIXA *
'''  <summary>
''' Notes
''' (1) This function adds one or more lines of text externally to
''' each pix, in a position given by %location.  In all cases,
''' the pix is expanded as necessary to accommodate the text.
''' (2) %val is the pixel value to be painted through the font mask.
''' It should be chosen to agree with the depth of pixs.
''' If it is out of bounds, an intermediate value is chosen.
''' For RGB, use hex notation 0xRRGGBB00, where RR is the
''' hex representation of the red intensity, etc.
''' (3) If sa == NULL, use the text embedded in each pix.  In all
''' cases, newlines in the text string are used to separate the
''' lines of text that are added to the pix.
''' (4) If sa has a smaller count than pixa, issue a warning
''' and do not use any embedded text.
''' (5) If there is a colormap, this does the best it can to use
''' the requested color, or something similar to it.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixas">[in] - input pixa; colormap ok</param>
'''  <param name="bmf">[in] - bitmap font data</param>
'''  <param name="sa">[in][optional] - sarray; use text embedded in each pix if null</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="location">[in] - L_ADD_ABOVE, L_ADD_BELOW, L_ADD_LEFT, L_ADD_RIGHT</param>
'''   <returns>pixad new pixa with rendered text, or NULL on error</returns>
Public Shared Function pixaAddTextlines(
				ByVal pixas as Pixa, 
				ByVal bmf as L_Bmf, 
				ByVal sa as Sarray, 
				ByVal val as UInteger, 
				ByVal location as Enumerations.L_ADD) as Pixa

	If IsNothing (pixas) then Throw New ArgumentNullException  ("pixas cannot be Nothing")
	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")

	Dim saPTR As IntPtr = IntPtr.Zero : If Not IsNothing(sa) Then saPTR = sa.Pointer

	Dim _Result as IntPtr = LeptonicaSharp.Natives.pixaAddTextlines( pixas.Pointer, bmf.Pointer, saPTR, val, location)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Pixa(_Result)
End Function

' SRC\textops.c (780, 1)
' pixaAddPixWithText()
' pixaAddPixWithText(PIXA *, PIX *, l_int32, L_BMF *, const char *, l_uint32, l_int32) as l_ok
'''  <summary>
''' Notes
''' (1) This function generates a new pix with added text, and adds
''' it by insertion into the pixa.
''' (2) If the input pixs is not cmapped and not 32 bpp, it is
''' converted to 32 bpp rgb.  %val is a standard 32 bpp pixel,
''' expressed as 0xrrggbb00.  If there is a colormap, this does
''' the best it can to use the requested color, or something close.
''' (3) if %bmf == NULL, generate an 8 pt font; this takes about 5 msec.
''' (4) If %textstr == NULL, use the text field in the pix.
''' (5) In general, the text string can be written in multiple lines;
''' use newlines as the separators.
''' (6) Typical usage is for debugging, where the pixa of labeled images
''' is used to generate a pdf.  Suggest using 1.0 for scalefactor.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="pixa">[in] - </param>
'''  <param name="pixs">[in] - any depth, colormap ok</param>
'''  <param name="reduction">[in] - integer subsampling factor</param>
'''  <param name="bmf">[in][optional] - bitmap font data</param>
'''  <param name="textstr">[in][optional] - text string to be added</param>
'''  <param name="val">[in] - color to set the text</param>
'''  <param name="location">[in] - L_ADD_ABOVE, L_ADD_BELOW, L_ADD_LEFT, L_ADD_RIGHT</param>
'''   <returns>0 if OK, 1 on error.</returns>
Public Shared Function pixaAddPixWithText(
				ByVal pixa as Pixa, 
				ByVal pixs as Pix, 
				ByVal reduction as Integer, 
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal val as UInteger, 
				ByVal location as Enumerations.L_ADD) as Integer

	If IsNothing (pixa) then Throw New ArgumentNullException  ("pixa cannot be Nothing")
	If IsNothing (pixs) then Throw New ArgumentNullException  ("pixs cannot be Nothing")
	If reduction > 2 and reduction < 16 then Throw New ArgumentException ("integer subsampling factor")

	Dim bmfPTR As IntPtr = IntPtr.Zero : If Not IsNothing(bmf) Then bmfPTR = bmf.Pointer

	Dim _Result as Integer = LeptonicaSharp.Natives.pixaAddPixWithText( pixa.Pointer, pixs.Pointer, reduction, bmfPTR, textstr, val, location)

	Return _Result
End Function

' SRC\textops.c (862, 1)
' bmfGetLineStrings()
' bmfGetLineStrings(L_BMF *, const char *, l_int32, l_int32, l_int32 *) as SARRAY *
'''  <summary>
''' Notes
''' (1) Divides the input text string into an array of text strings,
''' each of which will fit within maxw bits of width.
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="textstr">[in] - </param>
'''  <param name="maxw">[in] - max width of a text line in pixels</param>
'''  <param name="firstindent">[in] - indentation of first line, in x-widths</param>
'''  <param name="ph">[out] - height required to hold text bitmap</param>
'''   <returns>sarray of text strings for each line, or NULL on error</returns>
Public Shared Function bmfGetLineStrings(
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal maxw as Integer, 
				ByVal firstindent as Integer, 
				ByRef ph as Integer) as Sarray

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.bmfGetLineStrings( bmf.Pointer, textstr, maxw, firstindent, ph)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

' SRC\textops.c (938, 1)
' bmfGetWordWidths()
' bmfGetWordWidths(L_BMF *, const char *, SARRAY *) as NUMA *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="textstr">[in] - </param>
'''  <param name="sa">[in] - of individual words</param>
'''   <returns>numa of word lengths in pixels for the font represented by the bmf, or NULL on error</returns>
Public Shared Function bmfGetWordWidths(
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByVal sa as Sarray) as Numa

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")
	If IsNothing (sa) then Throw New ArgumentNullException  ("sa cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.bmfGetWordWidths( bmf.Pointer, textstr, sa.Pointer)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Numa(_Result)
End Function

' SRC\textops.c (979, 1)
' bmfGetStringWidth()
' bmfGetStringWidth(L_BMF *, const char *, l_int32 *) as l_ok
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="bmf">[in] - </param>
'''  <param name="textstr">[in] - </param>
'''  <param name="pw">[out] - width of text string, in pixels for the font represented by the bmf</param>
'''   <returns>0 if OK, 1 on error</returns>
Public Shared Function bmfGetStringWidth(
				ByVal bmf as L_Bmf, 
				ByVal textstr as String, 
				ByRef pw as Integer) as Integer

	If IsNothing (bmf) then Throw New ArgumentNullException  ("bmf cannot be Nothing")
	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")


	Dim _Result as Integer = LeptonicaSharp.Natives.bmfGetStringWidth( bmf.Pointer, textstr, pw)

	Return _Result
End Function

' SRC\textops.c (1023, 1)
' splitStringToParagraphs()
' splitStringToParagraphs(char *, l_int32) as SARRAY *
'''  <summary>
''' 
'''  </summary>
'''  <remarks>
'''  </remarks>
'''  <param name="textstr">[in] - text string</param>
'''  <param name="splitflag">[in] - see enum in bmf.h; valid values in {1,2,3}</param>
'''   <returns>sarray where each string is a paragraph of the input, or NULL on error.</returns>
Public Shared Function splitStringToParagraphs(
				ByVal textstr as String, 
				ByVal splitflag as Integer) as Sarray

	If IsNothing (textstr) then Throw New ArgumentNullException  ("textstr cannot be Nothing")


	Dim _Result as IntPtr = LeptonicaSharp.Natives.splitStringToParagraphs( textstr, splitflag)
	If  _Result = IntPtr.Zero then Return Nothing

	Return  new Sarray(_Result)
End Function

End Class

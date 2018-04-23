Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Text
Imports DevExpress.Utils.Drawing

Namespace DXSample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class MyLabel
		Inherits LabelControl

		Public Sub New()
			MyBase.New()
			SetStyle(ControlStyles.Selectable, True)
			endX = invalidEndIndex
			startX = invalidStartIndex
			ProcessSelection()
		End Sub

		Private startX, endX As Integer
		Private Const invalidStartIndex As Integer = -999
		Private Const invalidEndIndex As Integer = -998

		Private containsIndex_Renamed As Integer = -1

		Private Property ContainsIndex() As Integer
			Get
				Return containsIndex_Renamed
			End Get
			Set(ByVal value As Integer)
				containsIndex_Renamed = value
			End Set
		End Property
		Private selectedText_Renamed As String = String.Empty

		Private Property SelectedText() As String
			Get
				Return selectedText_Renamed
			End Get
			Set(ByVal value As String)
				selectedText_Renamed = value
			End Set
		End Property


		Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
			MyBase.OnMouseDown(e)
			If e.Button = MouseButtons.Left Then
				isMouseDowm = True
				startX = e.X
				endX = e.X
				ProcessSelection()
				Invalidate()
			End If
		End Sub
		Private isMouseDowm As Boolean = False
		Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
			MyBase.OnMouseMove(e)
			If isMouseDowm Then
				If (Not ClientRectangle.Contains(e.Location)) Then
					Return
				End If
				endX = e.X
				ProcessSelection()
				Invalidate()
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
			MyBase.OnMouseUp(e)
			ProcessSelection()
			isMouseDowm = False
		End Sub

		Protected Sub ProcessSelection()

			Dim startIndex As Integer = GetIndex(startX)
			Dim lastIndex As Integer = GetIndex(endX)
			If startX = invalidStartIndex OrElse endX = invalidEndIndex Then
				SelectedText = String.Empty
				ContainsIndex = -1

			ElseIf startIndex = lastIndex Then
				ContainsIndex = startIndex
				SelectedText = Text(startIndex).ToString()
			ElseIf startIndex < lastIndex Then
				ContainsIndex = startIndex
				SelectedText = Text.Substring(startIndex, lastIndex - startIndex + 1)
			Else
				ContainsIndex = lastIndex
				SelectedText = Text.Substring(lastIndex, startIndex - lastIndex + 1)
			End If
		End Sub

		Protected Function GetCharWidths() As Integer()
			Dim info As New GraphicsInfo()
			info.AddGraphics(Nothing)
			Dim widths() As Integer = TextUtils.GetMeasureString(info.Graphics, Text, Appearance.Font)
			info.ReleaseGraphics()
			Return widths
		End Function

		Private Function GetIndex(ByVal x As Integer) As Integer
			Dim widths() As Integer = GetCharWidths()
			Dim n As Integer = 0, i As Integer = -1
			Do While n <= x
				If i = (widths.Length - 1) Then
					Return i
				End If
				i += 1
				n += widths(i)
			Loop
			Return i
		End Function

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			MyBase.OnPaint(e)
			Dim foreColor As Color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.HighlightText)
			Dim backColor As Color = DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(LookAndFeel, SystemColors.Highlight)
			Using cache As New GraphicsCache(e)
				cache.Paint.DrawMultiColorString(cache, ClientRectangle, Text, SelectedText, Appearance, foreColor, backColor, False, ContainsIndex)
			End Using
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
			MyBase.OnKeyDown(e)
			Clipboard.SetDataObject(SelectedText, True)
		End Sub
	End Class
End Namespace

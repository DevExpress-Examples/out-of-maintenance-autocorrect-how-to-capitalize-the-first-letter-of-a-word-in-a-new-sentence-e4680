Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit

Namespace RichEditCapitalization
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub richEditControl1_AutoCorrect(ByVal sender As Object, ByVal e As AutoCorrectEventArgs) Handles richEditControl1.AutoCorrect
			Dim info As AutoCorrectInfo = e.AutoCorrectInfo
			e.AutoCorrectInfo = Nothing
			Dim count As Integer = 0

			If info.Text.Length <= 0 Then
				Return
			End If

			If Char.IsLetter(info.Text(0)) Then
				Dim replace As String = Char.ToUpper(info.Text(0)).ToString()

				Do
					If (Not info.DecrementStartPosition()) Then
						Exit Do
					End If

					count += 1

					If (Not Char.IsWhiteSpace(info.Text(0))) Then
						If info.Text(0) = "."c Then
							Exit Do
						End If

						Return
					End If
				Loop

				info.ReplaceWith = replace
				e.AutoCorrectInfo = info
			End If

			For i As Integer = 0 To count - 1
				info.IncrementStartPosition()
			Next i
		End Sub
	End Class
End Namespace
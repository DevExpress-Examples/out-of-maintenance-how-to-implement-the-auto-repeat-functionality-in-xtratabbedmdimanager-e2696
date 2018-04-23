Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraTabbedMdi
Imports DevExpress.Utils.Controls
Imports DevExpress.Utils

Namespace WindowsApplication1
	Public Class MyXtraTabbedMdiManager
		Inherits XtraTabbedMdiManager

		Public Sub New()
			timer.Interval = 500
			AddHandler timer.Tick, AddressOf timer_Tick
		End Sub

		Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			Dim mousePosition As Point = ViewInfo.TabControl.ScreenPointToControl(Control.MousePosition)
			If InButtons(mousePosition) Then
				ViewInfo.HeaderInfo.Buttons.ProcessEvent(New ProcessEventEventArgs(EventType.MouseDown, New DXMouseEventArgs(MouseButtons.Left, 1, mousePosition.X, mousePosition.Y, 0)))
			End If
		End Sub

		Private Function InButtons(ByVal location As Point) As Boolean
			Dim hi As DevExpress.XtraTab.ViewInfo.BaseTabHitInfo = CalcHitInfo(location)
			Return hi.HitTest = DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeaderButtons
		End Function

		Protected Overrides Sub OnMouseDown(ByVal e As DevExpress.Utils.DXMouseEventArgs)
			MyBase.OnMouseDown(e)
			If InButtons(e.Location) Then
				StartRepeat()
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(ByVal e As DevExpress.Utils.DXMouseEventArgs)
			MyBase.OnMouseUp(e)
			EndRepeat()
		End Sub
		Private timer As New Timer()

		Private Sub StartRepeat()
			timer.Enabled = True
		End Sub
		Private Sub EndRepeat()
			timer.Enabled = False
		End Sub

	End Class
End Namespace

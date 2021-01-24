Public Class frmCurrentSet

    Public Shadows Function ShowDialog(owner As Windows.Forms.IWin32Window) As Windows.Forms.DialogResult
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        For Each lConfiguration As String In clsConfiguration.AllExistingConfigurations
            With ListView1.Items.Add(lConfiguration)
                .Name = lConfiguration
                .Checked = CurrentSet.SelectedConfigurations.Contains(lConfiguration)
            End With
        Next
        DateTimePicker1.Value = CurrentSet.DateFrom
        DateTimePicker2.Value = CurrentSet.DateTo
        Select Case CurrentSet.OrderType
            Case clsCurrentSet.enumOrderType.DateASC
                rdDateASC.Checked = True
            Case clsCurrentSet.enumOrderType.Rnd
                rdRND.Checked = True
            Case Else
                rdRND2.Checked = True
        End Select
        txtWiden.Text = CurrentSet.Widen.ToString
        MyBase.ShowDialog(owner)
        CurrentSet.SelectedFiles.Clear() ' to invalidate the SelectedFiles. Next time SelectedFiles is accessed ii will be freshly refilled.
        Return Me.DialogResult
    End Function

    Private Sub ReFillConfigurationsList(pSelectConfiguration As String)
        Dim tmp As New List(Of String)
        For Each l As ListViewItem In ListView1.CheckedItems
            tmp.Add(l.Name)
        Next
        ListView1.Items.Clear()
        For Each lConfiguration As String In clsConfiguration.AllExistingConfigurations
            With ListView1.Items.Add(lConfiguration)
                .Name = lConfiguration
                .Checked = tmp.Contains(lConfiguration) OrElse lConfiguration = pSelectConfiguration
            End With
        Next
    End Sub

    Private Function Save() As Boolean
        CurrentSet.SelectedConfigurations.Clear()
        For Each l As ListViewItem In ListView1.CheckedItems
            CurrentSet.SelectedConfigurations.Add(l.Name)
        Next
        CurrentSet.DateFrom = DateTimePicker1.Value
        CurrentSet.DateTo = DateTimePicker2.Value
        If rdDateASC.Checked Then
            CurrentSet.OrderType = clsCurrentSet.enumOrderType.DateASC
        ElseIf rdRND.Checked Then
            CurrentSet.OrderType = clsCurrentSet.enumOrderType.Rnd
        Else
            CurrentSet.OrderType = clsCurrentSet.enumOrderType.RndDontRepeat
        End If
        If txtWiden.BackColor = Color.Red Then
            Beep()
            txtWiden.Focus()
            Return False
        End If
        If txtWiden.Text = "" Then
            CurrentSet.Widen = 0
        Else
            CurrentSet.Widen = CInt(txtWiden.Text)
        End If
        CurrentSet.CurrentFileIndex = -1
        CurrentSet.Serialize()
        Return True
    End Function

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If Not Save() Then Return
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_New_Click(sender As Object, e As EventArgs) Handles btn_New.Click
        Dim tmpFrm As New frmConfiguration
        ReFillConfigurationsList(tmpFrm.ShowDialog(Nothing))
    End Sub

    Private Sub btn_Edit_Click(sender As Object, e As EventArgs) Handles btn_Edit.Click
        If ListView1.SelectedItems.Count <> 1 Then Return
        Dim res As clsConfiguration
        res = clsConfiguration.Load(ListView1.SelectedItems(0).Name)
        Dim tmpFrm As New frmConfiguration
        tmpFrm.ShowDialog(res)
        ReFillConfigurationsList("")
    End Sub

    Private Sub btn_Del_Click(sender As Object, e As EventArgs) Handles btn_Del.Click
        If ListView1.SelectedItems.Count <> 1 Then Return
        Dim tmp As String = ListView1.SelectedItems(0).Text
        If MsgBox("Are you sure you want to DELETE configuration «" & tmp & "» ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) <> MsgBoxResult.Yes Then Return
        clsConfiguration.Delete(tmp)
        ReFillConfigurationsList("")
        Save()
    End Sub

    Private Sub frmHelp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ScreenSaver AndAlso Me.Owner IsNot Nothing Then Me.Owner.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmHelp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Owner IsNot Nothing Then Me.Owner.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btn_Folders_Click(sender As Object, e As EventArgs) Handles btn_Folders.Click
        Dim tmpFrm As New frmFolders
        tmpFrm.ShowDialog(Nothing)
    End Sub

    Private Sub btn_Usage_Click(sender As Object, e As EventArgs) Handles btn_Usage.Click
        If ListView1.SelectedItems.Count <> 1 Then Return
        If MsgBox("Are you sure you want to forget how many times each photo in Configuration «{configname}» has allready been shown ?".Replace("{configname}", ListView1.SelectedItems(0).Name), MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Return
        Try
            System.IO.File.Delete(SettingsPath & ListView1.SelectedItems(0).Name & "-FileUsage.txt")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "frmCurrentSet.btn_Usage")
        End Try
    End Sub

    Private Sub txtWiden_TextChanged(sender As Object, e As EventArgs) Handles txtWiden.TextChanged
        If txtWiden.Text <> "" AndAlso (Not IsNumeric(txtWiden.Text) OrElse CInt(txtWiden.Text) > 99 OrElse CInt(txtWiden.Text) < -99) Then
            txtWiden.BackColor = Color.Red
        Else
            txtWiden.BackColor = SystemColors.Window
        End If
    End Sub

End Class
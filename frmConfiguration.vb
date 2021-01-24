Public Class frmConfiguration
    Dim mConfiguration As clsConfiguration

    Public Shadows Function ShowDialog(pConfiguration As clsConfiguration) As String
        mConfiguration = pConfiguration
        If pConfiguration IsNot Nothing Then
            txt_Name.Text = pConfiguration.Name
            txt_Time.Text = pConfiguration.Seconds
            For Each lFolder As clsFolder In pConfiguration.Folders
                With ListView1.Items.Add(lFolder.Path)
                    .Name = lFolder.Path.ToUpper
                    .Checked = lFolder.IncludeSubFolders = System.IO.SearchOption.AllDirectories
                End With
            Next
        End If
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        MyBase.ShowDialog()
        Return txt_Name.Text
    End Function

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        If txt_Name.TextLength = 0 OrElse CInt(txt_Time.Text) <= 0 OrElse ListView1.Items.Count = 0 Then
            MsgBox("If you want to save this Configuration you must specify it's Name and it's Time to Showm, and you must include at least 1 Folder", MsgBoxStyle.Information)
            Exit Sub
        End If
        If mConfiguration Is Nothing Then mConfiguration = New clsConfiguration()
        mConfiguration.Name = txt_Name.Text
        mConfiguration.Seconds = CInt(txt_Time.Text)
        mConfiguration.Folders.Clear()
        For Each l As ListViewItem In ListView1.Items
            mConfiguration.Folders.Add(New clsFolder(l.Text, IIf(l.Checked, System.IO.SearchOption.AllDirectories, System.IO.SearchOption.TopDirectoryOnly)))
        Next
        mConfiguration.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_New_Click(sender As Object, e As EventArgs) Handles btn_New.Click
        Dim tmpFrm As New FolderBrowserDialog
        tmpFrm.Description = "Choose folder to add to configuration"
        tmpFrm.ShowNewFolderButton = False
        tmpFrm.SelectedPath = RecentFolder
        If tmpFrm.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        RecentFolder = tmpFrm.SelectedPath
        If Not ListView1.Items.ContainsKey(tmpFrm.SelectedPath.ToUpper) Then
            With ListView1.Items.Add(tmpFrm.SelectedPath)
                .Name = tmpFrm.SelectedPath.ToUpper
                .Checked = True
            End With
        End If
        ListView1.Items(tmpFrm.SelectedPath.ToUpper).Selected = True
        ListView1.Items(tmpFrm.SelectedPath.ToUpper).EnsureVisible()
    End Sub

    Private Sub btn_Del_Click(sender As Object, e As EventArgs) Handles btn_Del.Click
        If ListView1.SelectedItems.Count <> 1 Then Return
        ListView1.Items.Remove(ListView1.SelectedItems(0))
    End Sub

End Class
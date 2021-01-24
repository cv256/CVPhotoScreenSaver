Public Class frmCopy
    Public Shadows Function ShowDialog(owner As Windows.Forms.IWin32Window, pPath As String) As DialogResult
        lbOriginalPath.Text = pPath
        txtCopyPath.Text = CurrentSet.CopyPath
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        MyBase.ShowDialog(owner)
        Return Me.DialogResult
    End Function

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        CurrentSet.CopyPath = txtCopyPath.Text.TrimEnd("\")
        Dim dest As String = CurrentSet.CopyPath & "\" & System.IO.Path.GetFileName(lbOriginalPath.Text)
        Try
            If Not System.IO.Directory.Exists(CurrentSet.CopyPath) Then
                MsgBox("You must select a Directory/Folder." & vbCrLf & "«" & CurrentSet.CopyPath & "» is invalid.")
                Return
            End If
            System.IO.File.Copy(lbOriginalPath.Text, dest)
        Catch ex As Exception
            MsgBox("Copy" & vbCrLf & lbOriginalPath.Text & vbCrLf & "to" & vbCrLf & dest & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "frmCopy.Save")
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class
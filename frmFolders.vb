Public Class frmFolders
    Private fontBold As Font

    Public Shadows Function ShowDialog(pConfiguration As clsConfiguration) As String
        For Each config As String In clsConfiguration.AllExistingConfigurations
            Dim lvi As New ListViewItem
            lvi.Text = config
            lvi.Tag = clsConfiguration.Load(config)
            lvi.SubItems.Add("")
            lvi.UseItemStyleForSubItems = False
            lst_Configs.Items.Add(lvi)
        Next
        fontBold = New Font(lst_Configs.Font, FontStyle.Bold)
        Dim t As New WindowsExplorer.ExplorerTree
        t.Bounds = New Rectangle(12, lbl_Configs.Top, lst_Configs.Left - 12, lst_Configs.Bottom - lbl_Configs.Top)
        t.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        t.AllowDrop = False
        t.ShowAddressbar = True
        t.ShowToolbar = True
        Me.Controls.Add(t)
        Try
            t.TabIndex = 0
            t.Focus()
            t.setCurrentPath(RecentFolder)
        Catch ex As Exception

        End Try
        AddHandler t.PathChanged, AddressOf PathChanged
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        MyBase.ShowDialog()
        Return ""
    End Function

    Private Sub PathChanged(sender As Object, e As EventArgs)
        Dim tmpPath As String
        tmpPath = DirectCast(sender, WindowsExplorer.ExplorerTree).SelectedPath
        If String.IsNullOrEmpty(tmpPath) Then Return
        lbl_Configs.Text = "«" & IO.Path.GetFileName(tmpPath) & "» belongs to these Configurations:"
        RecentFolder = tmpPath
        For Each itm As ListViewItem In lst_Configs.Items
            itm.SubItems(1).Text = ""
            itm.BackColor = lst_Configs.BackColor
            itm.SubItems(1).BackColor = lst_Configs.BackColor
            itm.Font = lst_Configs.Font
            With DirectCast(itm.Tag, clsConfiguration)
                For Each i As clsFolder In .Folders
                    If tmpPath.ToUpper = i.Path.ToUpper Then
                        itm.SubItems(1).Text &= IIf(itm.SubItems(1).Text > "", " / ", "") & "«" & IO.Path.GetFileName(i.Path) & "»"
                        If i.IncludeSubFolders = IO.SearchOption.AllDirectories Then itm.SubItems(1).Text &= " and it's subfolders"
                        itm.BackColor = Color.LightGreen : itm.SubItems(0).BackColor = Color.LightGreen
                        itm.Font = fontBold
                    End If
                Next
                For Each i As clsFolder In .Folders
                    If tmpPath.ToUpper <> i.Path.ToUpper AndAlso (tmpPath.ToUpper & "/").Contains(i.Path.ToUpper & "/") AndAlso i.IncludeSubFolders = IO.SearchOption.AllDirectories Then
                        itm.SubItems(1).Text &= IIf(itm.SubItems(1).Text > "", " / ", "") & "«" & IO.Path.GetFileName(i.Path) & "» and it's subfolders"
                        itm.BackColor = Color.Yellow : itm.SubItems(0).BackColor = Color.Yellow
                        itm.Font = fontBold
                    End If
                Next
            End With
        Next itm
        lst_Configs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub btn_Cancel_Click(sender As Object, e As EventArgs) Handles btn_Cancel.Click
        Close()
    End Sub

End Class
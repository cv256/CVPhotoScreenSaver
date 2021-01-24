Public NotInheritable Class frmHelp

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title & " - Help"
        LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString) & vbCrLf & My.Application.Info.Copyright
        LabelCopyright.Text = "Yes, by " & My.Application.Info.CompanyName & vbCrLf & My.Application.Info.Trademark
        LabelPath.Text = SettingsPath
        Dim tmpItem As ListViewItem
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("Esc") : tmpItem.SubItems.Add("Exit CVPhotoScreenSaver") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("S") : tmpItem.SubItems.Add("Select Photos / Configure") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("I") : tmpItem.SubItems.Add("Show Info") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("P / space") : tmpItem.SubItems.Add("Pause / Resume") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("R") : tmpItem.SubItems.Add("Forget how many times each photo has been shown") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("C") : tmpItem.SubItems.Add("Copy a foto to another folder") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("Page Up") : tmpItem.SubItems.Add("Previous Photo") : ListView1.Items.Add(tmpItem)
        tmpItem = New ListViewItem : tmpItem.SubItems.Add("Page Down") : tmpItem.SubItems.Add("Next Photo") : ListView1.Items.Add(tmpItem)
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Me.Close()
    End Sub

    Private Sub LabelPath_Click(sender As Object, e As EventArgs) Handles LabelPath.Click
        Shell("Explorer.exe """ & SettingsPath & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Abort
        Close()
    End Sub

    Private Sub frmHelp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If ScreenSaver Then Me.Owner.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmHelp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.WindowState = FormWindowState.Maximized
    End Sub

End Class

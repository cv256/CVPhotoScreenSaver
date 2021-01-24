Public Class Form1

    Private FileBeingShown As CVPhotoScreenSaver.clsFile
    Private RecentFiles As New List(Of Integer) ' stack of the photos recently shown, the highest index the older, zero index is the photo just shown
    Private RecentFileBeingShown As Integer '  the highest the older 
    Private Const RecentFilesMax As Integer = 30

    Private Enum enumShowInfo
        None
        Path
        All
    End Enum
    Private ShowInfo As enumShowInfo = enumShowInfo.None

    Private Enum enumPrintFotoMode
        Auto
        Previous
        [Next]
        Keep
    End Enum


    Public Sub Run()
        MeTopMost(True)
        Timer1.Interval = 700 ' start showing photos
        Timer1.Enabled = True
        Me.ShowDialog()
        CurrentSet.Serialize()
    End Sub


    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        e.Handled = True
        Select Case e.KeyCode

            Case Keys.Space, Keys.P   ' resume from Pause, skip this foto
                If Timer1.Enabled Then  ' Pause it
                    Timer1.Enabled = False
                    Dim gr As Drawing.Graphics = Me.CreateGraphics()
                    PrintText(gr, "PAUSED", True, False)
                Else ' Resume it
                    Timer1.Interval = 50
                    Timer1.Enabled = True
                End If

            Case Keys.I
                If ShowInfo = enumShowInfo.None Then
                    ShowInfo = enumShowInfo.Path
                ElseIf ShowInfo = enumShowInfo.Path Then
                    ShowInfo = enumShowInfo.All
                Else
                    ShowInfo = enumShowInfo.None
                End If
                If ShowInfo <> enumShowInfo.None Then Timer1.Enabled = False ' force Pause
                PrintFoto(enumPrintFotoMode.Keep) ' to draw/undraw the infos

            Case Keys.Subtract ' zoom-

            Case Keys.Add  ' zoom+

            Case Keys.PageUp  ' previous
                PrintFoto(enumPrintFotoMode.Previous)

            Case Keys.PageDown  ' next
                PrintFoto(enumPrintFotoMode.Next)

            Case Keys.Escape, Keys.Shift, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey, Keys.Alt, Keys.Tab, Keys.Enter, Keys.Control, Keys.ControlKey, Keys.LControlKey, Keys.RControlKey, Keys.Modifiers, Keys.Menu
                If ScreenSaver Then
                    Me.Close()
                ElseIf e.KeyCode = Keys.Escape Then
                    ShowHelp()
                End If

            Case Keys.S ' show config
                ShowConfig()

            Case Keys.R ' reset FileUsage
                If MsgBox("Are you sure you want to forget how many times each photo has been shown ?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel) <> MsgBoxResult.Ok Then Return
                For Each f In CurrentSet.SelectedFiles
                    f.ShownTimes = 0
                Next

            Case Keys.C
                ShowCopy(PhotosPath & FileBeingShown.Path)

            Case Else
                If ScreenSaver Then ShowHelp()

        End Select
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PrintFoto(enumPrintFotoMode.Auto)
    End Sub

    Public Sub ShowConfig()
        Timer1.Enabled = False
        CurrentSet.SaveFileUsage(Me)
        MeTopMost(False)
        Dim tmpFrm As New frmCurrentSet
        tmpFrm.ShowDialog(Me)
        MeTopMost(True)
        Timer1.Enabled = True
    End Sub

    Public Sub ShowCopy(pPath As String)
        Timer1.Enabled = False
        MeTopMost(False)
        Dim tmpFrm As New frmCopy
        tmpFrm.ShowDialog(Me, PhotosPath & FileBeingShown.Path)
        MeTopMost(True)
        Timer1.Enabled = True
    End Sub



    Public Sub ShowHelp()
        Timer1.Enabled = False
        MeTopMost(False)
        Dim tmpFrm As New frmHelp
        If tmpFrm.ShowDialog(Me) = Windows.Forms.DialogResult.Abort Then
            Me.Close()
        Else
            MeTopMost(True)
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub PrintFoto(pPrintFotoMode As enumPrintFotoMode)
        Static PrintFotoWorking As Boolean
        If PrintFotoWorking Then Exit Sub
        PrintFotoWorking = True
        Dim OldTimerEnabled As Boolean = Timer1.Enabled
        Timer1.Enabled = False

        If CurrentSet.SelectedFiles.Count = 0 Then CurrentSet.LoadSelectedFiles(Me)

        If pPrintFotoMode = enumPrintFotoMode.Previous OrElse pPrintFotoMode = enumPrintFotoMode.Next Then OldTimerEnabled = False ' if user starts navigating the photos, automaticaly get into Pause mode (no automatic advance)
        If pPrintFotoMode = enumPrintFotoMode.Auto Then OldTimerEnabled = True

        If pPrintFotoMode <> enumPrintFotoMode.Keep Then
            If pPrintFotoMode = enumPrintFotoMode.Previous Then
                If RecentFileBeingShown < RecentFiles.Count - 1 Then RecentFileBeingShown += 1 ' navigate to older photo
                If RecentFileBeingShown = 0 Then RecentFileBeingShown = 1 ' we dont reshow index zero because its the same photo we were watching now
            Else
                RecentFileBeingShown -= 1
            End If
            If RecentFileBeingShown >= 0 AndAlso RecentFileBeingShown < RecentFiles.Count Then ' if we are rewatching previous photos:
                FileBeingShown = CurrentSet.SelectedFiles(RecentFiles(RecentFileBeingShown))
            Else ' if we are showing new photos:
                RecentFileBeingShown = -1
                FileBeingShown = CurrentSet.GetNextFile
                If FileBeingShown Is Nothing Then
                    MeTopMost(False)
                    Dim tmpFrm As New frmCurrentSet
                    If tmpFrm.ShowDialog(Me) <> DialogResult.OK Then End
                    MeTopMost(True)
                    GoTo Baza
                End If
                ' put this photo in the stack of recently shown photos:
                If Not RecentFiles.Contains(CurrentSet.CurrentFileIndex) Then RecentFiles.Insert(0, CurrentSet.CurrentFileIndex)
                If RecentFiles.Count >= RecentFilesMax Then RecentFiles.RemoveAt(RecentFiles.Count - 1)
            End If
        End If

        ' drawing:
        Dim gr As Drawing.Graphics = Me.CreateGraphics()
        Try
            Dim res As Image
            res = Image.FromFile(PhotosPath & FileBeingShown.Path)
            Dim reduction As Decimal
            reduction = res.Width * (1 + CurrentSet.Widen / 100) / Me.ClientRectangle.Width
            If res.Height / Me.ClientRectangle.Height > reduction Then reduction = res.Height / Me.ClientRectangle.Height
            Dim imageWidth As Integer = res.Width * (1 + CurrentSet.Widen / 100) / reduction, imageHeight As Integer = res.Height / reduction
            Dim imageX As Integer = (Me.ClientRectangle.Width - imageWidth) / 2, imageY As Integer = (Me.ClientRectangle.Height - imageHeight) / 2
            gr.Clear(Color.Black)
            gr.DrawImage(res, imageX, imageY, imageWidth, imageHeight)
            Dim s As String = ""
            If RecentFileBeingShown <> -1 Then s = "BACK " & RecentFileBeingShown + 1
            If OldTimerEnabled = False Then s &= "     PAUSED"
            If s.Length > 0 Then PrintText(gr, s, True, False)
            s = ""
            If ShowInfo = enumShowInfo.All Then
                s &= FileBeingShown.[Date].ToString & vbCrLf &
                    IIf(RecentFileBeingShown = -1, "# " & (CurrentSet.CurrentFileIndex + 1).ToString & If(CurrentSet.PossibleFilesIndexes IsNot Nothing, " / " & CurrentSet.PossibleFilesIndexes.Count, "") & " / " & CurrentSet.SelectedFiles.Count & vbCrLf, "") &
                    "Shown  " & FileBeingShown.ShownTimes & "  times" & vbCrLf &
                    FileBeingShown.Seconds & "  ''" & vbCrLf &
                    FileBeingShown.Configuration.Name & vbCrLf &
                    res.Width & IIf(CurrentSet.Widen > 0, "+" & CurrentSet.Widen & "%", IIf(CurrentSet.Widen < 0, CurrentSet.Widen & "%", "")) & " x " & res.Height & "   " & res.PixelFormat.ToString.Replace("Format", "").Replace("bpp", " ") & vbCrLf
            End If
            If ShowInfo <> enumShowInfo.None Then
                s &= FileBeingShown.Path
                PrintText(gr, s, False, False)
            End If
            res.Dispose()
            gr.Dispose()
            Timer1.Interval = FileBeingShown.Seconds * 1000
        Catch ex As Exception
            gr.DrawString(ex.Message, Me.Font, New SolidBrush(Color.White), 0, 0)
            Debug.Print(ex.Message)
        End Try

Baza:
        Timer1.Enabled = OldTimerEnabled
        PrintFotoWorking = False
    End Sub

    Private Sub PrintText(gr As Drawing.Graphics, pText As String, pRight As Boolean, pTop As Boolean)
        Dim textsize As SizeF = gr.MeasureString(pText, Me.Font)
        Dim x As Integer = 0, y As Integer = 0
        If pRight Then x = Me.ClientRectangle.Width - textsize.Width - 2
        If Not pTop Then y = Me.ClientRectangle.Height - textsize.Height - 2
        gr.DrawString(pText, Me.Font, New SolidBrush(Color.Black), x, y)
        gr.DrawString(pText, Me.Font, New SolidBrush(Color.Black), x + 2, y + 2)
        gr.DrawString(pText, Me.Font, New SolidBrush(Color.White), x + 1, y + 1)
    End Sub

    Private Sub MeTopMost(p As Boolean)
#If DEBUG Then
#Else
        'If ScreenSaver Then Me.WindowState = IIf(p, FormWindowState.Maximized, FormWindowState.Minimized)
        Me.TopMost = p AndAlso ScreenSaver
        Me.ShowInTaskbar = Not Me.TopMost
        If p AndAlso ScreenSaver Then
            'Dim tmpLng As Integer
            'tmpLng = SystemParametersInfo(SPI_SCREENSAVERRUNNING, 1&, 0&, 0&)
            Cursor.Hide()
        Else
            'Dim tmplng As Integer
            ''Re-enable the CTRL+ALT+DEL key combination if it is disabled.
            'tmplng = SystemParametersInfo(SPI_SCREENSAVERRUNNING, 0&, 0&, 0&)
            Cursor.Show()
        End If
#End If
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If ScreenSaver Then Me.Close()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False ' for safety
        CurrentSet.SaveFileUsage(Me)
        MeTopMost(False)
    End Sub


End Class

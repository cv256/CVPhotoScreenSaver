Module Module1
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As IntPtr

    Public CurrentSet As New clsCurrentSet
    Public SettingsPath As String
    Public RecentFolder As String
    Public ScreenSaver As Boolean
    Public PhotosPath As String

    <STAThread()> Sub Main(ByVal args As String())
        Dim GoConfig As Boolean = False, Debug As Boolean = False
        ScreenSaver = True
        ScreenSaver = Diagnostics.Process.GetCurrentProcess.MainModule.FileName.ToLower.EndsWith(".scr")
        PhotosPath = My.Application.Info.DirectoryPath & "\"
        SettingsPath = PhotosPath ' My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & My.Application.Info.Title & "\"

        For Each arg As String In args
            If arg.ToLower.Contains("/c") Then GoConfig = True
            If arg.ToLower.Contains("/d") Then Debug = True
            If arg.Contains("\") Then
                PhotosPath = arg.TrimEnd("\") & "\"
                SettingsPath = PhotosPath
            End If
        Next

        If Debug Then
            Dim DebugInfo As String
            DebugInfo = "Args: " & String.Join(" "c, args) & vbCrLf
            DebugInfo &= "Debug: " & Debug & vbCrLf
            DebugInfo &= "ScreenSaver: " & ScreenSaver & vbCrLf
            DebugInfo &= "GoConfig: " & GoConfig & vbCrLf
            DebugInfo &= "PhotosPath: " & PhotosPath & vbCrLf
            DebugInfo &= "SettingsPath: " & SettingsPath & vbCrLf
            DebugInfo &= "ProcessName: " & Diagnostics.Process.GetCurrentProcess.ProcessName & vbCrLf
            DebugInfo &= "FileName: " & Diagnostics.Process.GetCurrentProcess.MainModule.FileName & vbCrLf
            MsgBox(DebugInfo, MsgBoxStyle.Information)
        End If

        Dim oldProcesses As Process()
        oldProcesses = Diagnostics.Process.GetProcessesByName("CVPhotoScreenSaver") ' hardcoded porque o .SCR retorna Diagnostics.Process.GetCurrentProcess.ProcessName="CVPhot~1"
        For Each oldProcess As Process In oldProcesses
            If oldProcess.Id <> Diagnostics.Process.GetCurrentProcess.Id Then
                If Debug Then
                    MsgBox("Found Running Instance, changing focus to it and ending this instance", MsgBoxStyle.Information)
                End If
                SetForegroundWindow(oldProcess.MainWindowHandle)
                End
            End If
        Next

        If Not My.Computer.FileSystem.DirectoryExists(SettingsPath) Then My.Computer.FileSystem.CreateDirectory(SettingsPath)
        clsCurrentSet.LoadLastCurrentSet()
        If GoConfig Then
            Dim tmpFrm As New frmCurrentSet
            tmpFrm.ShowDialog(Nothing)
        Else
            ' Create a Screen Saver form, and then display the form.
            Dim tmpFrm As New Form1
            tmpFrm.Run()
        End If
    End Sub

End Module

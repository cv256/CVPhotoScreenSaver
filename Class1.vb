<Serializable()> Public Class clsCurrentSet

    Public SelectedConfigurations As New List(Of String) ' Viagens, Dança, Familia
    Public DateFrom As Date = New Date(1900, 1, 1)
    Public DateTo As Date = New Date(2059, 12, 31)
    Public OrderType As enumOrderType = enumOrderType.RndDontRepeat
    Public Widen As Integer = 0
    Public CurrentFileIndex As Integer = 0 ' 0 based  this variable is used when we're showing photos randomly, in sequence
    Public CopyPath As String = ""

    <NonSerialized()> <Xml.Serialization.XmlIgnore()> Public SelectedFiles As New List(Of clsFile)
    <NonSerialized()> <Xml.Serialization.XmlIgnore()> Public PossibleFilesIndexes As List(Of Integer) ' this was in clsCurentSet.GetNextFile() but now is here just because I want to debug it

    Public Enum enumOrderType
        DateASC
        Rnd
        RndDontRepeat
    End Enum

    Public Shared Sub LoadLastCurrentSet()
        Dim objStreamReader As System.IO.StreamReader = Nothing
        Try 'load the Selected Configurations names
            objStreamReader = New System.IO.StreamReader(SettingsPath & "CurrentSet.xml")
            Dim x As New System.Xml.Serialization.XmlSerializer(CurrentSet.GetType)
            CurrentSet = x.Deserialize(objStreamReader)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        If objStreamReader IsNot Nothing Then objStreamReader.Close()
    End Sub

    Public Sub LoadSelectedFiles(pForm As Form)
        Dim gr As Drawing.Graphics = pForm.CreateGraphics
        SelectedFiles.Clear()
        For Each lConfigurationName As String In SelectedConfigurations
            ' load this configuration:
            Dim tmpConfiguration As clsConfiguration
            tmpConfiguration = clsConfiguration.Load(lConfigurationName)
            If IsNothing(tmpConfiguration) Then Continue For
            ' add this configuration's files to the CurrentSet:
            For Each lConfigurationFile As clsFile In tmpConfiguration.Files(pReadUsage:=OrderType = enumOrderType.RndDontRepeat, gr:=gr, pFont:=pForm.Font)
                'Dim oldFile As clsFile
                'oldFile = SelectedFiles.FirstOrDefault(Function(f) f.Path.ToUpper = lConfigurationFile.Path.ToUpper)
                'If Not IsNothing(oldFile) Then
                '    If oldFile.Seconds < lConfigurationFile.Seconds Then oldFile.Seconds = lConfigurationFile.Seconds
                '    oldFile.Configurations &= vbCrLf & lConfigurationName
                'Else
                SelectedFiles.Add(lConfigurationFile) ' SelectedFiles.Add(lConfigurationFile.Clone)
                'End If
            Next lConfigurationFile
        Next lConfigurationName

        'gr.Clear(Color.DarkOliveGreen)
        'gr.DrawString("READING FILE USAGE", pForm.Font, New SolidBrush(Color.White), 0, 0)
        'Dim existingFile As New List(Of String)
        'Try
        '    existingFile = System.IO.File.ReadAllLines(SettingsPath & "FileUsage.txt").ToList
        'Catch ex As Exception
        '    Debug.Print(ex.Message)
        'End Try
        'Dim existingFileOK As New Generic.SortedList(Of String, Integer)
        'For Each f As String In existingFile
        '    Dim x As Integer
        '    x = f.LastIndexOf("=")
        '    existingFileOK.Add(f.Substring(0, x), CInt(f.Substring(x + 1)))
        'Next

        'For Each fo As clsFile In Me.SelectedFiles
        '    If existingFileOK.ContainsKey(fo.Path.ToUpper) Then fo.ShownTimes = existingFileOK(fo.Path.ToUpper)
        'Next fo

        If OrderType = enumOrderType.DateASC Then
            gr.Clear(Color.DarkOliveGreen)
            gr.DrawString("SORTING", pForm.Font, New SolidBrush(Color.White), 0, 0)
            SelectedFiles.Sort()
        End If

        gr.Clear(Color.DarkOliveGreen)
        gr.Dispose()
    End Sub

    Friend Sub Serialize()
        Dim tmp = SettingsPath & "CurrentSet.xml"
        Try
            'Serialize object to a text file.
            Dim objStreamWriter As New System.IO.StreamWriter(tmp)
            Dim x As New System.Xml.Serialization.XmlSerializer(Me.GetType)
            x.Serialize(objStreamWriter, Me)
            objStreamWriter.Close()
        Catch ex As Exception
            MsgBox(tmp & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "clsCurrentSet.Serialize")
        End Try
    End Sub

    Friend Sub SaveFileUsage(pform As Form)
        If Me.OrderType <> enumOrderType.RndDontRepeat Then Return
        Dim gr As System.Drawing.Graphics = pform.CreateGraphics()
        For Each pConfiguration As clsConfiguration In Me.SelectedFiles.Select(Function(f) f.Configuration).Distinct
            gr.Clear(Color.DarkRed)
            gr.DrawString("Saving FILE USAGE for " & pConfiguration.Name, pform.Font, New SolidBrush(Color.White), 0, 0)
            Dim existingFiles As New List(Of String) ' As New Dictionary(Of String, String)
            'Try
            '    existingFiles = System.IO.File.ReadAllLines(SettingsPath & "FileUsage.txt").ToDictionary(Function(f) f.Substring(0, f.LastIndexOf("="c)))
            'Catch ex As Exception
            '    Debug.Print(ex.Message)
            'End Try
            For Each fo As clsFile In Me.SelectedFiles.Where(Function(f) pConfiguration.Equals(f.Configuration) AndAlso f.ShownTimes > 0)
                '    If existingFiles.ContainsKey(fo.Path.ToUpper) Then
                '        existingFiles(fo.Path.ToUpper) = fo.Path.ToUpper & "=" & fo.ShownTimes
                '    Else
                existingFiles.Add(fo.Path.ToUpper & "=" & fo.ShownTimes) ' existingFiles.Add(fo.Path.ToUpper, fo.Path.ToUpper & "=" & fo.ShownTimes)
                '    End If
            Next fo
SaveIt:
            Dim tmp As String = SettingsPath & pConfiguration.Name & "-FileUsage.txt"
            Try
                System.IO.File.WriteAllLines(tmp, existingFiles.ToArray)
            Catch ex As Exception
                If MsgBox(tmp & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.RetryCancel, "clsCurrentSet.SaveFileUsage") = MsgBoxResult.Retry Then GoTo SaveIt
            End Try
        Next pConfiguration
        gr.Clear(Color.DarkRed)
        gr.Dispose()
    End Sub

    Public Function GetNextFile() As CVPhotoScreenSaver.clsFile
        If SelectedFiles.Count = 0 Then Return Nothing
        Dim FileToUse As CVPhotoScreenSaver.clsFile
        If OrderType = enumOrderType.Rnd Then
            Randomize()
            CurrentFileIndex = Math.Floor(Rnd() * SelectedFiles.Count)
        ElseIf OrderType = enumOrderType.RndDontRepeat Then
            Dim MinUse As Integer = SelectedFiles.Min(Function(f) f.ShownTimes)
            PossibleFilesIndexes = New List(Of Integer)
            For fx As Integer = 0 To SelectedFiles.Count - 1
                If SelectedFiles(fx).ShownTimes <= MinUse Then PossibleFilesIndexes.Add(fx)
            Next
            Randomize()
            CurrentFileIndex = PossibleFilesIndexes(Math.Floor(Rnd() * PossibleFilesIndexes.Count))
            Debug.Print("MinUse=" & MinUse & "   PossibleFiles.Count=" & PossibleFilesIndexes.Count & "   CurrentFileIndex=" & CurrentFileIndex & "   Path=" & SelectedFiles(CurrentFileIndex).Path)
        Else ' OrderType = enumOrderType.Date or OrderType = enumOrderType.Alpha
            CurrentFileIndex += 1
            If CurrentFileIndex < 0 OrElse CurrentFileIndex > SelectedFiles.Count - 1 Then CurrentFileIndex = 0
        End If
        FileToUse = SelectedFiles(CurrentFileIndex)
        FileToUse.ShownTimes += 1
        Return FileToUse
    End Function

End Class



<Serializable()> Public Class clsConfiguration
    <NonSerialized()> <Xml.Serialization.XmlIgnore()> Public Name As String
    Public Folders As New List(Of clsFolder)
    Public Seconds As Integer

    Friend Shared Function AllExistingConfigurations() As List(Of String)
        Dim res As New List(Of String)
        For Each lFile As String In My.Computer.FileSystem.GetFiles(SettingsPath, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
            If lFile.ToUpper.EndsWith("CURRENTSET.XML") Then Continue For
            res.Add(System.IO.Path.GetFileNameWithoutExtension(lFile))
        Next lFile
        Return res
    End Function

    Public Shared Function Load(pName As String) As clsConfiguration
        Dim res As New clsConfiguration
        Try
            'Deserialize text file to a new object.
            Dim objStreamReader As New System.IO.StreamReader(SettingsPath & pName & ".xml")
            Dim x As New System.Xml.Serialization.XmlSerializer(res.GetType)
            res = x.Deserialize(objStreamReader)
            objStreamReader.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "clsConfiguration.Load")
        End Try
        res.Name = pName
        Return res
    End Function

    Public Function Files(pReadUsage As Boolean, gr As Drawing.Graphics, pFont As Drawing.Font) As List(Of clsFile)
        Dim fileUsageOK As New Generic.SortedList(Of String, Integer)
        If pReadUsage Then
            gr.Clear(Color.DarkOliveGreen)
            gr.DrawString("Reading FILE USAGE for " & Me.Name, pFont, New SolidBrush(Color.White), 0, 0)
            Dim fileUsage As New List(Of String)
            Try
                fileUsage = System.IO.File.ReadAllLines(SettingsPath & Me.Name & "-FileUsage.txt").ToList
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
            ' ordena-as, para ser mais rapido no passo seguinte
            For Each f As String In fileUsage
                Dim x As Integer = f.LastIndexOf("=")
                fileUsageOK.Add(f.Substring(0, x).ToUpper, CInt(f.Substring(x + 1)))
            Next
        End If

        Dim res = New List(Of clsFile), tmpDate As Date
        For Each iFolder As clsFolder In Me.Folders
            gr.Clear(Color.DarkOliveGreen)
            gr.DrawString("Reading FILES for " & Me.Name & vbCrLf & vbCrLf & iFolder.Path, pFont, New SolidBrush(Color.White), 0, 0)
            Try
                For Each iFile As String In System.IO.Directory.GetFiles(PhotosPath & iFolder.Path, "*.jpg", iFolder.IncludeSubFolders)
                    Dim iFileShort As String = iFile.Replace(PhotosPath, "").ToUpper
                    tmpDate = System.IO.File.GetCreationTime(iFile)
                    If tmpDate < CurrentSet.DateFrom OrElse tmpDate > CurrentSet.DateTo Then Continue For
                    Dim newFile As New clsFile(iFileShort, tmpDate, Me.Seconds, Me)
                    If fileUsageOK.ContainsKey(iFileShort) Then newFile.ShownTimes = fileUsageOK(iFileShort)
                    res.Add(newFile)
                Next iFile
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "clsConfiguration.Files")
            End Try
        Next iFolder
        Return res
    End Function

    Public Sub Save()
        'Serialize object to a text file.
        Dim objStreamWriter As New System.IO.StreamWriter(SettingsPath & Me.Name & ".xml")
        Dim x As New System.Xml.Serialization.XmlSerializer(Me.GetType)
        x.Serialize(objStreamWriter, Me)
        objStreamWriter.Close()
    End Sub

    Public Shared Sub Delete(pConfigurationName As String)
        Dim tmp As String = SettingsPath & pConfigurationName & ".xml"
        Try
            My.Computer.FileSystem.DeleteFile(tmp)
        Catch ex As Exception
            MsgBox(tmp & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "clsConfiguration.Delete")
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Name
    End Function

End Class



Public Class clsFolder
    Public Path As String
    Public IncludeSubFolders As System.IO.SearchOption
    Public Sub New()

    End Sub
    Public Sub New(pPath As String, pIncludeSubFolders As System.IO.SearchOption)
        Path = PhotosPath & pPath
        IncludeSubFolders = pIncludeSubFolders
    End Sub
End Class



Public Class clsFile
    Implements IComparable(Of clsFile)
    Public Path As String
    Public Seconds As Integer = 5
    Public ShownTimes As Integer = 0
    Public Configuration As clsConfiguration
    Public [Date] As Date
    Public Sub New()

    End Sub

    Public Sub New(pPath As String, pDate As Date, pSeconds As Integer, pConfiguration As clsConfiguration)
        Path = pPath
        [Date] = pDate
        Seconds = pSeconds
        Configuration = pConfiguration
    End Sub
    Public Function Clone() As clsFile
        Dim res As New clsFile(Path, [Date], Seconds, Configuration)
        Return res
    End Function

    Public Function CompareTo(compareFile As clsFile) As Integer _
            Implements IComparable(Of clsFile).CompareTo
        ' A null value means that this object is greater. 
        If compareFile Is Nothing _
            OrElse Me.Date.ToString("yyyyMMddHHmm") > compareFile.Date.ToString("yyyyMMddHHmm") _
            OrElse (Me.Date.ToString("yyyyMMddHHmm") = compareFile.Date.ToString("yyyyMMddHHmm") AndAlso Me.Path > compareFile.Path) Then
            Return 1
        Else
            If Me.Path = compareFile.Path Then Return 0
            Return -1
        End If
    End Function

End Class
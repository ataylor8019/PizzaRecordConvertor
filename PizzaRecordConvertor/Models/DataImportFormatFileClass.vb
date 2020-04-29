Public MustInherit Class DataImportFormatFileClass 'Exists to encapsulate common file open/access/close methods
    'that are commonly used across all of the data models in this
    'project
    Protected p_FileToOpen As String   'name of file to open
    Protected p_FileHeader As String    'Header text of file to work with
    Protected p_FileRecord As String    'String holding combined individual values of fields of record of file
    'Protected p_FileOpenSuccess As Boolean    'Boolean signalling success or failure of file open
    Protected p_RecordWriter As System.IO.StreamWriter    'Record writer object

    Protected p_ModelString As String

    'Subs to prepare file header and record strings
    'Are overridden in decendant classes, as every
    'file has a different header and record
    Protected MustOverride Sub PrepareFileHeaderString()
    Protected MustOverride Sub PrepareFileRecordString()

    Public MustOverride Function PreparedFileRecordString() As String

    Public Property FileToOpen() As String
        Get
            Return p_FileToOpen
        End Get
        Set(ByVal value As String)
            p_FileToOpen = value
        End Set
    End Property

    Public Overridable Function OpenFile(fileToOpen As String) As Boolean
        Dim subString As String = "OpenFile"
        Dim p_FileOpenSuccess As Boolean = True
        PrepareFileHeaderString()
        Try
            p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(fileToOpen, True)
            p_RecordWriter.WriteLine(p_FileHeader)
        Catch argBad As ArgumentException
            p_FileOpenSuccess = False
            Throw New System.ArgumentException("""" & p_ModelString & """" & ":" & """" & subString & """" & ":" & """" & DateTime.Now.ToString() & """" & ":" & """" & argBad.ToString() & """")
        Catch ex As Exception
            p_FileOpenSuccess = False
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
        Return p_FileOpenSuccess
    End Function

    Public Overridable Sub WriteRecordToFile()
        p_FileRecord = PreparedFileRecordString()
        p_RecordWriter.WriteLine(p_FileRecord)
    End Sub

    Public Overridable Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

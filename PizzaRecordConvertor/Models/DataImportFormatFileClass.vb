Public MustInherit Class DataImportFormatFileClass 'Exists to encapsulate common file open/access/close methods
    'that are commonly used across all of the data models in this
    'project
    Protected p_FileToOpen As String   'name of file to open
    Protected p_FileHeader As String    'Header text of file to work with
    Protected p_FileRecord As String    'String holding combined individual values of fields of record of file
    Protected p_RecordWriter As System.IO.StreamWriter    'Record writer object

    Protected p_ModelString As String

    'Subs to prepare file header and record strings
    'Are overridden in decendant classes, as every
    'file has a different header and record
    Protected MustOverride Sub PrepareFileHeaderString()

    Public Property FileToOpen() As String
        Get
            Return p_FileToOpen
        End Get
        Set(ByVal value As String)
            p_FileToOpen = value
        End Set
    End Property

    Public Overridable Sub OpenFile(fileToOpen As String)
        Dim subString As String = "OpenFile"
        Dim writeHeader As Boolean = False
        PrepareFileHeaderString()
        writeHeader = My.Computer.FileSystem.FileExists(fileToOpen)
        p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(fileToOpen, True)
        If Not writeHeader Then p_RecordWriter.WriteLine(p_FileHeader)
    End Sub

    Public Overridable Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

Public Interface IOutputFileInterface
    ReadOnly Property OutputFileName As String
    ' WriteOnly Property FileCreateSuccess As Boolean
    WriteOnly Property OutputFileOpenSuccess As Boolean
    WriteOnly Property OutputFileCloseSuccess As Boolean
    WriteOnly Property FileWriteSuccess As Boolean
    ReadOnly Property OutputFileData As List(Of IFileTransfer.OutputFileStructure)
End Interface

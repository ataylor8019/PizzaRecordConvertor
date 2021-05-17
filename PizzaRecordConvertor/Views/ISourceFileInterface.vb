Public Interface ISourceFileInterface
    'Inherits IFileStructureModel

    WriteOnly Property SourceFileOpenSuccess As Boolean
    WriteOnly Property FileReadSuccess As Boolean
    WriteOnly Property SourceFileCloseSuccess As Boolean
    WriteOnly Property VerifyFilename As Boolean
    Property SourceFile As FileIO.TextFieldParser
    ReadOnly Property SourceFileName As String
    ReadOnly Property FullPathSourceFileName As String
    Property OrderDateTime As String
    WriteOnly Property SourceOrderRecordData As OutputFileStructure
    WriteOnly Property SourceOrderFileData As List(Of OutputFileStructure)

End Interface

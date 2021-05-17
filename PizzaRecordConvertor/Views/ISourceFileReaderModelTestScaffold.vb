Imports System.IO
Public Interface ISourceFileReaderModelTestScaffold
    Property SourceFile() As FileIO.TextFieldParser
    ReadOnly Property FileData() As List(Of OutputFileStructure)
    Property FileCollection() As FileInfo
    Function OpenDataEntity(entityFileName As String) As Boolean
    Function CloseDataEntity() As Boolean
    Function VerifyFilename(sourceFileName As String) As Boolean
    Property OrderDateTime() As String
    Function GetOrderDateTime(sourceFileName As String) As String
    Function GetDataLineTypeFromFile(sourceFile As Microsoft.VisualBasic.FileIO.TextFieldParser) As String    'Returns line type of data from peek ahead of source file
    Function userReadOrderFileData() As Boolean
    Function ReadOrderFileData(sourceFile As Microsoft.VisualBasic.FileIO.TextFieldParser) As Boolean

End Interface

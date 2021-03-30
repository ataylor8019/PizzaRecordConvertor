Public Interface IOutputFileWriterModelTestScaffold
    WriteOnly Property FileData() As List(Of IFileStructureModel.OutputFileStructure)
    Function OpenDataEntity(entityFileName As String) As Boolean
    Function CloseDataEntity() As Boolean
    Sub PrepareFileHeaderString()
    Function AssembleRecord(inputStructure As IFileStructureModel.OutputFileStructure) As String
    Function WriteHeader() As Boolean
    Function WriteRecord() As Boolean
    Function WriteRecordToFile(targetString As String) As Boolean
End Interface

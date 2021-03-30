Public Class OutputFilePresenter
    Private TransferViewInstance As IOutputFileInterface
    Private NewOrderModelInstance As OutputFileWriterModel
    Private p_OldOrderFileObject As Microsoft.VisualBasic.FileIO.TextFieldParser
    Private p_FileOpenSuccess As Boolean

    Sub New(view As IOutputFileInterface)
        TransferViewInstance = view
        NewOrderModelInstance = New OutputFileWriterModel
        p_FileOpenSuccess = False
    End Sub

    Sub CreateOrOpenOutputFile()
        TransferViewInstance.OutputFileOpenSuccess = NewOrderModelInstance.OpenDataEntity(TransferViewInstance.OutputFileName)
    End Sub

    Sub LoadDataForOutputFileWrite()
        NewOrderModelInstance.FileData = TransferViewInstance.OutputFileData
    End Sub

    Sub WriteToOutputFile()
        TransferViewInstance.FileWriteSuccess = NewOrderModelInstance.WriteRecord()
    End Sub

    Sub CloseOutputFile()
        TransferViewInstance.OutputFileCloseSuccess = NewOrderModelInstance.CloseDataEntity()
    End Sub
End Class

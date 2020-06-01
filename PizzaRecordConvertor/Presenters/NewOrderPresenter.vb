Public Class NewOrderPresenter
    Private p_ImportFileViewInstance As INewOrderInterface
    Private p_ImportFileModelInstance As NewOrderModel
    Private p_FileOpenSuccess As Boolean

    Public Sub New(view As INewOrderInterface)
        p_ImportFileViewInstance = view
        p_ImportFileModelInstance = New NewOrderModel
        p_FileOpenSuccess = False
    End Sub

    Public Sub OpenItemFileToWrite()
        p_ImportFileViewInstance.NewOrderImportFileLocationDisplayField = p_ImportFileViewInstance.NewOrderImportFileLocation
        p_ImportFileModelInstance.OpenFile(p_ImportFileViewInstance.NewOrderImportFileLocation)
    End Sub

    Public Sub GetRecordFromDataRead()
        p_ImportFileModelInstance.RecordLineToWrite = p_ImportFileViewInstance.NewOrderFormatRecordLine
    End Sub

    Public Sub WriteItemRecord()
        p_ImportFileModelInstance.WriteRecord()
    End Sub

    Public Sub ClearFields()
        p_ImportFileModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_ImportFileModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

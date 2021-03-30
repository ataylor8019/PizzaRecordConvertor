Public Class SourceFilePresenter
    Private TransferViewInstance As ISourceFileInterface
    Private OldOrderModelInstance As SourceFileReaderModel
    Private p_OldOrderFileObject As Microsoft.VisualBasic.FileIO.TextFieldParser
    Private p_FileOpenSuccess As Boolean

    Sub New(view As ISourceFileInterface)
        TransferViewInstance = view
        OldOrderModelInstance = New SourceFileReaderModel
    End Sub



    Sub VerifyFilename()
        TransferViewInstance.VerifyFilename = OldOrderModelInstance.VerifyFilename(TransferViewInstance.SourceFileName)
    End Sub

    Sub SetDateTime()
        TransferViewInstance.OrderDateTime = OldOrderModelInstance.GetOrderDateTime(TransferViewInstance.SourceFileName)
        OldOrderModelInstance.OrderDateTime = TransferViewInstance.OrderDateTime
    End Sub

    Sub OpenSourceFile()
        TransferViewInstance.SourceFileOpenSuccess = OldOrderModelInstance.OpenDataEntity(TransferViewInstance.FullPathSourceFileName)
    End Sub

    Sub GetSourceFileObject()
        TransferViewInstance.SourceFile = OldOrderModelInstance.SourceFile
    End Sub

    Sub ScanOpenFile()
        TransferViewInstance.FileReadSuccess = OldOrderModelInstance.userReadOrderFileData()
    End Sub

    Sub CollectFormattedSourceOrderFileData()
        TransferViewInstance.SourceOrderFileData = OldOrderModelInstance.FileData
    End Sub

    Sub ClearFileData()
        OldOrderModelInstance.FileData.Clear()
    End Sub

    Sub CloseSourceFile()
        TransferViewInstance.SourceFileCloseSuccess = OldOrderModelInstance.CloseDataEntity()
    End Sub
End Class

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
        p_ImportFileModelInstance.FirstName = p_ImportFileViewInstance.NewOrderFormatCustomerFirstName
        p_ImportFileModelInstance.MiddleInitial = p_ImportFileViewInstance.NewOrderFormatCustomerMiddleInitial
        p_ImportFileModelInstance.LastName = p_ImportFileViewInstance.NewOrderFormatCustomerLastName
        p_ImportFileModelInstance.HomePhoneNumber = p_ImportFileViewInstance.NewOrderFormatCustomerHomePhoneNumber
        p_ImportFileModelInstance.StreetAddress = p_ImportFileViewInstance.NewOrderFormatCustomerStreetAddress
        p_ImportFileModelInstance.ItemName = p_ImportFileViewInstance.NewOrderFormatOrderItemName
        p_ImportFileModelInstance.ItemQuantity = p_ImportFileViewInstance.NewOrderFormatOrderItemQuantity
        p_ImportFileModelInstance.ItemIndividualPrice = p_ImportFileViewInstance.NewOrderFormatOrderItemIndividualPrice
        p_ImportFileModelInstance.ItemMultiplePrice = p_ImportFileViewInstance.NewOrderFormatOrderItemMultiplePrice
        p_ImportFileModelInstance.OrderTotalCost = p_ImportFileViewInstance.NewOrderFormatOrderPrice
        p_ImportFileModelInstance.Notes = p_ImportFileViewInstance.NewOrderFormatOrderNotes
        p_ImportFileModelInstance.LineItemNumber = p_ImportFileViewInstance.NewOrderLineItemNumber
        p_ImportFileModelInstance.OrderDateTime = p_ImportFileViewInstance.NewOrderDateTime
    End Sub

    Public Sub WriteItemRecord()
        p_ImportFileModelInstance.WriteRecordToFile()
    End Sub

    Public Sub ClearFields()
        p_ImportFileModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_ImportFileModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

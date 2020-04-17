Public Class CustomerPresenter
    Private p_CustomerViewInstance As ICustomerInterface
    Private p_CustomerModelInstance As CustomerModel

    Public Sub New(view As ICustomerInterface)
        p_CustomerViewInstance = view
        p_CustomerModelInstance = New CustomerModel
    End Sub

    Public Sub OpenCustomerFileToWrite()
        p_CustomerModelInstance.FileToOpen = p_CustomerViewInstance.CustomerGetFileToOpenField
        p_CustomerModelInstance.OpenFile()
    End Sub

    Public Sub GetCustomerRecordFromDataRead()
        p_CustomerModelInstance.FirstName = p_CustomerViewInstance.CustomerFirstNameField
        p_CustomerModelInstance.MiddleInitial = p_CustomerViewInstance.CustomerMiddleInitialField
        p_CustomerModelInstance.LastName = p_CustomerViewInstance.CustomerLastNameField
        p_CustomerModelInstance.HomePhoneNumber = p_CustomerViewInstance.CustomerHomePhoneNumberField
        p_CustomerModelInstance.StreetAddress = p_CustomerViewInstance.CustomerStreetAddressField

        Try
            p_CustomerModelInstance.GetID() ' Will be Create or Find ID in future
            p_CustomerViewInstance.CustomerCustomerIDField = p_CustomerModelInstance.CustomerID
            p_CustomerViewInstance.CustomerNewCustomer = p_CustomerModelInstance.IsNewRecord()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub WriteCustomerRecord()
        Try
            p_CustomerModelInstance.WriteRecordToFile()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub ClearFields()
        p_CustomerModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_CustomerModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

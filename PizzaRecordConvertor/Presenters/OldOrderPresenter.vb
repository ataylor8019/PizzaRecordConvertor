Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OldOrderPresenter
    Private p_OldOrderViewInstance As IOldOrderInterface
    Private p_OldOrderModelInstance As OldOrderModel


    Sub New(view As IOldOrderInterface)
        p_OldOrderViewInstance = view
        p_OldOrderModelInstance = New OldOrderModel
    End Sub

    Public Sub OpenOldOrder()
        p_OldOrderModelInstance.FileToOpen = p_OldOrderViewInstance.GetFileToOpenField
        p_OldOrderModelInstance.OpenFile()
    End Sub

    Sub LoadCustomerPersonalDataFromFile()
        p_OldOrderModelInstance.LoadCustomerPersonalDataFromFile()
        p_OldOrderViewInstance.SetCustomerFirstNameField = p_OldOrderModelInstance.CustomerFirstName
        p_OldOrderViewInstance.SetCustomerLastNameField = p_OldOrderModelInstance.CustomerLastName
        p_OldOrderViewInstance.SetCustomerMiddleInitialField = p_OldOrderModelInstance.CustomerMiddleInitial
        p_OldOrderViewInstance.SetCustomerAddressField = p_OldOrderModelInstance.CustomerAddress
        p_OldOrderViewInstance.SetCustomerPhoneNumberField = p_OldOrderModelInstance.CustomerPhoneNumber



    End Sub

    Sub CloseFile()
        p_OldOrderModelInstance.CloseFileFORTESTINGONLY()
    End Sub

    Sub ReadCustomerData(ByRef orderFile As Microsoft.VisualBasic.FileIO.TextFieldParser)

    End Sub

    Sub ReadOrderData(ByRef orderFile As Microsoft.VisualBasic.FileIO.TextFieldParser)

    End Sub

    Sub ReadNotesData(ByRef orderFile As Microsoft.VisualBasic.FileIO.TextFieldParser)

    End Sub

End Class

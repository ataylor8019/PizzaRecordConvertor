Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OldOrderPresenter
    Private p_OldOrderViewInstance As IOldOrderInterface
    Private p_OldOrderModelInstance As OldOrderModel
    Private p_OldOrderScanMode As OldOrderModel.LineTypeRead

    Sub New(view As IOldOrderInterface)
        p_OldOrderViewInstance = view
        p_OldOrderModelInstance = New OldOrderModel
    End Sub

    Public Sub ParseOldOrderToNewDBFormat()
        p_OldOrderModelInstance.FileToOpen = p_OldOrderViewInstance.GetFileToOpenField
        p_OldOrderModelInstance.OpenFile()
    End Sub

    Public Sub OpenOldOrder()
        p_OldOrderModelInstance.FileToOpen = p_OldOrderViewInstance.GetFileToOpenField
        p_OldOrderModelInstance.OpenFile()
    End Sub

    Sub LoadCustomerPersonalDataFromFile()
        p_OldOrderModelInstance.LoadCustomerPersonalDataFromFile()
        p_OldOrderViewInstance.OldOrderFirstNameField = p_OldOrderModelInstance.CustomerFirstName
        p_OldOrderViewInstance.OldOrderLastNameField = p_OldOrderModelInstance.CustomerLastName
        p_OldOrderViewInstance.OldOrderMiddleInitialField = p_OldOrderModelInstance.CustomerMiddleInitial
        p_OldOrderViewInstance.OldOrderAddressField = p_OldOrderModelInstance.CustomerAddress
        p_OldOrderViewInstance.OldOrderPhoneNumberField = p_OldOrderModelInstance.CustomerPhoneNumber

        Dim testVal As OldOrderModel.LineTypeRead
        testVal = p_OldOrderModelInstance.GetStageOfFileRead
    End Sub

    Sub CloseFile()
        p_OldOrderModelInstance.CloseFileFORTESTINGONLY()
    End Sub

    Sub ReadCustomerData()

    End Sub

    Sub ReadOrderData()

    End Sub

    Sub ReadNotesData()

    End Sub

End Class

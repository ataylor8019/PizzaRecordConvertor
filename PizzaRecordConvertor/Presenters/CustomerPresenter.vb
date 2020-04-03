Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

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

    Public Sub CloseFile()

    End Sub
End Class

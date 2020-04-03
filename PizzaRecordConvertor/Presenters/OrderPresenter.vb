Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OrderPresenter
    Private p_OrderViewInstance As IOrderInterface
    Private p_OrderModelInstance As OrderModel

    Public Sub New(view As IOrderInterface)

    End Sub

    Public Sub OpenOrderFileToWrite()

    End Sub

    Public Sub CloseFile()

    End Sub
End Class

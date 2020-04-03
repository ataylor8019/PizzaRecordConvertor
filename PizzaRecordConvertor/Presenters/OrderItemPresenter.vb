Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OrderItemPresenter
    Private p_OrderItemViewInstance As IOrderItemInterface
    Private p_OrderItemModelInstance As OrderItemModel

    Public Sub New(view As IOrderItemInterface)

    End Sub

    Public Sub OpenOrderItemFileToWrite()

    End Sub

    Public Sub CloseFile()

    End Sub
End Class

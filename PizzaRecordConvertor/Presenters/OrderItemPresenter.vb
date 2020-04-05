Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OrderItemPresenter
    Private p_OrderItemViewInstance As IOrderItemInterface
    Private p_OrderItemModelInstance As OrderItemModel

    Public Sub New(view As IOrderItemInterface)
        p_OrderItemViewInstance = view
        p_OrderItemModelInstance = New OrderItemModel
    End Sub

    Public Sub OpenOrderItemFileToWrite()
        p_OrderItemModelInstance.FileToOpen = p_OrderItemViewInstance.OrderItemGetFileToOpenField
        p_OrderItemModelInstance.OpenFile()
    End Sub

    Public Sub GetOrderItemRecordFromDataRead()
        p_OrderItemModelInstance.OrderID = p_OrderItemViewInstance.OrderItemOrderIDField
        p_OrderItemModelInstance.MenuID = p_OrderItemViewInstance.OrderItemMenuIDField
        p_OrderItemModelInstance.ItemQuantity = p_OrderItemViewInstance.OrderItemItemQuantityField
        p_OrderItemModelInstance.TotalItemPrice = p_OrderItemViewInstance.OrderItemTotalItemPriceField
    End Sub

    Public Sub WriteOrderItemRecord()
        Try
            p_OrderItemModelInstance.WriteOrderItemToFile()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub ClearFields()
        p_OrderItemModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_OrderItemModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

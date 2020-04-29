Public Class OrderItemPresenter
    Private p_OrderItemViewInstance As IOrderItemInterface
    Private p_OrderItemModelInstance As OrderItemModel
    Private p_FileOpenSuccess As Boolean

    Public Sub New(view As IOrderItemInterface)
        p_OrderItemViewInstance = view
        p_OrderItemModelInstance = New OrderItemModel
        p_FileOpenSuccess = False
    End Sub

    Public Sub OpenOrderItemFileToWrite()
        p_OrderItemViewInstance.OrderItemOutputFileLocationDisplayField = p_OrderItemViewInstance.OrderItemOutputFileLocation
        p_OrderItemModelInstance.OpenFile(p_OrderItemViewInstance.OrderItemOutputFileLocation)
    End Sub

    Public Sub GetOrderItemRecordFromDataRead()
        p_OrderItemModelInstance.OrderID = p_OrderItemViewInstance.OrderItemOrderIDField
        p_OrderItemModelInstance.MenuID = p_OrderItemViewInstance.OrderItemMenuIDField
        p_OrderItemModelInstance.ItemQuantity = p_OrderItemViewInstance.OrderItemItemQuantityField
        p_OrderItemModelInstance.TotalItemPrice = p_OrderItemViewInstance.OrderItemTotalItemPriceField
    End Sub

    Public Sub WriteOrderItemRecord()
        Try
            p_OrderItemModelInstance.WriteRecordToFile()
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

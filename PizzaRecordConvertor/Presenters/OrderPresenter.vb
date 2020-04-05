Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OrderPresenter
    Private p_OrderViewInstance As IOrderInterface
    Private p_OrderModelInstance As OrderModel

    Public Sub New(view As IOrderInterface)
        p_OrderViewInstance = view
        p_OrderModelInstance = New OrderModel
    End Sub

    Public Sub OpenOrderFileToWrite()
        p_OrderModelInstance.FileToOpen = p_OrderViewInstance.OrderGetFileToOpenField
        p_OrderModelInstance.OpenFile()
    End Sub

    Public Sub InitializeOrderRecord()
        p_OrderModelInstance.CustomerID = p_OrderViewInstance.OrderCustomerIDField
        p_OrderModelInstance.CreateID()
        p_OrderViewInstance.OrderOrderIDField = p_OrderModelInstance.OrderID
    End Sub

    Public Sub CompleteOrderFromDataRead()
        p_OrderModelInstance.OrderTotal = p_OrderViewInstance.OrderOrderPriceField
        p_OrderModelInstance.OrderNotes = p_OrderViewInstance.OrderOrderNotesField
    End Sub

    Public Sub WriteOrderRecord()
        Try
            p_OrderModelInstance.WriteOrderToFile()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub ClearFields()
        p_OrderModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_OrderModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

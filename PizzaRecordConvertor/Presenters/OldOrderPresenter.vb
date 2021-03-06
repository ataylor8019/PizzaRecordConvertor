﻿Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class OldOrderPresenter
    Private p_OldOrderViewInstance As IOldOrderInterface
    Private p_OldOrderModelInstance As OldOrderModel
    Private p_OldOrderScanMode As OldOrderModel.LineTypeRead
    Private p_FileOpenSuccess As Boolean

    Sub New(view As IOldOrderInterface)
        p_OldOrderViewInstance = view
        p_OldOrderModelInstance = New OldOrderModel
        p_FileOpenSuccess = False
    End Sub

    Public Sub OpenOldOrder()
        p_OldOrderModelInstance.OpenFile(p_OldOrderViewInstance.GetFileToOpenField)
    End Sub

    Public Sub LoadDataFromFile()
        p_OldOrderModelInstance.LoadDataFromFile()
        p_OldOrderScanMode = p_OldOrderModelInstance.GetStageOfFileRead

        Select Case p_OldOrderScanMode
            Case OldOrderModel.LineTypeRead.Customer
                p_OldOrderViewInstance.OldOrderFirstNameField = p_OldOrderModelInstance.CustomerFirstName
                p_OldOrderViewInstance.OldOrderLastNameField = p_OldOrderModelInstance.CustomerLastName
                p_OldOrderViewInstance.OldOrderMiddleInitialField = p_OldOrderModelInstance.CustomerMiddleInitial
                p_OldOrderViewInstance.OldOrderAddressField = p_OldOrderModelInstance.CustomerAddress
                p_OldOrderViewInstance.OldOrderPhoneNumberField = p_OldOrderModelInstance.CustomerPhoneNumber
                p_OldOrderViewInstance.OldOrderCustomerProcessCanRun = True

            Case OldOrderModel.LineTypeRead.OrderItem
                p_OldOrderViewInstance.OldOrderItemName = p_OldOrderModelInstance.OldOrderItemName
                p_OldOrderViewInstance.OldOrderItemQuantity = p_OldOrderModelInstance.OldOrderItemQuantity
                p_OldOrderViewInstance.OldOrderItemIndividualPrice = p_OldOrderModelInstance.OldOrderItemIndividualPrice
                p_OldOrderViewInstance.OldOrderItemMultiplePrice = p_OldOrderModelInstance.OldOrderItemMultiplePrice
                p_OldOrderViewInstance.OldOrderLineItemNumber = p_OldOrderModelInstance.LineItemNumber
                p_OldOrderViewInstance.OldOrderBodyProcessCanRun = True

            Case OldOrderModel.LineTypeRead.OrderTotal
                p_OldOrderViewInstance.OldOrderTotalPrice = p_OldOrderModelInstance.OrderTotalPrice
                p_OldOrderViewInstance.OldOrderOrderTotalPriceGathered = True

            Case OldOrderModel.LineTypeRead.OrderNotes
                p_OldOrderViewInstance.OldOrderNotes = p_OldOrderModelInstance.Notes
                p_OldOrderViewInstance.OldOrderOrderNotesGathered = True

            Case OldOrderModel.LineTypeRead.Complete
                p_OldOrderViewInstance.OldOrderFileReadComplete = True

        End Select
    End Sub

    Public Sub ClearFields()
        p_OldOrderModelInstance.ClearFields()
    End Sub

    Sub CloseFile()
        p_OldOrderModelInstance.CloseFileFORTESTINGONLY()
    End Sub

End Class

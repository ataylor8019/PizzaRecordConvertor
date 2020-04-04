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

    Public Sub OpenOldOrder()
        p_OldOrderModelInstance.FileToOpen = p_OldOrderViewInstance.GetFileToOpenField
        p_OldOrderModelInstance.OpenFile()
    End Sub

    Public Sub LoadDataFromFile()
        If p_OldOrderModelInstance.FileOpenSuccess Then
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
                    p_OldOrderViewInstance.OldOrderBodyProcessCanRun = True
                    'p_OldOrderViewInstance.OldOrderOrderItemProcessCanRun = True
                    'p_OldOrderViewInstance.OldOrderMenuItemProcessCanRun = True

                Case OldOrderModel.LineTypeRead.OrderTotal
                    p_OldOrderViewInstance.OldOrderTotalPrice = p_OldOrderModelInstance.OrderTotalPrice
                    'p_OldOrderViewInstance.OldOrderOrderProcessCanRun = True

                Case OldOrderModel.LineTypeRead.OrderNotes
                    p_OldOrderViewInstance.OldOrderNotes = p_OldOrderModelInstance.Notes
                    p_OldOrderViewInstance.OldOrderOrderProcessCanRun = True

                Case OldOrderModel.LineTypeRead.Complete
                    p_OldOrderViewInstance.OldOrderFileReadComplete = True

            End Select

        End If
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

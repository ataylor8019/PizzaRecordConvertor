Imports PizzaRecordConvertor

Public Class RecordConverter
    Implements IOldOrderInterface
    'Implements IOrderInterface
    'Implements ICustomerInterface
    'Implements IOrderInterface
    'Implements IMenuItemInterface

    Private p_FileInputLine

    Private p_CustomerFirstName
    Private p_CustomerMiddleInitial
    Private p_CustomerLastName
    Private p_CustomerAddress
    Private p_CustomerPhoneNumber
    Private p_LineItemEntry
    Private p_Notes

    Private p_OrderItemName
    Private p_OrderItemQuantity
    Private p_OrderItemIndividualPrice
    Private p_OrderItemMultiplePrice

    Private p_CustomerProcessCanRun
    Private p_OrderProcessCanRun
    Private p_OrderItemProcessCanRun
    Private p_MenuItemProcessCanRun


    Dim p_OOPresenter As OldOrderPresenter



    'Plan is to read first line to get customer information, read following lines,
    'so long as the first entry isn't named "Notes", continue feeding to other models
    'When "Notes" is read, read the remainder of the file and store that in a string

    'Open this file, pass to OldOrderPresenter.ReadCustomerData, .ReadOrderData, and 
    'ReadNotesData, in that order



    'Public Property GetCustomerFirstNameField As Object Implements IOldOrderInterface.GetCustomerFirstNameField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetCustomerLastNameField As Object Implements IOldOrderInterface.GetCustomerLastNameField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetCustomerMiddleInitialField As Object Implements IOldOrderInterface.GetCustomerMiddleInitialField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetCustomerAddressField As Object Implements IOldOrderInterface.GetCustomerAddressField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetCustomerPhoneNumberField As Object Implements IOldOrderInterface.GetCustomerPhoneNumberField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetCustomerLineItemEntryField As Object Implements IOldOrderInterface.GetCustomerLineItemEntryField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    'Public Property GetNotesField As Object Implements IOldOrderInterface.GetNotesField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    Public WriteOnly Property OldOrderFirstNameField As Object Implements IOldOrderInterface.OldOrderFirstNameField
        'Get
        '    Throw New NotImplementedException()
        'End Get
        Set(value As Object)
            p_CustomerFirstName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderLastNameField As Object Implements IOldOrderInterface.OldOrderLastNameField
        'Get
        '    Throw New NotImplementedException()
        'End Get
        Set(value As Object)
            p_CustomerLastName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderMiddleInitialField As Object Implements IOldOrderInterface.OldOrderMiddleInitialField
        'Get
        '    Throw New NotImplementedException()
        'End Get
        Set(value As Object)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public WriteOnly Property OldOrderAddressField As Object Implements IOldOrderInterface.OldOrderAddressField
        'Get
        '    Throw New NotImplementedException()
        'End Get
        Set(value As Object)
            p_CustomerAddress = value
        End Set
    End Property

    'Public Property SetCustomerLineItemEntryField As Object Implements IOldOrderInterface.SetCustomerLineItemEntryField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        p_LineItemEntry = value
    '    End Set
    'End Property

    'Public Property SetNotesField As Object Implements IOldOrderInterface.SetNotesField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        p_Notes = value
    '    End Set
    'End Property

    Public ReadOnly Property GetFileToOpenField As Object Implements IOldOrderInterface.GetFileToOpenField
        Get
            Return Trim(txtOldOrderFileLocation.Text)
        End Get
        'Set(value As Object)
        '    Throw New NotImplementedException()
        'End Set
    End Property

    Public WriteOnly Property OldOrderPhoneNumberField As Object Implements IOldOrderInterface.OldOrderPhoneNumberField
        Set(value As Object)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public WriteOnly Property OldOrderNotes As Object Implements IOldOrderInterface.OldOrderNotes
        Set(value As Object)
            p_Notes = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemName As Object Implements IOldOrderInterface.OldOrderItemName
        Set(value As Object)
            p_OrderItemName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemQuantity As Object Implements IOldOrderInterface.OldOrderItemQuantity
        Set(value As Object)
            p_OrderItemQuantity = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemIndividualPrice As Object Implements IOldOrderInterface.OldOrderItemIndividualPrice
        Set(value As Object)
            p_OrderItemIndividualPrice = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemMultiplePrice As Object Implements IOldOrderInterface.OldOrderItemMultiplePrice
        Set(value As Object)
            p_OrderItemMultiplePrice = value
        End Set
    End Property

    Public WriteOnly Property OldOrderTotalPrice As Object Implements IOldOrderInterface.OldOrderTotalPrice
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property OldOrderCustomerProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderCustomerProcessCanRun
        Set(value As Boolean)
            p_CustomerProcessCanRun = value
        End Set
    End Property

    Public WriteOnly Property OldOrderOrderProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderOrderProcessCanRun
        Set(value As Boolean)
            p_OrderProcessCanRun = value
        End Set
    End Property

    Public WriteOnly Property OldOrderOrderItemProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderOrderItemProcessCanRun
        Set(value As Boolean)
            p_OrderItemProcessCanRun = value
        End Set
    End Property

    Public WriteOnly Property OldOrderMenuItemProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderMenuItemProcessCanRun
        Set(value As Boolean)
            p_MenuItemProcessCanRun = value
        End Set
    End Property

    'Public Property SetFileToOpenField As Object Implements IOldOrderInterface.SetFileToOpenField
    '    Get
    '        Throw New NotImplementedException()
    '    End Get
    '    Set(value As Object)
    '        Throw New NotImplementedException()
    '    End Set
    'End Property

    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_OOPresenter = New OldOrderPresenter(Me)
    End Sub

    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click
        p_OOPresenter.OpenOldOrder()
        p_OOPresenter.LoadDataFromFile()
        p_OOPresenter.CloseFile()

        MsgBox("The following values were taken from the file: " & vbCrLf & p_CustomerFirstName & vbCrLf _
               & p_CustomerLastName & vbCrLf & p_CustomerMiddleInitial & vbCrLf & p_CustomerAddress & vbCrLf _
               & p_CustomerPhoneNumber & vbCrLf & p_OrderItemName & vbCrLf & p_OrderItemQuantity & vbCrLf _
               & p_OrderItemIndividualPrice & vbCrLf & p_OrderItemMultiplePrice)



    End Sub
End Class

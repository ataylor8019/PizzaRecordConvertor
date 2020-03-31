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

    Public WriteOnly Property SetCustomerPhoneNumberField As Object Implements IOldOrderInterface.SetCustomerPhoneNumberField
        'Get
        '    Throw New NotImplementedException()
        'End Get
        Set(value As Object)
            p_CustomerPhoneNumber = value
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
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property OldOrderMenuItemName As Object Implements IOldOrderInterface.OldOrderMenuItemName
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property OldOrderMenuItemQuantity As Object Implements IOldOrderInterface.OldOrderMenuItemQuantity
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property OldOrderMenuItemPrice As Object Implements IOldOrderInterface.OldOrderMenuItemPrice
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public WriteOnly Property OldOrderNotes As Object Implements IOldOrderInterface.OldOrderNotes
        Set(value As Object)
            Throw New NotImplementedException()
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
        p_OOPresenter.LoadCustomerPersonalDataFromFile()
        p_OOPresenter.CloseFile()

        MsgBox("The following values were taken from the file: " & vbCrLf & p_CustomerFirstName & vbCrLf _
               & p_CustomerLastName & vbCrLf & p_CustomerMiddleInitial & vbCrLf & p_CustomerAddress & vbCrLf _
               & p_CustomerPhoneNumber)

    End Sub
End Class

Imports PizzaRecordConvertor

Public Class RecordConverter
    Implements IOldOrderInterface
    Implements IOrderInterface
    Implements ICustomerInterface
    Implements IOrderInterface
    Implements IMenuItemInterface

    Private p_FileInputLine

    Private p_CustomerFirstName
    Private p_CustomerMiddleInitial
    Private p_CustomerLastName
    Private p_CustomerAddress
    Private p_CustomerPhoneNumber
    Private p_LineItemEntry
    Private p_Notes



    Public Property GetCustomerFirstNameField As Object Implements IOldOrderInterface.GetCustomerFirstNameField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetCustomerLastNameField As Object Implements IOldOrderInterface.GetCustomerLastNameField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetCustomerMiddleInitialField As Object Implements IOldOrderInterface.GetCustomerMiddleInitialField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetCustomerAddressField As Object Implements IOldOrderInterface.GetCustomerAddressField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetCustomerPhoneNumberField As Object Implements IOldOrderInterface.GetCustomerPhoneNumberField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetCustomerLineItemEntryField As Object Implements IOldOrderInterface.GetCustomerLineItemEntryField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property GetNotesField As Object Implements IOldOrderInterface.GetNotesField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property SetCustomerFirstNameField As Object Implements IOldOrderInterface.SetCustomerFirstNameField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_CustomerFirstName = value
        End Set
    End Property

    Public Property SetCustomerLastNameField As Object Implements IOldOrderInterface.SetCustomerLastNameField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_CustomerLastName = value
        End Set
    End Property

    Public Property SetCustomerMiddleInitialField As Object Implements IOldOrderInterface.SetCustomerMiddleInitialField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property SetCustomerAddressField As Object Implements IOldOrderInterface.SetCustomerAddressField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_CustomerAddress = value
        End Set
    End Property

    Public Property SetCustomerPhoneNumberField As Object Implements IOldOrderInterface.SetCustomerPhoneNumberField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property SetCustomerLineItemEntryField As Object Implements IOldOrderInterface.SetCustomerLineItemEntryField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_LineItemEntry = value
        End Set
    End Property

    Public Property SetNotesField As Object Implements IOldOrderInterface.SetNotesField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            p_Notes = value
        End Set
    End Property

    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class

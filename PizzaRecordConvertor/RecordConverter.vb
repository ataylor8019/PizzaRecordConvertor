Imports PizzaRecordConvertor

Public Class RecordConverter
    Implements IOldOrderInterface
    'Implements IOrderInterface
    Implements ICustomerInterface
    'Implements IOrderInterface
    'Implements IMenuItemInterface

    Private p_FileInputLine
    Private p_FileLocation As String

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
    Private p_OldOrderFileReadComplete As Boolean

    Dim p_OOPresenter As OldOrderPresenter
    Dim p_CustomerPresenterInstance As CustomerPresenter



    'Plan is to read first line to get customer information, read following lines,
    'so long as the first entry isn't named "Notes", continue feeding to other models
    'When "Notes" is read, read the remainder of the file and store that in a string

    'Open this file, pass to OldOrderPresenter.ReadCustomerData, .ReadOrderData, and 
    'ReadNotesData, in that order

    Public WriteOnly Property OldOrderFirstNameField As Object Implements IOldOrderInterface.OldOrderFirstNameField
        Set(value As Object)
            p_CustomerFirstName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderLastNameField As Object Implements IOldOrderInterface.OldOrderLastNameField
        Set(value As Object)
            p_CustomerLastName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderMiddleInitialField As Object Implements IOldOrderInterface.OldOrderMiddleInitialField
        Set(value As Object)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public WriteOnly Property OldOrderAddressField As Object Implements IOldOrderInterface.OldOrderAddressField
        Set(value As Object)
            p_CustomerAddress = value
        End Set
    End Property

    Public ReadOnly Property GetFileToOpenField As Object Implements IOldOrderInterface.GetFileToOpenField
        Get
            Return p_FileLocation & Trim(txtOldOrderFileLocation.Text)
        End Get
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

    Public Property OldOrderFileReadComplete As Boolean Implements IOldOrderInterface.OldOrderFileReadComplete
        Get
            Return p_OldOrderFileReadComplete
        End Get
        Set(value As Boolean)
            p_OldOrderFileReadComplete = value
        End Set
    End Property

    Public Property CustomerFirstNameField As Object Implements ICustomerInterface.CustomerFirstNameField
        Get
            Return p_CustomerFirstName
        End Get
        Set(value As Object)
            p_CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastNameField As Object Implements ICustomerInterface.CustomerLastNameField
        Get
            Return p_CustomerLastName
        End Get
        Set(value As Object)
            p_CustomerLastName = value
        End Set
    End Property

    Public Property CustomerStreetAddressField As Object Implements ICustomerInterface.CustomerStreetAddressField
        Get
            Return p_CustomerAddress
        End Get
        Set(value As Object)
            p_CustomerAddress = value
        End Set
    End Property

    Public Property CustomerHomePhoneNumberField As Object Implements ICustomerInterface.CustomerHomePhoneNumberField
        Get
            Return p_CustomerPhoneNumber
        End Get
        Set(value As Object)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property CustomerCustomerIDField As Object Implements ICustomerInterface.CustomerCustomerIDField
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property CustomerCustomerProcessCanRun As Object Implements ICustomerInterface.CustomerCustomerProcessCanRun
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property CustomerGetFileToOpenField As Object Implements ICustomerInterface.CustomerGetFileToOpenField
        Get
            Return p_FileLocation & "CustomerData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_OOPresenter = New OldOrderPresenter(Me)
        p_CustomerPresenterInstance = New CustomerPresenter(Me)
        p_OldOrderFileReadComplete = False
        p_FileLocation = "C:\Users\xuserx1\Documents\"
    End Sub

    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click
        p_OOPresenter.OpenOldOrder()
        p_CustomerPresenterInstance.OpenCustomerFileToWrite()
        Do Until p_OldOrderFileReadComplete
            p_OOPresenter.LoadDataFromFile()

            MsgBox("The following values were taken from the file: " & vbCrLf & p_CustomerFirstName & vbCrLf _
       & p_CustomerLastName & vbCrLf & p_CustomerMiddleInitial & vbCrLf & p_CustomerAddress & vbCrLf _
       & p_CustomerPhoneNumber & vbCrLf & p_OrderItemName & vbCrLf & p_OrderItemQuantity & vbCrLf _
       & p_OrderItemIndividualPrice & vbCrLf & p_OrderItemMultiplePrice)
            'If Customer boolean is true, write to Customer file
            'Generate IDs for Order
            'If Order Item, Menu Item boolean is true, generate IDs for Order Item, Menu Item, write to the Order Item, Menu Item files
            'Note - will need to make dictionary or sorted list for Menu items
            'If Notes boolean is true, write to Order file
        Loop

        'Set Customer, Order Item, Menu Item, Notes booleans to false
        p_OOPresenter.CloseFile()





    End Sub
End Class

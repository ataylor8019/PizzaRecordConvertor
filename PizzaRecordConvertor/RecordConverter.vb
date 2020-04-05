Imports PizzaRecordConvertor

Public Class RecordConverter
    Implements IOldOrderInterface
    Implements IOrderInterface
    Implements ICustomerInterface
    Implements IOrderItemInterface
    Implements IMenuItemInterface

    Private p_FileInputLine
    Private p_FileLocation As String

    Private p_CustomerFirstName
    Private p_CustomerMiddleInitial
    Private p_CustomerLastName
    Private p_CustomerAddress
    Private p_CustomerPhoneNumber
    Private p_CustomerID As String
    Private p_OrderID As String
    Private p_OrderPrice As String
    Private p_Notes As String

    Private p_MenuID As String
    Private p_MenuItemName As String
    Private p_MenuItemPrice As String
    Private p_MenuItemNotes As String

    Private p_OrderItemID
    Private p_OrderItemQuantity
    Private p_OrderItemIndividualPrice
    Private p_OrderItemMultiplePrice

    Private p_CustomerProcessCanRun As Boolean
    Private p_OrderProcessCanRun As Boolean
    Private p_OrderItemProcessCanRun
    Private p_MenuItemProcessCanRun
    Private p_OldOrderFileReadComplete As Boolean
    Private p_BodyProcessCanRun As Boolean

    Private p_CustomerNewCustomer As Boolean
    Private p_MenuItemNewMenuItem As Boolean


    Dim p_OldOrderPresenterInstance As OldOrderPresenter
    Dim p_CustomerPresenterInstance As CustomerPresenter
    Dim p_OrderPresenterInstance As OrderPresenter
    Dim p_MenuItemPresenterInstance As MenuItemPresenter
    Dim p_OrderItemPresenterInstance As OrderItemPresenter



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

    Public WriteOnly Property OldOrderNotes As String Implements IOldOrderInterface.OldOrderNotes
        Set(value As String)
            p_Notes = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemName As Object Implements IOldOrderInterface.OldOrderItemName
        Set(value As Object)
            p_MenuItemName = value
            MenuItemItemNameField = p_MenuItemName
        End Set
    End Property

    Public WriteOnly Property OldOrderItemQuantity As Object Implements IOldOrderInterface.OldOrderItemQuantity
        Set(value As Object)
            p_OrderItemQuantity = value
            OrderItemItemQuantityField = p_OrderItemQuantity
        End Set
    End Property

    Public WriteOnly Property OldOrderItemIndividualPrice As Object Implements IOldOrderInterface.OldOrderItemIndividualPrice
        Set(value As Object)
            p_OrderItemIndividualPrice = value
            MenuItemItemPriceField = p_OrderItemIndividualPrice
        End Set
    End Property

    Public WriteOnly Property OldOrderItemMultiplePrice As Object Implements IOldOrderInterface.OldOrderItemMultiplePrice
        Set(value As Object)
            p_OrderItemMultiplePrice = value
            OrderItemTotalItemPriceField = p_OrderItemMultiplePrice
        End Set
    End Property

    Public WriteOnly Property OldOrderTotalPrice As String Implements IOldOrderInterface.OldOrderTotalPrice
        Set(value As String)
            p_OrderPrice = value
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

    Public WriteOnly Property OldOrderBodyProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderBodyProcessCanRun
        Set(value As Boolean)
            p_BodyProcessCanRun = value
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

    Public Property CustomerCustomerIDField As String Implements ICustomerInterface.CustomerCustomerIDField
        Get
            Return p_CustomerID
        End Get
        Set(value As String)
            p_CustomerID = value
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

    Public Property CustomerMiddleInitialField As String Implements ICustomerInterface.CustomerMiddleInitialField
        Get
            Return p_CustomerMiddleInitial
        End Get
        Set(value As String)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property OrderOrderIDField As String Implements IOrderInterface.OrderOrderIDField
        Get
            Return p_OrderID
        End Get
        Set(value As String)
            p_OrderID = value
            OrderItemOrderIDField = p_OrderID
        End Set
    End Property

    Public ReadOnly Property OrderCustomerIDField As String Implements IOrderInterface.OrderCustomerIDField
        Get
            Return p_CustomerID
        End Get
    End Property

    Public Property OrderOrderPriceField As String Implements IOrderInterface.OrderOrderPriceField
        Get
            Return p_OrderPrice
        End Get
        Set(value As String)
            p_OrderPrice = value
        End Set
    End Property

    Public Property OrderOrderNotesField As String Implements IOrderInterface.OrderOrderNotesField
        Get
            Return p_Notes
        End Get
        Set(value As String)
            p_Notes = value
        End Set
    End Property

    Public Property OrderGetFileToOpenField As Object Implements IOrderInterface.OrderGetFileToOpenField
        Get
            Return p_FileLocation & "OrderData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property MenuItemMenuIDField As Object Implements IMenuItemInterface.MenuItemMenuIDField
        Get
            Return p_MenuID
        End Get
        Set(value As Object)
            p_MenuID = value
            OrderItemMenuIDField = p_MenuID
        End Set
    End Property

    Public Property MenuItemItemNameField As Object Implements IMenuItemInterface.MenuItemItemNameField
        Get
            Return p_MenuItemName
        End Get
        Set(value As Object)
            p_MenuItemName = value
        End Set
    End Property

    Public Property MenuItemItemPriceField As Object Implements IMenuItemInterface.MenuItemItemPriceField
        Get
            Return p_MenuItemPrice
        End Get
        Set(value As Object)
            p_MenuItemPrice = value
        End Set
    End Property

    Public Property MenuItemItemNotesField As Object Implements IMenuItemInterface.MenuItemItemNotesField
        Get
            Return p_MenuItemNotes
        End Get
        Set(value As Object)
            p_MenuItemNotes = value
        End Set
    End Property

    Public Property MenuItemGetFileToOpenField As Object Implements IMenuItemInterface.MenuItemGetFileToOpenField
        Get
            Return p_FileLocation & "MenuItemData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property OrderItemOrderIDField As Object Implements IOrderItemInterface.OrderItemOrderIDField
        Get
            Return p_OrderItemID
        End Get
        Set(value As Object)
            p_OrderItemID = value
        End Set
    End Property

    Public Property OrderItemMenuIDField As Object Implements IOrderItemInterface.OrderItemMenuIDField
        Get
            Return p_OrderItemIndividualPrice
        End Get
        Set(value As Object)
            p_OrderItemIndividualPrice = value
        End Set
    End Property

    Public Property OrderItemTotalItemPriceField As Object Implements IOrderItemInterface.OrderItemTotalItemPriceField
        Get
            Return p_OrderItemMultiplePrice
        End Get
        Set(value As Object)
            p_OrderItemMultiplePrice = value
        End Set
    End Property

    Public Property OrderItemItemQuantityField As Object Implements IOrderItemInterface.OrderItemItemQuantityField
        Get
            Return p_OrderItemQuantity
        End Get
        Set(value As Object)
            p_OrderItemQuantity = value
        End Set
    End Property

    Public Property OrderItemGetFileToOpenField As Object Implements IOrderItemInterface.OrderItemGetFileToOpenField
        Get
            Return p_FileLocation & "OrderItemData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property CustomerNewCustomer As Boolean Implements ICustomerInterface.CustomerNewCustomer
        Get
            Return p_CustomerNewCustomer
        End Get
        Set(value As Boolean)
            p_CustomerNewCustomer = value
        End Set
    End Property

    Public Property MenuItemNewMenuItem As Boolean Implements IMenuItemInterface.MenuItemNewMenuItem
        Get
            Return p_MenuItemNewMenuItem
        End Get
        Set(value As Boolean)
            p_MenuItemNewMenuItem = value
        End Set
    End Property

    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_OldOrderPresenterInstance = New OldOrderPresenter(Me)
        p_CustomerPresenterInstance = New CustomerPresenter(Me)
        p_OrderPresenterInstance = New OrderPresenter(Me)
        p_MenuItemPresenterInstance = New MenuItemPresenter(Me)
        p_OrderItemPresenterInstance = New OrderItemPresenter(Me)
        p_OldOrderFileReadComplete = False
        p_MenuItemNotes = "N\A"
        p_FileLocation = "C:\Users\xuserx1\Documents\PizzaData\"
    End Sub

    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click

        'Open these first, as they will stay open through all the old order file reads
        p_CustomerPresenterInstance.OpenCustomerFileToWrite()
        p_OrderPresenterInstance.OpenOrderFileToWrite()
        p_MenuItemPresenterInstance.OpenMenuItemFileToWrite()
        p_OrderItemPresenterInstance.OpenOrderItemFileToWrite()

        'For each old order file
        p_OldOrderPresenterInstance.OpenOldOrder()

        Do Until p_OldOrderFileReadComplete
            p_OldOrderPresenterInstance.LoadDataFromFile()
            If p_CustomerProcessCanRun Then    'If here, write to the Customer file, Generate OrderID
                Try
                    p_CustomerPresenterInstance.GetCustomerRecordFromDataRead()
                    p_OrderPresenterInstance.InitializeOrderRecord()
                    If CustomerNewCustomer Then p_CustomerPresenterInstance.WriteCustomerRecord()
                    p_CustomerProcessCanRun = False
                    p_CustomerPresenterInstance.ClearFields()
                Catch ex As Exception
                    MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
                End Try
            ElseIf p_BodyProcessCanRun Then    'If here, write to the MenuItem file, OrderItem file, generate IDs for both MenuItems and Individual Order IDs
                Try
                    p_MenuItemPresenterInstance.GetMenuItemRecordFromDataRead()
                    If MenuItemNewMenuItem Then p_MenuItemPresenterInstance.WriteMenuItemRecord()
                    p_OrderItemPresenterInstance.GetOrderItemRecordFromDataRead()
                    p_OrderItemPresenterInstance.WriteOrderItemRecord()
                    p_BodyProcessCanRun = False
                    p_MenuItemPresenterInstance.ClearFields()
                Catch ex As Exception
                    MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
                End Try
            ElseIf p_OrderProcessCanRun Then    'If here, write OrderID, total, notes data to Order file
                Try
                    p_OrderPresenterInstance.CompleteOrderFromDataRead()
                    p_OrderPresenterInstance.WriteOrderRecord()
                    p_OrderProcessCanRun = False
                Catch ex As Exception
                    MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
                End Try
            End If


            'MsgBox("The following values were taken from the file: " & p_OrderItemName & vbCrLf & p_OrderItemQuantity & vbCrLf _
            '& p_OrderItemIndividualPrice & vbCrLf & p_OrderItemMultiplePrice)
            'If Customer boolean is true, write to Customer file
            'Generate IDs for Order
            'If Order Item, Menu Item boolean is true, generate IDs for Order Item, Menu Item, write to the Order Item, Menu Item files
            'Note - will need to make dictionary or sorted list for Menu items
            'If Notes boolean is true, write to Order file
        Loop

        'Set Customer, Order Item, Menu Item, Notes booleans to false
        'Ensure that all fields other than ID fields are cleared, we don't want to write stale data from one file
        'to another
        p_OldOrderPresenterInstance.CloseFile()
        'End of new loop, close this file first, it will be one of many old order files


        'Close these files when we are done writing all customer and order data (happens when we are done reading from old order files)
        p_CustomerPresenterInstance.CloseFile()
        p_OrderPresenterInstance.CloseFile()
        p_MenuItemPresenterInstance.CloseFile()
        p_OrderItemPresenterInstance.CloseFile()

    End Sub
End Class

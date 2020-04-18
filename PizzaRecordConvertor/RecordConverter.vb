Imports PizzaRecordConvertor
Imports System.IO
Imports System.Text.RegularExpressions


Public Class RecordConverter
    Implements IOldOrderInterface
    Implements IOrderInterface
    Implements ICustomerInterface
    Implements IOrderItemInterface
    Implements IMenuItemInterface

#Region "PrivateVariableDeclarations"
    Private p_FileInputLine
    Private p_FileLocation As String

    Private p_CustomerFirstName As String
    Private p_CustomerMiddleInitial As String
    Private p_CustomerLastName As String
    Private p_CustomerAddress As String
    Private p_CustomerPhoneNumber As String
    Private p_CustomerID As String
    Private p_OrderID As String
    Private p_OrderPrice As String
    Private p_Notes As String

    Private p_MenuID As String
    Private p_MenuItemID As String
    Private p_MenuItemName As String
    Private p_MenuItemPrice As String
    Private p_MenuItemNotes As String

    Private p_OrderFileName As String

    Private p_OrderItemID As String
    Private p_OrderItemQuantity As String
    Private p_OrderItemIndividualPrice As String
    Private p_OrderItemMultiplePrice As String

    Private p_CustomerProcessCanRun As Boolean
    Private p_OrderProcessCanRun As Boolean
    Private p_OrderItemProcessCanRun As Boolean
    Private p_MenuItemProcessCanRun As Boolean
    Private p_OldOrderFileReadComplete As Boolean
    Private p_BodyProcessCanRun As Boolean

    Private p_CustomerNewCustomer As Boolean
    Private p_MenuItemNewMenuItem As Boolean
#End Region

#Region "PresenterDeclarations"
    Dim p_OldOrderPresenterInstance As OldOrderPresenter
    Dim p_CustomerPresenterInstance As CustomerPresenter
    Dim p_OrderPresenterInstance As OrderPresenter
    Dim p_MenuItemPresenterInstance As MenuItemPresenter
    Dim p_OrderItemPresenterInstance As OrderItemPresenter
#End Region

    'Program overview:

    '1: Select scan location
    '2: Open scan location
    'Begin Loop:
    '3: Test files in scan location for matching criteria of old order files
    '4: On match, open the old order file
    '    4.a: Read a line from the old order file
    '    4.b: Decide how to interpet line
    '        4.b.i: If customer line, have customer object read data, write to its file, also set up Order entry
    '        4.b.ii: If regular body line, have order item and menu item objects read data, write to their files
    '        4.b.iii: If end of old order file, complete order record with total, notes data, write to its file
    '    4.c: Signal that the current old order file is complete using boolean, and close old order file
    'End Loop
    '5: Close all open output data files (customer, order, order item, menu item)

#Region "OldOrderProperties"

    Public WriteOnly Property OldOrderFirstNameField As String Implements IOldOrderInterface.OldOrderFirstNameField
        Set(value As String)
            p_CustomerFirstName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderLastNameField As String Implements IOldOrderInterface.OldOrderLastNameField
        Set(value As String)
            p_CustomerLastName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderMiddleInitialField As String Implements IOldOrderInterface.OldOrderMiddleInitialField
        Set(value As String)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public WriteOnly Property OldOrderAddressField As String Implements IOldOrderInterface.OldOrderAddressField
        Set(value As String)
            p_CustomerAddress = value
        End Set
    End Property

    Public ReadOnly Property GetFileToOpenField As String Implements IOldOrderInterface.GetFileToOpenField
        Get
            Return p_FileLocation & "\" & p_OrderFileName
        End Get
    End Property

    Public WriteOnly Property OldOrderPhoneNumberField As String Implements IOldOrderInterface.OldOrderPhoneNumberField
        Set(value As String)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public WriteOnly Property OldOrderNotes As String Implements IOldOrderInterface.OldOrderNotes
        Set(value As String)
            p_Notes = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemName As String Implements IOldOrderInterface.OldOrderItemName
        Set(value As String)
            p_MenuItemName = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemQuantity As String Implements IOldOrderInterface.OldOrderItemQuantity
        Set(value As String)
            p_OrderItemQuantity = value
        End Set
    End Property

    Public WriteOnly Property OldOrderItemIndividualPrice As String Implements IOldOrderInterface.OldOrderItemIndividualPrice
        Set(value As String)
            p_OrderItemIndividualPrice = value
            p_MenuItemPrice = p_OrderItemIndividualPrice
        End Set
    End Property

    Public WriteOnly Property OldOrderItemMultiplePrice As String Implements IOldOrderInterface.OldOrderItemMultiplePrice
        Set(value As String)
            p_OrderItemMultiplePrice = value
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

#End Region

#Region "CustomerFileProperties"

    Public ReadOnly Property CustomerFirstNameField As String Implements ICustomerInterface.CustomerFirstNameField
        Get
            Return p_CustomerFirstName
        End Get
    End Property

    Public ReadOnly Property CustomerMiddleInitialField As String Implements ICustomerInterface.CustomerMiddleInitialField
        Get
            Return p_CustomerMiddleInitial
        End Get
    End Property
    Public ReadOnly Property CustomerLastNameField As String Implements ICustomerInterface.CustomerLastNameField
        Get
            Return p_CustomerLastName
        End Get
    End Property

    Public ReadOnly Property CustomerStreetAddressField As String Implements ICustomerInterface.CustomerStreetAddressField
        Get
            Return p_CustomerAddress
        End Get
    End Property

    Public ReadOnly Property CustomerHomePhoneNumberField As String Implements ICustomerInterface.CustomerHomePhoneNumberField
        Get
            Return p_CustomerPhoneNumber
        End Get
    End Property

    Public Property CustomerCustomerIDField As String Implements ICustomerInterface.CustomerCustomerIDField
        Get
            Return p_CustomerID
        End Get
        Set(value As String)
            p_CustomerID = value
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

    Public Property CustomerGetFileToOpenField As String Implements ICustomerInterface.CustomerGetFileToOpenField
        Get
            txtCustomerFileLocation.Text = p_FileLocation & "\" & "CustomerData.txt"
            Return p_FileLocation & "\" & "CustomerData.txt"
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property


#End Region

#Region "OrderFileProperties"
    Public Property OrderOrderIDField As String Implements IOrderInterface.OrderOrderIDField
        Get
            Return p_OrderID
        End Get
        Set(value As String)
            p_OrderID = value
            p_OrderItemID = p_OrderID
        End Set
    End Property

    Public ReadOnly Property OrderCustomerIDField As String Implements IOrderInterface.OrderCustomerIDField
        Get
            Return p_CustomerID
        End Get
    End Property

    Public ReadOnly Property OrderOrderPriceField As String Implements IOrderInterface.OrderOrderPriceField
        Get
            Return p_OrderPrice
        End Get
    End Property

    Public ReadOnly Property OrderOrderNotesField As String Implements IOrderInterface.OrderOrderNotesField
        Get
            Return p_Notes
        End Get
    End Property

    Public Property OrderGetFileToOpenField As Object Implements IOrderInterface.OrderGetFileToOpenField
        Get
            txtOrderFileLocation.Text = p_FileLocation & "\" & "OrderData.txt"
            Return p_FileLocation & "\" & "OrderData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

#End Region

#Region "MenuFileProperties"
    Public Property MenuItemMenuIDField As Object Implements IMenuItemInterface.MenuItemMenuIDField
        Get
            Return p_MenuID
        End Get
        Set(value As Object)
            p_MenuID = value
        End Set
    End Property

    Public ReadOnly Property MenuItemItemNameField As Object Implements IMenuItemInterface.MenuItemItemNameField
        Get
            Return p_MenuItemName
        End Get
    End Property

    Public ReadOnly Property MenuItemItemPriceField As Object Implements IMenuItemInterface.MenuItemItemPriceField
        Get
            Return p_MenuItemPrice
        End Get
    End Property

    Public ReadOnly Property MenuItemItemNotesField As Object Implements IMenuItemInterface.MenuItemItemNotesField
        Get
            Return p_MenuItemNotes
        End Get
    End Property

    Public Property MenuItemNewMenuItem As Boolean Implements IMenuItemInterface.MenuItemNewMenuItem
        Get
            Return p_MenuItemNewMenuItem
        End Get
        Set(value As Boolean)
            p_MenuItemNewMenuItem = value
        End Set
    End Property

    Public Property MenuItemGetFileToOpenField As Object Implements IMenuItemInterface.MenuItemGetFileToOpenField
        Get
            txtMenuItemFileLocation.Text = p_FileLocation & "\" & "MenuItemData.txt"
            Return p_FileLocation & "\" & "MenuItemData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

#End Region

#Region "OrderItemFileProperties"
    Public ReadOnly Property OrderItemOrderIDField As Object Implements IOrderItemInterface.OrderItemOrderIDField
        Get
            Return p_OrderItemID
        End Get
    End Property

    Public ReadOnly Property OrderItemMenuIDField As Object Implements IOrderItemInterface.OrderItemMenuIDField
        Get
            Return p_MenuID
        End Get
    End Property

    Public ReadOnly Property OrderItemTotalItemPriceField As Object Implements IOrderItemInterface.OrderItemTotalItemPriceField
        Get
            Return p_OrderItemMultiplePrice
        End Get
    End Property

    Public ReadOnly Property OrderItemItemQuantityField As Object Implements IOrderItemInterface.OrderItemItemQuantityField
        Get
            Return p_OrderItemQuantity
        End Get
    End Property

    Public Property OrderItemGetFileToOpenField As Object Implements IOrderItemInterface.OrderItemGetFileToOpenField
        Get
            txtOrderItemFileLocation.Text = p_FileLocation & "\" & "OrderItemData.txt"
            Return p_FileLocation & "\" & "OrderItemData.txt"
        End Get
        Set(value As Object)
            Throw New NotImplementedException()
        End Set
    End Property

#End Region

#Region "Initialization"
    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_OldOrderPresenterInstance = New OldOrderPresenter(Me)
        p_CustomerPresenterInstance = New CustomerPresenter(Me)
        p_OrderPresenterInstance = New OrderPresenter(Me)
        p_MenuItemPresenterInstance = New MenuItemPresenter(Me)
        p_OrderItemPresenterInstance = New OrderItemPresenter(Me)
        p_OldOrderFileReadComplete = False
        p_MenuItemNotes = "N\A"
        p_FileLocation = Application.StartupPath & "\PizzaData"



    End Sub

#End Region

#Region "CommandButtons"
    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click

        My.Computer.FileSystem.CreateDirectory(p_FileLocation & "\" & "TestGoodData")
        My.Computer.FileSystem.CreateDirectory(p_FileLocation & "\" & "TestBadData")

        'Start by disabling button, so user can't just keep importing the same files over and over
        btnConvertOldOrderFiles.Enabled = False

        'Begin loop
        'Set directory info = file location
        'Create fileinfo variable
        'read fileinfo variable name property
        'open, work on fileinfo variable name in place of magic filename
        Dim directoryInfo As New DirectoryInfo(p_FileLocation)
        Dim fileList As FileInfo() = directoryInfo.GetFiles()

        Dim orderFile As FileInfo

        'We want a file that looks like this: order_MMYYDDDD_HHMISS.txt
        'If the file doesn't look like that, it isn't a valid order file
        'and we aren't going to try to read it to import its data
        Dim rgx1 As Regex = New Regex("^order_(?:[1][0-2])|(?:[0][1-9])(?:[12][0-9])|(?:[3][01])|(?:[0][1-9])[0-9]{4}_(?:[01][0-9])|(?:[2][0-3])([0-5][0-9]){2}.txt$", RegexOptions.Multiline)

        'Open these first, as they will stay open through all the old order file reads
        p_CustomerPresenterInstance.OpenCustomerFileToWrite()
        p_OrderPresenterInstance.OpenOrderFileToWrite()
        p_MenuItemPresenterInstance.OpenMenuItemFileToWrite()
        p_OrderItemPresenterInstance.OpenOrderItemFileToWrite()

        'We will now read multiple order files, extract and write data from each of them
        For Each orderFile In fileList
            'For each old order file

            p_OrderFileName = orderFile.Name
            If rgx1.IsMatch(p_OrderFileName) Then    'It's a valid order file
                p_OldOrderPresenterInstance.OpenOldOrder()    'Open the order file to begin reading from it

                Do Until p_OldOrderFileReadComplete
                    p_OldOrderPresenterInstance.LoadDataFromFile() 'Read a line from the file, the boolean value we get below tells us where we are in the file
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
                Loop

                'End of new loop, close this file first, it will be one of many old order files
                p_OldOrderPresenterInstance.CloseFile()


                'Set to false, to prepare for the reading of a new file
                p_OldOrderFileReadComplete = False
            End If
        Next

        'Close these files when we are done writing all customer and order data (happens when we are done reading from old order files)
        p_CustomerPresenterInstance.CloseFile()
        p_OrderPresenterInstance.CloseFile()
        p_MenuItemPresenterInstance.CloseFile()
        p_OrderItemPresenterInstance.CloseFile()

    End Sub

    Private Sub btnScanLocationSelect_Click(sender As Object, e As EventArgs) Handles btnScanLocationSelect.Click
        If FolderBrowserDialog1.ShowDialog <> DialogResult.Cancel Then
            p_FileLocation = FolderBrowserDialog1.SelectedPath
            lblScanLocation.Text = "Will Scan: " & """" & p_FileLocation & """"
        End If
    End Sub

#End Region
End Class

Imports PizzaRecordConvertor
Imports System.IO
Imports System.Text.RegularExpressions


Public Class RecordConverter
    Implements IOldOrderInterface
    Implements INewOrderInterface

#Region "PrivateVariableDeclarations"
    Private p_FileInputLine
    Private p_FileLocation As String

    Private p_OldOrderCustomerFirstName As String
    Private p_OldOrderCustomerMiddleInitial As String
    Private p_OldOrderCustomerLastName As String
    Private p_OldOrderCustomerAddress As String
    Private p_OldOrderCustomerPhoneNumber As String
    Private p_OldOrderCustomerID As String
    Private p_OldOrderOrderID As String
    Private p_OldOrderOrderPrice As String
    Private p_OldOrderNotes As String
    Private p_OldOrderOrderItemID As String
    Private p_OldOrderOrderItemName As String
    Private p_OldOrderOrderItemQuantity As String
    Private p_OldOrderOrderItemIndividualPrice As String
    Private p_OldOrderOrderItemMultiplePrice As String
    Private p_OldOrderLineItemNumber As String

    Private p_NewOrderCustomerFirstName As String
    Private p_NewOrderCustomerMiddleInitial As String
    Private p_NewOrderCustomerLastName As String
    Private p_NewOrderCustomerAddress As String
    Private p_NewOrderCustomerPhoneNumber As String
    Private p_NewOrderCustomerID As String
    Private p_NewOrderOrderID As String
    Private p_NewOrderOrderPrice As String
    Private p_NewOrderNotes As String
    Private p_NewOrderOrderItemID As String
    Private p_NewOrderOrderItemName As String
    Private p_NewOrderOrderItemQuantity As String
    Private p_NewOrderOrderItemIndividualPrice As String
    Private p_NewOrderOrderItemMultiplePrice As String
    Private p_NewOrderLineItemNumber As String
    Private p_NewOrderDateTime As String

    Private Structure NewOrderFileFormat
        Friend pS_NewOrderCustomerFirstName As String
        Friend pS_NewOrderCustomerMiddleInitial As String
        Friend pS_NewOrderCustomerLastName As String
        Friend pS_NewOrderCustomerAddress As String
        Friend pS_NewOrderCustomerPhoneNumber As String
        Friend pS_NewOrderOrderPrice As String
        Friend pS_NewOrderNotes As String
        Friend pS_NewOrderOrderItemName As String
        Friend pS_NewOrderOrderItemQuantity As String
        Friend pS_NewOrderOrderItemIndividualPrice As String
        Friend pS_NewOrderOrderItemMultiplePrice As String
        Friend pS_NewOrderLineItemNumber As String
        Friend pS_NewOrderDateTime As String
    End Structure

    Private NewOrderFileRecords As List(Of NewOrderFileFormat)

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
    Private p_OrderPriceGathered As Boolean
    Private p_OrderNotesGathered As Boolean
    Private p_MenuItemProcessCanRun As Boolean
    Private p_OldOrderFileReadComplete As Boolean
    Private p_BodyProcessCanRun As Boolean

    Private p_HeaderSwitch As Boolean
    Private p_BodySwitch As Boolean
    Private p_UpperFooterSwitch As Boolean
    Private p_LowerFooterSwitch As Boolean
    Private p_CompleteFileRead As Boolean

    Private p_CustomerNewCustomer As Boolean
    Private p_MenuItemNewMenuItem As Boolean

    Private p_ErrorLog As IO.StreamWriter



#End Region

#Region "PresenterDeclarations"
    Dim p_OldOrderPresenterInstance As OldOrderPresenter
    Dim p_NewOrderPresenterInstance As NewOrderPresenter
#End Region

    'Program overview:

    '1: Select scan location
    '2: Open scan location
    'Begin Loop:
    '3: Test files in scan location for matching criteria of old order files
    '4: On match, open the old order file
    '    4.a: Read a line from the old order file
    '    4.b: Decide how to interpet line, write data to NewOrderFormat structure list we create
    '    4.c: Signal that the current old order file is complete using boolean, write structure to NewOrder file, and close old order file
    'End Loop
    '5: Close all open output data files (ImportReadyData.txt)

#Region "OldOrderProperties"

    Public Property OldOrderFirstNameField As String Implements IOldOrderInterface.OldOrderFirstNameField
        Get
            Return p_OldOrderCustomerFirstName
        End Get
        Set(value As String)
            p_OldOrderCustomerFirstName = value
        End Set
    End Property

    Public Property OldOrderLastNameField As String Implements IOldOrderInterface.OldOrderLastNameField
        Get
            Return p_OldOrderCustomerLastName
        End Get
        Set(value As String)
            p_OldOrderCustomerLastName = value
        End Set
    End Property

    Public Property OldOrderMiddleInitialField As String Implements IOldOrderInterface.OldOrderMiddleInitialField
        Get
            Return p_OldOrderCustomerMiddleInitial
        End Get
        Set(value As String)
            p_OldOrderCustomerMiddleInitial = value
        End Set
    End Property

    Public Property OldOrderAddressField As String Implements IOldOrderInterface.OldOrderAddressField
        Get
            Return p_OldOrderCustomerAddress
        End Get
        Set(value As String)
            p_OldOrderCustomerAddress = value
        End Set
    End Property

    Public ReadOnly Property GetFileToOpenField As String Implements IOldOrderInterface.GetFileToOpenField
        Get
            Return p_FileLocation & "\" & p_OrderFileName
        End Get
    End Property

    Public Property OldOrderPhoneNumberField As String Implements IOldOrderInterface.OldOrderPhoneNumberField
        Get
            Return p_OldOrderCustomerPhoneNumber
        End Get
        Set(value As String)
            p_OldOrderCustomerPhoneNumber = value
        End Set
    End Property

    Public Property OldOrderNotes As String Implements IOldOrderInterface.OldOrderNotes
        Get
            Return p_OldOrderNotes
        End Get
        Set(value As String)
            p_OldOrderNotes = value
        End Set
    End Property

    Public Property OldOrderItemName As String Implements IOldOrderInterface.OldOrderItemName
        Get
            Return p_OldOrderOrderItemName
        End Get
        Set(value As String)
            p_OldOrderOrderItemName = value
        End Set
    End Property

    Public Property OldOrderItemQuantity As String Implements IOldOrderInterface.OldOrderItemQuantity
        Get
            Return p_OldOrderOrderItemQuantity
        End Get
        Set(value As String)
            p_OldOrderOrderItemQuantity = value
        End Set
    End Property

    Public Property OldOrderItemIndividualPrice As String Implements IOldOrderInterface.OldOrderItemIndividualPrice
        Get
            Return p_OldOrderOrderItemIndividualPrice
        End Get
        Set(value As String)
            p_OldOrderOrderItemIndividualPrice = value
        End Set
    End Property

    Public Property OldOrderItemMultiplePrice As String Implements IOldOrderInterface.OldOrderItemMultiplePrice
        Get
            Return p_OldOrderOrderItemMultiplePrice
        End Get
        Set(value As String)
            p_OldOrderOrderItemMultiplePrice = value
        End Set
    End Property

    Public Property OldOrderTotalPrice As String Implements IOldOrderInterface.OldOrderTotalPrice
        Get
            Return p_OldOrderOrderPrice
        End Get
        Set(value As String)
            p_OldOrderOrderPrice = value
        End Set
    End Property

    Public Property OldOrderLineItemNumber As String Implements IOldOrderInterface.OldOrderLineItemNumber
        Get
            Return p_OldOrderLineItemNumber
        End Get
        Set(value As String)
            p_OldOrderLineItemNumber = value
        End Set
    End Property


    Public WriteOnly Property OldOrderCustomerProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderCustomerProcessCanRun
        Set(value As Boolean)
            p_CustomerProcessCanRun = value
        End Set
    End Property

    Public WriteOnly Property OldOrderBodyProcessCanRun As Boolean Implements IOldOrderInterface.OldOrderBodyProcessCanRun
        Set(value As Boolean)
            p_BodyProcessCanRun = value
        End Set
    End Property

    Public WriteOnly Property OldOrderOrderTotalPriceGathered As Boolean Implements IOldOrderInterface.OldOrderOrderTotalPriceGathered
        Set(value As Boolean)
            p_OrderPriceGathered = value
        End Set
    End Property

    Public WriteOnly Property OldOrderOrderNotesGathered As Boolean Implements IOldOrderInterface.OldOrderOrderNotesGathered
        Set(value As Boolean)
            p_OrderNotesGathered = value
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


#Region "NewOrderProperties"

    Public Property NewOrderFormatCustomerFirstName As String Implements INewOrderInterface.NewOrderFormatCustomerFirstName
        Get
            Return p_NewOrderCustomerFirstName
        End Get
        Set(value As String)
            p_NewOrderCustomerFirstName = value
        End Set
    End Property

    Public Property NewOrderFormatCustomerLastName As String Implements INewOrderInterface.NewOrderFormatCustomerLastName
        Get
            Return p_NewOrderCustomerLastName
        End Get
        Set(value As String)
            p_NewOrderCustomerLastName = value
        End Set
    End Property

    Public Property NewOrderFormatCustomerMiddleInitial As String Implements INewOrderInterface.NewOrderFormatCustomerMiddleInitial
        Get
            Return p_NewOrderCustomerMiddleInitial
        End Get
        Set(value As String)
            p_NewOrderCustomerMiddleInitial = value
        End Set
    End Property

    Public Property NewOrderFormatCustomerStreetAddress As String Implements INewOrderInterface.NewOrderFormatCustomerStreetAddress
        Get
            Return p_NewOrderCustomerAddress
        End Get
        Set(value As String)
            p_NewOrderCustomerAddress = value
        End Set
    End Property

    Public Property NewOrderFormatCustomerHomePhoneNumber As String Implements INewOrderInterface.NewOrderFormatCustomerHomePhoneNumber
        Get
            Return p_NewOrderCustomerPhoneNumber
        End Get
        Set(value As String)
            p_NewOrderCustomerPhoneNumber = value
        End Set
    End Property

    Public Property NewOrderFormatOrderItemName As String Implements INewOrderInterface.NewOrderFormatOrderItemName
        Get
            Return p_NewOrderOrderItemName
        End Get
        Set(value As String)
            p_NewOrderOrderItemName = value
        End Set
    End Property

    Public Property NewOrderFormatOrderItemQuantity As String Implements INewOrderInterface.NewOrderFormatOrderItemQuantity
        Get
            Return p_NewOrderOrderItemQuantity
        End Get
        Set(value As String)
            p_NewOrderOrderItemQuantity = value
        End Set
    End Property

    Public Property NewOrderFormatOrderItemIndividualPrice As String Implements INewOrderInterface.NewOrderFormatOrderItemIndividualPrice
        Get
            Return p_NewOrderOrderItemIndividualPrice
        End Get
        Set(value As String)
            p_NewOrderOrderItemIndividualPrice = value
        End Set
    End Property

    Public Property NewOrderFormatOrderItemMultiplePrice As String Implements INewOrderInterface.NewOrderFormatOrderItemMultiplePrice
        Get
            Return p_NewOrderOrderItemMultiplePrice
        End Get
        Set(value As String)
            p_NewOrderOrderItemMultiplePrice = value
        End Set
    End Property

    Public Property NewOrderFormatOrderNotes As String Implements INewOrderInterface.NewOrderFormatOrderNotes
        Get
            Return p_NewOrderNotes
        End Get
        Set(value As String)
            p_NewOrderNotes = value
        End Set
    End Property

    Public Property NewOrderDateTime As String Implements INewOrderInterface.NewOrderDateTime
        Get
            Return p_NewOrderDateTime
        End Get
        Set(value As String)
            p_NewOrderDateTime = value
        End Set
    End Property

    Public ReadOnly Property NewOrderImportFileLocation As String Implements INewOrderInterface.NewOrderImportFileLocation
        Get
            Return p_FileLocation & "\DatabaseImportFiles\" & "ImportReadyData.txt"
        End Get
    End Property

    Public WriteOnly Property NewOrderImportFileLocationDisplayField As String Implements INewOrderInterface.NewOrderImportFileLocationDisplayField
        Set(value As String)
            txtNewOrderFileLocation.Text = value
        End Set
    End Property

    Public Property NewOrderFormatOrderPrice As String Implements INewOrderInterface.NewOrderFormatOrderPrice
        Get
            Return p_NewOrderOrderPrice
        End Get
        Set(value As String)
            p_NewOrderOrderPrice = value
        End Set
    End Property

    Public Property NewOrderLineItemNumber As String Implements INewOrderInterface.NewOrderLineItemNumber
        Get
            Return p_NewOrderLineItemNumber
        End Get
        Set(value As String)
            p_NewOrderLineItemNumber = value
        End Set
    End Property

#End Region

    WriteOnly Property ErrorLogLocation As String
        Set(value As String)
            txtErrorLogLocation.Text = value
        End Set
    End Property

    WriteOnly Property FailedOrderFilesLocation As String
        Set(value As String)
            txtFailedOrderReadsLocation.Text = value
        End Set
    End Property

    Private Sub WriteErrorToLog(ErrorInformation As String)
        p_ErrorLog.WriteLine(ErrorInformation)
    End Sub

    Private Sub WriteErrorToLog(ErrorLocation As String, DateOccured As DateTime, ErrorMessage As String)
        Dim ErrorString As String = ErrorLocation & "," & DateOccured.ToString() & "," & ErrorMessage
        p_ErrorLog.WriteLine(ErrorString)
    End Sub

#Region "Initialization"
    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        p_OldOrderPresenterInstance = New OldOrderPresenter(Me)
        p_NewOrderPresenterInstance = New NewOrderPresenter(Me)
        p_OldOrderFileReadComplete = False
        p_MenuItemNotes = "N\A"
        p_FileLocation = Application.StartupPath & "\PizzaData"
        lblScanLocation.Text = "Will Scan: " & """" & p_FileLocation & """"

        NewOrderFileRecords = New List(Of NewOrderFileFormat)

        p_HeaderSwitch = False
        p_BodySwitch = False
        p_UpperFooterSwitch = False
        p_LowerFooterSwitch = False

        p_CustomerProcessCanRun = False
        p_BodyProcessCanRun = False
        p_OrderNotesGathered = False
        p_OrderPriceGathered = False

    End Sub

    Private Sub RecordConverter_Exit(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If p_ErrorLog IsNot Nothing Then p_ErrorLog.Close()
    End Sub

#End Region
    Private Sub LoadOrderMainInfoIntoFormatter() ' Here we load data from the OldOrder properties into the structure for later use
        NewOrderFileRecords.Add(New NewOrderFileFormat With {.pS_NewOrderCustomerFirstName = OldOrderFirstNameField,
                              .pS_NewOrderCustomerMiddleInitial = OldOrderMiddleInitialField, .pS_NewOrderCustomerLastName = OldOrderLastNameField,
                              .pS_NewOrderCustomerPhoneNumber = OldOrderPhoneNumberField, .pS_NewOrderCustomerAddress = OldOrderAddressField,
                              .pS_NewOrderOrderItemName = OldOrderItemName, .pS_NewOrderOrderItemQuantity = OldOrderItemQuantity,
                              .pS_NewOrderOrderItemIndividualPrice = OldOrderItemIndividualPrice, .pS_NewOrderOrderItemMultiplePrice = OldOrderItemMultiplePrice,
                              .pS_NewOrderLineItemNumber = OldOrderLineItemNumber, .pS_NewOrderDateTime = NewOrderDateTime})
    End Sub

    Private Sub UpdateFromOldOrder(order As NewOrderFileFormat) ' Here we actually pass the values in the structure to properties of the NewOrder view
        NewOrderFormatCustomerFirstName = order.pS_NewOrderCustomerFirstName
        NewOrderFormatCustomerMiddleInitial = order.pS_NewOrderCustomerMiddleInitial
        NewOrderFormatCustomerLastName = order.pS_NewOrderCustomerLastName
        NewOrderFormatCustomerHomePhoneNumber = order.pS_NewOrderCustomerPhoneNumber
        NewOrderFormatCustomerStreetAddress = order.pS_NewOrderCustomerAddress
        NewOrderFormatOrderItemName = order.pS_NewOrderOrderItemName
        NewOrderFormatOrderItemQuantity = order.pS_NewOrderOrderItemQuantity
        NewOrderFormatOrderItemIndividualPrice = order.pS_NewOrderOrderItemIndividualPrice
        NewOrderFormatOrderItemMultiplePrice = order.pS_NewOrderOrderItemMultiplePrice
        NewOrderLineItemNumber = order.pS_NewOrderLineItemNumber
        NewOrderDateTime = order.pS_NewOrderDateTime
    End Sub

#Region "CommandButtons"
    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click
        'New version set up to only write to one import file, leave table creation to SQL

        'Create folders to hold import files, failed order reads, and error logs
        Try
            My.Computer.FileSystem.CreateDirectory(p_FileLocation & "\DatabaseImportFiles")
            My.Computer.FileSystem.CreateDirectory(p_FileLocation & "\FailedOrderReads")
            My.Computer.FileSystem.CreateDirectory(p_FileLocation & "\ErrorLogs")
            p_ErrorLog = New IO.StreamWriter(p_FileLocation & "\ErrorLogs\ErrorLog.txt")
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString() & " The preceeding error is preventing the process from initializing. Please ensure " _
                   & "that you have the appropriate privileges to create and write to files and directories before proceeding. The program will now exit.")
            'If we cannot make directories or files, don't even try to run the process, exit
            If p_ErrorLog IsNot Nothing Then p_ErrorLog.Close()
            End
        End Try


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
        Dim DateTimeStringRegex As Regex = New Regex("[0-9]{8}_[0-9]{6}")
        Dim DateTimeStringMatch As Match

        'Open this first, as it will stay open through all the old order file reads
        p_NewOrderPresenterInstance.OpenItemFileToWrite()

        'We will now read multiple order files, extract and write data from each of them
        For Each orderFile In fileList
            p_OrderFileName = orderFile.Name
            If rgx1.IsMatch(p_OrderFileName) Then    'It's a valid order file
                DateTimeStringMatch = DateTimeStringRegex.Match(p_OrderFileName)
                NewOrderDateTime = DateTimeStringMatch.Value()
                Try
                    p_OldOrderPresenterInstance.OpenOldOrder()    'Open the order file to begin reading from it
                Catch ex As Exception
                    WriteErrorToLog("File I/O Error: " & p_OrderFileName, Now(), ex.Message)
                    Continue For
                End Try

                'Begin individual old order file process loop
                Do Until p_OldOrderFileReadComplete

                    'At beginning of each line read, set the file location booleans to false
                    'This prevents lines from "inheriting" the location values of other lines,
                    'making the program think it has completed when it hasn't, or read one type
                    'of line when it's really another
                    p_CustomerProcessCanRun = False
                    p_BodyProcessCanRun = False
                    p_OrderNotesGathered = False
                    p_OrderPriceGathered = False

                    Try
                        p_OldOrderPresenterInstance.LoadDataFromFile() 'Read a line from the file, the boolean value we get below tells us where we are in the file
                    Catch ex As Exception
                        WriteErrorToLog("File I/O Error: " & p_OrderFileName & " - There was an error in reading or extracting the data. " _
                                        & "Ensure that the file is properly formatted before reprocessing.", DateTime.Now, ex.Message)
                        Exit Do
                    End Try

                    If p_CustomerProcessCanRun Then    'If here, write to the Customer file, Generate OrderID
                        If (Not p_HeaderSwitch) And (Not p_BodySwitch) And (Not p_UpperFooterSwitch) And (Not p_LowerFooterSwitch) Then 'If Header or Body or Footer switch on, fail, send to error
                            p_HeaderSwitch = True
                        Else
                            WriteErrorToLog("File Structure Error: " & p_OrderFileName & " - Record segments are out of order, see documentation for proper input file structure.", DateAndTime.Now, "Data Input Error: Check program input")
                            Exit Do
                        End If
                    ElseIf p_BodyProcessCanRun Then    'If here, write to the MenuItem file, OrderItem file, generate IDs for both MenuItems and Individual Order IDs
                        If p_HeaderSwitch And (Not p_UpperFooterSwitch) And (Not p_LowerFooterSwitch) Then 'If Header switch is not on, fail, send to error
                            Try
                                LoadOrderMainInfoIntoFormatter()
                                p_BodySwitch = True    'Body of file has been entered
                            Catch ex As Exception
                                WriteErrorToLog("Data Read Error: " & p_OrderFileName & " - Failed to load record or customer data to intermediate " _
                                & "processing stage. Check to ensure that all fields in file header, item records, are included. Check to ensure " _
                                & "that the correct number and kind of delimiter characters are used in file header and item records.", DateAndTime.Now, ex.Message)
                                Exit Do
                            End Try
                        Else
                            WriteErrorToLog("File Structure Error: " & p_OrderFileName & " - Customer Information segment in unexpected position.", DateAndTime.Now, "Data Input Error: Check program input")
                            Exit Do
                        End If
                    ElseIf p_OrderPriceGathered Then    'If here, write OrderID, total, notes data to Order file
                        'Updated to prevent scenario where either total or notes is missing from the order input file
                        If p_HeaderSwitch And p_BodySwitch And (Not p_UpperFooterSwitch) And (Not p_LowerFooterSwitch) Then
                            'If Header, Body switches aren't on, fail, send to error
                            p_UpperFooterSwitch = True    'Footer successfully read
                        Else
                            WriteErrorToLog("File Structure Error: " & p_OrderFileName & " - Order Total segment in unexpected position", DateAndTime.Now, "Data Input Error: Check program input")
                            Exit Do
                        End If
                    ElseIf p_OrderNotesGathered Then    'If here, write OrderID, total, notes data to Order file
                        'Updated to prevent scenario where either total or notes is missing from the order input file
                        If p_HeaderSwitch And p_BodySwitch And p_UpperFooterSwitch And (Not p_LowerFooterSwitch) Then
                            'If Header, Body switches aren't on, fail, send to error
                            p_LowerFooterSwitch = True    'Footer successfully read
                        Else
                            WriteErrorToLog("File Structure Error: " & p_OrderFileName & " - Notes segment in unexpected position.", Now, "Data Input Error: Check program input")
                            Exit Do
                        End If
                    End If
                Loop

                Try
                    p_OldOrderPresenterInstance.CloseFile() 'End of new loop, close this file first, it will be one of many old order files
                Catch ex As Exception
                    WriteErrorToLog("File I/O Error: " & p_OrderFileName & " - Failed to close file. File may already be closed, or nonexistent. Check for file existence.", DateTime.Now, ex.Message)
                End Try


                'If all three of these switches aren't true, we didn't go through a complete file and/or
                'parts of the file are missing. The order file is bad, move it to the appropriate folder
                If Not (p_HeaderSwitch And p_BodySwitch And p_UpperFooterSwitch And p_LowerFooterSwitch) Then
                    My.Computer.FileSystem.MoveFile(GetFileToOpenField, p_FileLocation & "\FailedOrderReads\" & p_OrderFileName) 'Rows in file are out of order, sending to error folder
                    WriteErrorToLog("File Structure Error: " & p_OrderFileName, Now, "Data Input Error: Check program input")
                Else
                    For Each order In NewOrderFileRecords
                        Try
                            UpdateFromOldOrder(order)
                        Catch ex As Exception
                            WriteErrorToLog("Data Read Error: " & NewOrderImportFileLocation & " - Failed to load record or customer data to intermediate " _
                                & "processing stage. Check to ensure that all fields in file header, item records, are included. Check to ensure " _
                                & "that the correct number and kind of delimiter characters are used in file header and item records.", DateAndTime.Now, ex.Message)
                            Continue For
                        End Try

                        NewOrderFormatOrderPrice = OldOrderTotalPrice
                        NewOrderFormatOrderNotes = OldOrderNotes
                        Try
                            p_NewOrderPresenterInstance.GetRecordFromDataRead()
                        Catch ex As Exception
                            WriteErrorToLog("Data Read Error: " & NewOrderImportFileLocation & " - Failed to load record or customer data to intermediate " _
                                & "processing stage. Check to ensure that all fields in file header, item records, are included. Check to ensure " _
                                & "that the correct number and kind of delimiter characters are used in file header and item records.", DateAndTime.Now, ex.Message)
                        End Try

                        Try
                            p_NewOrderPresenterInstance.WriteItemRecord()
                        Catch ex As Exception
                            WriteErrorToLog("File I/O Error: " & NewOrderImportFileLocation & " - Failed to write to file. Check error message following error timestamp, and for file existence.", DateTime.Now, ex.Message)
                        End Try

                        p_NewOrderPresenterInstance.ClearFields()
                    Next
                End If

                NewOrderFileRecords.Clear()

                'Set to false, to prepare for the reading of a new file
                p_OldOrderFileReadComplete = False

                'Clear switches to prepare for the reading of a new file
                p_HeaderSwitch = False
                p_BodySwitch = False
                p_UpperFooterSwitch = False
                p_LowerFooterSwitch = False


                p_OldOrderPresenterInstance.ClearFields()
                Try
                    p_OldOrderPresenterInstance.CloseFile()
                Catch ex As Exception
                    WriteErrorToLog("File I/O Error: " & p_OrderFileName & " - Failed to close file. File may already be closed, or nonexistent. Check for file existence.", DateTime.Now, ex.Message)
                End Try
            End If
        Next

        'Close these files when we are done writing all customer and order data (happens when we are done reading from old order files)
        Try
            p_NewOrderPresenterInstance.CloseFile()
        Catch ex As Exception
            WriteErrorToLog("File I/O Error: " & NewOrderImportFileLocation & " - Failed to close file. File may already be closed, or nonexistent. Check for file existence.", DateTime.Now, ex.Message)
        End Try
        p_ErrorLog.Close() 'Ensure that ErrorLog closes no matter what

        ErrorLogLocation = p_FileLocation & "\ErrorLogs\" & "ErrorLog.txt"
        FailedOrderFilesLocation = p_FileLocation & "\FailedOrderReads\"
    End Sub

    Private Sub btnScanLocationSelect_Click(sender As Object, e As EventArgs) Handles btnScanLocationSelect.Click
        If FolderBrowserDialog1.ShowDialog <> DialogResult.Cancel Then
            p_FileLocation = FolderBrowserDialog1.SelectedPath
            lblScanLocation.Text = "Will Scan: " & """" & p_FileLocation & """"
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        End
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        p_OldOrderPresenterInstance.ClearFields()
        p_NewOrderPresenterInstance.ClearFields()
        NewOrderImportFileLocationDisplayField = ""
        ErrorLogLocation = ""
        FailedOrderFilesLocation = ""
        btnConvertOldOrderFiles.Enabled = True
    End Sub


#End Region
End Class

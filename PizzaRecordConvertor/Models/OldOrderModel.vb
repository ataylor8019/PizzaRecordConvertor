Imports System.Collections
Imports System.Enum

Public Class OldOrderModel
    Private p_FileToOpen As String

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

    Private p_CustomerPrimaryKeyLog

    Private p_OldOrderFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser


    Public Property CustomerFirstName() As String
        Get
            Return p_CustomerFirstName
        End Get
        Set(ByVal value As String)
            p_CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastName() As String
        Get
            Return p_CustomerLastName
        End Get
        Set(ByVal value As String)
            p_CustomerLastName = value
        End Set
    End Property

    Public Property CustomerMiddleInitial() As String
        Get
            Return p_CustomerMiddleInitial
        End Get
        Set(ByVal value As String)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property CustomerPhoneNumber() As String
        Get
            Return p_CustomerPhoneNumber
        End Get
        Set(ByVal value As String)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property CustomerAddress() As String
        Get
            Return p_CustomerAddress
        End Get
        Set(ByVal value As String)
            p_CustomerAddress = value
        End Set
    End Property

    Public Property LineItemEntry() As String
        Get
            Return p_LineItemEntry
        End Get
        Set(ByVal value As String)
            p_LineItemEntry = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return p_Notes
        End Get
        Set(ByVal value As String)
            p_Notes = value
        End Set
    End Property

    Private p_CustomerData As String()
    Public Property CustomerData() As String()
        Get
            Return p_CustomerData
        End Get
        Set(ByVal value As String())
            p_CustomerData = value
        End Set
    End Property

    Private p_OrderItemData As String()
    Public Property OrderItemData() As String()
        Get
            Return p_OrderItemData
        End Get
        Set(ByVal value As String())
            p_OrderItemData = value
        End Set
    End Property

    Private p_OrderTotalPrice As String
    Public Property OrderTotalPrice() As String
        Get
            Return p_OrderTotalPrice
        End Get
        Set(ByVal value As String)
            p_OrderTotalPrice = value
        End Set
    End Property

    Private p_OrderSummaryData As String()
    Public Property OrderSummaryData() As String
        Get
            Return p_OrderSummaryData
        End Get
        Set(ByVal value As String)
            p_OrderSummaryData = value
        End Set
    End Property

    Private p_OrderNotesData As String
    Public Property OrderNotesData() As String
        Get
            Return p_OrderNotesData
        End Get
        Set(ByVal value As String)
            p_OrderNotesData = value
        End Set
    End Property

    Public Property FileToOpen() As String
        Get
            Return p_FileToOpen
        End Get
        Set(ByVal value As String)
            p_FileToOpen = value
        End Set
    End Property


    Private p_StageOfFileRead As LineTypeRead
    Public ReadOnly Property GetStageOfFileRead() As LineTypeRead 'Property to tell presenter what part of the file is being read, and therefore what properties to check for updates
        Get
            Return p_StageOfFileRead
        End Get
    End Property

    Public Sub OpenFile()
        p_OldOrderFileReader = New FileIO.TextFieldParser(p_FileToOpen)
        p_OldOrderFileReader.SetDelimiters(",")
    End Sub

    Public Sub LoadCustomerPersonalDataFromFile() 'Reads the first row containing customer data from the file, stores in variables for outgoing properties
        Try
            p_CustomerData = p_OldOrderFileReader.ReadFields()
            p_CustomerFirstName = p_CustomerData(0)
            p_CustomerMiddleInitial = p_CustomerData(1)
            p_CustomerLastName = p_CustomerData(2)
            p_CustomerAddress = p_CustomerData(3)
            p_CustomerPhoneNumber = p_CustomerData(4)
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try

    End Sub

    Public Sub LoadCustomerOrderDataFromFile() 'Reads any data that isn't customer or notes data, stores in variables for outgoing properties
        Try
            If p_OldOrderFileReader.PeekChars(1) IsNot "" Then
                If (p_OldOrderFileReader.PeekChars(4)).ToLower() = "cust" Then
                    p_CustomerData = p_OldOrderFileReader.ReadFields()
                    p_CustomerFirstName = p_CustomerData(0)
                    p_CustomerMiddleInitial = p_CustomerData(1)
                    p_CustomerLastName = p_CustomerData(2)
                    p_CustomerAddress = p_CustomerData(3)
                    p_CustomerPhoneNumber = p_CustomerData(4)
                    p_StageOfFileRead = LineTypeRead.Customer
                ElseIf (p_OldOrderFileReader.PeekChars(4)).ToLower() = "item" Then
                    p_OrderItemData = p_OldOrderFileReader.ReadFields()
                    p_OrderItemName = p_OrderItemData(0)
                    p_OrderItemQuantity = p_OrderItemData(1)
                    p_OrderItemIndividualPrice = p_OrderItemData(2)
                    p_OrderItemMultiplePrice = p_OrderItemData(3)
                    p_StageOfFileRead = LineTypeRead.OrderItem
                ElseIf (p_OldOrderFileReader.PeekChars(5)).ToLower() = "total" Then
                    p_OrderSummaryData = p_OldOrderFileReader.ReadFields()
                    p_OrderTotalPrice = p_OrderSummaryData(1)
                    p_StageOfFileRead = LineTypeRead.OrderTotal
                ElseIf (p_OldOrderFileReader.PeekChars(5)).ToLower() = "notes" Then
                    p_OrderNotesData = p_OldOrderFileReader.ReadToEnd()
                    p_Notes = p_OrderNotesData.Substring(5)
                    p_StageOfFileRead = LineTypeRead.OrderNotes
                End If
            End If
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_OldOrderFileReader.Close()
    End Sub

    Enum LineTypeRead 'Presents values to be selected based on the part of the file that is being read
        Customer
        OrderItem
        OrderTotal
        OrderNotes
    End Enum

End Class

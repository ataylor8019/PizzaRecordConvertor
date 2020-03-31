Imports System.Collections

Public Class OldOrderModel
    Private p_FileToOpen As String

    Private p_CustomerFirstName
    Private p_CustomerMiddleInitial
    Private p_CustomerLastName
    Private p_CustomerAddress
    Private p_CustomerPhoneNumber
    Private p_LineItemEntry
    Private p_Notes

    Private p_MenuItemName
    Private p_MenuItemQuantity
    Private p_MenuItemPrice

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

    Private p_OrderData As String()
    Public Property OrderData() As String()
        Get
            Return p_OrderData
        End Get
        Set(ByVal value As String())
            p_OrderData = value
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

    Private m_ReadyToReadNotes As Boolean
    Public Property ReadyToReadNotes() As Boolean 'Property to tell us if we are ready to read the Notes section of the file
        Get
            Return m_ReadyToReadNotes
        End Get
        Set(ByVal value As Boolean)
            m_ReadyToReadNotes = value
        End Set
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
                If (p_OldOrderFileReader.PeekChars(5)).ToLower() <> "notes" Then
                    p_OrderData = p_OldOrderFileReader.ReadFields()
                    p_MenuItemName = p_OrderData(0)
                    p_MenuItemQuantity = p_OrderData(1)
                    p_MenuItemPrice = p_OrderData(2)
                Else
                    m_ReadyToReadNotes = True
                End If
            End If
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_OldOrderFileReader.Close()
    End Sub


End Class

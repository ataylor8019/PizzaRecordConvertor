Imports System.Collections

Public Class OldOrderModel
    Private m_FileToOpen As String

    Private m_CustomerFirstName
    Private m_CustomerMiddleInitial
    Private m_CustomerLastName
    Private m_CustomerAddress
    Private m_CustomerPhoneNumber
    Private m_LineItemEntry
    Private m_Notes
    Private m_CustomerPrimaryKeyLog

    Private m_OldOrderFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser


    Public Property CustomerFirstName() As String
        Get
            Return m_CustomerFirstName
        End Get
        Set(ByVal value As String)
            m_CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastName() As String
        Get
            Return m_CustomerLastName
        End Get
        Set(ByVal value As String)
            m_CustomerLastName = value
        End Set
    End Property

    Public Property CustomerMiddleInitial() As String
        Get
            Return m_CustomerMiddleInitial
        End Get
        Set(ByVal value As String)
            m_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property CustomerPhoneNumber() As String
        Get
            Return m_CustomerPhoneNumber
        End Get
        Set(ByVal value As String)
            m_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property CustomerAddress() As String
        Get
            Return m_CustomerAddress
        End Get
        Set(ByVal value As String)
            m_CustomerAddress = value
        End Set
    End Property

    Public Property LineItemEntry() As String
        Get
            Return m_LineItemEntry
        End Get
        Set(ByVal value As String)
            m_LineItemEntry = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return m_Notes
        End Get
        Set(ByVal value As String)
            m_Notes = value
        End Set
    End Property

    Private m_CustomerData As String()
    Public Property CustomerData() As String()
        Get
            Return m_CustomerData
        End Get
        Set(ByVal value As String())
            m_CustomerData = value
        End Set
    End Property

    Private m_OrderData As String
    Public Property OrderData() As String
        Get
            Return m_OrderData
        End Get
        Set(ByVal value As String)
            m_OrderData = value
        End Set
    End Property

    Public Property FileToOpen() As String
        Get
            Return m_FileToOpen
        End Get
        Set(ByVal value As String)
            m_FileToOpen = value
        End Set
    End Property

    Public Sub OpenFile()
        m_OldOrderFileReader = New FileIO.TextFieldParser(m_FileToOpen)
        m_OldOrderFileReader.SetDelimiters(",")
    End Sub

    Public Sub LoadCustomerPersonalDataFromFile()
        Try
            m_CustomerData = m_OldOrderFileReader.ReadFields()
            m_CustomerFirstName = m_CustomerData(0)
            m_CustomerMiddleInitial = m_CustomerData(1)
            m_CustomerLastName = m_CustomerData(2)
            m_CustomerAddress = m_CustomerData(3)
            m_CustomerPhoneNumber = m_CustomerData(4)
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try

    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        m_OldOrderFileReader.Close()
    End Sub


End Class

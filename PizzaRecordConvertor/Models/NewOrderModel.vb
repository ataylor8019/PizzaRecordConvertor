﻿Public Class NewOrderModel
    Inherits DataImportFormatFileClass

    Private p_CustomerFirstName
    Private p_CustomerLastName
    Private p_CustomerMiddleInitial
    Private p_CustomerStreetAddress
    Private p_CustomerHomePhoneNumber
    Private p_OrderItemName As String
    Private p_OrderItemQuantity As String
    Private p_OrderItemIndividualPrice As String
    Private p_OrderItemMultiplePrice As String
    Private p_OrderTotalPrice As String
    Private p_OrderNotes As String
    Private p_LineItemNumber As String
    Private p_OrderDateTime As String

    Private p_NewRecord As Boolean = True

    Private p_CustomerSeed As Int32 = 0
    Private p_CustomerID As String
    Private p_CustomerOldKey As String
    Private p_CustomerNewKey As String
    Private p_CustomerNewKeyDictionary As Dictionary(Of String, String)

    Sub New()
        p_CustomerNewKeyDictionary = New Dictionary(Of String, String)
        p_ModelString = "CustomerModel"
        p_LineItemNumber = 0
    End Sub

    Public Property FirstName() As String
        Get
            Return p_CustomerFirstName
        End Get
        Set(ByVal value As String)
            p_CustomerFirstName = value
        End Set
    End Property

    Public Property MiddleInitial() As String
        Get
            Return p_CustomerMiddleInitial
        End Get
        Set(value As String)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return p_CustomerLastName
        End Get
        Set(ByVal value As String)
            p_CustomerLastName = value
        End Set
    End Property

    Public Property StreetAddress() As String
        Get
            Return p_CustomerStreetAddress
        End Get
        Set(ByVal value As String)
            p_CustomerStreetAddress = value
        End Set
    End Property

    Public Property HomePhoneNumber() As String
        Get
            Return p_CustomerHomePhoneNumber
        End Get
        Set(ByVal value As String)
            p_CustomerHomePhoneNumber = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return p_OrderItemName
        End Get
        Set(value As String)
            p_OrderItemName = value
        End Set
    End Property

    Public Property ItemQuantity() As String
        Get
            Return p_OrderItemQuantity
        End Get
        Set(value As String)
            p_OrderItemQuantity = value
        End Set
    End Property

    Public Property ItemIndividualPrice() As String
        Get
            Return p_OrderItemIndividualPrice
        End Get
        Set(value As String)
            p_OrderItemIndividualPrice = value
        End Set
    End Property

    Public Property ItemMultiplePrice() As String
        Get
            Return p_OrderItemMultiplePrice
        End Get
        Set(value As String)
            p_OrderItemMultiplePrice = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return p_OrderNotes
        End Get
        Set(value As String)
            p_OrderNotes = value
        End Set
    End Property

    Public Property OrderDateTime() As String
        Get
            Return p_OrderDateTime
        End Get
        Set(value As String)
            p_OrderDateTime = value
        End Set
    End Property

    Public Property OrderTotalCost() As String
        Get
            Return p_OrderTotalPrice
        End Get
        Set(value As String)
            p_OrderTotalPrice = value
        End Set
    End Property
    Public Property LineItemNumber() As String
        Get
            Return p_LineItemNumber
        End Get
        Set(ByVal value As String)
            p_LineItemNumber = value
        End Set
    End Property

    Protected Overrides Sub PrepareFileHeaderString()
        p_FileHeader = "CUSTOMERFIRSTNAME" & vbTab & "CUSTOMERMIDDLEINITIAL" & vbTab & "CUSTOMERLASTNAME" & vbTab & "CUSTOMERHOMEPHONENUMBER" & vbTab & "CUSTOMERADDRESS" _
            & vbTab & "ORDERLINEITEMNUMBER" & vbTab & "ITEMNAME" & vbTab & "ITEMQUANTITY" & vbTab & "ITEMINDIVIDUALPRICE" & vbTab & "ITEMPRICEXQUANTITY" & vbTab & "ORDERTOTALCOST" & vbTab & "ORDERNOTES" & vbTab & "ORDERDATETIME"
    End Sub


    Public Overrides Function PreparedFileRecordString() As String
        Dim fRecord As String = """" & p_CustomerFirstName & """" & vbTab & """" & p_CustomerMiddleInitial & """" & vbTab & """" & p_CustomerLastName _
             & """" & vbTab & """" & p_CustomerHomePhoneNumber & """" & vbTab & """" & p_CustomerStreetAddress & """" _
             & vbTab & """" & p_LineItemNumber & """" & vbTab & """" & p_OrderItemName & """" & vbTab & """" & p_OrderItemQuantity & """" _
             & vbTab & """" & p_OrderItemIndividualPrice & """" & vbTab & """" & p_OrderItemMultiplePrice & """" & vbTab & """" & p_OrderTotalPrice & """" & vbTab & """" & p_OrderNotes & """" & vbTab & """" & p_OrderDateTime & """"

        Return fRecord
    End Function

    Public Sub ClearFields()
        p_NewRecord = True
        p_CustomerFirstName = vbNullString
        p_CustomerLastName = vbNullString
        p_CustomerMiddleInitial = vbNullString
        p_CustomerStreetAddress = vbNullString
        p_CustomerHomePhoneNumber = vbNullString
        p_OrderItemName = vbNullString
        p_OrderItemQuantity = vbNullString
        p_OrderItemIndividualPrice = vbNullString
        p_OrderItemMultiplePrice = vbNullString
        p_OrderNotes = ""
        p_LineItemNumber = 0
        p_OrderDateTime = vbNullString
    End Sub
End Class
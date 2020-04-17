﻿Public Class CustomerModel
    Inherits DataImportFormatFileClass

    Private p_FirstName
    Private p_LastName
    Private p_MiddleInitial
    Private p_StreetAddress
    Private p_HomePhoneNumber

    Private p_NewRecord As Boolean = True

    Private p_CustomerSeed As Int32 = 0
    Private p_CustomerID As String
    Private p_CustomerOldKey As String
    Private p_CustomerNewKey As String
    Private p_CustomerNewKeyDictionary As Dictionary(Of String, String)

    Sub New()
        p_CustomerNewKeyDictionary = New Dictionary(Of String, String)
    End Sub

    Public Property FirstName() As String
        Get
            Return p_FirstName
        End Get
        Set(ByVal value As String)
            p_FirstName = value
        End Set
    End Property

    Public Property MiddleInitial() As String
        Get
            Return p_MiddleInitial
        End Get
        Set(value As String)
            p_MiddleInitial = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return p_LastName
        End Get
        Set(ByVal value As String)
            p_LastName = value
        End Set
    End Property

    Public Property StreetAddress() As String
        Get
            Return p_StreetAddress
        End Get
        Set(ByVal value As String)
            p_StreetAddress = value
        End Set
    End Property

    Public Property HomePhoneNumber() As String
        Get
            Return p_HomePhoneNumber
        End Get
        Set(ByVal value As String)
            p_HomePhoneNumber = value
        End Set
    End Property

    Public ReadOnly Property CustomerID() As String
        Get
            Return p_CustomerID
        End Get
    End Property

    Public Property IsNewRecord()
        Get
            Return p_NewRecord
        End Get
        Set(value)
            p_NewRecord = value
        End Set
    End Property

    Protected Overrides Sub PrepareFileHeaderString()
        p_FileHeader = "CUSTOMERID,CUSTOMERFIRSTNAME,CUSTOMERMIDDLEINITIAL,CUSTOMERLASTNAME,CUSTOMERHOMEPHONENUMBER,CUSTOMERADDRESS"
    End Sub

    Protected Overrides Sub PrepareFileRecordString()
        p_FileRecord = """" & p_CustomerID & """" & "," & """" & p_FirstName & """" & "," & """" & p_MiddleInitial & """" & "," & """" & p_LastName _
             & """" & "," & """" & p_HomePhoneNumber & """" & "," & """" & p_StreetAddress & """"
    End Sub

    Public Sub GetID()
        Try
            p_CustomerOldKey = p_FirstName & "::" & p_MiddleInitial & "::" & p_LastName & "::" _
                & p_HomePhoneNumber & "::" & p_StreetAddress

            'Check to see if this this key exists in the dictionary.
            'If it does, ID = ID already attached to this key
            'If not, ID = CustomerID calculated here
            If p_CustomerNewKeyDictionary.ContainsKey(p_CustomerOldKey) Then
                p_CustomerID = p_CustomerNewKeyDictionary(p_CustomerOldKey)
                p_NewRecord = False
                'Add something here to prevent writing of data to text file, just pass ID to needed
                'properties outside of this function
            Else
                p_CustomerSeed += 1
                p_CustomerID = p_CustomerSeed.ToString().PadLeft(8, "0"c)
                p_CustomerNewKeyDictionary.Add(p_CustomerOldKey, p_CustomerID)
                p_NewRecord = True
            End If

        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_CustomerSeed -= 1
            p_CustomerID = vbNullString
        End Try
    End Sub

    Public Sub ClearFields()
        p_NewRecord = True
        p_FileRecord = vbNullString
        p_CustomerID = vbNullString
        p_FirstName = vbNullString
        p_MiddleInitial = vbNullString
        p_LastName = vbNullString
        p_HomePhoneNumber = vbNullString
        p_StreetAddress = vbNullString
    End Sub

End Class

Imports PizzaRecordConvertor.DataImportFormatFileClass
Public Class MenuItemModel
    Inherits DataImportFormatFileClass

    Private p_MenuSeed As Int32 = 0
    Private p_MenuID As String
    Private p_ItemName
    Private p_ItemPrice
    Private p_ItemNotes As String
    Private p_MenuItemOldKey As String

    Private p_MenuItemNewKeyDictionary As Dictionary(Of String, String)
    Private p_NewRecord As Boolean = True

    Public Property MenuID() As String    '5 digit menu ID
        Get
            Return p_MenuID
        End Get
        Set(ByVal value As String)
            p_MenuID = value
        End Set
    End Property

    Public Property ItemName() As String    'Name of item ordered to be used as the menu name
        Get
            Return p_ItemName
        End Get
        Set(ByVal value As String)
            p_ItemName = value
        End Set
    End Property

    Public Property ItemPrice() As String    'Price of item ordered (single quantity)
        Get
            Return p_ItemPrice
        End Get
        Set(ByVal value As String)
            p_ItemPrice = value
        End Set
    End Property

    Public Property ItemNotes() As String    'Notes about item
        Get
            Return p_ItemNotes
        End Get
        Set(ByVal value As String)
            p_ItemNotes = value
        End Set
    End Property

    Public Property IsNewRecord()    'Boolean signifying if menu item should be considered new or previously existing
        Get
            Return p_NewRecord
        End Get
        Set(value)
            p_NewRecord = value
        End Set
    End Property

    Public Sub New()
        p_MenuItemNewKeyDictionary = New Dictionary(Of String, String)
        p_ModelString = "MenuItemModel"
    End Sub

    Public Sub GetID()
        Dim subString As String = "GetID"

        Try
            p_MenuItemOldKey = p_ItemName & "::" & p_ItemPrice
            'Check to see if this this key exists in the dictionary.
            If p_MenuItemNewKeyDictionary.ContainsKey(p_MenuItemOldKey) Then 'If it does, ID = ID already attached to this key
                p_MenuID = p_MenuItemNewKeyDictionary(p_MenuItemOldKey)
                p_NewRecord = False
            Else    'If not, ID calculated here
                p_MenuSeed += 1
                p_MenuID = p_MenuSeed.ToString().PadLeft(5, "0"c)
                p_MenuItemNewKeyDictionary.Add(p_MenuItemOldKey, p_MenuID)
                p_NewRecord = True
            End If
        Catch argNull As ArgumentNullException
            Throw New System.ArgumentNullException(MsgBox("ArgumentNullException in " & p_ModelString & ":" & subString & " with message: " & argNull.ToString()))
        Catch argOutRange As ArgumentOutOfRangeException
            Throw New System.ArgumentOutOfRangeException(MsgBox("ArgumentOutOfRangeException in" & p_ModelString & ":" & subString & " with message: " & argOutRange.ToString()))
        Catch argBad As ArgumentException
            Throw New System.ArgumentException(MsgBox("ArgumentException in " & p_ModelString & ":" & subString & " with message: " & argBad.ToString()))
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Protected Overrides Sub PrepareFileHeaderString()
        p_FileHeader = "MENUID,MENUITEMNAME,MENUITEMPRICE,MENUITEMNOTES"
    End Sub

    Protected Overrides Sub PrepareFileRecordString()
        p_FileRecord = """" & p_MenuID & """" & "," & """" & p_ItemName & """" & "," & """" & p_ItemPrice & """" & "," & p_ItemNotes
    End Sub

    Public Sub ClearFields()
        p_NewRecord = True
        p_FileRecord = vbNullString
        p_MenuID = vbNullString
        p_ItemName = vbNullString
        p_ItemPrice = vbNullString
        p_ItemNotes = vbNullString
    End Sub

End Class

Public Class MenuItemModel

    Private p_MenuSeed As Int32 = 0
    Private p_MenuID As String
    Private p_ItemName
    Private p_ItemPrice
    Private p_ItemNotes As String
    Private p_MenuItemOldKey As String

    Private p_MenuItemNewKeyDictionary As Dictionary(Of String, String)

    Private p_FileToOpen

    Private p_FileHeader As String
    Private p_FileRecord As String

    Private p_NewRecord As Boolean = True

    Private p_FileOpenSuccess As Boolean
    Private p_RecordWriter As System.IO.StreamWriter

    Public Property MenuID() As String
        Get
            Return p_MenuID
        End Get
        Set(ByVal value As String)
            p_MenuID = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return p_ItemName
        End Get
        Set(ByVal value As String)
            p_ItemName = value
        End Set
    End Property

    Public Property ItemPrice() As String
        Get
            Return p_ItemPrice
        End Get
        Set(ByVal value As String)
            p_ItemPrice = value
        End Set
    End Property

    Public Property ItemNotes() As String
        Get
            Return p_ItemNotes
        End Get
        Set(ByVal value As String)
            p_ItemNotes = value
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

    Public Property IsNewRecord()
        Get
            Return p_NewRecord
        End Get
        Set(value)
            p_NewRecord = value
        End Set
    End Property

    Public Sub New()
        p_MenuItemNewKeyDictionary = New Dictionary(Of String, String)
    End Sub

    Public Sub GetID()
        Try
            p_MenuItemOldKey = p_ItemName & "::" & p_ItemPrice
            'Check to see if this this key exists in the dictionary.
            'If it does, ID = ID already attached to this key
            'If not, ID = CustomerID calculated here
            If p_MenuItemNewKeyDictionary.ContainsKey(p_MenuItemOldKey) Then
                p_MenuID = p_MenuItemNewKeyDictionary(p_MenuItemOldKey)
                p_NewRecord = False
                'Add something here to prevent writing of data to text file, just pass ID to needed
                'properties outside of this function
            Else
                p_MenuSeed += 1
                p_MenuID = p_MenuSeed.ToString().PadLeft(5, "0"c)
                p_MenuItemNewKeyDictionary.Add(p_MenuItemOldKey, p_MenuID)
                p_NewRecord = True
            End If
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub OpenFile()
        Try
            p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(p_FileToOpen, True)
            p_FileHeader = "MENUID, MENUITEMNAME, MENUITEMPRICE, MENUITEMNOTES"
            p_RecordWriter.WriteLine(p_FileHeader)
            p_FileOpenSuccess = True
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try
    End Sub

    Public Sub WriteMenuItemToFile()
        p_FileRecord = """" & p_MenuID & """" & "," & """" & p_ItemName & """" & "," & """" & p_ItemPrice & """" & "," & p_ItemNotes

        p_RecordWriter.WriteLine(p_FileRecord)
    End Sub

    Public Sub ClearFields()
        p_NewRecord = True
        p_FileRecord = vbNullString
        p_MenuID = vbNullString
        p_ItemName = vbNullString
        p_ItemPrice = vbNullString
        p_ItemNotes = vbNullString
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

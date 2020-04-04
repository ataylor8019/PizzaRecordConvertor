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

    Public Sub New()
        p_MenuItemNewKeyDictionary = New Dictionary(Of String, String)
    End Sub

    Public Sub CreateID()
        Try
            p_MenuItemOldKey = p_ItemName & "::" & p_ItemPrice
            p_MenuSeed += 1
            p_MenuID = p_MenuSeed.ToString().PadLeft(5, "0"c)
            p_MenuItemNewKeyDictionary.Add(p_MenuItemOldKey, p_MenuID)
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

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

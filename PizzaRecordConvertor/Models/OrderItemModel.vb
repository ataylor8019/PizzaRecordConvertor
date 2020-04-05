Public Class OrderItemModel
    Private p_OrderID
    Private p_MenuID
    Private p_TotalItemPrice
    Private p_ItemQuantity

    Private p_FileToOpen

    Private p_FileHeader As String
    Private p_FileRecord As String

    Private p_FileOpenSuccess As Boolean
    Private p_RecordWriter As System.IO.StreamWriter

    Public Property OrderID() As String
        Get
            Return p_OrderID
        End Get
        Set(ByVal value As String)
            p_OrderID = value
        End Set
    End Property

    Public Property MenuID() As String
        Get
            Return p_MenuID
        End Get
        Set(ByVal value As String)
            p_MenuID = value
        End Set
    End Property

    Public Property TotalItemPrice() As String
        Get
            Return p_TotalItemPrice
        End Get
        Set(ByVal value As String)
            p_TotalItemPrice = value
        End Set
    End Property

    Public Property ItemQuantity() As String
        Get
            Return p_ItemQuantity
        End Get
        Set(ByVal value As String)
            p_ItemQuantity = value
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


    Public Sub OpenFile()
        Try
            p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(p_FileToOpen, True)
            p_FileHeader = "ORDERID, MENUID, ORDERITEMQUANTITY, ORDERITEMPRICE"
            p_RecordWriter.WriteLine(p_FileHeader)
            p_FileOpenSuccess = True
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try
    End Sub

    Public Sub WriteOrderItemToFile()
        p_FileRecord = """" & p_OrderID & """" & "," & """" & p_MenuID & """" & "," & """" & p_ItemQuantity & """" & "," & """" & p_TotalItemPrice & """"
        p_RecordWriter.WriteLine(p_FileRecord)
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

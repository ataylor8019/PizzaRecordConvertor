Public Class OrderModel
    Private p_OrderSeed As Int32 = 0
    Private p_OrderID As String
    Private p_CustomerID
    Private p_OrderTotal
    Private p_OrderNotes

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

    Public Property CustomerID() As String
        Get
            Return p_CustomerID
        End Get
        Set(ByVal value As String)
            p_CustomerID = value
        End Set
    End Property

    Public Property OrderTotal() As String
        Get
            Return p_OrderTotal
        End Get
        Set(ByVal value As String)
            p_OrderTotal = value
        End Set
    End Property

    Public Property OrderNotes() As String
        Get
            Return p_OrderNotes
        End Get
        Set(ByVal value As String)
            p_OrderNotes = value
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


    Public Sub CreateID()
        Try
            p_OrderSeed += 1
            p_OrderID = p_OrderSeed.ToString().PadLeft(9, "0"c)
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub OpenFile()
        Try
            p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(p_FileToOpen, True)
            p_FileHeader = "ORDERID, CUSTOMERID, ORDERTOTAL, ORDERNOTES"
            p_RecordWriter.WriteLine(p_FileHeader)
            p_FileOpenSuccess = True
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try
    End Sub

    Public Sub WriteOrderToFile()
        p_FileRecord = """" & p_OrderID & """" & "," & """" & p_CustomerID & """" & "," & """" & p_OrderTotal & """" & "," & p_OrderNotes

        p_RecordWriter.WriteLine(p_FileRecord)
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub


End Class

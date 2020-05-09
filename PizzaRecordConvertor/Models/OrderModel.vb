Public Class OrderModel
    Inherits DataImportFormatFileClass

    Private p_OrderSeed As Int32 = 0
    Private p_OrderID As String
    Private p_CustomerID
    Private p_OrderTotal
    Private p_OrderNotes

    Sub New()
        p_ModelString = "OrderModel"
    End Sub

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

    Public Sub CreateID()
        Dim subString As String = "CreateID"
        Try
            p_OrderSeed += 1
            p_OrderID = p_OrderSeed.ToString().PadLeft(9, "0"c)
        Catch argOutRange As ArgumentOutOfRangeException
            Throw New System.ArgumentOutOfRangeException("""" & p_ModelString & """" & ":" & """" & subString & """" & ":" & """" & DateTime.Now.ToString() & """" & ":" & """" & argOutRange.ToString & """")
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Protected Overrides Sub PrepareFileHeaderString()
        p_FileHeader = "ORDERID,CUSTOMERID,ORDERTOTAL,ORDERNOTES"
    End Sub

    'Protected Overrides Sub PrepareFileRecordString()
    '    p_FileRecord = """" & p_OrderID & """" & "," & """" & p_CustomerID & """" & "," & """" & p_OrderTotal & """" & "," & """" & p_OrderNotes & """"
    'End Sub

    Public Overrides Function PreparedFileRecordString() As String
        Dim fRecord As String = """" & p_OrderID & """" & "," & """" & p_CustomerID & """" & "," & """" & p_OrderTotal & """" & "," & """" & p_OrderNotes & """"

        Return fRecord
    End Function

    Public Sub ClearFields()
        p_FileRecord = vbNullString
        p_OrderID = vbNullString
        p_CustomerID = vbNullString
        p_OrderTotal = vbNullString
        p_OrderNotes = vbNullString
    End Sub

End Class

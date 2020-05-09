Public Class OrderItemModel
    Inherits DataImportFormatFileClass

    Private p_OrderID
    Private p_MenuID
    Private p_TotalItemPrice
    Private p_ItemQuantity

    Sub New()
        p_ModelString = "OrderItemModel"
    End Sub

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

    Protected Overrides Sub PrepareFileHeaderString()
        p_FileHeader = "ORDERID,MENUID,ORDERITEMQUANTITY,ORDERITEMPRICE"
    End Sub

    'Protected Overrides Sub PrepareFileRecordString()
    '    p_FileRecord = """" & p_OrderID & """" & "," & """" & p_MenuID & """" & "," & """" & p_ItemQuantity & """" & "," & """" & p_TotalItemPrice & """"
    'End Sub

    Public Overrides Function PreparedFileRecordString() As String
        Dim fRecord As String = """" & p_OrderID & """" & "," & """" & p_MenuID & """" & "," & """" & p_ItemQuantity & """" & "," & """" & p_TotalItemPrice & """"

        Return fRecord
    End Function

    Public Sub ClearFields()
        p_FileRecord = vbNullString
        p_OrderID = vbNullString
        p_MenuID = vbNullString
        p_ItemQuantity = vbNullString
        p_TotalItemPrice = vbNullString
    End Sub

End Class

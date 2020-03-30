Public Class OrderItemModel
    Private m_OrderID
    Private m_MenuID
    Private m_CustomerID
    Private m_ItemQuantity

    Public Property OrderID() As String
        Get
            Return m_OrderID
        End Get
        Set(ByVal value As String)
            m_OrderID = value
        End Set
    End Property

    Public Property MenuID() As String
        Get
            Return m_MenuID
        End Get
        Set(ByVal value As String)
            m_MenuID = value
        End Set
    End Property

    Public Property CustomerID() As String
        Get
            Return m_CustomerID
        End Get
        Set(ByVal value As String)
            m_CustomerID = value
        End Set
    End Property

    Public Property ItemQuantity() As String
        Get
            Return m_ItemQuantity
        End Get
        Set(ByVal value As String)
            m_ItemQuantity = value
        End Set
    End Property
End Class

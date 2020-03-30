Public Class OrderModel
    Private m_OrderID
    Private m_CustomerID
    Private m_OrderPrice
    Private m_OrderNotes

    Public Property OrderID() As String
        Get
            Return m_OrderID
        End Get
        Set(ByVal value As String)
            m_OrderID = value
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

    Public Property OrderPrice() As String
        Get
            Return m_OrderPrice
        End Get
        Set(ByVal value As String)
            m_OrderPrice = value
        End Set
    End Property

    Public Property OrderNotes() As String
        Get
            Return m_OrderNotes
        End Get
        Set(ByVal value As String)
            m_OrderNotes = value
        End Set
    End Property
End Class

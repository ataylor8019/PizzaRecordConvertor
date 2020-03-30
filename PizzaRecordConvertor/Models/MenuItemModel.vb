Public Class MenuItemModel
    Private m_MenuID
    Private m_ItemName
    Private m_ItemPrice
    Private m_ItemNotes

    Public Property MenuID() As String
        Get
            Return m_MenuID
        End Get
        Set(ByVal value As String)
            m_MenuID = value
        End Set
    End Property

    Public Property ItemName() As String
        Get
            Return m_ItemName
        End Get
        Set(ByVal value As String)
            m_ItemName = value
        End Set
    End Property

    Public Property ItemPrice() As String
        Get
            Return m_ItemPrice
        End Get
        Set(ByVal value As String)
            m_ItemPrice = value
        End Set
    End Property

    Public Property ItemNotes() As String
        Get
            Return m_ItemNotes
        End Get
        Set(ByVal value As String)
            m_ItemNotes = value
        End Set
    End Property
End Class

Public Class OldOrderModel
    Private m_CustomerFirstName
    Private m_CustomerMiddleInitial
    Private m_CustomerLastName
    Private m_CustomerAddress
    Private m_CustomerPhoneNumber
    Private m_LineItemEntry
    Private m_Notes


    Public Property CustomerFirstName() As String
        Get
            Return m_CustomerFirstName
        End Get
        Set(ByVal value As String)
            m_CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastName() As String
        Get
            Return m_CustomerLastName
        End Get
        Set(ByVal value As String)
            m_CustomerLastName = value
        End Set
    End Property

    Public Property CustomerMiddleInitial() As String
        Get
            Return m_CustomerMiddleInitial
        End Get
        Set(ByVal value As String)
            m_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property CustomerPhoneNumber() As String
        Get
            Return m_CustomerPhoneNumber
        End Get
        Set(ByVal value As String)
            m_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property CustomerAddress() As String
        Get
            Return m_CustomerAddress
        End Get
        Set(ByVal value As String)
            m_CustomerAddress = value
        End Set
    End Property

    Public Property LineItemEntry() As String
        Get
            Return m_LineItemEntry
        End Get
        Set(ByVal value As String)
            m_LineItemEntry = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return m_Notes
        End Get
        Set(ByVal value As String)
            m_Notes = value
        End Set
    End Property
End Class

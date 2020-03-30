Public Class CustomerModel
    Private m_FirstName
    Private m_LastName
    Private m_StreetAddress
    Private m_HomePhoneNumber
    Private m_CustomerID

    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal value As String)
            m_FirstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(ByVal value As String)
            m_LastName = value
        End Set
    End Property

    Public Property StreetAddress() As String
        Get
            Return m_StreetAddress
        End Get
        Set(ByVal value As String)
            m_StreetAddress = value
        End Set
    End Property

    Public Property HomePhoneNumber() As String
        Get
            Return m_HomePhoneNumber
        End Get
        Set(ByVal value As String)
            m_HomePhoneNumber = value
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
End Class

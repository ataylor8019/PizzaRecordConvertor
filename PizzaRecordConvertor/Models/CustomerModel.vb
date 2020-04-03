Imports My.Computer.FileSystem.OpenTextFileWriter

Public Class CustomerModel
    Private m_FirstName
    Private m_LastName
    Private m_StreetAddress
    Private m_HomePhoneNumber
    Private m_CustomerID
    Private p_FileToOpen

    Private p_FileOpenSuccess As Boolean
    Private p_RecordWriter As System.IO.StreamWriter

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
            p_FileOpenSuccess = True
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try

    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

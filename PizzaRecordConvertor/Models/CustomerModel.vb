Imports My.Computer.FileSystem.OpenTextFileWriter

Public Class CustomerModel
    Private p_FirstName
    Private p_LastName
    Private p_MiddleInitial
    Private p_StreetAddress
    Private p_HomePhoneNumber
    Private p_FileToOpen

    Private p_FileHeader As String
    Private p_FileRecord As String

    Private p_FileOpenSuccess As Boolean
    Private p_RecordWriter As System.IO.StreamWriter

    Private p_CustomerSeed As Int32 = 0
    Private p_CustomerID As String
    Private p_CustomerOldKey As String
    Private p_CustomerNewKey As String
    Private p_CustomerNewKeyDictionary As Dictionary(Of String, String)

    Sub New()
        p_CustomerNewKeyDictionary = New Dictionary(Of String, String)
    End Sub

    Public Property FirstName() As String
        Get
            Return p_FirstName
        End Get
        Set(ByVal value As String)
            p_FirstName = value
        End Set
    End Property

    Public Property MiddleInitial() As String
        Get
            Return p_MiddleInitial
        End Get
        Set(value As String)
            p_MiddleInitial = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return p_LastName
        End Get
        Set(ByVal value As String)
            p_LastName = value
        End Set
    End Property

    Public Property StreetAddress() As String
        Get
            Return p_StreetAddress
        End Get
        Set(ByVal value As String)
            p_StreetAddress = value
        End Set
    End Property

    Public Property HomePhoneNumber() As String
        Get
            Return p_HomePhoneNumber
        End Get
        Set(ByVal value As String)
            p_HomePhoneNumber = value
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

    Public ReadOnly Property CustomerID() As String
        Get
            Return p_CustomerID
        End Get
    End Property

    Public Sub OpenFile()
        Try
            p_RecordWriter = My.Computer.FileSystem.OpenTextFileWriter(p_FileToOpen, True)
            p_FileHeader = "CUSTOMERID, CUSTOMERFIRSTNAME, CUSTOMERMIDDLEINITIAL, CUSTOMERLASTNAME, CUSTOMERHOMEPHONENUMBER, CUSTOMERADDRESS"
            p_RecordWriter.WriteLine(p_FileHeader)
            p_FileOpenSuccess = True
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try

    End Sub

    Public Sub CreateID()
        Try
            p_CustomerOldKey = p_FirstName & "::" & p_MiddleInitial & "::" & p_LastName & "::" _
                & p_HomePhoneNumber & "::" & p_StreetAddress
            p_CustomerSeed += 1
            p_CustomerID = p_CustomerSeed.ToString().PadLeft(8, "0"c)
            p_CustomerNewKeyDictionary.Add(p_CustomerOldKey, p_CustomerID)
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_CustomerSeed -= 1
            p_CustomerID = vbNullString
        End Try
    End Sub

    Public Sub WriteCustomerToFile()
        p_FileRecord = p_CustomerID & "," & p_FirstName & "," & p_MiddleInitial & "," & p_LastName _
             & "," & p_HomePhoneNumber & "," & p_StreetAddress

        p_RecordWriter.WriteLine(p_FileRecord)
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_RecordWriter.Close()
    End Sub
End Class

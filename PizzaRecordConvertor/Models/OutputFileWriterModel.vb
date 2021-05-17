Public Class OutputFileWriterModel
    'Implements IFileStructureModel
    Implements IOutputFileWriterModelTestScaffold

    Private _targetFile As System.IO.StreamWriter
    Private _fileHeader As String
    Private myStructure As OutputFileStructure

    Private p_RecordWriter As System.IO.StreamWriter    'Record writer object

    Private _fileData As List(Of OutputFileStructure)


    Public WriteOnly Property FileData() As List(Of OutputFileStructure) Implements IOutputFileWriterModelTestScaffold.FileData
        Set(value As List(Of OutputFileStructure))
            _fileData = value
        End Set
    End Property

    Public Function OpenDataEntity(entityFileName As String) As Boolean Implements IOutputFileWriterModelTestScaffold.OpenDataEntity

        Try
            _targetFile = My.Computer.FileSystem.OpenTextFileWriter(entityFileName, True)
            Return True
        Catch fileErr As ArgumentException
            MsgBox("Error in creating or opening output file. Check that you have creation/write privileges in desired directory.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try


    End Function

    Public Function CloseDataEntity() As Boolean Implements IOutputFileWriterModelTestScaffold.CloseDataEntity

        Try
            _targetFile.Close()
            Return True
        Catch fileErr As System.Text.EncoderFallbackException
            MsgBox("Error in closing file. Check directory/file for possible access and locking by other users.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

    End Function

    Public Sub PrepareFileHeaderString() Implements IOutputFileWriterModelTestScaffold.PrepareFileHeaderString
        _fileHeader = "CUSTOMERFIRSTNAME" & vbTab & "CUSTOMERMIDDLEINITIAL" & vbTab & "CUSTOMERLASTNAME" & vbTab & "CUSTOMERHOMEPHONENUMBER" & vbTab & "CUSTOMERADDRESS" _
            & vbTab & "ORDERLINEITEMNUMBER" & vbTab & "ITEMNAME" & vbTab & "ITEMQUANTITY" & vbTab & "ITEMINDIVIDUALPRICE" & vbTab & "ITEMPRICEXQUANTITY" & vbTab & "ORDERTOTALCOST" & vbTab & "ORDERNOTES" & vbTab & "ORDERDATETIME"
    End Sub

    Public Function AssembleRecord(inputStructure As OutputFileStructure) As String Implements IOutputFileWriterModelTestScaffold.AssembleRecord
        Dim AssembledRecord As String = """" & inputStructure._NewOrderCustomerFirstName & """" & vbTab & """" & inputStructure._NewOrderCustomerMiddleInitial & """" & vbTab & """" & inputStructure._NewOrderCustomerLastName _
             & """" & vbTab & """" & inputStructure._NewOrderCustomerPhoneNumber & """" & vbTab & """" & inputStructure._NewOrderCustomerAddress & """" _
             & vbTab & """" & inputStructure._NewOrderLineItemNumber & """" & vbTab & """" & inputStructure._NewOrderOrderItemName & """" & vbTab & """" & inputStructure._NewOrderOrderItemQuantity & """" _
             & vbTab & """" & inputStructure._NewOrderOrderItemIndividualPrice & """" & vbTab & """" & inputStructure._NewOrderOrderItemMultiplePrice & """" & vbTab & """" & inputStructure._NewOrderOrderPrice & """" & vbTab & """" & inputStructure._NewOrderNotes & """" & vbTab & """" & inputStructure._NewOrderDateTime & """"

        Return AssembledRecord
    End Function

    Public Function WriteHeader() As Boolean Implements IOutputFileWriterModelTestScaffold.WriteHeader

        Try
            _targetFile.WriteLine(_fileHeader)
            Return True
        Catch fileErr As ObjectDisposedException
            MsgBox("Failed to write header to output file. Check write privileges on desired directory/file, and try again.")
            Return False
        Catch fileErr As IO.IOException
            MsgBox("Failed to write header to output file. Check write privileges on desired directory/file, and try again.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

        Return True
    End Function

    Public Function WriteRecord() As Boolean Implements IOutputFileWriterModelTestScaffold.WriteRecord
        Dim NewOrderFormatRecordLine As String
        For Each order In _fileData
            Try
                NewOrderFormatRecordLine = AssembleRecord(order)
                If WriteRecordToFile(NewOrderFormatRecordLine) Then Continue For
            Catch ex As Exception
                Return False
            End Try
        Next
        Return True
    End Function

    Public Function WriteRecordToFile(targetString As String) As Boolean Implements IOutputFileWriterModelTestScaffold.WriteRecordToFile
        Try
            _targetFile.WriteLine(targetString)
            Return True
        Catch fileErr As ObjectDisposedException
            MsgBox("Failed to write record to output file. Check write privileges on desired directory/file, and try again.")
            Return False
        Catch fileErr As IO.IOException
            MsgBox("Failed to write record to output file. Check write privileges on desired directory/file, and try again.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try
    End Function


End Class
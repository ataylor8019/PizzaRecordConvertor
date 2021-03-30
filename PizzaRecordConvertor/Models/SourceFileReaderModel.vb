Imports System.IO
Imports System.Text.RegularExpressions

Public Class SourceFileReaderModel
    Implements IFileStructureModel
    Implements ISourceFileReaderModelTestScaffold

    Private p_OrderTotalPrice As String
    Private p_OrderNotesData As String
    Private p_OrderDateTime As String
    Private p_CustomerData As String()
    Private p_OrderItemData As String()
    Private p_OrderSummaryData As String()
    Private _sourceFile As FileIO.TextFieldParser

    Private _fileCollection As FileInfo
    Private myStructure As IFileStructureModel.OutputFileStructure

    Private _fileData As List(Of IFileStructureModel.OutputFileStructure)

    Public Property SourceFile() As FileIO.TextFieldParser Implements ISourceFileReaderModelTestScaffold.SourceFile
        Get
            Return _sourceFile
        End Get
        Set(value As FileIO.TextFieldParser)
            _sourceFile = value
        End Set
    End Property


    Public ReadOnly Property FileData() As List(Of IFileStructureModel.OutputFileStructure) Implements ISourceFileReaderModelTestScaffold.FileData
        Get
            Return _fileData
        End Get
    End Property

    Public Property FileCollection() As FileInfo Implements ISourceFileReaderModelTestScaffold.FileCollection
        Set(value As FileInfo)
            _fileCollection = value
        End Set
        Get
            Return _fileCollection
        End Get
    End Property

    Sub New()
        _fileData = New List(Of IFileStructureModel.OutputFileStructure)
    End Sub

    Public Function OpenDataEntity(entityFileName As String) As Boolean Implements ISourceFileReaderModelTestScaffold.OpenDataEntity

        Try
            _sourceFile = New FileIO.TextFieldParser(entityFileName)
            Return True
        Catch fileErr As ArgumentNullException
            MsgBox("Unable to create file due to argument error. Check file name before attempting to create file.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

    End Function

    Public Function CloseDataEntity() As Boolean Implements ISourceFileReaderModelTestScaffold.CloseDataEntity

        Try
            _sourceFile.Close()
            Return True
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

    End Function

    Public Function VerifyFilename(sourceFileName As String) As Boolean Implements ISourceFileReaderModelTestScaffold.VerifyFilename

        Try
            Dim rgx1 As Regex = New Regex("^order_(?:[1][0-2])|(?:[0][1-9])(?:[12][0-9])|(?:[3][01])|(?:[0][1-9])[0-9]{4}_(?:[01][0-9])|(?:[2][0-3])([0-5][0-9]){2}.txt$", RegexOptions.Multiline)
            If rgx1.IsMatch(sourceFileName) Then Return True
        Catch regexErr As ArgumentOutOfRangeException
            MsgBox("Regex definition or match function argument is out of range.")
            Return False
        Catch regexErr As ArgumentNullException
            MsgBox("Regex definition or match function argument is null.")
            Return False
        Catch regexErr As ArgumentException
            MsgBox("Argument error in regex definition or match function.")
            Return False
        Catch regexErr As RegexMatchTimeoutException
            MsgBox("Regex match time has exceeded system timeout limit.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

        Return False
    End Function

    Public Property OrderDateTime() As String Implements ISourceFileReaderModelTestScaffold.OrderDateTime
        Get
            Return p_OrderDateTime
        End Get
        Set(value As String)
            p_OrderDateTime = value
        End Set
    End Property

    Public Function GetOrderDateTime(sourceFileName As String) As String Implements ISourceFileReaderModelTestScaffold.GetOrderDateTime
        Try
            Dim DateTimeStringRegex As Regex = New Regex("[0-9]{8}_[0-9]{6}")
            Dim DateTimeStringMatch As Match
            Dim NewOrderDateTime As String
            DateTimeStringMatch = DateTimeStringRegex.Match(sourceFileName)
            NewOrderDateTime = DateTimeStringMatch.Value()
            Return NewOrderDateTime
        Catch regexErr As ArgumentNullException
            MsgBox("Regex definition or match function argument is null.")
            Return Nothing
        Catch regexErr As ArgumentException
            MsgBox("Argument error in regex definition or match function.")
            Return Nothing
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return Nothing
        End Try

    End Function

    Public Function GetDataLineTypeFromFile(sourceFile As Microsoft.VisualBasic.FileIO.TextFieldParser) As String Implements ISourceFileReaderModelTestScaffold.GetDataLineTypeFromFile  'Returns line type of data from peek ahead of source file
        Try
            If sourceFile.PeekChars(4).ToLower = "cust" Or sourceFile.PeekChars(4).ToLower = "item" Then
                Return Trim((sourceFile.PeekChars(4)).ToLower())
            ElseIf sourceFile.PeekChars(5).ToLower = "notes" Or sourceFile.PeekChars(5).ToLower = "total" Then
                Return Trim((sourceFile.PeekChars(5)).ToLower())
            Else
                Return Nothing
            End If
        Catch fileErr As ArgumentException
            MsgBox("Data could not be viewed or previewed in file due to argument error.")
            Return Nothing
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return Nothing
        End Try


    End Function

    Public Function userReadOrderFileData() As Boolean Implements ISourceFileReaderModelTestScaffold.userReadOrderFileData
        Return ReadOrderFileData(_sourceFile)
    End Function
    Public Function ReadOrderFileData(sourceFile As Microsoft.VisualBasic.FileIO.TextFieldParser) As Boolean Implements ISourceFileReaderModelTestScaffold.ReadOrderFileData
        Try
            Dim _tempFileData As New List(Of IFileStructureModel.OutputFileStructure)
            sourceFile.SetDelimiters(",")
            Dim lineType As String
            Do While (Not sourceFile.EndOfData)
                lineType = GetDataLineTypeFromFile(sourceFile)
                If lineType = "cust" Then
                    p_CustomerData = sourceFile.ReadFields()
                ElseIf lineType = "item" Then
                    p_OrderItemData = sourceFile.ReadFields()
                    _tempFileData.Add(New IFileStructureModel.OutputFileStructure With {._NewOrderCustomerFirstName = p_CustomerData(1),
                              ._NewOrderCustomerMiddleInitial = p_CustomerData(2), ._NewOrderCustomerLastName = p_CustomerData(3),
                              ._NewOrderCustomerPhoneNumber = p_CustomerData(4), ._NewOrderCustomerAddress = p_CustomerData(5),
                              ._NewOrderOrderItemName = p_OrderItemData(1), ._NewOrderOrderItemQuantity = p_OrderItemData(2),
                              ._NewOrderOrderItemIndividualPrice = p_OrderItemData(3), ._NewOrderOrderItemMultiplePrice = p_OrderItemData(4),
                              ._NewOrderLineItemNumber = Nothing, ._NewOrderDateTime = p_OrderDateTime, ._NewOrderOrderPrice = Nothing, ._NewOrderNotes = Nothing})
                ElseIf lineType = "total" Then
                    p_OrderSummaryData = sourceFile.ReadFields()
                ElseIf lineType = "notes" Then
                    p_OrderNotesData = sourceFile.ReadToEnd()
                End If
            Loop

            Dim lnNumber As Integer = 1
            For Each order In _tempFileData

                _fileData.Add(New IFileStructureModel.OutputFileStructure With {._NewOrderCustomerFirstName = order._NewOrderCustomerFirstName,
                              ._NewOrderCustomerMiddleInitial = order._NewOrderCustomerMiddleInitial, ._NewOrderCustomerLastName = order._NewOrderCustomerLastName,
                              ._NewOrderCustomerPhoneNumber = order._NewOrderCustomerPhoneNumber, ._NewOrderCustomerAddress = order._NewOrderCustomerAddress,
                              ._NewOrderOrderItemName = order._NewOrderOrderItemName, ._NewOrderOrderItemQuantity = order._NewOrderOrderItemQuantity,
                              ._NewOrderOrderItemIndividualPrice = order._NewOrderOrderItemIndividualPrice, ._NewOrderOrderItemMultiplePrice = order._NewOrderOrderItemMultiplePrice,
                              ._NewOrderLineItemNumber = lnNumber.ToString(), ._NewOrderDateTime = order._NewOrderDateTime, ._NewOrderOrderPrice = p_OrderSummaryData(1), ._NewOrderNotes = p_OrderNotesData})
                lnNumber += 1
            Next

            Return True
        Catch fileErr As ArgumentException
            MsgBox("Data could not be viewed or previewed in file due to argument error.")
            Return Nothing
        Catch fileErr As FileIO.MalformedLineException
            MsgBox("Field or total record line data malformed or formatted incorrectly. Correct formatting errors before retrying.")
            Return False
        Catch ex As Exception
            MsgBox("General error, specifics unknown. Program shutdown is recommended.")
            Return False
        End Try

    End Function

    Public Sub Clear()
        _fileData.Clear()
    End Sub
End Class

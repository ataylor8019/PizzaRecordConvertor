Imports PizzaRecordConvertor
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.FileIO

Public Class RecordConverter
    Implements ISourceFileInterface
    Implements IOutputFileInterface

    Dim _appLocation As String
    Dim _importReadyFolder As String
    Dim _errorLogFolder As String
    Dim _failedOrderFolder As String

#Region "PrivateVariableDeclarations"

    Private _workFile As FileIO.TextFieldParser
    Private _sourceFileName As String
    Private _outputFileName As String
    Private _fileNameVerified As Boolean
    Private _sourceFileAccessSuccess As Boolean
    Private _sourceFileReadSuccess As Boolean
    Private _sourceFileCloseSuccess As Boolean
    Private _outputFileAccessSuccess As Boolean
    Private _outputFileWriteSuccess As Boolean
    Private _outputFileCloseSuccess As Boolean
    Private _newOrderDateTime As String
    Private _outputRecordData As OutputFileStructure
    Private _outputFileData As List(Of OutputFileStructure)



    Private _errorLog As StreamWriter



#End Region

#Region "PresenterDeclarations"
    Dim _SourceFilePresenterInstance As SourceFilePresenter
    Dim _OutputFilePresenterInstance As OutputFilePresenter
#End Region

    'Program overview:

    '1: Select scan location
    '2: Open scan location
    'Begin Loop:
    '3: Test files in scan location for matching criteria of old order files
    '4: On match, open the old order file
    '    4.a: Read a line from the old order file
    '    4.b: Decide how to interpet line, write data to NewOrderFormat structure list we create
    '    4.c: Signal that the current old order file is complete using boolean, write structure to NewOrder file, and close old order file
    'End Loop
    '5: Close all open output data files (ImportReadyData.txt)


#Region "SourceFileProperties"
    Public WriteOnly Property SourceFileOpenSuccess As Boolean Implements ISourceFileInterface.SourceFileOpenSuccess
        Set(value As Boolean)
            _sourceFileAccessSuccess = value
        End Set
    End Property

    Public WriteOnly Property FileReadSuccess As Boolean Implements ISourceFileInterface.FileReadSuccess
        Set(value As Boolean)
            _sourceFileReadSuccess = value
        End Set
    End Property

    Public WriteOnly Property SourceFileCloseSuccess As Boolean Implements ISourceFileInterface.SourceFileCloseSuccess
        Set(value As Boolean)
            _sourceFileCloseSuccess = value
        End Set
    End Property

    Public WriteOnly Property VerifyFilename As Boolean Implements ISourceFileInterface.VerifyFilename
        Set(value As Boolean)
            _fileNameVerified = value
        End Set
    End Property

    Public ReadOnly Property SourceFileName As String Implements ISourceFileInterface.SourceFileName
        Get
            Return _sourceFileName
        End Get
    End Property

    Public Property OrderDateTime As String Implements ISourceFileInterface.OrderDateTime
        Get
            Return _NewOrderDateTime
        End Get
        Set(value As String)
            _NewOrderDateTime = value
        End Set
    End Property

    WriteOnly Property SourceOrderRecordData As OutputFileStructure Implements ISourceFileInterface.SourceOrderRecordData
        Set(value As OutputFileStructure)
            _outputRecordData = value
        End Set
    End Property

    WriteOnly Property SourceOrderFileData As List(Of OutputFileStructure) Implements ISourceFileInterface.SourceOrderFileData
        Set(value As List(Of OutputFileStructure))
            _outputFileData = value
        End Set
    End Property

    Public Property SourceFile As TextFieldParser Implements ISourceFileInterface.SourceFile
        Get
            Return _workFile
        End Get
        Set(value As TextFieldParser)
            _workFile = value
        End Set
    End Property
#End Region

#Region "TargetFileProperties"

    Public ReadOnly Property OutputFileName As String Implements IOutputFileInterface.OutputFileName
        Get
            Return _outputFileName
        End Get
    End Property

    Public WriteOnly Property OutputFileOpenSuccess As Boolean Implements IOutputFileInterface.OutputFileOpenSuccess
        Set(value As Boolean)
            _outputFileAccessSuccess = value
        End Set
    End Property

    Public WriteOnly Property FileWriteSuccess As Boolean Implements IOutputFileInterface.FileWriteSuccess
        Set(value As Boolean)
            _outputFileWriteSuccess = value
        End Set
    End Property

    Public ReadOnly Property OutputFileData As List(Of OutputFileStructure) Implements IOutputFileInterface.OutputFileData
        Get
            Return _outputFileData
        End Get
    End Property

    Public WriteOnly Property OutputFileCloseSuccess As Boolean Implements IOutputFileInterface.OutputFileCloseSuccess
        Set(value As Boolean)
            _outputFileCloseSuccess = value
        End Set
    End Property
#End Region

    WriteOnly Property ImportLogLocation As String
        Set(value As String)
            txtNewOrderFileLocation.Text = value
        End Set
    End Property


    WriteOnly Property ErrorLogLocation As String
        Set(value As String)
            txtErrorLogLocation.Text = value
        End Set
    End Property

    WriteOnly Property FailedOrderFilesLocation As String
        Set(value As String)
            txtFailedOrderReadsLocation.Text = value
        End Set
    End Property

    Public ReadOnly Property FullPathSourceFileName As String Implements ISourceFileInterface.FullPathSourceFileName
        Get
            Return _appLocation & "\" & _sourceFileName
        End Get
    End Property

    Private Sub WriteErrorToLog(ErrorInformation As String)
        _errorLog.WriteLine(ErrorInformation)
    End Sub

    Private Sub WriteErrorToLog(ErrorLocation As String, DateOccured As DateTime, ErrorMessage As String)
        Dim ErrorString As String = ErrorLocation & "," & DateOccured.ToString() & "," & ErrorMessage
        _errorLog.WriteLine(ErrorString)
    End Sub

#Region "Initialization"
    Private Sub RecordConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _SourceFilePresenterInstance = New SourceFilePresenter(Me)
        _OutputFilePresenterInstance = New OutputFilePresenter(Me)

        _appLocation = Application.StartupPath & "\PizzaData"

        _importReadyFolder = "\DatabaseImportFiles"
        _errorLogFolder = "\ErrorLogs"
        _failedOrderFolder = "FailedOrderReads"
        lblScanLocation.Text = "Will Scan: " & """" & _appLocation & """"
    End Sub

    Private Sub RecordConverter_Exit(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        If _errorLog IsNot Nothing Then _errorLog.Close()
    End Sub

#End Region

#Region "CommandButtons"
    Private Sub btnConvertOldOrderFiles_Click(sender As Object, e As EventArgs) Handles btnConvertOldOrderFiles.Click
        'New version set up to only write to one import file, leave table creation to SQL

        'Create folders to hold import files, failed order reads, and error logs
        Try
            My.Computer.FileSystem.CreateDirectory(_appLocation & _importReadyFolder)
            My.Computer.FileSystem.CreateDirectory(_appLocation & _failedOrderFolder)
            My.Computer.FileSystem.CreateDirectory(_appLocation & _errorLogFolder)
            _errorLog = New IO.StreamWriter(_appLocation & _errorLogFolder & "\ErrorLog.txt")
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString() & " The preceeding error is preventing the process from initializing. Please ensure " _
                   & "that you have the appropriate privileges to create and write to files and directories before proceeding. The program will now exit.")
            'If we cannot make directories or files, don't even try to run the process, exit
            If _errorLog IsNot Nothing Then _errorLog.Close()
            End
        End Try


        'Start by disabling button, so user can't just keep importing the same files over and over
        btnConvertOldOrderFiles.Enabled = False
        'All of this is getting cleaned up.

        'New process:
        '1) Get list of files in directory
        ' While not out of files
        '2) Open new file to write to
        '3) Test if filename is legitimate
        '4) If legitimate, load datetime to presenter/model, : if not, write to error log, move file
        '5) Test for open filename success, if so, continue, if not, write to error log, move file
        '6) Read data from file, test for data read success, if so, continue, if not, write to error log, move file
        '7) Get output structure from presenter/model, if blank, write to error log, move file
        '8) Close file
        '9) Write to new file
        '10) Continue
        ' End when out of files

        Dim directoryInfo As New DirectoryInfo(_appLocation)
        Dim fileList As FileInfo() = directoryInfo.GetFiles()

        'Open new output file here
        _outputFileName = _appLocation & _importReadyFolder & "\ImportReadyData.txt"
        _OutputFilePresenterInstance.CreateOrOpenOutputFile()

        If _outputFileAccessSuccess Then
            For Each order In fileList
                _sourceFileName = order.Name
                _SourceFilePresenterInstance.VerifyFilename()
                If _fileNameVerified Then
                    _SourceFilePresenterInstance.OpenSourceFile()
                    If _sourceFileAccessSuccess Then
                        _SourceFilePresenterInstance.GetSourceFileObject()
                        _SourceFilePresenterInstance.SetDateTime()
                        _SourceFilePresenterInstance.ScanOpenFile()
                        If _sourceFileReadSuccess Then
                            _SourceFilePresenterInstance.CollectFormattedSourceOrderFileData()
                            If _outputFileData IsNot Nothing Then
                                _OutputFilePresenterInstance.LoadDataForOutputFileWrite()
                                _OutputFilePresenterInstance.WriteToOutputFile()
                                If Not _outputFileWriteSuccess Then MsgBox("Could not write to output file " & _sourceFileName & ". Continuing to next file.")
                            End If

                            'test for successful write
                        Else
                                MsgBox("Could not read input file " & _sourceFileName & ". Continuing to next file.")
                            Continue For
                        End If
                        _SourceFilePresenterInstance.CloseSourceFile()
                        _SourceFilePresenterInstance.ClearFileData()
                        ' Test _sourceFileCloseSuccess for truth, error if false
                        '            'Close order file
                    Else
                        MsgBox("Could not open input file " & _sourceFileName & ". Continuing to next file.")
                        Continue For
                    End If
                Else
                    MsgBox("File name " & _sourceFileName & " is an invalid file name. Continuing to next file.")
                    Continue For
                End If
            Next

            _OutputFilePresenterInstance.CloseOutputFile()
        Else
            MsgBox("Cannot create work directories due to unknown error. Ensure the user has the appropriate access rights before continuing.")
            End
        End If

        ImportLogLocation = _outputFileName
        ErrorLogLocation = _appLocation & _failedOrderFolder & "\ErrorLog.txt"
        FailedOrderFilesLocation = _appLocation & _errorLogFolder
        _errorLog.Close()
    End Sub

    Private Sub btnScanLocationSelect_Click(sender As Object, e As EventArgs) Handles btnScanLocationSelect.Click
        If FolderBrowserDialog1.ShowDialog <> DialogResult.Cancel Then
            _appLocation = FolderBrowserDialog1.SelectedPath
            lblScanLocation.Text = "Will Scan: " & """" & _appLocation & """"
        End If
    End Sub

    Private Sub btnEnd_Click(sender As Object, e As EventArgs) Handles btnEnd.Click
        End
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        ImportLogLocation = ""
        ErrorLogLocation = ""
        FailedOrderFilesLocation = ""
        _SourceFilePresenterInstance.ClearFileData()
        btnConvertOldOrderFiles.Enabled = True
    End Sub


#End Region
End Class

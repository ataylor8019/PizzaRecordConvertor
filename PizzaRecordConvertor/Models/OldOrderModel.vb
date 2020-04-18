Imports System.Collections
Imports System.Enum

Public Class OldOrderModel
    Private p_ModelString As String
    Private p_FileToOpen As String

    Private p_CustomerFirstName As String
    Private p_CustomerMiddleInitial As String
    Private p_CustomerLastName As String
    Private p_CustomerAddress As String
    Private p_CustomerPhoneNumber As String
    Private p_LineItemEntry As String
    Private p_Notes As String

    Private p_OrderItemName As String
    Private p_OrderItemQuantity As String
    Private p_OrderItemIndividualPrice As String
    Private p_OrderItemMultiplePrice As String

    Private p_FileOpenSuccess As Boolean

    Private p_OldOrderFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser

    Private p_StageOfFileRead As LineTypeRead
    Private p_OrderTotalPrice As String
    Private p_OrderNotesData As String
    Private p_CustomerData As String()
    Private p_OrderItemData As String()
    Private p_OrderSummaryData As String()

    Public Sub New()
        p_modelString = "OldOrderModel"
    End Sub

    Public Property OldOrderItemName() As String
        Get
            Return p_OrderItemName
        End Get
        Set(ByVal value As String)
            p_OrderItemName = value
        End Set
    End Property

    Public Property OldOrderItemQuantity() As String
        Get
            Return p_OrderItemQuantity
        End Get
        Set(value As String)
            p_OrderItemQuantity = value
        End Set
    End Property

    Public Property OldOrderItemIndividualPrice() As String
        Get
            Return p_OrderItemIndividualPrice
        End Get
        Set(value As String)
            p_OrderItemIndividualPrice = value
        End Set
    End Property

    Public Property OldOrderItemMultiplePrice() As String
        Get
            Return p_OrderItemMultiplePrice
        End Get
        Set(value As String)
            p_OrderItemMultiplePrice = value
        End Set
    End Property

    Public Property FileOpenSuccess() As Boolean
        Get
            Return p_FileOpenSuccess
        End Get
        Set(ByVal value As Boolean)
            p_FileOpenSuccess = value
        End Set
    End Property

    Public Property CustomerFirstName() As String
        Get
            Return p_CustomerFirstName
        End Get
        Set(ByVal value As String)
            p_CustomerFirstName = value
        End Set
    End Property

    Public Property CustomerLastName() As String
        Get
            Return p_CustomerLastName
        End Get
        Set(ByVal value As String)
            p_CustomerLastName = value
        End Set
    End Property

    Public Property CustomerMiddleInitial() As String
        Get
            Return p_CustomerMiddleInitial
        End Get
        Set(ByVal value As String)
            p_CustomerMiddleInitial = value
        End Set
    End Property

    Public Property CustomerPhoneNumber() As String
        Get
            Return p_CustomerPhoneNumber
        End Get
        Set(ByVal value As String)
            p_CustomerPhoneNumber = value
        End Set
    End Property

    Public Property CustomerAddress() As String
        Get
            Return p_CustomerAddress
        End Get
        Set(ByVal value As String)
            p_CustomerAddress = value
        End Set
    End Property

    Public Property LineItemEntry() As String
        Get
            Return p_LineItemEntry
        End Get
        Set(ByVal value As String)
            p_LineItemEntry = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return p_Notes
        End Get
        Set(ByVal value As String)
            p_Notes = value
        End Set
    End Property

    Public Property CustomerData() As String()
        Get
            Return p_CustomerData
        End Get
        Set(ByVal value As String())
            p_CustomerData = value
        End Set
    End Property


    Public Property OrderItemData() As String()
        Get
            Return p_OrderItemData
        End Get
        Set(ByVal value As String())
            p_OrderItemData = value
        End Set
    End Property

    Public Property OrderTotalPrice() As String
        Get
            Return p_OrderTotalPrice
        End Get
        Set(ByVal value As String)
            p_OrderTotalPrice = value
        End Set
    End Property

    Public Property OrderSummaryData() As String()
        Get
            Return p_OrderSummaryData
        End Get
        Set(ByVal value As String())
            p_OrderSummaryData = value
        End Set
    End Property

    Public Property OrderNotesData() As String
        Get
            Return p_OrderNotesData
        End Get
        Set(ByVal value As String)
            p_OrderNotesData = value
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

    Public ReadOnly Property GetStageOfFileRead() As LineTypeRead 'Property to tell presenter what part of the file is being read, and therefore what properties to check for updates
        Get
            Return p_StageOfFileRead
        End Get
    End Property

    Public Sub OpenFile()
        Dim subString = "OpenFile"
        Try
            p_OldOrderFileReader = New FileIO.TextFieldParser(p_FileToOpen)
            p_OldOrderFileReader.SetDelimiters(",")
            p_FileOpenSuccess = True
        Catch argNull As ArgumentNullException
            Throw New System.ArgumentNullException(MsgBox("ArgumentNullException in " & p_ModelString & ":" & subString & " with message: " & argNull.ToString()))
        Catch argBad As ArgumentException
            Throw New System.ArgumentException(MsgBox("ArgumentException in " & p_ModelString & ":" & subString & " with message: " & argBad.ToString()))
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
            p_FileOpenSuccess = False
        End Try
    End Sub

    Public Sub LoadDataFromFile() 'Reads data from file, stores to appropriate properties based on line type
        Dim subString = "LoadDataFromFile"
        Try
            If Not p_OldOrderFileReader.EndOfData Then
                If (p_OldOrderFileReader.PeekChars(4)).ToLower() = "cust" Then
                    p_CustomerData = p_OldOrderFileReader.ReadFields()
                    p_CustomerFirstName = p_CustomerData(1)
                    p_CustomerMiddleInitial = p_CustomerData(2)
                    p_CustomerLastName = p_CustomerData(3)
                    p_CustomerAddress = p_CustomerData(4)
                    p_CustomerPhoneNumber = p_CustomerData(5)
                    p_StageOfFileRead = LineTypeRead.Customer
                ElseIf (p_OldOrderFileReader.PeekChars(4)).ToLower() = "item" Then
                    p_OrderItemData = p_OldOrderFileReader.ReadFields()
                    p_OrderItemName = p_OrderItemData(1)
                    p_OrderItemQuantity = p_OrderItemData(2)
                    p_OrderItemIndividualPrice = p_OrderItemData(3)
                    p_OrderItemMultiplePrice = p_OrderItemData(4)
                    p_StageOfFileRead = LineTypeRead.OrderItem
                ElseIf (p_OldOrderFileReader.PeekChars(5)).ToLower() = "total" Then
                    p_OrderSummaryData = p_OldOrderFileReader.ReadFields()
                    p_OrderTotalPrice = p_OrderSummaryData(1)
                    p_StageOfFileRead = LineTypeRead.OrderTotal
                ElseIf (p_OldOrderFileReader.PeekChars(5)).ToLower() = "notes" Then
                    p_OrderNotesData = p_OldOrderFileReader.ReadToEnd()
                    p_Notes = Trim(p_OrderNotesData.Substring(6))
                    p_StageOfFileRead = LineTypeRead.OrderNotes
                End If
            Else
                p_StageOfFileRead = LineTypeRead.Complete
            End If
        Catch nullEx As NullReferenceException
            Throw New NullReferenceException(MsgBox("NullReferenceException in" & p_ModelString & ":" & subString & " with message: " & nullEx.ToString()))
        Catch argOutRange As ArgumentOutOfRangeException
            Throw New System.ArgumentOutOfRangeException(MsgBox("ArgumentOutOfRangeException in" & p_ModelString & ":" & subString & " with message: " & argOutRange.ToString()))
        Catch argBad As ArgumentException
            Throw New System.ArgumentException(MsgBox("ArgumentException in " & p_ModelString & ":" & subString & " with message: " & argBad.ToString()))
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub ClearFields()
        p_CustomerFirstName = vbNullString
        p_CustomerMiddleInitial = vbNullString
        p_CustomerLastName = vbNullString
        p_CustomerAddress = vbNullString
        p_CustomerPhoneNumber = vbNullString
        p_OrderItemName = vbNullString
        p_OrderItemQuantity = vbNullString
        p_OrderItemIndividualPrice = vbNullString
        p_OrderItemMultiplePrice = vbNullString
        p_OrderTotalPrice = vbNullString
        p_Notes = vbNullString
    End Sub

    Public Sub CloseFileFORTESTINGONLY()
        p_OldOrderFileReader.Close()
    End Sub

    Enum LineTypeRead 'Presents values to be selected based on the part of the file that is being read
        Customer
        OrderItem
        OrderTotal
        OrderNotes
        Complete
    End Enum

End Class

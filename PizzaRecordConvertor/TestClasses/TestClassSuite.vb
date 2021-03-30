Imports Rhino.Mocks
Imports NUnit.Framework


Public Class TestClassSuite

    <Test>
    Public Sub TestSub()
        Dim mySourceFileReaderMock As ISourceFileReaderModelTestScaffold = MockRepository.GenerateStub(Of ISourceFileReaderModelTestScaffold)
        Dim testBoolean As String = mySourceFileReaderMock.GetOrderDateTime("gkgkk01082017_172351hgfhg")
        mySourceFileReaderMock.AssertWasCalled(Sub(x) x.GetOrderDateTime("01082017_172351"))
    End Sub

    <Test>
    Public Sub TestSub2()
        Dim mySourceMock As SourceFileReaderModel = MockRepository.GenerateMock(Of SourceFileReaderModel)
        'mySourceMock.Stub(Sub(x) x.GetOrderDateTime("01082017_172351"))
        Dim testString As String = mySourceMock.GetOrderDateTime("order01082017_172351")
        Assert.AreEqual(testString, "01082017_172351")
    End Sub

    '<Test>
    'Public Sub TestSub3()
    '    Dim mySourceMock As SourceFileReaderModel = New SourceFileReaderModel()
    '    Dim testFile As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter("TestFile", False)
    '    testFile.WriteLine("cust 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13")
    '    testFile.Close()
    '    Dim actFile As New FileIO.TextFieldParser("TestFile")

    '    mySourceMock.ReadOrderFileData(actFile)
    '    'mySourceMock.Stub(Sub(x) x.ReadOrderFileData(actFile))
    '    'mySourceMock.Stub(Sub(x) x.GetOrderDateTime("01082017_172351"))
    '    'Dim testString As String = mySourceMock.GetOrderDateTime("order01082017_172351")
    '    Dim testList As New List(Of IFileStructureModel.OutputFileStructure) = { New IFileStructureModel.OutputFileStructure With { ._NewOrderCustomerFirstName = "1",
    '                          ._NewOrderCustomerMiddleInitial = "1", ._NewOrderCustomerLastName = "1",
    '                          ._NewOrderCustomerPhoneNumber = "1", ._NewOrderCustomerAddress = "1",
    '                          ._NewOrderOrderItemName = "1", ._NewOrderOrderItemQuantity = "1",
    '                          ._NewOrderOrderItemIndividualPrice = "1", ._NewOrderOrderItemMultiplePrice = "1",
    '                          ._NewOrderLineItemNumber = "1", ._NewOrderDateTime = "1", ._NewOrderOrderPrice = "1", ._NewOrderNotes = "1"}}
    '    Assert.AreEqual(mySourceMock.FileData(), {{"1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13"}})
    'End Sub
End Class

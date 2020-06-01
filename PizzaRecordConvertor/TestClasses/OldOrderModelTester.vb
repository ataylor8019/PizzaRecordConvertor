Imports NUnit
Imports NUnit.Framework

<TestFixture()> Public Class OldOrderModelTester
    Dim p_WorkLocation As String
    Dim TestFixtureFileReader As Microsoft.VisualBasic.FileIO.TextFieldParser

    <SetUp> Sub TestSetup()
        p_WorkLocation = ""
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadCustomerDataProperties_SplitsDataProperly()
        Dim TestObject As New OldOrderModel()
        Dim TestArray As String() = {"null", "1", "2", "3", "4", "5"}
        TestObject.LoadCustomerDataProperties(TestArray)
        Assert.AreEqual(TestObject.CustomerFirstName, "1")
        Assert.AreEqual(TestObject.CustomerLastName, "2")
        Assert.AreEqual(TestObject.CustomerMiddleInitial, "3")
        Assert.AreEqual(TestObject.CustomerAddress, "4")
        Assert.AreEqual(TestObject.CustomerPhoneNumber, "5")
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadOrderDataProperties_SplitsDataProperly()
        Dim TestObject As New OldOrderModel()
        Dim TestArray As String() = {"null", "1", "2", "3", "4"}
        TestObject.LoadOrderDataProperties(TestArray)
        Assert.AreEqual(TestObject.OldOrderItemName, "1")
        Assert.AreEqual(TestObject.OldOrderItemQuantity, "2")
        Assert.AreEqual(TestObject.OldOrderItemIndividualPrice, "3")
        Assert.AreEqual(TestObject.OldOrderItemMultiplePrice, "4")
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadOrderTotalProperty_SplitsDataProperly()
        Dim TestObject As New OldOrderModel()
        Dim TestArray As String() = {"null", "1"}
        TestObject.LoadOrderTotalProperty(TestArray)
        Assert.AreEqual(TestObject.OrderTotalPrice, "1")
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadNotesProperty_SplitsDataProperly()
        Dim TestObject As New OldOrderModel()
        Dim TestString As String = "ERROR!String Copied With No Issue"
        TestObject.LoadNotesProperty(TestString)
        Assert.AreEqual(TestObject.Notes, "String Copied With No Issue") 'Need to change property names of this and other properties to be consistent
    End Sub

    ''' Below is garbage, keeping as example of how to set up sub tests where nothing is returned, will try not to end up in this situation again '''
    '<Test()> Public Sub TestOldOrderModel_OpenFile_NoFileName()
    '    Dim TestObject As New OldOrderModel()

    '    'TestObject.FileToOpen = ""
    '    Assert.Throws(Of ArgumentNullException)(New TestDelegate(Function() TestObject.OpenFile("")))
    'End Sub

    '<Test()> Public Sub TestOldOrderModel_LoadDataFromFile_NoData()
    '    Dim TestObject As New OldOrderModel()
    '    TestObject.FileToOpen = p_WorkLocation & "nulldata.txt"
    '    TestObject.OpenFile()
    '    Assert.Throws(Of NullReferenceException)(New TestDelegate(AddressOf TestObject.LoadDataFromFile))
    'End Sub

    '<Test()> Public Sub TestOldOrderModel_LoadDataFromFile_MalformedCustomer()
    '    Dim TestObject As New OldOrderModel()
    '    TestObject.FileToOpen = p_WorkLocation & "malformedcustomer.txt"
    '    TestObject.OpenFile()
    '    Assert.Throws(Of ArgumentException)(New TestDelegate(AddressOf TestObject.LoadDataFromFile))
    'End Sub
End Class

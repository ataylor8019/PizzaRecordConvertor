Imports NUnit
Imports NUnit.Framework

<TestFixture()> Public Class OldOrderModelTester
    Dim p_WorkLocation As String

    <SetUp> Sub TestSetup()
        p_WorkLocation = ""
    End Sub
    <Test()> Public Sub TestOldOrderModel_OpenFile_NoFileName()
        Dim TestObject As New OldOrderModel()

        TestObject.FileToOpen = ""
        Assert.Throws(Of ArgumentNullException)(New TestDelegate(AddressOf TestObject.OpenFile))
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadDataFromFile_NoData()
        Dim TestObject As New OldOrderModel()
        TestObject.FileToOpen = p_WorkLocation & "nulldata.txt"
        TestObject.OpenFile()
        Assert.Throws(Of NullReferenceException)(New TestDelegate(AddressOf TestObject.LoadDataFromFile))
    End Sub

    <Test()> Public Sub TestOldOrderModel_LoadDataFromFile_MalformedCustomer()
        Dim TestObject As New OldOrderModel()
        TestObject.FileToOpen = p_WorkLocation & "malformedcustomer.txt"
        TestObject.OpenFile()
        Assert.Throws(Of ArgumentException)(New TestDelegate(AddressOf TestObject.LoadDataFromFile))
    End Sub
End Class

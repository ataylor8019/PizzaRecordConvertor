Imports NUnit
Imports NUnit.Framework

<TestFixture()> Public Class CustomerModelTester
    <Test()> Public Sub TestCustomerModel_OpenFile_NoFileName()
        Dim TestObject As New CustomerModel()

        'TestObject.FileToOpen = ""

        Assert.False(TestObject.OpenFile(""))
        'Assert.Throws(Of ArgumentNullException)(New TestDelegate(AddressOf TestObject.OpenFile(Of String)))
    End Sub
End Class

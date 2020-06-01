Public Interface INewOrderInterface
    Property NewOrderFormatRecordLine As String

    Property NewOrderFormatOrderNotes As String
    Property NewOrderFormatOrderPrice As String
    Property NewOrderDateTime As String

    ReadOnly Property NewOrderImportFileLocation As String
    WriteOnly Property NewOrderImportFileLocationDisplayField As String
End Interface

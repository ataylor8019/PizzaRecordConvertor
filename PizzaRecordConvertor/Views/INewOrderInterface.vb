Public Interface INewOrderInterface
    Property NewOrderFormatCustomerFirstName As String
    Property NewOrderFormatCustomerLastName As String
    Property NewOrderFormatCustomerMiddleInitial As String
    Property NewOrderFormatCustomerStreetAddress As String
    Property NewOrderFormatCustomerHomePhoneNumber As String
    Property NewOrderFormatOrderItemName As String
    Property NewOrderFormatOrderItemQuantity As String
    Property NewOrderFormatOrderItemIndividualPrice As String
    Property NewOrderFormatOrderItemMultiplePrice As String
    Property NewOrderFormatOrderNotes As String
    Property NewOrderFormatOrderPrice As String
    Property NewOrderLineItemNumber As String
    Property NewOrderDateTime As String

    ReadOnly Property NewOrderImportFileLocation As String
    WriteOnly Property NewOrderImportFileLocationDisplayField As String
End Interface

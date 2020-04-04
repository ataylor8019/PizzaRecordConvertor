Public Interface IOldOrderInterface
    'Reason for strange and/or repetitive prefixes:
    'Many of these properties are writing to private variables
    'in the realized view object (usually a form), that are then used
    'by other views in other presenters. In a given presenter, from
    'the view's "point of view", it only knows about its own properties,
    'and there is no good and architecturally sound way to pass other
    'properties directly from other views for use in its own processing.
    'For this reason, every view property gets its own prefix, that
    'prefix being the name of the general entity/future table being worked with.
    'In this manner, an entity like "OldOrder" can set its FirstName value, and
    'then a receiving entity like "Customer" can pick up that FirstName value:
    'they both operate on the same private variable (example: p_FirstName), however
    '"OldOrder" writes to it by setting property "OldOrderFirstName", and "Customer"
    'reads from it by getting "CustomerFirstName".

    ReadOnly Property GetFileToOpenField

    WriteOnly Property OldOrderFirstNameField
    WriteOnly Property OldOrderLastNameField
    WriteOnly Property OldOrderMiddleInitialField
    WriteOnly Property OldOrderAddressField
    WriteOnly Property OldOrderPhoneNumberField

    WriteOnly Property OldOrderItemName
    WriteOnly Property OldOrderItemQuantity
    WriteOnly Property OldOrderItemIndividualPrice
    WriteOnly Property OldOrderItemMultiplePrice
    WriteOnly Property OldOrderTotalPrice As String
    WriteOnly Property OldOrderNotes As String

    WriteOnly Property OldOrderCustomerProcessCanRun As Boolean
    WriteOnly Property OldOrderOrderProcessCanRun As Boolean
    WriteOnly Property OldOrderBodyProcessCanRun As Boolean
    WriteOnly Property OldOrderMenuItemProcessCanRun As Boolean

    Property OldOrderFileReadComplete As Boolean
    'WriteOnly Property SetCustomerLineItemEntryField
    'WriteOnly Property SetNotesField

    'Property SetFileToOpenField
End Interface

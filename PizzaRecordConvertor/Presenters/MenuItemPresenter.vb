Public Class MenuItemPresenter
    Private p_MenuItemViewInstance As IMenuItemInterface
    Private p_MenuItemModelInstance As MenuItemModel
    Private p_FileOpenSuccess As Boolean

    Public Sub New(view As IMenuItemInterface)
        p_MenuItemViewInstance = view
        p_MenuItemModelInstance = New MenuItemModel
        p_FileOpenSuccess = False
    End Sub

    Public Sub OpenMenuItemFileToWrite()
        p_MenuItemViewInstance.MenuItemOutputFileLocationDisplayField = p_MenuItemViewInstance.MenuItemOutputFileLocation
        p_MenuItemModelInstance.OpenFile(p_MenuItemViewInstance.MenuItemOutputFileLocation)
    End Sub

    Public Sub GetMenuItemRecordFromDataRead()
        p_MenuItemModelInstance.ItemName = p_MenuItemViewInstance.MenuItemItemNameField
        p_MenuItemModelInstance.ItemPrice = p_MenuItemViewInstance.MenuItemItemPriceField
        p_MenuItemModelInstance.ItemNotes = p_MenuItemViewInstance.MenuItemItemNotesField

        Try
            p_MenuItemModelInstance.GetID() ' Will be Create or Find ID in future
            p_MenuItemViewInstance.MenuItemMenuIDField = p_MenuItemModelInstance.MenuID
            p_MenuItemViewInstance.MenuItemNewMenuItem = p_MenuItemModelInstance.IsNewRecord
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub WriteMenuItemRecord()
        Try
            p_MenuItemModelInstance.WriteRecordToFile()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub ClearFields()
        p_MenuItemModelInstance.ClearFields()
    End Sub

    Public Sub CloseFile()
        p_MenuItemModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

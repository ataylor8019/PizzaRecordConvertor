﻿Imports PizzaRecordConvertor.Views
Imports PizzaRecordConvertor.Models

Public Class MenuItemPresenter
    Private p_MenuItemViewInstance As IMenuItemInterface
    Private p_MenuItemModelInstance As MenuItemModel

    Public Sub New(view As IMenuItemInterface)
        p_MenuItemViewInstance = view
        p_MenuItemModelInstance = New MenuItemModel
    End Sub

    Public Sub OpenMenuItemFileToWrite()
        p_MenuItemModelInstance.FileToOpen = p_MenuItemViewInstance.MenuItemGetFileToOpenField
        p_MenuItemModelInstance.OpenFile()
    End Sub

    Public Sub GetMenuItemRecordFromDataRead()
        p_MenuItemModelInstance.ItemName = p_MenuItemViewInstance.MenuItemItemNameField
        p_MenuItemModelInstance.ItemPrice = p_MenuItemViewInstance.MenuItemItemPriceField
        p_MenuItemModelInstance.ItemNotes = p_MenuItemViewInstance.MenuItemItemNotesField

        Try
            p_MenuItemModelInstance.CreateID()
            p_MenuItemViewInstance.MenuItemMenuIDField = p_MenuItemModelInstance.MenuID
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub WriteMenuItemRecord()
        Try
            p_MenuItemModelInstance.WriteMenuItemToFile()
        Catch ex As Exception
            MsgBox("General error: " & ex.ToString() & " Will be handled in a future update")
        End Try
    End Sub

    Public Sub CloseFile()
        p_MenuItemModelInstance.CloseFileFORTESTINGONLY()
    End Sub
End Class

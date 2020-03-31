<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecordConverter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtOldOrderFileLocation = New System.Windows.Forms.TextBox()
        Me.txtCustomerFileLocation = New System.Windows.Forms.TextBox()
        Me.txtOrderFileLocation = New System.Windows.Forms.TextBox()
        Me.txtOrderItemFileLocation = New System.Windows.Forms.TextBox()
        Me.txtMenuItemFileLocation = New System.Windows.Forms.TextBox()
        Me.lblOldOrderFileLocation = New System.Windows.Forms.Label()
        Me.lblOutputLocations = New System.Windows.Forms.Label()
        Me.lblCustomerFileLocation = New System.Windows.Forms.Label()
        Me.lblOrderFileLocation = New System.Windows.Forms.Label()
        Me.lblOrderItemFileLocation = New System.Windows.Forms.Label()
        Me.btnConvertOldOrderFiles = New System.Windows.Forms.Button()
        Me.lblMenuItemFileLocation = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtOldOrderFileLocation
        '
        Me.txtOldOrderFileLocation.Location = New System.Drawing.Point(12, 38)
        Me.txtOldOrderFileLocation.Name = "txtOldOrderFileLocation"
        Me.txtOldOrderFileLocation.Size = New System.Drawing.Size(300, 26)
        Me.txtOldOrderFileLocation.TabIndex = 0
        '
        'txtCustomerFileLocation
        '
        Me.txtCustomerFileLocation.Location = New System.Drawing.Point(391, 113)
        Me.txtCustomerFileLocation.Name = "txtCustomerFileLocation"
        Me.txtCustomerFileLocation.Size = New System.Drawing.Size(300, 26)
        Me.txtCustomerFileLocation.TabIndex = 1
        '
        'txtOrderFileLocation
        '
        Me.txtOrderFileLocation.Location = New System.Drawing.Point(391, 178)
        Me.txtOrderFileLocation.Name = "txtOrderFileLocation"
        Me.txtOrderFileLocation.Size = New System.Drawing.Size(300, 26)
        Me.txtOrderFileLocation.TabIndex = 2
        '
        'txtOrderItemFileLocation
        '
        Me.txtOrderItemFileLocation.Location = New System.Drawing.Point(391, 240)
        Me.txtOrderItemFileLocation.Name = "txtOrderItemFileLocation"
        Me.txtOrderItemFileLocation.Size = New System.Drawing.Size(300, 26)
        Me.txtOrderItemFileLocation.TabIndex = 3
        '
        'txtMenuItemFileLocation
        '
        Me.txtMenuItemFileLocation.Location = New System.Drawing.Point(391, 303)
        Me.txtMenuItemFileLocation.Name = "txtMenuItemFileLocation"
        Me.txtMenuItemFileLocation.Size = New System.Drawing.Size(300, 26)
        Me.txtMenuItemFileLocation.TabIndex = 4
        '
        'lblOldOrderFileLocation
        '
        Me.lblOldOrderFileLocation.AutoSize = True
        Me.lblOldOrderFileLocation.Location = New System.Drawing.Point(8, 15)
        Me.lblOldOrderFileLocation.Name = "lblOldOrderFileLocation"
        Me.lblOldOrderFileLocation.Size = New System.Drawing.Size(239, 20)
        Me.lblOldOrderFileLocation.TabIndex = 5
        Me.lblOldOrderFileLocation.Text = "Enter Location of Old Files Here:"
        '
        'lblOutputLocations
        '
        Me.lblOutputLocations.AutoSize = True
        Me.lblOutputLocations.Location = New System.Drawing.Point(387, 38)
        Me.lblOutputLocations.Name = "lblOutputLocations"
        Me.lblOutputLocations.Size = New System.Drawing.Size(299, 20)
        Me.lblOutputLocations.TabIndex = 6
        Me.lblOutputLocations.Text = "Location of Database Import Ready Files"
        '
        'lblCustomerFileLocation
        '
        Me.lblCustomerFileLocation.AutoSize = True
        Me.lblCustomerFileLocation.Location = New System.Drawing.Point(387, 90)
        Me.lblCustomerFileLocation.Name = "lblCustomerFileLocation"
        Me.lblCustomerFileLocation.Size = New System.Drawing.Size(176, 20)
        Me.lblCustomerFileLocation.TabIndex = 7
        Me.lblCustomerFileLocation.Text = "Customer File Location:"
        '
        'lblOrderFileLocation
        '
        Me.lblOrderFileLocation.AutoSize = True
        Me.lblOrderFileLocation.Location = New System.Drawing.Point(387, 155)
        Me.lblOrderFileLocation.Name = "lblOrderFileLocation"
        Me.lblOrderFileLocation.Size = New System.Drawing.Size(147, 20)
        Me.lblOrderFileLocation.TabIndex = 8
        Me.lblOrderFileLocation.Text = "Order File Location:"
        '
        'lblOrderItemFileLocation
        '
        Me.lblOrderItemFileLocation.AutoSize = True
        Me.lblOrderItemFileLocation.Location = New System.Drawing.Point(387, 217)
        Me.lblOrderItemFileLocation.Name = "lblOrderItemFileLocation"
        Me.lblOrderItemFileLocation.Size = New System.Drawing.Size(183, 20)
        Me.lblOrderItemFileLocation.TabIndex = 9
        Me.lblOrderItemFileLocation.Text = "Order Item File Location:"
        '
        'btnConvertOldOrderFiles
        '
        Me.btnConvertOldOrderFiles.Location = New System.Drawing.Point(12, 70)
        Me.btnConvertOldOrderFiles.Name = "btnConvertOldOrderFiles"
        Me.btnConvertOldOrderFiles.Size = New System.Drawing.Size(300, 30)
        Me.btnConvertOldOrderFiles.TabIndex = 10
        Me.btnConvertOldOrderFiles.Text = "Begin Old Order Conversion"
        Me.btnConvertOldOrderFiles.UseVisualStyleBackColor = True
        '
        'lblMenuItemFileLocation
        '
        Me.lblMenuItemFileLocation.AutoSize = True
        Me.lblMenuItemFileLocation.Location = New System.Drawing.Point(387, 280)
        Me.lblMenuItemFileLocation.Name = "lblMenuItemFileLocation"
        Me.lblMenuItemFileLocation.Size = New System.Drawing.Size(183, 20)
        Me.lblMenuItemFileLocation.TabIndex = 11
        Me.lblMenuItemFileLocation.Text = "Menu Item File Location:"
        '
        'RecordConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 419)
        Me.Controls.Add(Me.lblMenuItemFileLocation)
        Me.Controls.Add(Me.btnConvertOldOrderFiles)
        Me.Controls.Add(Me.lblOrderItemFileLocation)
        Me.Controls.Add(Me.lblOrderFileLocation)
        Me.Controls.Add(Me.lblCustomerFileLocation)
        Me.Controls.Add(Me.lblOutputLocations)
        Me.Controls.Add(Me.lblOldOrderFileLocation)
        Me.Controls.Add(Me.txtMenuItemFileLocation)
        Me.Controls.Add(Me.txtOrderItemFileLocation)
        Me.Controls.Add(Me.txtOrderFileLocation)
        Me.Controls.Add(Me.txtCustomerFileLocation)
        Me.Controls.Add(Me.txtOldOrderFileLocation)
        Me.Name = "RecordConverter"
        Me.Text = "Pizza Record Converter v1.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtOldOrderFileLocation As TextBox
    Friend WithEvents txtCustomerFileLocation As TextBox
    Friend WithEvents txtOrderFileLocation As TextBox
    Friend WithEvents txtOrderItemFileLocation As TextBox
    Friend WithEvents txtMenuItemFileLocation As TextBox
    Friend WithEvents lblOldOrderFileLocation As Label
    Friend WithEvents lblOutputLocations As Label
    Friend WithEvents lblCustomerFileLocation As Label
    Friend WithEvents lblOrderFileLocation As Label
    Friend WithEvents lblOrderItemFileLocation As Label
    Friend WithEvents btnConvertOldOrderFiles As Button
    Friend WithEvents lblMenuItemFileLocation As Label
End Class

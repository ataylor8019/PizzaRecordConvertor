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
        Me.txtCustomerFileLocation = New System.Windows.Forms.TextBox()
        Me.txtOrderFileLocation = New System.Windows.Forms.TextBox()
        Me.txtOrderItemFileLocation = New System.Windows.Forms.TextBox()
        Me.txtMenuItemFileLocation = New System.Windows.Forms.TextBox()
        Me.lblOutputLocations = New System.Windows.Forms.Label()
        Me.lblCustomerFileLocation = New System.Windows.Forms.Label()
        Me.lblOrderFileLocation = New System.Windows.Forms.Label()
        Me.lblOrderItemFileLocation = New System.Windows.Forms.Label()
        Me.btnConvertOldOrderFiles = New System.Windows.Forms.Button()
        Me.lblMenuItemFileLocation = New System.Windows.Forms.Label()
        Me.btnScanLocationSelect = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblScanLocation = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtCustomerFileLocation
        '
        Me.txtCustomerFileLocation.Location = New System.Drawing.Point(12, 181)
        Me.txtCustomerFileLocation.Name = "txtCustomerFileLocation"
        Me.txtCustomerFileLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtCustomerFileLocation.TabIndex = 1
        '
        'txtOrderFileLocation
        '
        Me.txtOrderFileLocation.Location = New System.Drawing.Point(12, 246)
        Me.txtOrderFileLocation.Name = "txtOrderFileLocation"
        Me.txtOrderFileLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtOrderFileLocation.TabIndex = 2
        '
        'txtOrderItemFileLocation
        '
        Me.txtOrderItemFileLocation.Location = New System.Drawing.Point(12, 308)
        Me.txtOrderItemFileLocation.Name = "txtOrderItemFileLocation"
        Me.txtOrderItemFileLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtOrderItemFileLocation.TabIndex = 3
        '
        'txtMenuItemFileLocation
        '
        Me.txtMenuItemFileLocation.Location = New System.Drawing.Point(12, 371)
        Me.txtMenuItemFileLocation.Name = "txtMenuItemFileLocation"
        Me.txtMenuItemFileLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtMenuItemFileLocation.TabIndex = 4
        '
        'lblOutputLocations
        '
        Me.lblOutputLocations.AutoSize = True
        Me.lblOutputLocations.Location = New System.Drawing.Point(15, 126)
        Me.lblOutputLocations.Name = "lblOutputLocations"
        Me.lblOutputLocations.Size = New System.Drawing.Size(299, 20)
        Me.lblOutputLocations.TabIndex = 6
        Me.lblOutputLocations.Text = "Location of Database Import Ready Files"
        '
        'lblCustomerFileLocation
        '
        Me.lblCustomerFileLocation.AutoSize = True
        Me.lblCustomerFileLocation.Location = New System.Drawing.Point(15, 158)
        Me.lblCustomerFileLocation.Name = "lblCustomerFileLocation"
        Me.lblCustomerFileLocation.Size = New System.Drawing.Size(176, 20)
        Me.lblCustomerFileLocation.TabIndex = 7
        Me.lblCustomerFileLocation.Text = "Customer File Location:"
        '
        'lblOrderFileLocation
        '
        Me.lblOrderFileLocation.AutoSize = True
        Me.lblOrderFileLocation.Location = New System.Drawing.Point(15, 223)
        Me.lblOrderFileLocation.Name = "lblOrderFileLocation"
        Me.lblOrderFileLocation.Size = New System.Drawing.Size(147, 20)
        Me.lblOrderFileLocation.TabIndex = 8
        Me.lblOrderFileLocation.Text = "Order File Location:"
        '
        'lblOrderItemFileLocation
        '
        Me.lblOrderItemFileLocation.AutoSize = True
        Me.lblOrderItemFileLocation.Location = New System.Drawing.Point(15, 285)
        Me.lblOrderItemFileLocation.Name = "lblOrderItemFileLocation"
        Me.lblOrderItemFileLocation.Size = New System.Drawing.Size(183, 20)
        Me.lblOrderItemFileLocation.TabIndex = 9
        Me.lblOrderItemFileLocation.Text = "Order Item File Location:"
        '
        'btnConvertOldOrderFiles
        '
        Me.btnConvertOldOrderFiles.Location = New System.Drawing.Point(391, 15)
        Me.btnConvertOldOrderFiles.Name = "btnConvertOldOrderFiles"
        Me.btnConvertOldOrderFiles.Size = New System.Drawing.Size(300, 41)
        Me.btnConvertOldOrderFiles.TabIndex = 10
        Me.btnConvertOldOrderFiles.Text = "Begin Old Order Conversion"
        Me.btnConvertOldOrderFiles.UseVisualStyleBackColor = True
        '
        'lblMenuItemFileLocation
        '
        Me.lblMenuItemFileLocation.AutoSize = True
        Me.lblMenuItemFileLocation.Location = New System.Drawing.Point(15, 348)
        Me.lblMenuItemFileLocation.Name = "lblMenuItemFileLocation"
        Me.lblMenuItemFileLocation.Size = New System.Drawing.Size(183, 20)
        Me.lblMenuItemFileLocation.TabIndex = 11
        Me.lblMenuItemFileLocation.Text = "Menu Item File Location:"
        '
        'btnScanLocationSelect
        '
        Me.btnScanLocationSelect.Location = New System.Drawing.Point(19, 15)
        Me.btnScanLocationSelect.Name = "btnScanLocationSelect"
        Me.btnScanLocationSelect.Size = New System.Drawing.Size(328, 41)
        Me.btnScanLocationSelect.TabIndex = 12
        Me.btnScanLocationSelect.Text = "Press to Select Order File Location"
        Me.btnScanLocationSelect.UseVisualStyleBackColor = True
        '
        'lblScanLocation
        '
        Me.lblScanLocation.AutoSize = True
        Me.lblScanLocation.Location = New System.Drawing.Point(15, 76)
        Me.lblScanLocation.Name = "lblScanLocation"
        Me.lblScanLocation.Size = New System.Drawing.Size(0, 20)
        Me.lblScanLocation.TabIndex = 13
        '
        'RecordConverter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 419)
        Me.Controls.Add(Me.lblScanLocation)
        Me.Controls.Add(Me.btnScanLocationSelect)
        Me.Controls.Add(Me.lblMenuItemFileLocation)
        Me.Controls.Add(Me.btnConvertOldOrderFiles)
        Me.Controls.Add(Me.lblOrderItemFileLocation)
        Me.Controls.Add(Me.lblOrderFileLocation)
        Me.Controls.Add(Me.lblCustomerFileLocation)
        Me.Controls.Add(Me.lblOutputLocations)
        Me.Controls.Add(Me.txtMenuItemFileLocation)
        Me.Controls.Add(Me.txtOrderItemFileLocation)
        Me.Controls.Add(Me.txtOrderFileLocation)
        Me.Controls.Add(Me.txtCustomerFileLocation)
        Me.Name = "RecordConverter"
        Me.Text = "Pizza Record Converter v1.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCustomerFileLocation As TextBox
    Friend WithEvents txtOrderFileLocation As TextBox
    Friend WithEvents txtOrderItemFileLocation As TextBox
    Friend WithEvents txtMenuItemFileLocation As TextBox
    Friend WithEvents lblOutputLocations As Label
    Friend WithEvents lblCustomerFileLocation As Label
    Friend WithEvents lblOrderFileLocation As Label
    Friend WithEvents lblOrderItemFileLocation As Label
    Friend WithEvents btnConvertOldOrderFiles As Button
    Friend WithEvents lblMenuItemFileLocation As Label
    Friend WithEvents btnScanLocationSelect As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblScanLocation As Label
End Class

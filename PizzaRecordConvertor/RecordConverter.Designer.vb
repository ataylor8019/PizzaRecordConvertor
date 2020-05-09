<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RecordConverter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtNewOrderFileLocation = New System.Windows.Forms.TextBox()
        Me.txtErrorLogLocation = New System.Windows.Forms.TextBox()
        Me.txtFailedOrderReadsLocation = New System.Windows.Forms.TextBox()
        Me.lblOutputLocations = New System.Windows.Forms.Label()
        Me.lblImportFileLocation = New System.Windows.Forms.Label()
        Me.lblErrorLogLocation = New System.Windows.Forms.Label()
        Me.lblFailedConversionLocation = New System.Windows.Forms.Label()
        Me.btnConvertOldOrderFiles = New System.Windows.Forms.Button()
        Me.btnScanLocationSelect = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblScanLocation = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNewOrderFileLocation
        '
        Me.txtNewOrderFileLocation.Location = New System.Drawing.Point(12, 254)
        Me.txtNewOrderFileLocation.Name = "txtNewOrderFileLocation"
        Me.txtNewOrderFileLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtNewOrderFileLocation.TabIndex = 1
        '
        'txtErrorLogLocation
        '
        Me.txtErrorLogLocation.Location = New System.Drawing.Point(12, 319)
        Me.txtErrorLogLocation.Name = "txtErrorLogLocation"
        Me.txtErrorLogLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtErrorLogLocation.TabIndex = 2
        '
        'txtFailedOrderReadsLocation
        '
        Me.txtFailedOrderReadsLocation.Location = New System.Drawing.Point(12, 381)
        Me.txtFailedOrderReadsLocation.Name = "txtFailedOrderReadsLocation"
        Me.txtFailedOrderReadsLocation.Size = New System.Drawing.Size(672, 26)
        Me.txtFailedOrderReadsLocation.TabIndex = 3
        '
        'lblOutputLocations
        '
        Me.lblOutputLocations.AutoSize = True
        Me.lblOutputLocations.Location = New System.Drawing.Point(15, 199)
        Me.lblOutputLocations.Name = "lblOutputLocations"
        Me.lblOutputLocations.Size = New System.Drawing.Size(299, 20)
        Me.lblOutputLocations.TabIndex = 6
        Me.lblOutputLocations.Text = "Location of Database Import Ready Files"
        '
        'lblImportFileLocation
        '
        Me.lblImportFileLocation.AutoSize = True
        Me.lblImportFileLocation.Location = New System.Drawing.Point(15, 231)
        Me.lblImportFileLocation.Name = "lblImportFileLocation"
        Me.lblImportFileLocation.Size = New System.Drawing.Size(153, 20)
        Me.lblImportFileLocation.TabIndex = 7
        Me.lblImportFileLocation.Text = "Import File Location:"
        '
        'lblErrorLogLocation
        '
        Me.lblErrorLogLocation.AutoSize = True
        Me.lblErrorLogLocation.Location = New System.Drawing.Point(15, 296)
        Me.lblErrorLogLocation.Name = "lblErrorLogLocation"
        Me.lblErrorLogLocation.Size = New System.Drawing.Size(144, 20)
        Me.lblErrorLogLocation.TabIndex = 8
        Me.lblErrorLogLocation.Text = "Error Log Location:"
        '
        'lblFailedConversionLocation
        '
        Me.lblFailedConversionLocation.AutoSize = True
        Me.lblFailedConversionLocation.Location = New System.Drawing.Point(15, 358)
        Me.lblFailedConversionLocation.Name = "lblFailedConversionLocation"
        Me.lblFailedConversionLocation.Size = New System.Drawing.Size(256, 20)
        Me.lblFailedConversionLocation.TabIndex = 9
        Me.lblFailedConversionLocation.Text = "Failed Order Conversions Location:"
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
        Me.Controls.Add(Me.btnConvertOldOrderFiles)
        Me.Controls.Add(Me.lblFailedConversionLocation)
        Me.Controls.Add(Me.lblErrorLogLocation)
        Me.Controls.Add(Me.lblImportFileLocation)
        Me.Controls.Add(Me.lblOutputLocations)
        Me.Controls.Add(Me.txtFailedOrderReadsLocation)
        Me.Controls.Add(Me.txtErrorLogLocation)
        Me.Controls.Add(Me.txtNewOrderFileLocation)
        Me.Name = "RecordConverter"
        Me.Text = "Pizza Record Converter v1.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNewOrderFileLocation As TextBox
    Friend WithEvents txtErrorLogLocation As TextBox
    Friend WithEvents txtFailedOrderReadsLocation As TextBox
    Friend WithEvents lblOutputLocations As Label
    Friend WithEvents lblImportFileLocation As Label
    Friend WithEvents lblErrorLogLocation As Label
    Friend WithEvents lblFailedConversionLocation As Label
    Friend WithEvents btnConvertOldOrderFiles As Button
    Friend WithEvents btnScanLocationSelect As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents lblScanLocation As Label
End Class

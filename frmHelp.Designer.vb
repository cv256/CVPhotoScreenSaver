<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHelp
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
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelPath = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Save.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Save.Location = New System.Drawing.Point(235, 284)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(115, 62)
        Me.btn_Save.TabIndex = 10
        Me.btn_Save.Text = "OK, got it," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Continue"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(9, 9)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(344, 264)
        Me.ListView1.TabIndex = 11
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Dummy"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Key"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 75
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Function"
        Me.ColumnHeader3.Width = 600
        '
        'LabelVersion
        '
        Me.LabelVersion.Location = New System.Drawing.Point(6, 285)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(223, 29)
        Me.LabelVersion.TabIndex = 12
        Me.LabelVersion.Text = "Label1"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Location = New System.Drawing.Point(6, 314)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(223, 33)
        Me.LabelCopyright.TabIndex = 13
        Me.LabelCopyright.Text = "Label1"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'LabelPath
        '
        Me.LabelPath.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPath.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelPath.Location = New System.Drawing.Point(6, 370)
        Me.LabelPath.Name = "LabelPath"
        Me.LabelPath.Size = New System.Drawing.Size(361, 22)
        Me.LabelPath.TabIndex = 14
        Me.LabelPath.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(235, 347)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 25)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "End now  :-("
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmHelp
        '
        Me.AcceptButton = Me.btn_Save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.CancelButton = Me.Button1
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(362, 381)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelPath)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btn_Save)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHelp"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Help"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelPath As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class

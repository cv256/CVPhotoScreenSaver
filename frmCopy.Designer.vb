<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopy
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
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.txtCopyPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbOriginalPath = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Cancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(680, 134)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(115, 39)
        Me.btn_Cancel.TabIndex = 2
        Me.btn_Cancel.Text = "Back"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Save.Location = New System.Drawing.Point(680, 66)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(115, 62)
        Me.btn_Save.TabIndex = 1
        Me.btn_Save.Text = "Copy"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'txtCopyPath
        '
        Me.txtCopyPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCopyPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCopyPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories
        Me.txtCopyPath.Location = New System.Drawing.Point(105, 34)
        Me.txtCopyPath.Name = "txtCopyPath"
        Me.txtCopyPath.Size = New System.Drawing.Size(689, 20)
        Me.txtCopyPath.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Folder to Copy to:"
        '
        'lbOriginalPath
        '
        Me.lbOriginalPath.AutoSize = True
        Me.lbOriginalPath.Location = New System.Drawing.Point(9, 5)
        Me.lbOriginalPath.Name = "lbOriginalPath"
        Me.lbOriginalPath.Size = New System.Drawing.Size(67, 13)
        Me.lbOriginalPath.TabIndex = 15
        Me.lbOriginalPath.Text = "Original Path"
        '
        'frmCopy
        '
        Me.AcceptButton = Me.btn_Save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Cancel
        Me.ClientSize = New System.Drawing.Size(800, 180)
        Me.Controls.Add(Me.lbOriginalPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCopyPath)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Save)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCopy"
        Me.Text = "Copy Photo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Cancel As Button
    Friend WithEvents btn_Save As Button
    Friend WithEvents txtCopyPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbOriginalPath As Label
End Class

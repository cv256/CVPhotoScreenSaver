<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFolders
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
        Me.lbl_Configs = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lst_Configs = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(790, 503)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(115, 39)
        Me.btn_Cancel.TabIndex = 10
        Me.btn_Cancel.Text = "Back"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'lbl_Configs
        '
        Me.lbl_Configs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Configs.BackColor = System.Drawing.SystemColors.Window
        Me.lbl_Configs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Configs.Location = New System.Drawing.Point(474, 26)
        Me.lbl_Configs.Name = "lbl_Configs"
        Me.lbl_Configs.Size = New System.Drawing.Size(306, 37)
        Me.lbl_Configs.TabIndex = 5
        Me.lbl_Configs.Text = "...and check the Configurations it belongs to:"
        Me.lbl_Configs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Select Folder here:"
        '
        'lst_Configs
        '
        Me.lst_Configs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lst_Configs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lst_Configs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lst_Configs.Location = New System.Drawing.Point(473, 64)
        Me.lst_Configs.MultiSelect = False
        Me.lst_Configs.Name = "lst_Configs"
        Me.lst_Configs.Size = New System.Drawing.Size(308, 478)
        Me.lst_Configs.TabIndex = 7
        Me.lst_Configs.UseCompatibleStateImageBehavior = False
        Me.lst_Configs.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(473, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "...and check the Configurations it belongs to:"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Configuration"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Folders"
        '
        'frmFolders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 549)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lst_Configs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.lbl_Configs)
        Me.Name = "frmFolders"
        Me.Text = "Configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents lbl_Configs As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lst_Configs As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
End Class

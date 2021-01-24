<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurrentSet
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ConfigurationName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_New = New System.Windows.Forms.Button()
        Me.btn_Edit = New System.Windows.Forms.Button()
        Me.btn_Del = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_Cancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rdDateASC = New System.Windows.Forms.RadioButton()
        Me.rdRND = New System.Windows.Forms.RadioButton()
        Me.rdRND2 = New System.Windows.Forms.RadioButton()
        Me.btn_Folders = New System.Windows.Forms.Button()
        Me.btn_Usage = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtWiden = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ConfigurationName})
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.Location = New System.Drawing.Point(0, 30)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(590, 454)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ConfigurationName
        '
        Me.ConfigurationName.Text = "Configuration Name"
        Me.ConfigurationName.Width = 600
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select the Configuration(s) wich photos you want to see now:"
        '
        'btn_New
        '
        Me.btn_New.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_New.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_New.Location = New System.Drawing.Point(596, 30)
        Me.btn_New.Name = "btn_New"
        Me.btn_New.Size = New System.Drawing.Size(113, 39)
        Me.btn_New.TabIndex = 2
        Me.btn_New.Text = "&Create new Configuration"
        Me.btn_New.UseVisualStyleBackColor = True
        '
        'btn_Edit
        '
        Me.btn_Edit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Edit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Edit.Location = New System.Drawing.Point(596, 75)
        Me.btn_Edit.Name = "btn_Edit"
        Me.btn_Edit.Size = New System.Drawing.Size(113, 39)
        Me.btn_Edit.TabIndex = 3
        Me.btn_Edit.Text = "&Edit selected Configuration"
        Me.btn_Edit.UseVisualStyleBackColor = True
        '
        'btn_Del
        '
        Me.btn_Del.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Del.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Del.Location = New System.Drawing.Point(596, 120)
        Me.btn_Del.Name = "btn_Del"
        Me.btn_Del.Size = New System.Drawing.Size(113, 39)
        Me.btn_Del.TabIndex = 4
        Me.btn_Del.Text = "Delete selected Configuration"
        Me.btn_Del.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Save.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Save.Location = New System.Drawing.Point(637, 422)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(115, 62)
        Me.btn_Save.TabIndex = 5
        Me.btn_Save.Text = "Start showing this Set"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_Cancel
        '
        Me.btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Cancel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cancel.Location = New System.Drawing.Point(637, 490)
        Me.btn_Cancel.Name = "btn_Cancel"
        Me.btn_Cancel.Size = New System.Drawing.Size(115, 39)
        Me.btn_Cancel.TabIndex = 6
        Me.btn_Cancel.Text = "Back"
        Me.btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 493)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Only show fotos from:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker1.Location = New System.Drawing.Point(115, 491)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 8
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.Location = New System.Drawing.Point(390, 491)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(321, 493)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "to"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rdDateASC
        '
        Me.rdDateASC.AutoSize = True
        Me.rdDateASC.Location = New System.Drawing.Point(310, 517)
        Me.rdDateASC.Name = "rdDateASC"
        Me.rdDateASC.Size = New System.Drawing.Size(89, 17)
        Me.rdDateASC.TabIndex = 11
        Me.rdDateASC.TabStop = True
        Me.rdDateASC.Text = "order by Date"
        Me.rdDateASC.UseVisualStyleBackColor = True
        '
        'rdRND
        '
        Me.rdRND.AutoSize = True
        Me.rdRND.Location = New System.Drawing.Point(199, 517)
        Me.rdRND.Name = "rdRND"
        Me.rdRND.Size = New System.Drawing.Size(65, 17)
        Me.rdRND.TabIndex = 12
        Me.rdRND.TabStop = True
        Me.rdRND.Text = "Random"
        Me.rdRND.UseVisualStyleBackColor = True
        '
        'rdRND2
        '
        Me.rdRND2.AutoSize = True
        Me.rdRND2.Location = New System.Drawing.Point(4, 517)
        Me.rdRND2.Name = "rdRND2"
        Me.rdRND2.Size = New System.Drawing.Size(147, 17)
        Me.rdRND2.TabIndex = 13
        Me.rdRND2.TabStop = True
        Me.rdRND2.Text = "Random (avoid repeating)"
        Me.rdRND2.UseVisualStyleBackColor = True
        '
        'btn_Folders
        '
        Me.btn_Folders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Folders.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Folders.Location = New System.Drawing.Point(596, 266)
        Me.btn_Folders.Name = "btn_Folders"
        Me.btn_Folders.Size = New System.Drawing.Size(113, 39)
        Me.btn_Folders.TabIndex = 14
        Me.btn_Folders.Text = "&View/Edit Folders"
        Me.btn_Folders.UseVisualStyleBackColor = True
        '
        'btn_Usage
        '
        Me.btn_Usage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Usage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Usage.Location = New System.Drawing.Point(596, 165)
        Me.btn_Usage.Name = "btn_Usage"
        Me.btn_Usage.Size = New System.Drawing.Size(113, 39)
        Me.btn_Usage.TabIndex = 15
        Me.btn_Usage.Text = "Reset photos Usage" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on sel.Configuration"
        Me.btn_Usage.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(634, 404)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Widen:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(738, 404)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "%"
        '
        'txtWiden
        '
        Me.txtWiden.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWiden.Location = New System.Drawing.Point(680, 401)
        Me.txtWiden.MaxLength = 3
        Me.txtWiden.Name = "txtWiden"
        Me.txtWiden.Size = New System.Drawing.Size(52, 20)
        Me.txtWiden.TabIndex = 19
        Me.txtWiden.Text = "0"
        Me.txtWiden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmCurrentSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 541)
        Me.Controls.Add(Me.txtWiden)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btn_Usage)
        Me.Controls.Add(Me.btn_Folders)
        Me.Controls.Add(Me.rdRND2)
        Me.Controls.Add(Me.rdRND)
        Me.Controls.Add(Me.rdDateASC)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Cancel)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_Del)
        Me.Controls.Add(Me.btn_Edit)
        Me.Controls.Add(Me.btn_New)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "frmCurrentSet"
        Me.Text = "Current Set"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_New As System.Windows.Forms.Button
    Friend WithEvents btn_Edit As System.Windows.Forms.Button
    Friend WithEvents btn_Del As System.Windows.Forms.Button
    Friend WithEvents btn_Save As System.Windows.Forms.Button
    Friend WithEvents btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents ConfigurationName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdDateASC As System.Windows.Forms.RadioButton
    Friend WithEvents rdRND As System.Windows.Forms.RadioButton
    Friend WithEvents rdRND2 As System.Windows.Forms.RadioButton
    Friend WithEvents btn_Folders As System.Windows.Forms.Button
    Friend WithEvents btn_Usage As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtWiden As TextBox
End Class

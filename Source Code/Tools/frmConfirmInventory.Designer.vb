<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfirmInventory
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCategory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.catid = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(247, 73)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 37)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Confirm"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCategory
        '
        Me.txtCategory.DropDownHeight = 130
        Me.txtCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtCategory.ForeColor = System.Drawing.Color.Black
        Me.txtCategory.FormattingEnabled = True
        Me.txtCategory.IntegralHeight = False
        Me.txtCategory.ItemHeight = 17
        Me.txtCategory.Location = New System.Drawing.Point(96, 16)
        Me.txtCategory.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtCategory.MaxDropDownItems = 7
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(310, 25)
        Me.txtCategory.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(26, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 405
        Me.Label8.Text = "Category"
        '
        'txtUnit
        '
        Me.txtUnit.DropDownHeight = 130
        Me.txtUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnit.ForeColor = System.Drawing.Color.Black
        Me.txtUnit.FormattingEnabled = True
        Me.txtUnit.IntegralHeight = False
        Me.txtUnit.ItemHeight = 17
        Me.txtUnit.Location = New System.Drawing.Point(96, 44)
        Me.txtUnit.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.txtUnit.MaxDropDownItems = 7
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(310, 25)
        Me.txtUnit.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(56, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 17)
        Me.Label2.TabIndex = 404
        Me.Label2.Text = "Unit"
        '
        'catid
        '
        Me.catid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.catid.Location = New System.Drawing.Point(59, 133)
        Me.catid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.catid.Name = "catid"
        Me.catid.Size = New System.Drawing.Size(83, 25)
        Me.catid.TabIndex = 406
        Me.catid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.catid.Visible = False
        '
        'frmConfirmInventory
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 120)
        Me.Controls.Add(Me.catid)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmConfirmInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inventory Confirmation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents catid As System.Windows.Forms.TextBox

End Class

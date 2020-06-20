<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserInventorySelector
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
        Me.txtUseraccount = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.userid = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(180, 53)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 28)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Load Inventory"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtUseraccount
        '
        Me.txtUseraccount.DropDownHeight = 200
        Me.txtUseraccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtUseraccount.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtUseraccount.FormattingEnabled = True
        Me.txtUseraccount.IntegralHeight = False
        Me.txtUseraccount.ItemHeight = 15
        Me.txtUseraccount.Location = New System.Drawing.Point(13, 28)
        Me.txtUseraccount.MaxDropDownItems = 20
        Me.txtUseraccount.Name = "txtUseraccount"
        Me.txtUseraccount.Size = New System.Drawing.Size(303, 23)
        Me.txtUseraccount.TabIndex = 400
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(10, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 15)
        Me.Label12.TabIndex = 401
        Me.Label12.Text = "Select User Account"
        '
        'userid
        '
        Me.userid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.userid.Location = New System.Drawing.Point(12, 61)
        Me.userid.Name = "userid"
        Me.userid.Size = New System.Drawing.Size(70, 20)
        Me.userid.TabIndex = 402
        Me.userid.Visible = False
        '
        'frmUserInventorySelector
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 90)
        Me.Controls.Add(Me.userid)
        Me.Controls.Add(Me.txtUseraccount)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmUserInventorySelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Inventory Viewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtUseraccount As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents userid As System.Windows.Forms.TextBox

End Class

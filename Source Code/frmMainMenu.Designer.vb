<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.lblServer = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Imagemenu = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtOffice = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblServer
        '
        Me.lblServer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblServer.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblServer.ForeColor = System.Drawing.Color.Green
        Me.lblServer.Location = New System.Drawing.Point(23, 10)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(322, 20)
        Me.lblServer.TabIndex = 9
        Me.lblServer.Text = "Connected Server : 10.1.0.200"
        Me.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Button6.Location = New System.Drawing.Point(19, 115)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(328, 45)
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "New Item Inventory"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Button10.Location = New System.Drawing.Point(19, 162)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(328, 45)
        Me.Button10.TabIndex = 20
        Me.Button10.Text = "User Inventory Transaction"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Button11.Location = New System.Drawing.Point(19, 209)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(328, 45)
        Me.Button11.TabIndex = 21
        Me.Button11.Text = "Inventory Summary Report"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Imagemenu
        '
        Me.Imagemenu.ImageStream = CType(resources.GetObject("Imagemenu.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Imagemenu.TransparentColor = System.Drawing.Color.Transparent
        Me.Imagemenu.Images.SetKeyName(0, "Task list.png")
        Me.Imagemenu.Images.SetKeyName(1, "document_delete_48.png")
        Me.Imagemenu.Images.SetKeyName(2, "view-right-close.png")
        Me.Imagemenu.Images.SetKeyName(3, "preferences-contact-list.png")
        Me.Imagemenu.Images.SetKeyName(4, "Paper-x.png")
        Me.Imagemenu.Images.SetKeyName(5, "system-users-4.png")
        Me.Imagemenu.Images.SetKeyName(6, "documentation2.png")
        Me.Imagemenu.Images.SetKeyName(7, "osmo.png")
        Me.Imagemenu.Images.SetKeyName(8, "user3.png")
        Me.Imagemenu.Images.SetKeyName(9, "Period end.png")
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.Red
        Me.Button1.Location = New System.Drawing.Point(20, 256)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(328, 45)
        Me.Button1.TabIndex = 347
        Me.Button1.Text = "Change Your Password"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtOffice
        '
        Me.txtOffice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtOffice.FormattingEnabled = True
        Me.txtOffice.Location = New System.Drawing.Point(19, 89)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Size = New System.Drawing.Size(327, 23)
        Me.txtOffice.TabIndex = 368
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.Label1.Location = New System.Drawing.Point(59, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 20)
        Me.Label1.TabIndex = 369
        Me.Label1.Text = "Selelct your branch to start inventory"
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblUser.Location = New System.Drawing.Point(23, 30)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(322, 20)
        Me.lblUser.TabIndex = 370
        Me.lblUser.Text = "Logged User: Winter Bugahod (105)"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.5!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(19, 256)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(328, 45)
        Me.Button2.TabIndex = 371
        Me.Button2.Text = "Mandarin Autoparts"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 317)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOffice)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.lblUser)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FFE Inventory Utility Tool"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Imagemenu As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtOffice As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class

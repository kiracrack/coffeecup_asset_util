Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO

Public Class frmLoginAccount

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(file_conn) = False Then
            frmConnectionSetup.ShowDialog()
            End
        End If
        OpenMysqlConnection()
    End Sub

    Private Sub cmdset_Click(sender As Object, e As EventArgs) Handles cmdset.Click
        If txtUsername.Text = "" Then
            MessageBox.Show("Please select user!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUsername.Focus()
            Exit Sub

        ElseIf txtpassword.Text = "" Then
            MessageBox.Show("Please enter password!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpassword.Focus()
            Exit Sub
        End If

        Try
            Dim globallogin As Boolean = False
            If LCase(txtUsername.Text) = "root" Then
                com.CommandText = "SELECT * from tblaccounts where username='ROOT'  and password='" & EncryptTripleDES(UCase(txtUsername.Text) + txtpassword.Text) & "'" : rst = com.ExecuteReader()
                While rst.Read()
                    If rst.GetSchemaTable.Rows.Count <> 0 Then
                        globallogin = True
                        globaluserid = rst("accountid").ToString
                        globalUsername = rst("username").ToString
                        globalFullname = rst("fullname").ToString
                    Else
                        globallogin = False
                    End If
                End While
                rst.Close()
            Else
                com.CommandText = "SELECT * from tblaccounts inner join tblpermissions on tblaccounts.permission = tblpermissions.percode where username='" & rchar(UCase(txtUsername.Text)) & "'  and password='" & EncryptTripleDES(UCase(txtUsername.Text) + txtpassword.Text) & "'" : rst = com.ExecuteReader()
                While rst.Read()
                    If rst.GetSchemaTable.Rows.Count <> 0 Then
                        globallogin = True
                        globaluserid = rst("accountid").ToString
                        globalUsername = rst("username").ToString
                        globalFullname = rst("fullname").ToString
                    Else
                        globallogin = False
                    End If
                End While
                rst.Close()
            End If

            If globallogin = True Then
                Me.Hide()
                frmMainMenu.Show()
            Else
                MessageBox.Show("Login not authorized!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtpassword.Focus()
                Exit Sub
            End If
         
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message, vbCrLf _
                            & "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub

  
    Private Sub txtSolveby_SelectedValueChanged(sender As Object, e As EventArgs)
        txtpassword.Focus()
    End Sub

    Private Sub txtpassword_GotFocus(sender As Object, e As EventArgs) Handles txtpassword.GotFocus
        Me.AcceptButton = cmdset
    End Sub

   
    Private Sub txtpassword_MouseCaptureChanged(sender As Object, e As EventArgs) Handles txtpassword.MouseCaptureChanged
        Me.AcceptButton = Nothing
    End Sub
 
    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Chr(13) Then
            txtpassword.Focus()
        End If
    End Sub
End Class
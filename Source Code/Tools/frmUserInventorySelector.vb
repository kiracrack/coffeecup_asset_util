Imports System.Globalization

Public Class frmUserInventorySelector
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUseraccount.Text = "" Then
            MessageBox.Show("Please select user account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUseraccount.Focus()
            Exit Sub
       
        End If
        If MessageBox.Show("Are you sure you want to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            frmInventoryReport.userid.Text = userid.Text
            frmInventoryReport.FilterInventoryReports()
            Me.Close()
        End If
    End Sub

    Private Sub frmUserInventorySelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadToComboBox("select distinct trnby,(select fullname from tblaccounts where accountid = tblinventorycffe.trnby) as 'fullname' from tblinventorycffe where officeid='" & globalofficeid & "' order by fullname asc", "fullname", "trnby", txtUseraccount)
    End Sub
    Private Sub txtAccountablePerson_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtUseraccount.SelectedValueChanged
        If txtUseraccount.Text <> "" Then
            userid.Text = DirectCast(txtUseraccount.SelectedItem, ComboBoxItem).HiddenValue()
        End If
    End Sub
End Class

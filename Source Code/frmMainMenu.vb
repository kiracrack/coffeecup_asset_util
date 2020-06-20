Imports System.Security.AccessControl
Imports System.IO

Public Class frmMainMenu

    Private Sub frmMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmLoginAccount.Close()
    End Sub

  
    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblServer.Text = "Connected server: " & sqlserver & ":" & sqlPort
        lblUser.Text = "Logged User: " & globalFullname & " (" & globaluserid & ")"
        LoadToComboBox("select *,ucase(officename) as 'office' from tblcompoffice  order by officename asc", "office", "officeid", txtOffice)
    End Sub
   
   
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If txtOffice.Text = "" Then
            MsgBox("Please select office!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        End If
        frmNewInventoryEntry.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If txtOffice.Text = "" Then
            MsgBox("Please select office!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        End If
        frmInventoryReport.MyDataGridView.ContextMenuStrip = frmInventoryReport.cms_em
        frmInventoryReport.userid.Text = globaluserid
        frmInventoryReport.Show()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
         
        frmInventoryPerformance.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmChangePassword.Show()
    End Sub

    Private Sub txtOffice_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtOffice.SelectedValueChanged
        If txtOffice.Text <> "" Then
            globalofficeid = DirectCast(txtOffice.SelectedItem, ComboBoxItem).HiddenValue()
        End If
    End Sub

    Private Sub txtOffice_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtOffice.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtOffice.Text = "" Then
            MsgBox("Please select office!", MsgBoxStyle.Exclamation, "Error Message")
            Exit Sub
        End If
        frmMandarinAutoparts.ShowDialog()
    End Sub
End Class

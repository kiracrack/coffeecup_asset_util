Imports System.Globalization

Public Class frmConfirmInventory
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function

    
    Private Sub frmConfirmInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtCategory.Items.Count = 0 Then
            LoadToComboBox("SELECT * FROM  tblprocategory order by description asc;", "description", "catid", txtCategory)
        End If
        If txtUnit.Items.Count = 0 Then
            LoadToPainComboBox("SELECT distinct(unit) as 'unittype' from tblglobalproducts", "unittype", txtUnit)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmMandarinAutoparts.ConfirmInventory(catid.Text, txtCategory.Text, txtUnit.Text)
        Me.Close()
    End Sub
    Private Sub txtcategory_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtCategory.SelectedValueChanged
        If txtcategory.Text <> "" Then
            catid.Text = DirectCast(txtcategory.SelectedItem, ComboBoxItem).HiddenValue()
        End If
    End Sub
End Class

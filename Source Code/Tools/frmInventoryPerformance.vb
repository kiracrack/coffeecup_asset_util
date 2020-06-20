Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmInventoryPerformance
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.SelectedTab = TabPage2
        FilterInventoryOffice()
        TabControl1.SelectedTab = TabPage1
        FilterInventoryPerformance()
    End Sub

    Public Sub FilterInventoryPerformance()
        msda = New MySqlDataAdapter("select (select fullname from tblaccounts where accountid = tblinventorycffe.trnby) as 'Encoders', count(*) as 'Total Entries' from tblinventorycffe group by trnby order by count(*) desc;", conn)
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda.Fill(dst, 0)
        MyDataGridView.DataSource = dst.Tables(0)
        GridColumnAlignment(MyDataGridView, {"Total Entries"}, DataGridViewContentAlignment.MiddleCenter)
        MyDataGridView.Columns("Total Entries").Width = 100

    End Sub

    Public Sub FilterInventoryOffice()
        msda = New MySqlDataAdapter("select officeid, (select officename from tblcompoffice where officeid = tblinventorycffe.officeid) as 'Office', count(*) as 'Total Entries' from tblinventorycffe group by officeid order by count(*) desc;", conn)
        MyDataGridView_office.DataSource = Nothing : dst = New DataSet
        msda.Fill(dst, 0)
        MyDataGridView_office.DataSource = dst.Tables(0)
        MyDataGridView_office.Columns("officeid").Visible = False
        GridColumnAlignment(MyDataGridView_office, {"Total Entries"}, DataGridViewContentAlignment.MiddleCenter)
        MyDataGridView_office.Columns("Total Entries").Width = 100

    End Sub

    Private Sub DuplicateItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateItemToolStripMenuItem.Click
        globalofficeid = MyDataGridView_office.Item("officeid", MyDataGridView_office.CurrentRow.Index).Value().ToString
        frmInventoryReport.MyDataGridView.ContextMenuStrip = frmInventoryReport.ContextMenuStrip_viewing
        frmInventoryReport.Text = "INVENTORY TRANSACTION OF " & UCase(MyDataGridView_office.Item("Office", MyDataGridView_office.CurrentRow.Index).Value().ToString)
        frmInventoryReport.userid.Text = "%"
        frmInventoryReport.Show()
    End Sub
 
End Class
Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmInventoryReport
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Escape) Then
            Me.Close()
        ElseIf keyData = (Keys.F12) Then
            frmUserInventorySelector.Show(Me)
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmRequestType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FilterInventoryReports()
    End Sub

    Public Sub FilterInventoryReports()
        msda = New MySqlDataAdapter("select  ffecode, (select itemname from tblglobalproducts where productid = tblinventorycffe.productid) as 'Product Name', " _
                                                + " cast((select description from tblprocategory where catid=tblinventorycffe.catid) as char(500)) as 'Category', " _
                                                + " Quantity, Unit, cost as 'Unit Cost', Total,date_format(datepurchased,'%Y-%m-%d') as 'Date Purchase', " _
                                                + " cast((select stockhousename from tblstockhouse where stockhouseid = tblinventorycffe.stockhouseid) as char(500)) as 'Office Subsidiary', " _
                                                + " cast((select fullname from tblaccounts where accountid=tblinventorycffe.acctableperson) as char(500)) as 'Accountable Person', " _
                                                + "  Remarks, case when Actived=1 then 'YES' else 'NO' end as 'Actived',(select fullname from tblaccounts where accountid = tblinventorycffe.trnby) as 'Transaction By'  from tblinventorycffe where officeid='" & globalofficeid & "' and trnby like '%" & userid.Text & "%';", conn)
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda.Fill(dst, 0)

        MyDataGridView.DataSource = dst.Tables(0)
        MyDataGridView.Columns("Remarks").Width = 300
        MyDataGridView.Columns("ffecode").Visible = False

        GridColumnAlignment(MyDataGridView, {"Quantity", "Unit", "Date Purchase", "Actived"}, DataGridViewContentAlignment.MiddleCenter)
        GridCurrencyColumn(MyDataGridView, {"Unit Cost", "Total"})
        MyDataGridView.Columns("Remarks").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        MyDataGridView.Columns("Remarks").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        MyDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub EditEnventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditEnventoryToolStripMenuItem.Click
        frmNewInventoryEntry.mode.Text = "edit"
        frmNewInventoryEntry.trnid.Text = MyDataGridView.Item("refcode", MyDataGridView.CurrentRow.Index).Value().ToString
        frmNewInventoryEntry.trncode.Text = MyDataGridView.Item("ffecode", MyDataGridView.CurrentRow.Index).Value().ToString
        frmNewInventoryEntry.Show(Me)
    End Sub

    Private Sub DeleteEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteEntryToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
                com.CommandText = "delete from tblinventorycffe where ffecode='" & rw.Cells("ffecode").Value.ToString() & "'" : com.ExecuteNonQuery()
                com.CommandText = "delete from tblinventorydetails where ffecode='" & rw.Cells("ffecode").Value.ToString() & "'" : com.ExecuteNonQuery()
            Next
            FilterInventoryReports()
            MsgBox("Product successfully deleted!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub ExtendServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtendServiceToolStripMenuItem.Click
        FilterInventoryReports()
    End Sub

    Private Sub DuplicateItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateItemToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            Dim trncode As String = getGlobalTrnid("util", globaluserid)
            com.CommandText = "insert into tblinventorycffe (poid,ffecode,productid,catid,quantity,unit,cost,total,vendorid,officeid,stockhouseid,acctableperson,acctabledate,remarks,datepurchased,trnby,datetrn,actived,`status`) " _
                                + " select poid,'" & trncode & "',productid,catid,quantity,unit,cost,total,vendorid,officeid,stockhouseid,acctableperson,acctabledate,remarks,datepurchased,trnby,datetrn,actived,1 from tblinventorycffe where ffecode='" & MyDataGridView.Item("ffecode", MyDataGridView.CurrentRow.Index).Value().ToString & "'" : com.ExecuteNonQuery()
            com.CommandText = "insert into tblinventorydetails (ffecode,description,value) select '" & trncode & "',description,value from tblinventorydetails where ffecode='" & MyDataGridView.Item("ffecode", MyDataGridView.CurrentRow.Index).Value().ToString & "'" : com.ExecuteNonQuery()
            frmNewInventoryEntry.mode.Text = "edit"
            frmNewInventoryEntry.trncode.Text = trncode
            frmNewInventoryEntry.Show(Me)
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        frmNewInventoryEntry.mode.Text = "view"
        frmNewInventoryEntry.trnid.Text = MyDataGridView.Item("refcode", MyDataGridView.CurrentRow.Index).Value().ToString
        frmNewInventoryEntry.trncode.Text = MyDataGridView.Item("ffecode", MyDataGridView.CurrentRow.Index).Value().ToString
        frmNewInventoryEntry.Show(Me)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        FilterInventoryReports()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        Dim f As FolderBrowserDialog = New FolderBrowserDialog
        Try
            If f.ShowDialog() = DialogResult.OK Then
                msda = New MySqlDataAdapter("select (select itemname from tblglobalproducts where productid = tblinventorycffe.productid) as 'Product Name', " _
                                              + " cast((select description from tblprocategory where catid=tblinventorycffe.catid) as char(500)) as 'Category', " _
                                              + " Quantity, Unit, cost as 'Unit Cost', Total,date_format(datepurchased,'%Y-%m-%d') as 'Date Purchase', " _
                                              + " cast((select stockhousename from tblstockhouse where stockhouseid = tblinventorycffe.stockhouseid) as char(500)) as 'Office Subsidiary', " _
                                              + " cast((select fullname from tblaccounts where accountid=tblinventorycffe.acctableperson) as char(500)) as 'Accountable Person', " _
                                              + " date_format(acctabledate,'%Y-%m-%d') as 'Date Issued', Remarks, case when Actived=1 then 'YES' else 'NO' end as 'Actived',(select fullname from tblaccounts where accountid = tblinventorycffe.trnby) as 'Transaction By', " _
                                              + " cast((select group_concat(concat(description,': ', value) SEPARATOR  '\n') from tblinventorydetails where ffecode = tblinventorycffe.ffecode) as char(10000))  as 'Complete Details'  from tblinventorycffe where officeid='" & globalofficeid & "' and trnby like '%" & userid.Text & "%';", conn)
                dst = New DataSet
                msda.Fill(dst, 0)
                dst.WriteXml(f.SelectedPath & "\" & LCase(Me.Text) & ".xls")

                MessageBox.Show("Export done successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK)
        End Try
    End Sub

 
End Class
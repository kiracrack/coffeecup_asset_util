Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System
Imports System.IO
Imports System.Drawing.Printing

Public Class frmMandarinAutoparts
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
        msda = New MySqlDataAdapter("SELECT id, ucase(concat(if(brand is null,'',concat(brand,' ')),if(genericname is null,'',concat(genericname,' ')),if(productname is null,'',concat(productname,' ')),if(Model is null,'',concat(Model,' ')),if(Usedfor is null,'',concat(Usedfor,' ')),if(SerialNumber is null,'',concat(SerialNumber,' ')),if(OtherDescriptiveNumber is null,'',concat(OtherDescriptiveNumber,' ')))) as 'ItemName' ,Brand, Model, PartNumber,Quantity FROM `masterlistfinal` where deleted=0 and uploaded=0;", conn)
        MyDataGridView.DataSource = Nothing : dst = New DataSet
        msda.Fill(dst, 0)

        MyDataGridView.DataSource = dst.Tables(0)
        MyDataGridView.Columns("ItemName").Width = 700
        MyDataGridView.Columns("id").Visible = False

        GridColumnAlignment(MyDataGridView, {"Quantity", "PartNumber"}, DataGridViewContentAlignment.MiddleCenter)
        'MyDataGridView.Columns("ItemName").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        MyDataGridView.Columns("ItemName").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'MyDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        frmConfirmInventory.ShowDialog()
    End Sub
    Public Function ConfirmInventory(ByVal catid As String, ByVal categoryname As String, ByVal unit As String)
        For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
            Dim newProductID As String = getproid()
            com.CommandText = "insert into tblglobalproducts set productid='" & newProductID & "', " _
                                                                       + " itemname='" & rchar(rw.Cells("ItemName").Value.ToString) & "', " _
                                                                       + " partnumber='" & rchar(rw.Cells("PartNumber").Value.ToString) & "', " _
                                                                       + " catid='" & catid & "', " _
                                                                       + " unit='" & unit & "', " _
                                                                       + " enablesell=1, " _
                                                                       + " vatableitem=1, " _
                                                                       + " salemode='esba'," _
                                                                       + " allowinputdiscountedamount=1," _
                                                                       + " entryby='" & globaluserid & "', " _
                                                                       + " dateentered=current_timestamp, actived=1;" : com.ExecuteNonQuery()

            com.CommandText = "insert into tblinventory set officeid='" & globalofficeid & "', " _
                                                                        + " productid='" & newProductID & "', " _
                                                                        + " productname='" & rchar(rw.Cells("ItemName").Value.ToString) & If(rw.Cells("PartNumber").Value.ToString <> "", " " + rchar(rw.Cells("PartNumber").Value.ToString), "") & "', " _
                                                                        + " catid='" & catid & "', " _
                                                                        + " categoryname='" & rchar(categoryname) & "', " _
                                                                        + " quantity=" & Val(CC(rw.Cells("Quantity").Value.ToString)) & ", " _
                                                                        + " unit='" & unit & "', " _
                                                                        + " lastupdate=current_timestamp, " _
                                                                        + " lasttrnby='" & globaluserid & "', " _
                                                                        + " dateinventory=current_timestamp;" : com.ExecuteNonQuery()

            com.CommandText = "insert into tblinventorylogs set batchcode='migration',vendorid='SPR-1042', trncode='" & rw.Cells("id").Value.ToString & "', officeid='" & globalofficeid & "', catid='" & catid & "', productid='" & newProductID & "', quantity='" & Val(CC(rw.Cells("Quantity").Value.ToString)) & "', unit='" & unit & "', unitcost=0,total=0,datepurchased=current_timestamp, remarks='migration',datetrn=current_timestamp,trnby='" & globaluserid & "',confirmed=1 " : com.ExecuteNonQuery()
            com.CommandText = "update masterlistfinal set uploaded=1 where id='" & rw.Cells("id").Value.ToString & "'" : com.ExecuteNonQuery()
            MyDataGridView.Rows.Remove(rw)
        Next
        Return True
    End Function

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If MessageBox.Show("Are you sure you want to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
                com.CommandText = "update masterlistfinal set deleted=1 where id='" & rw.Cells("id").Value.ToString & "'" : com.ExecuteNonQuery()
                MyDataGridView.Rows.Remove(rw)
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        FilterInventoryReports()
    End Sub
End Class
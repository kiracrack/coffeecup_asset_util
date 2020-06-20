Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class frmNewInventoryEntry
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.F2) Then
            MyDataGridView.Focus()

        End If
        Return ProcessCmdKey
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        If txtProductName.Text = "" Then
            MsgBox("Please select Product!", MsgBoxStyle.Critical)
            txtProductName.Focus()
            Exit Sub
        ElseIf Val(CC(txtQuantity.Text)) < 0 Then
            MsgBox("Please enter quantity!", MsgBoxStyle.Critical)
            txtQuantity.Focus()
            Exit Sub
        End If
        If MessageBox.Show("Are you sure you want to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then
            If trnid.Text <> "" Then
                com.CommandText = "UPDATE tblinventorycffe set poid='ffe-utility-trn', ffecode='" & trncode.Text & "',productid='" & productid.Text & "', catid='" & catid.Text & "', quantity='" & Val(CC(txtQuantity.Text)) & "', unit='" & txtUnitType.Text & "', cost='" & Val(CC(txtUnitCost.Text)) & "', total='" & Val(CC(txtTotal.Text)) & "', vendorid='default', officeid='" & globalofficeid & "', stockhouseid='" & stockhouseid.Text & "', acctableperson='" & accountableid.Text & "', acctabledate='" & ConvertDate(txtDateIssue.Text) & "', remarks='" & rchar(txtRemarks.Text) & "', datepurchased='" & ConvertDate(txtDatePurchased.Text) & "', actived=" & ckActive.CheckState & " where refcode='" & trnid.Text & "'" : com.ExecuteNonQuery()
            Else
                com.CommandText = "delete from tblinventorycffe where ffecode='" & trncode.Text & "'" : com.ExecuteNonQuery()
                com.CommandText = "INSERT into tblinventorycffe set poid='ffe-utility-trn', ffecode='" & trncode.Text & "',productid='" & productid.Text & "', catid='" & catid.Text & "', quantity='" & Val(CC(txtQuantity.Text)) & "', unit='" & txtUnitType.Text & "', cost='" & Val(CC(txtUnitCost.Text)) & "', total='" & Val(CC(txtTotal.Text)) & "', vendorid='default', officeid='" & globalofficeid & "', stockhouseid='" & stockhouseid.Text & "', acctableperson='" & accountableid.Text & "', acctabledate='" & ConvertDate(txtDateIssue.Text) & "', remarks='" & rchar(txtRemarks.Text) & "', datepurchased='" & ConvertDate(txtDatePurchased.Text) & "', trnby='" & globaluserid & "', datetrn=current_timestamp, actived=" & ckActive.CheckState & "" : com.ExecuteNonQuery()
            End If

            com.CommandText = "delete from tblinventorydetails where ffecode='" & trncode.Text & "'" : com.ExecuteNonQuery()
            For Each rw As DataGridViewRow In MyDataGridView.Rows
                If Not rw.Cells("Description").Value Is Nothing And Not rw.Cells("Value").Value Is Nothing Then
                    com.CommandText = "insert into tblinventorydetails set ffecode='" & trncode.Text & "', description='" & rchar(rw.Cells("Description").Value.ToString) & "', value='" & rchar(rw.Cells("Value").Value.ToString) & "'" : com.ExecuteNonQuery()
                End If
            Next
            MsgBox("Product successfully saved!", MsgBoxStyle.Information)
            NewInventory()
        End If
    End Sub
    Private Sub frmPointOfSale_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MyDataGridView.Rows.Count > 1 Then
            If MessageBox.Show("Are you sure you want to cancel current entries? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbYes Then

            Else
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub frmLoanAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddata()
        PopulateCombobox()
        NewInventory()
    End Sub

    Public Sub PopulateCombobox()
        Dim dgcmbcol As DataGridViewComboBoxColumn
        dgcmbcol = New DataGridViewComboBoxColumn
        dgcmbcol.HeaderText = "Description"
        dgcmbcol.Width = 65
        dgcmbcol.Name = "Description"
        dgcmbcol.ReadOnly = False
        dgcmbcol.AutoComplete = False

        dgcmbcol.FlatStyle = FlatStyle.Flat
        LoadToGridComboBox("select distinct(description) as 'val' from tblinventorydetails order by description asc", "val", dgcmbcol)
        MyDataGridView.Columns.Add(dgcmbcol)

        Dim dgcmbcol1 As DataGridViewComboBoxColumn
        dgcmbcol1 = New DataGridViewComboBoxColumn
        dgcmbcol1.HeaderText = "Value"
        dgcmbcol1.Width = 65
        dgcmbcol1.Name = "Value"
        dgcmbcol1.ReadOnly = False
        dgcmbcol1.AutoComplete = False

        dgcmbcol1.FlatStyle = FlatStyle.Flat
        LoadToGridComboBox("select distinct(value) as 'val' from tblinventorydetails order by value asc", "val", dgcmbcol1)
        MyDataGridView.Columns.Add(dgcmbcol1)


    End Sub

    Public Sub NewInventory()
        If mode.Text <> "edit" Then
            If mode.Text = "view" Then
                cmdSave.Visible = False
                ToolStripButton1.Enabled = False
                ToolStripButton2.Enabled = False
                ToolStripButton3.Enabled = False
                txtProductName.Enabled = False
                txtstockhouse.Enabled = False
                txtAccountablePerson.Enabled = False
                txtDateIssue.Enabled = False
                txtDatePurchased.Enabled = False
                ckActive.Enabled = False

                txtQuantity.ReadOnly = True
                txtUnitCost.ReadOnly = True

                txtRemarks.ReadOnly = True

                MyDataGridView.AllowUserToAddRows = False
                MyDataGridView.AllowUserToDeleteRows = False
                MyDataGridView.ReadOnly = True

            Else
                cmdSave.Visible = True
                ToolStripButton1.Enabled = True
                ToolStripButton2.Enabled = True
                ToolStripButton3.Enabled = True
                txtProductName.Enabled = True
                txtstockhouse.Enabled = True
                txtAccountablePerson.Enabled = True
                txtDateIssue.Enabled = True
                txtDatePurchased.Enabled = True
                ckActive.Enabled = True

                txtQuantity.ReadOnly = False
                txtUnitCost.ReadOnly = False

                txtRemarks.ReadOnly = False

                MyDataGridView.AllowUserToAddRows = True
                MyDataGridView.AllowUserToDeleteRows = True
                MyDataGridView.ReadOnly = False

                trncode.Text = getGlobalTrnid("util", globaluserid)
                txtQuantity.Text = 1
                ckActive.Checked = True
                txtProductName.Focus()
                txtProductName.DroppedDown = True
                trnid.Text = ""

            End If
        End If

        com.CommandText = "select *,(select itemname from tblglobalproducts where productid = tblinventorycffe.productid) as 'Product Name', " _
                                                + " cast((select description from tblprocategory where catid=tblinventorycffe.catid) as char(500)) as 'Category', " _
                                                + " cast((select stockhousename from tblstockhouse where stockhouseid = tblinventorycffe.stockhouseid) as char(500)) as 'Office Subsidiary', " _
                                                + " cast((select fullname from tblaccounts where accountid=tblinventorycffe.acctableperson) as char(500)) as 'Accountable Person' " _
                                                + "  from tblinventorycffe where ffecode ='" & trncode.Text & "'" : rst = com.ExecuteReader
        While rst.Read
            txtProductName.Text = rst("Product Name").ToString
            productid.Text = rst("productid").ToString
            txtCategory.Text = rst("Category").ToString
            catid.Text = rst("catid").ToString
            txtQuantity.Text = rst("quantity").ToString
            txtUnitType.Text = rst("unit").ToString
            txtUnitCost.Text = FormatNumber(rst("cost").ToString, 2)
            txtTotal.Text = FormatNumber(rst("total").ToString, 2)
            txtDatePurchased.Text = CDate(rst("datepurchased").ToString)
            txtstockhouse.Text = rst("Office Subsidiary").ToString
            stockhouseid.Text = rst("stockhouseid").ToString
            txtAccountablePerson.Text = rst("Accountable Person").ToString
            accountableid.Text = rst("acctableperson").ToString
            If rst("acctabledate").ToString <> "" Then
                txtDateIssue.Text = CDate(rst("acctabledate").ToString)
            End If
            txtRemarks.Text = rst("remarks").ToString
            ckActive.Checked = rst("actived")
        End While
        rst.Close()


        MyDataGridView.Rows.Clear()
        com.CommandText = "select distinct Description, Value as val from tblinventorydetails where ffecode='" & trncode.Text & "' group by Description" : rst = com.ExecuteReader
        While rst.Read
            ' MsgBox(rst("Description").ToString & "-" & rst("val").ToString)
            MyDataGridView.Rows.Add(rst("Description").ToString, rst("val").ToString)
        End While
        rst.Close()

        mode.Text = ""
    End Sub

    Public Sub LoadSudgestion()
        MyDataGridView.Rows.Clear()
        com.CommandText = "select distinct Description , Value from tblinventorydetails inner join tblinventorycffe  on tblinventorydetails.ffecode = tblinventorycffe.ffecode where productid='" & productid.Text & "' group by Description" : rst = com.ExecuteReader
        While rst.Read
            MyDataGridView.Rows.Add(rst("Description").ToString, rst("Value").ToString)
        End While
        rst.Close()
    End Sub

    Private Sub MyDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles MyDataGridView.DataError

    End Sub

    Private Sub MyDataGridView_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles MyDataGridView.EditingControlShowing
        If TypeOf e.Control Is System.Windows.Forms.ComboBox Then
            With DirectCast(e.Control, System.Windows.Forms.ComboBox)
                .DropDownStyle = ComboBoxStyle.DropDown
                .AutoCompleteMode = AutoCompleteMode.Suggest
                .AutoCompleteSource = AutoCompleteSource.ListItems
            End With
        End If
    End Sub
    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles MyDataGridView.CellValidating
        If (TypeOf CType(sender, DataGridView).EditingControl Is DataGridViewComboBoxEditingControl) Then
            Dim cmb As DataGridViewComboBoxEditingControl = CType(CType(sender, DataGridView).EditingControl, DataGridViewComboBoxEditingControl)
            If Not cmb Is Nothing Then
                Dim grid As DataGridView = cmb.EditingControlDataGridView
                Dim value As Object = cmb.Text
                '// Add value to list if not there
                If cmb.Items.IndexOf(value) = -1 And cmb.Text <> "" Then
                    '// Must add to both the current combobox as well as the template, to avoid duplicate entries...
                    cmb.Items.Add(value)
                    Dim cmbCol As DataGridViewComboBoxColumn = CType(grid.Columns(grid.CurrentCell.ColumnIndex), DataGridViewComboBoxColumn)
                    If Not cmbCol Is Nothing Then
                        cmbCol.Items.Add(value)
                        grid.CurrentCell.Value = value
                    End If
                End If
                grid.CurrentCell.Value = value
            End If
        End If
    End Sub

    'Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MyDataGridView.CellMouseClick
    '    MyDataGridView.BeginEdit(True)
    'End Sub
    Public Sub loaddata()
        Loadproduct()
        LoadStockhouse()
        LoadAccountable()
    End Sub
    Public Sub Loadproduct()
        LoadToComboBox("select *,ucase(itemname) as 'product' from tblglobalproducts inner join tblprocategory on tblglobalproducts.catid = tblprocategory.catid where uses=2 order by itemname asc", "product", "productid", txtProductName)
    End Sub
    Public Sub LoadStockhouse()
        LoadToComboBox("select *,ucase(stockhousename) as 'stockhouse' from tblstockhouse where officeid='" & globalofficeid & "' order by stockhousename asc", "stockhouse", "stockhouseid", txtstockhouse)
    End Sub
    Public Sub LoadAccountable()
        LoadToComboBox("select * from tblaccounts where officeid='" & globalofficeid & "' order by fullname asc", "fullname", "accountid", txtAccountablePerson)
    End Sub

    'Private Sub txtProductName_LostFocus(sender As Object, e As EventArgs) Handles txtProductName.LostFocus
    '    LoadSudgestion()
    'End Sub


    Private Sub txtProductName_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtProductName.SelectedValueChanged
        If mode.Text = "edit" Or mode.Text = "view" Then Exit Sub
        If txtProductName.Text <> "" Then
            productid.Text = DirectCast(txtProductName.SelectedItem, ComboBoxItem).HiddenValue()
            com.CommandText = "select *, cast((select description from tblprocategory where catid=tblglobalproducts.catid) as char(500)) as 'category', " _
                     + " ifnull(ifnull((select procost from tblitemvendor where officeid='" & globalofficeid & "' and itemid = tblglobalproducts.productid order by lastupdate asc limit 1), (select purchasedprice from tblinventory where productid=tblglobalproducts.productid and officeid = '" & globalofficeid & "' limit 1)),0) as 'latestcost' from tblglobalproducts where productid='" & productid.Text & "'" : rst = com.ExecuteReader
            While rst.Read
                catid.Text = rst("catid").ToString
                txtCategory.Text = rst("category").ToString
                txtUnitType.Text = rst("unit").ToString
                txtUnitCost.Text = FormatNumber(rst("latestcost").ToString, 2)
            End While
            rst.Close()
            LoadSudgestion()
        End If
    End Sub
    Private Sub txtstockhouse_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtstockhouse.SelectedValueChanged
        If mode.Text = "edit" Or mode.Text = "view" Then Exit Sub
        If txtstockhouse.Text <> "" Then
            stockhouseid.Text = DirectCast(txtstockhouse.SelectedItem, ComboBoxItem).HiddenValue()
        End If
    End Sub
    Private Sub txtAccountablePerson_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtAccountablePerson.SelectedValueChanged
        If mode.Text = "edit" Or mode.Text = "view" Then Exit Sub
        If txtAccountablePerson.Text <> "" Then
            accountableid.Text = DirectCast(txtAccountablePerson.SelectedItem, ComboBoxItem).HiddenValue()
        End If
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        InputNumberOnly(txtQuantity, e)
    End Sub

    Private Sub txtUnitCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitCost.KeyPress
        InputNumberOnly(txtQuantity, e)
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged, txtUnitCost.TextChanged
        txtTotal.Text = FormatNumber(Val(CC(txtUnitCost.Text)) * Val(CC(txtQuantity.Text)))
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        frmProductRegistration.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        frmStockhouseRegistration.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        frmEmployees.ShowDialog(Me)
    End Sub

    Private Sub ToolStripSplitButton1_Click(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.Click
        Me.Close()
    End Sub

    
    Private Sub MyDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MyDataGridView.CellContentClick

    End Sub

    Private Sub txtstockhouse_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtstockhouse.SelectedIndexChanged

    End Sub
End Class

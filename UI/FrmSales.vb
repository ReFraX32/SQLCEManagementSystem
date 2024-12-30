Imports BLL

Public Class FrmSales
    Private ReadOnly saleBLL As New SaleBLL()
    Private ReadOnly productBLL As New ProductBLL()
    Private ReadOnly customerBLL As New CustomerBLL()
    Private ReadOnly items As New List(Of SaleItem)
    Private nextItemID As Integer = 1

    Private Sub FrmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
        LoadProducts()
        FormatTotalLabel()
        dtpSaleDate.Format = DateTimePickerFormat.Custom
        dtpSaleDate.CustomFormat = "dd/MM/yyyy HH:mm"
    End Sub

    Private Sub FormatTotalLabel()
        lblTotal.Text = Format(0, "C2")
        lblTotal.BackColor = Color.LightGray
        lblTotal.ForeColor = Color.Black
        lblTotal.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub LoadCustomers()
        Dim dt = customerBLL.GetCustomers()
        cmbCustomers.DataSource = dt
        cmbCustomers.DisplayMember = "Name"
        cmbCustomers.ValueMember = "ID"
        cmbCustomers.SelectedIndex = -1
    End Sub

    Private Sub LoadProducts()
        Dim dt = productBLL.GetProducts()
        cmbProducts.DataSource = dt
        cmbProducts.DisplayMember = "Name"
        cmbProducts.ValueMember = "ID"
        cmbProducts.SelectedIndex = -1
    End Sub

    Private Sub FormatDataGridView()
        With dgvItems
            .AutoGenerateColumns = True
            For Each col As DataGridViewColumn In .Columns
                Select Case col.Name
                    Case "ID"
                        col.HeaderText = "Item ID"
                        col.Width = 70
                    Case "SaleID"
                        col.Visible = False
                    Case "ProductID"
                        col.HeaderText = "Product ID"
                        col.Width = 80
                    Case "Quantity"
                        col.HeaderText = "Quantity"
                        col.DefaultCellStyle.Format = "N0"
                        col.Width = 80
                    Case "UnitPrice"
                        col.HeaderText = "Unit Price"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                    Case "TotalPrice"
                        col.HeaderText = "Total Price"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                End Select
            Next
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub BtnAddProduct_Click(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        If cmbProducts.SelectedItem Is Nothing OrElse Not Decimal.TryParse(txtQuantity.Text, Nothing) Then
            MessageBox.Show("Please select a product and enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedProduct = CType(cmbProducts.SelectedItem, DataRowView)
        Dim item As New SaleItem With {
            .ID = nextItemID,
            .ProductID = selectedProduct("ID"),
            .Quantity = Decimal.Parse(txtQuantity.Text),
            .UnitPrice = Convert.ToDecimal(selectedProduct("Price")),
            .TotalPrice = Decimal.Parse(txtQuantity.Text) * Convert.ToDecimal(selectedProduct("Price"))
        }

        items.Add(item)
        nextItemID += 1
        dgvItems.DataSource = Nothing
        dgvItems.DataSource = items
        FormatDataGridView()
        lblTotal.Text = Format(items.Sum(Function(i) i.TotalPrice), "C2")
    End Sub

    Private Sub BtnSaveSale_Click(sender As Object, e As EventArgs) Handles btnSaveSale.Click
        If items.Count = 0 OrElse cmbCustomers.SelectedValue Is Nothing Then
            MessageBox.Show("Please add products and select a customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim saleID = saleBLL.AddSale(CInt(cmbCustomers.SelectedValue), dtpSaleDate.Value, items)
        If saleID > 0 Then
            MessageBox.Show($"Sale saved successfully with Sale ID: {saleID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetForm()
        End If
    End Sub

    Private Sub ResetForm()
        items.Clear()
        nextItemID = 1
        dgvItems.DataSource = Nothing
        FormatTotalLabel()
        txtQuantity.Clear()
        cmbCustomers.SelectedIndex = -1
        cmbProducts.SelectedIndex = -1
    End Sub
End Class
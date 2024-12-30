Imports BLL

Public Class FrmProducts
    Private ReadOnly productBLL As New ProductBLL()

    Private Sub FrmProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
    End Sub

    Private Sub LoadProducts()
        Try
            Dim productsTable As DataTable = productBLL.GetProducts()
            If productsTable IsNot Nothing AndAlso productsTable.Rows.Count > 0 Then
                DataGridView1.DataSource = productsTable
                FormatDataGridView()
            Else
                MessageBox.Show("No products available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView()
        With DataGridView1
            .AutoGenerateColumns = True
            For Each col As DataGridViewColumn In .Columns
                Select Case col.Name
                    Case "ID"
                        col.HeaderText = "Product ID"
                        col.Width = 80
                    Case "Name"
                        col.HeaderText = "Product Name"
                        col.Width = 150
                    Case "Price"
                        col.HeaderText = "Price"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                    Case "Category"
                        col.HeaderText = "Category"
                        col.Width = 120
                End Select
            Next
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse
           String.IsNullOrWhiteSpace(txtPrice.Text) OrElse
           String.IsNullOrWhiteSpace(txtCategory.Text) Then
            MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
            MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            productBLL.AddProduct(txtName.Text, price, txtCategory.Text)
            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim productRow = productBLL.GetProducts().Select($"ID = {id}").FirstOrDefault()
            If productRow Is Nothing Then
                MessageBox.Show("No product found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim productName As String = productRow("Name").ToString()

            If MessageBox.Show($"Are you sure you want to update the product '{productName}'?",
                             "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                Return
            End If

            If String.IsNullOrWhiteSpace(txtName.Text) OrElse
               String.IsNullOrWhiteSpace(txtPrice.Text) OrElse
               String.IsNullOrWhiteSpace(txtCategory.Text) Then
                MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim price As Decimal
            If Not Decimal.TryParse(txtPrice.Text, price) OrElse price <= 0 Then
                MessageBox.Show("Please enter a valid positive price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            productBLL.UpdateProduct(id, txtName.Text, price, txtCategory.Text)
            MessageBox.Show($"Product '{txtName.Text}' updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim productRow = productBLL.GetProducts().Select($"ID = {id}").FirstOrDefault()
            If productRow Is Nothing Then
                MessageBox.Show("No product found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim productName As String = productRow("Name").ToString()

            If MessageBox.Show($"Are you sure you want to delete the product '{productName}'?",
                             "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                Return
            End If

            productBLL.DeleteProduct(id)
            MessageBox.Show($"Product '{productName}' deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()
            ResetForm()
        Catch ex As Exception
            MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If String.IsNullOrWhiteSpace(txtSearch.Text) Then
                LoadProducts()
                Return
            End If

            Dim name As String = txtSearch.Text
            Dim result As DataTable = productBLL.SearchProductsByName(name)

            If result.Rows.Count = 0 Then
                MessageBox.Show("No products found with the provided name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProducts()
                Return
            End If

            DataGridView1.DataSource = result
            FormatDataGridView()
        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadProducts()
        End If
    End Sub

    Private Sub ResetForm()
        txtID.Clear()
        txtName.Clear()
        txtPrice.Clear()
        txtCategory.Clear()
        txtSearch.Clear()
    End Sub
End Class
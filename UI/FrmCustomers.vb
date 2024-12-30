Imports BLL

Public Class FrmCustomers
    Private ReadOnly customerBLL As New CustomerBLL()
    Private Sub FrmCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCustomers()
    End Sub

    Private Sub LoadCustomers()
        DataGridView1.DataSource = customerBLL.GetCustomers()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtName.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhone.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        customerBLL.AddCustomer(txtName.Text, txtPhone.Text, txtEmail.Text)
        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadCustomers()
        ResetForm()
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Please enter a valid ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim customerRow = customerBLL.GetCustomers().Select($"ID = {id}").FirstOrDefault()
        If customerRow Is Nothing Then
            MessageBox.Show("No customer found with the provided ID. Please verify and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim customerName As String = customerRow("Name").ToString()

        Dim result = MessageBox.Show($"Are you sure you want to update the customer '{customerName}'?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        If String.IsNullOrWhiteSpace(txtName.Text) OrElse
           String.IsNullOrWhiteSpace(txtPhone.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        customerBLL.UpdateCustomer(id, txtName.Text, txtPhone.Text, txtEmail.Text)
        MessageBox.Show($"Customer '{txtName.Text}' updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadCustomers()
        ResetForm()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim id As Integer

        If Not Integer.TryParse(txtID.Text, id) Then
            MessageBox.Show("Please enter a valid numeric ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim customerRow = customerBLL.GetCustomers().Select($"ID = {id}").FirstOrDefault()
        If customerRow Is Nothing Then
            MessageBox.Show("No customer found with the provided ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim customerName As String = customerRow("Name").ToString()

        Dim result = MessageBox.Show($"Are you sure you want to delete the customer '{customerName}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then
            Return
        End If

        customerBLL.DeleteCustomer(id)
        MessageBox.Show($"Customer '{customerName}' deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        LoadCustomers()
        ResetForm()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadCustomers()
            Return
        End If

        Dim name As String = txtSearch.Text
        Dim result As DataTable = customerBLL.SearchCustomersByName(name)

        If result.Rows.Count = 0 Then
            MessageBox.Show("No customers found with the provided name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadCustomers()
            Return
        End If

        DataGridView1.DataSource = result
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadCustomers()
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub ResetForm()
        txtID.Clear()
        txtName.Clear()
        txtPhone.Clear()
        txtEmail.Clear()
        txtSearch.Clear()
    End Sub
End Class
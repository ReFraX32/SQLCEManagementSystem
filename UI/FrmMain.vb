Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadForm(New FrmCustomers())
    End Sub

    Private Sub BtnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        LoadForm(New FrmCustomers())
    End Sub

    Private Sub BtnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        LoadForm(New FrmProducts())
    End Sub

    Private Sub BtnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        LoadForm(New FrmSales())
    End Sub

    Private Sub BtnSalesReport_Click(sender As Object, e As EventArgs) Handles btnSalesReport.Click
        LoadForm(New FrmSalesReport())
    End Sub

    Private Sub BtnProductReport_Click(sender As Object, e As EventArgs) Handles btnProductReport.Click
        LoadForm(New FrmProductReport())
    End Sub

    Private Sub BtnSearchSales_Click(sender As Object, e As EventArgs) Handles btnSearchSales.Click
        LoadForm(New FrmSearchSales())
    End Sub

    Private Sub LoadForm(form As Form)
        pnlContent.Controls.Clear()
        form.TopLevel = False
        form.FormBorderStyle = FormBorderStyle.None
        form.Dock = DockStyle.Fill
        pnlContent.Controls.Add(form)
        form.Show()
    End Sub
End Class
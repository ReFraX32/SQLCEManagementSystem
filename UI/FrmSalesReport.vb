Imports BLL

Public Class FrmSalesReport
    Private ReadOnly saleBLL As New SaleBLL()

    Private Sub FrmSalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesReport()
    End Sub

    Private Sub LoadSalesReport()
        Try
            Dim salesReportTable As DataTable = saleBLL.GetSalesReport()

            If salesReportTable IsNot Nothing AndAlso salesReportTable.Rows.Count > 0 Then
                dgvSalesReport.DataSource = salesReportTable
                FormatDataGridView()
            Else
                MessageBox.Show("No data available for the sales report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading sales report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView()
        With dgvSalesReport
            .AutoGenerateColumns = True
            For Each col As DataGridViewColumn In .Columns
                Select Case col.Name
                    Case "SaleID"
                        col.HeaderText = "Sale ID"
                        col.Width = 70
                    Case "CustomerName"
                        col.HeaderText = "Customer Name"
                        col.Width = 150
                    Case "SaleDate"
                        col.HeaderText = "Sale Date"
                        col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
                        col.Width = 120
                    Case "ProductName"
                        col.HeaderText = "Product Name"
                        col.Width = 150
                    Case "Quantity"
                        col.HeaderText = "Quantity"
                        col.DefaultCellStyle.Format = "N0"
                        col.Width = 80
                    Case "UnitPrice"
                        col.HeaderText = "Unit Price"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                    Case "Subtotal"
                        col.HeaderText = "Subtotal"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                    Case "SaleTotal"
                        col.HeaderText = "Total"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                End Select
            Next
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub
End Class
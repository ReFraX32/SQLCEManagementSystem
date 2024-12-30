Imports BLL

Public Class FrmProductReport
    Private ReadOnly productBLL As New ProductBLL()
    Private Sub FrmProductReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProductReport()
    End Sub

    Private Sub LoadProductReport()
        Try
            Dim productReportTable As DataTable = productBLL.GetProductReport()

            If productReportTable IsNot Nothing AndAlso productReportTable.Rows.Count > 0 Then
                dgvProductReport.DataSource = productReportTable
                FormatDataGridView()
            Else
                MessageBox.Show("No data available for the product report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading product report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView()
        With dgvProductReport
            .AutoGenerateColumns = True
            For Each col As DataGridViewColumn In .Columns
                Select Case col.Name
                    Case "ProductName"
                        col.HeaderText = "Product Name"
                        col.Width = 150
                    Case "Month"
                        col.HeaderText = "Month"
                        col.Width = 100
                    Case "QuantitySold"
                        col.HeaderText = "Quantity Sold"
                        col.DefaultCellStyle.Format = "N0"
                        col.Width = 100
                    Case "TotalRevenue"
                        col.HeaderText = "Total Revenue"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 120
                End Select
            Next
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub
End Class
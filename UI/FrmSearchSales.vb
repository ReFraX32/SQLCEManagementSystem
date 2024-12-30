Imports BLL

Public Class FrmSearchSales
    Private ReadOnly saleBLL As New SaleBLL()

    Public Sub New()
        InitializeComponent()
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub FrmSearchSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpStartDate.Enabled = False
        dtpEndDate.Enabled = False
        LoadAllSales()
    End Sub

    Private Sub LoadAllSales()
        Try
            Dim salesTable As DataTable = saleBLL.SearchSales("", Nothing, Nothing, Nothing)
            If salesTable IsNot Nothing Then
                dgvSales.DataSource = salesTable
                FormatDataGridView()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading sales data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatDataGridView()
        With dgvSales
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
                    Case "Total"
                        col.HeaderText = "Total"
                        col.DefaultCellStyle.Format = "C2"
                        col.Width = 100
                End Select
            Next
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Dim customerName As String = txtCustomerName.Text.Trim()
            Dim saleID As Integer? = If(String.IsNullOrEmpty(txtSaleID.Text),
                                      CType(Nothing, Integer?),
                                      Convert.ToInt32(txtSaleID.Text))
            Dim startDate As DateTime? = If(chkUseDateRange.Checked,
                                          dtpStartDate.Value.Date,
                                          CType(Nothing, DateTime?))
            Dim endDate As DateTime? = If(chkUseDateRange.Checked,
                                        dtpEndDate.Value.Date.AddDays(1).AddTicks(-1),
                                        CType(Nothing, DateTime?))

            If String.IsNullOrEmpty(customerName) AndAlso
               Not saleID.HasValue AndAlso
               Not chkUseDateRange.Checked Then
                LoadAllSales()
                Return
            End If

            Dim salesTable As DataTable = saleBLL.SearchSales(customerName, saleID, startDate, endDate)
            dgvSales.DataSource = salesTable
            FormatDataGridView()
        Catch ex As Exception
            MessageBox.Show("Error searching sales: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtCustomerName.Clear()
        txtSaleID.Clear()
        chkUseDateRange.Checked = False
        dgvSales.DataSource = Nothing
        LoadAllSales()
    End Sub

    Private Sub ChkUseDateRange_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDateRange.CheckedChanged
        dtpStartDate.Enabled = chkUseDateRange.Checked
        dtpEndDate.Enabled = chkUseDateRange.Checked
    End Sub
End Class
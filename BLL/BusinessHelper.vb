Imports DAL

Public Class Customer
    Public Property ID As Integer
    Public Property Name As String
    Public Property Phone As String
    Public Property Email As String
End Class

Public Class Sale
    Public Property ID As Integer
    Public Property CustomerID As Integer
    Public Property SaleDate As DateTime
    Public Property Total As Decimal
End Class

Public Class SaleItem
    Public Property ID As Integer
    Public Property SaleID As Integer
    Public Property ProductID As Integer
    Public Property UnitPrice As Decimal
    Public Property Quantity As Decimal
    Public Property TotalPrice As Decimal
End Class

Public Class Product
    Public Property ID As Integer
    Public Property Name As String
    Public Property Price As Decimal
    Public Property Category As String
End Class

Public Class CustomerBLL
    Private ReadOnly customerDAL As New CustomerDAL()

    Public Function GetCustomers() As DataTable
        Return customerDAL.GetAllCustomers()
    End Function

    Public Sub AddCustomer(name As String, phone As String, email As String)
        customerDAL.InsertCustomer(name, phone, email)
    End Sub

    Public Sub UpdateCustomer(id As Integer, name As String, phone As String, email As String)
        customerDAL.UpdateCustomer(id, name, phone, email)
    End Sub

    Public Sub DeleteCustomer(id As Integer)
        customerDAL.DeleteCustomer(id)
    End Sub

    Public Function SearchCustomersByName(name As String) As DataTable
        Return customerDAL.SearchCustomersByName(name)
    End Function
End Class

Public Class SaleBLL
    Private ReadOnly saleDAL As New SaleDAL()

    Public Function GetSales() As DataTable
        Return saleDAL.GetAllSales()
    End Function

    Public Function AddSale(customerID As Integer, saleDate As DateTime, items As List(Of SaleItem)) As Integer
        If items Is Nothing OrElse items.Count = 0 Then
            Return -1
        End If

        Try
            Dim total As Decimal = items.Sum(Function(i) i.TotalPrice)
            Dim saleID As Integer = saleDAL.InsertSale(customerID, saleDate, total)

            If saleID <= 0 Then
                Return -1
            End If

            For Each item In items
                item.SaleID = saleID
                saleDAL.InsertSaleItem(saleID, item.ProductID, item.Quantity, item.UnitPrice, item.TotalPrice)
            Next

            Return saleID

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error in AddSale: " & ex.Message)
            Return -1
        End Try
    End Function

    Public Function SearchSales(customerName As String, saleID As Integer?, startDate As DateTime?, endDate As DateTime?) As DataTable
        Return saleDAL.SearchSales(customerName, saleID, startDate, endDate)
    End Function

    Public Function GetSalesReport() As DataTable
        Return saleDAL.GetSalesReport()
    End Function
End Class

Public Class SaleItemBLL
    Private ReadOnly saleItemDAL As New SaleItemDAL()

    Public Function GetSaleItems() As DataTable
        Return saleItemDAL.GetAllSalesItems()
    End Function
End Class

Public Class ProductBLL
    Private ReadOnly productDAL As New ProductDAL()

    Public Function GetProducts() As DataTable
        Return productDAL.GetAllProducts()
    End Function

    Public Sub AddProduct(name As String, price As Decimal, category As String)
        productDAL.InsertProduct(name, price, category)
    End Sub

    Public Sub UpdateProduct(id As Integer, name As String, price As Decimal, category As String)
        productDAL.UpdateProduct(id, name, price, category)
    End Sub

    Public Sub DeleteProduct(id As Integer)
        productDAL.DeleteProduct(id)
    End Sub

    Public Function GetProductReport() As DataTable
        Return productDAL.GetProductReport()
    End Function

    Public Function SearchProductsByName(name As String) As DataTable
        Return productDAL.SearchProductsByName(name)
    End Function
End Class
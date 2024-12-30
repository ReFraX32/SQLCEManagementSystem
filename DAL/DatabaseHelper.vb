Imports System.Data.SqlServerCe
Imports System.Configuration

Public Module DatabaseHelper
    Public Function GetConnection() As SqlCeConnection
        Return New SqlCeConnection(ConfigurationManager.ConnectionStrings("DatabaseConnection").ConnectionString)
    End Function
End Module

Public Class CustomerDAL
    Public Function GetAllCustomers() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Customers"
            Using cmd As New SqlCeCommand(query, connection)
                Dim adapter As New SqlCeDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub InsertCustomer(name As String, phone As String, email As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO Customers (Name, Phone, Email) VALUES (@Name, @Phone, @Email)"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub UpdateCustomer(id As Integer, name As String, phone As String, email As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "UPDATE Customers SET Name = @Name, Phone = @Phone, Email = @Email WHERE ID = @ID"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteCustomer(id As Integer)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "DELETE FROM Customers WHERE ID = @ID"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchCustomersByName(name As String) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Customers WHERE Name LIKE @Name"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "%" & name & "%"
                Dim adapter As New SqlCeDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function
End Class

Public Class ProductDAL
    Public Function GetAllProducts() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Products"
            Using cmd As New SqlCeCommand(query, connection)
                Dim adapter As New SqlCeDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub InsertProduct(name As String, price As Decimal, category As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO Products (Name, Price, Category) VALUES (@Name, @Price, @Category)"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchProductsByName(name As String) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Products WHERE Name LIKE @Name"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = "%" & name & "%"
                Dim adapter As New SqlCeDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                Return table
            End Using
        End Using
    End Function

    Public Sub UpdateProduct(id As Integer, name As String, price As Decimal, category As String)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "UPDATE Products SET Name = @Name, Price = @Price, Category = @Category WHERE ID = @ID"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = category
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub DeleteProduct(id As Integer)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "DELETE FROM Products WHERE ID = @ID"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function GetProductReport() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "
            SELECT p.Name AS ProductName, 
                   SUBSTRING(CONVERT(NVARCHAR, s.Date, 120), 1, 7) AS Month,
                   SUM(CONVERT(decimal(10,2), si.Quantity)) AS QuantitySold,
                   SUM(CONVERT(decimal(10,2), si.TotalPrice)) AS TotalRevenue
            FROM Products p
            LEFT JOIN SalesItems si ON p.ID = si.ProductID
            LEFT JOIN Sales s ON si.SaleID = s.ID
            GROUP BY p.Name, SUBSTRING(CONVERT(NVARCHAR, s.Date, 120), 1, 7)
            ORDER BY p.Name, Month"

            Try
                Using cmd As New SqlCeCommand(query, connection)
                    Dim adapter As New SqlCeDataAdapter(cmd)
                    Dim productReportTable As New DataTable()
                    adapter.Fill(productReportTable)
                    Return productReportTable
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Error in GetProductReport: " & ex.Message)
                Throw
            End Try
        End Using
    End Function
End Class

Public Class SaleDAL
    Public Function GetAllSales() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM Sales"
            Dim cmd As New SqlCeCommand(query, connection)
            Dim adapter As New SqlCeDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function

    Public Function InsertSale(customerID As Integer, saleDate As DateTime, total As Decimal) As Integer
        Dim saleID As Integer = 0
        Dim query As String = "INSERT INTO Sales (CustomerID, [Date], Total) VALUES (@CustomerID, @Date, @Total)"
        Dim queryGetID As String = "SELECT @@IDENTITY"

        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Using transaction = connection.BeginTransaction()
                Using command As New SqlCeCommand(query, connection, transaction)
                    command.Parameters.AddWithValue("@CustomerID", customerID)
                    command.Parameters.AddWithValue("@Date", saleDate)
                    command.Parameters.AddWithValue("@Total", total)
                    command.ExecuteNonQuery()
                End Using

                Using commandGetID As New SqlCeCommand(queryGetID, connection, transaction)
                    saleID = Convert.ToInt32(commandGetID.ExecuteScalar())
                End Using

                transaction.Commit()
            End Using
        End Using

        Return saleID
    End Function

    Public Sub InsertSaleItem(saleID As Integer, productID As Integer, quantity As Integer, unitPrice As Decimal, totalPrice As Decimal)
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "INSERT INTO SalesItems (SaleID, ProductID, Quantity, UnitPrice, TotalPrice) VALUES (@SaleID, @ProductID, @Quantity, @UnitPrice, @TotalPrice)"
            Using cmd As New SqlCeCommand(query, connection)
                cmd.Parameters.AddWithValue("@SaleID", saleID)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.Parameters.AddWithValue("@Quantity", quantity)
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice)
                cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function SearchSales(customerName As String, saleID As Integer?, startDate As DateTime?, endDate As DateTime?) As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT s.ID, s.Date, s.Total, c.Name AS CustomerName FROM Sales s JOIN Customers c ON s.CustomerID = c.ID WHERE 1=1"

            If Not String.IsNullOrEmpty(customerName) Then query &= " AND c.Name LIKE @CustomerName"
            If saleID.HasValue Then query &= " AND s.ID = @SaleID"
            If startDate.HasValue AndAlso endDate.HasValue Then query &= " AND s.Date BETWEEN @StartDate AND @EndDate"

            Dim cmd As New SqlCeCommand(query, connection)
            If Not String.IsNullOrEmpty(customerName) Then cmd.Parameters.AddWithValue("@CustomerName", "%" & customerName & "%")
            If saleID.HasValue Then cmd.Parameters.AddWithValue("@SaleID", saleID.Value)
            If startDate.HasValue AndAlso endDate.HasValue Then
                cmd.Parameters.AddWithValue("@StartDate", startDate.Value)
                cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
            End If

            Dim adapter As New SqlCeDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function

    Public Function GetSalesReport() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()

            Dim query As String = "
            SELECT 
                s.ID AS SaleID, 
                c.Name AS CustomerName, 
                s.Date AS SaleDate,
                p.Name AS ProductName,
                CONVERT(decimal(10,2), si.Quantity) AS Quantity,
                CONVERT(decimal(10,2), si.UnitPrice) AS UnitPrice,
                CONVERT(decimal(10,2), si.TotalPrice) AS Subtotal,
                CONVERT(decimal(10,2), s.Total) AS SaleTotal
            FROM Sales s
            INNER JOIN Customers c ON s.CustomerID = c.ID
            INNER JOIN SalesItems si ON s.ID = si.SaleID
            INNER JOIN Products p ON si.ProductID = p.ID
            ORDER BY s.Date DESC, s.ID"

            Try
                Using cmd As New SqlCeCommand(query, connection)
                    Dim adapter As New SqlCeDataAdapter(cmd)
                    Dim salesReportTable As New DataTable()
                    adapter.Fill(salesReportTable)
                    Return salesReportTable
                End Using
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Error in GetSalesReport: " & ex.Message)
                Throw
            End Try
        End Using
    End Function
End Class

Public Class SaleItemDAL
    Public Function GetAllSalesItems() As DataTable
        Using connection = DatabaseHelper.GetConnection()
            connection.Open()
            Dim query As String = "SELECT * FROM SalesItems"
            Dim cmd As New SqlCeCommand(query, connection)
            Dim adapter As New SqlCeDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            Return table
        End Using
    End Function
End Class
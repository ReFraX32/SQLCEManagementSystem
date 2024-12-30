<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCustomers = New System.Windows.Forms.Button()
        Me.btnSearchSales = New System.Windows.Forms.Button()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.btnSalesReport = New System.Windows.Forms.Button()
        Me.btnSales = New System.Windows.Forms.Button()
        Me.btnProductReport = New System.Windows.Forms.Button()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlSidebar.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.PictureBox7)
        Me.pnlSidebar.Controls.Add(Me.Label6)
        Me.pnlSidebar.Controls.Add(Me.Panel1)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(200, 450)
        Me.pnlSidebar.TabIndex = 0
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.UI.My.Resources.Resources.Main_Screen
        Me.PictureBox7.Location = New System.Drawing.Point(29, 6)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(135, 90)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 0
        Me.PictureBox7.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Snow
        Me.Label6.Location = New System.Drawing.Point(54, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Service Selector"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox6)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnCustomers)
        Me.Panel1.Controls.Add(Me.btnSearchSales)
        Me.Panel1.Controls.Add(Me.btnProducts)
        Me.Panel1.Controls.Add(Me.btnSalesReport)
        Me.Panel1.Controls.Add(Me.btnSales)
        Me.Panel1.Controls.Add(Me.btnProductReport)
        Me.Panel1.Location = New System.Drawing.Point(3, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 305)
        Me.Panel1.TabIndex = 7
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.UI.My.Resources.Resources.Search_Sales
        Me.PictureBox6.Location = New System.Drawing.Point(14, 262)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(45, 35)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 10
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.UI.My.Resources.Resources.Product_Report
        Me.PictureBox5.Location = New System.Drawing.Point(10, 201)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(49, 34)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.UI.My.Resources.Resources.Sales_Report
        Me.PictureBox4.Location = New System.Drawing.Point(10, 152)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(49, 34)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 8
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.UI.My.Resources.Resources.Sales_Manager
        Me.PictureBox3.Location = New System.Drawing.Point(13, 102)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(39, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.UI.My.Resources.Resources.Product_Manager
        Me.PictureBox2.Location = New System.Drawing.Point(9, 51)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.UI.My.Resources.Resources.Customer_Manager
        Me.PictureBox1.Location = New System.Drawing.Point(11, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnCustomers
        '
        Me.btnCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCustomers.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnCustomers.Location = New System.Drawing.Point(0, 0)
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnCustomers.Size = New System.Drawing.Size(194, 45)
        Me.btnCustomers.TabIndex = 0
        Me.btnCustomers.Text = "Customer Manager"
        Me.btnCustomers.UseVisualStyleBackColor = True
        '
        'btnSearchSales
        '
        Me.btnSearchSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSales.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnSearchSales.Location = New System.Drawing.Point(0, 252)
        Me.btnSearchSales.Name = "btnSearchSales"
        Me.btnSearchSales.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnSearchSales.Size = New System.Drawing.Size(194, 53)
        Me.btnSearchSales.TabIndex = 5
        Me.btnSearchSales.Text = "Search Sales"
        Me.btnSearchSales.UseVisualStyleBackColor = True
        '
        'btnProducts
        '
        Me.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProducts.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnProducts.Location = New System.Drawing.Point(-3, 41)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnProducts.Size = New System.Drawing.Size(196, 54)
        Me.btnProducts.TabIndex = 1
        Me.btnProducts.Text = "Product Manager"
        Me.btnProducts.UseVisualStyleBackColor = True
        '
        'btnSalesReport
        '
        Me.btnSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesReport.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnSalesReport.Location = New System.Drawing.Point(-1, 143)
        Me.btnSalesReport.Name = "btnSalesReport"
        Me.btnSalesReport.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnSalesReport.Size = New System.Drawing.Size(194, 52)
        Me.btnSalesReport.TabIndex = 3
        Me.btnSalesReport.Text = "Sales Report"
        Me.btnSalesReport.UseVisualStyleBackColor = True
        '
        'btnSales
        '
        Me.btnSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSales.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnSales.Location = New System.Drawing.Point(-1, 92)
        Me.btnSales.Name = "btnSales"
        Me.btnSales.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnSales.Size = New System.Drawing.Size(194, 54)
        Me.btnSales.TabIndex = 2
        Me.btnSales.Text = "Sales Manager"
        Me.btnSales.UseVisualStyleBackColor = True
        '
        'btnProductReport
        '
        Me.btnProductReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductReport.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.btnProductReport.Location = New System.Drawing.Point(-1, 194)
        Me.btnProductReport.Name = "btnProductReport"
        Me.btnProductReport.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
        Me.btnProductReport.Size = New System.Drawing.Size(194, 52)
        Me.btnProductReport.TabIndex = 4
        Me.btnProductReport.Text = "Product Report"
        Me.btnProductReport.UseVisualStyleBackColor = True
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(39, Byte), Integer))
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(200, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(600, 450)
        Me.pnlContent.TabIndex = 1
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSidebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "Business and Database Manager"
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents btnSearchSales As Button
    Friend WithEvents btnProductReport As Button
    Friend WithEvents btnSalesReport As Button
    Friend WithEvents btnSales As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnCustomers As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
End Class

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OMS.Data.Model
{
    public partial class NorthwindSQLiteContext : DbContext
    {
        public NorthwindSQLiteContext()
        {
        }

        public NorthwindSQLiteContext(DbContextOptions<NorthwindSQLiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=D:\\NorthwindSQLite.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "Categories_CategoryName");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnType("nvarchar(15)");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Picture).HasColumnType("image");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.City, "Customers_City");

                entity.HasIndex(e => e.CompanyName, "Customers_CompanyName");

                entity.HasIndex(e => e.PostalCode, "Customers_PostalCode");

                entity.HasIndex(e => e.Region, "Customers_Region");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("nchar(5)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                entity.Property(e => e.ContactName).HasColumnType("nvarchar(30)");

                entity.Property(e => e.ContactTitle).HasColumnType("nvarchar(30)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Fax).HasColumnType("nvarchar(24)");

                entity.Property(e => e.Phone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");
            });

           

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.LastName, "Employees_LastName");

                entity.HasIndex(e => e.PostalCode, "Employees_PostalCode");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasColumnType("nvarchar(60)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Country).HasColumnType("nvarchar(15)");

                entity.Property(e => e.Extension).HasColumnType("nvarchar(4)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar(10)");

                entity.Property(e => e.HireDate).HasColumnType("datetime");

                entity.Property(e => e.HomePhone).HasColumnType("nvarchar(24)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar(20)");

                entity.Property(e => e.Notes).HasColumnType("ntext");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PhotoPath).HasColumnType("nvarchar(255)");

                entity.Property(e => e.PostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.Region).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ReportsTo).HasColumnType("int");

                entity.Property(e => e.Title).HasColumnType("nvarchar(30)");

                entity.Property(e => e.TitleOfCourtesy).HasColumnType("nvarchar(25)");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo);
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "Orders_CustomerID");

                entity.HasIndex(e => e.CustomerId, "Orders_CustomersOrders");

                entity.HasIndex(e => e.EmployeeId, "Orders_EmployeeID");

                entity.HasIndex(e => e.EmployeeId, "Orders_EmployeesOrders");

                entity.HasIndex(e => e.OrderDate, "Orders_OrderDate");

                entity.HasIndex(e => e.ShipPostalCode, "Orders_ShipPostalCode");

                entity.HasIndex(e => e.ShippedDate, "Orders_ShippedDate");

                entity.HasIndex(e => e.ShipVia, "Orders_ShippersOrders");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("nchar(5)")
                    .HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("int")
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShipAddress).HasColumnType("nvarchar(60)");

                entity.Property(e => e.ShipCity).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShipCountry).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShipName).HasColumnType("nvarchar(40)");

                entity.Property(e => e.ShipPostalCode).HasColumnType("nvarchar(10)");

                entity.Property(e => e.ShipRegion).HasColumnType("nvarchar(15)");

                entity.Property(e => e.ShipVia).HasColumnType("int");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId);

               
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasIndex(e => e.OrderId, "Order Details_OrderID");

                entity.HasIndex(e => e.OrderId, "Order Details_OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId, "Order Details_ProductID");

                entity.HasIndex(e => e.ProductId, "Order Details_ProductsOrder_Details");

                entity.Property(e => e.OrderId)
                    .HasColumnType("int")
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("int")
                    .HasColumnName("ProductID");

                entity.Property(e => e.Discount).HasColumnType("real");

                entity.Property(e => e.Quantity)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "Products_CategoriesProducts");

                entity.HasIndex(e => e.CategoryId, "Products_CategoryID");

                entity.HasIndex(e => e.ProductName, "Products_ProductName");

                entity.HasIndex(e => e.SupplierId, "Products_SupplierID");

                entity.HasIndex(e => e.SupplierId, "Products_SuppliersProducts");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("int")
                    .HasColumnName("CategoryID");

                entity.Property(e => e.Discontinued)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnType("nvarchar(40)");

                entity.Property(e => e.QuantityPerUnit).HasColumnType("nvarchar(20)");

                entity.Property(e => e.ReorderLevel)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SupplierId)
                    .HasColumnType("int")
                    .HasColumnName("SupplierID");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

               
            });

          

           

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

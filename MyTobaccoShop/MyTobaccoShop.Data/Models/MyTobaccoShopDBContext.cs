// <copyright file="MyTobaccoShopDBContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Data.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// MyTobaccoShopDBContext Class.
    /// </summary>
    public class MyTobaccoShopDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyTobaccoShopDBContext"/> class.
        /// PoliceAppDbContext constructor.
        /// </summary>
        public MyTobaccoShopDBContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or Sets Products Property.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or Sets Users Property.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or Sets Customers Property.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or Sets Orders Property.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or Sets Categories Property.
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// OnConfiguring method, connects to the database using the connection string.
        /// </summary>
        /// <param name="optionsBuilder">optionsBuilder parameter.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder?.IsConfigured == false)
            {
                string str = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=""T:\semester 8\prog 4\MyTobaccoShop\MyTobaccoShop\MyTobaccoShop.Data\MyTobaccoShopDB.mdf""; Integrated Security = True; MultipleActiveResultSets=true;";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(str);
            }
        }

        /// <summary>
        /// OnModelCreating method, Create a model.
        /// </summary>
        /// <param name="modelBuilder">model to build.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category cigarette = new Category
            {
                CategoryID = 1,
                CategoryTitle = "cigarettes",
                CategoryDescription = "This category contains only the following page.C (Cigarette)",
            };
            Product product1 = new Product()
            {
                ProductID = 1,
                ProductName = "Davidoff White 200s",
                ProductPrice = 1000,
                CategoryId = cigarette.CategoryID,
            };
            Customer bill = new Customer()
            {
                CustomerID = 1,
                CustomerAddress = "Budapes",
                CustomerContact = "702905761",
                CustomerEmail = "bil@gmail.com",
                CustomerName = "Bill",
            };

            User user = new User()
            {
                UserID = 1,
                UserEmail = "Abdulrahman@gmail.com",
                UserFullName = "Abdularhman Abdulqawi",
                UserPassword = "7700",
                UserType = "Admin",
                UserUsername = "abdul2021",
            };

            Order order1 = new Order()
            {
                OrderID = 1,
                OrderQuantity = 10,
                CustomerId = bill.CustomerID,
                ProductId = product1.ProductID,
            };

            if (modelBuilder != null)
            {
                modelBuilder.Entity<User>().HasData(user);
                modelBuilder.Entity<Customer>().HasData(bill);
                modelBuilder.Entity<Category>().HasData(cigarette);
                modelBuilder.Entity<Product>().HasData(product1);
                modelBuilder.Entity<Order>().HasData(order1);
            }
        }
    }
}

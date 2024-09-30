// <copyright file="MyTobaccoShopDBContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Data.Models
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.IO;

    /// <summary>
    /// MyTobaccoShopDBContext Class.
    /// </summary>
    public class MyTobaccoShopDBContext : DbContext
    {
        private static string _databaseName = "MyTobaccoShopDB";
        private static string _databasePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTobaccoShopDBContext"/> class.
        /// MyTobaccoShopDBContext constructor.
        /// </summary>
        public MyTobaccoShopDBContext()
        {
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{_databaseName}.mdf");
            EnsureDatabaseCreated();
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
                string connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_databasePath};Integrated Security=True;MultipleActiveResultSets=true;";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
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

        /// <summary>
        /// Ensures that the database is created.
        /// </summary>
        private void EnsureDatabaseCreated()
        {
            if (!File.Exists(_databasePath))
            {
                CreateDatabase();
            }

            // Ensure the database schema is created
            Database.EnsureCreated();
        }

        /// <summary>
        /// Creates the database file.
        /// </summary>
        private void CreateDatabase()
        {
            string masterConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";

            using (var connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $@"
                        CREATE DATABASE [{_databaseName}]
                        ON PRIMARY (
                            NAME = [{_databaseName}_Data],
                            FILENAME = '{_databasePath}'
                        )
                        LOG ON (
                            NAME = [{_databaseName}_Log],
                            FILENAME = '{Path.ChangeExtension(_databasePath, ".ldf")}'
                        )";

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
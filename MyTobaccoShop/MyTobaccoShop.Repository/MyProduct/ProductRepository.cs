// <copyright file="ProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyProduct
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Product Repository Implementaion Class.
    /// </summary>
    public class ProductRepository : MyRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public ProductRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get Product By Id Method Implementaion.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>Order.</returns>
        public override Product GetById(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.ProductID == id);
        }

        /// <summary>
        /// Update Product Price Method Implementaion.
        /// </summary>
        /// <param name="id">Product ID.</param>
        /// <param name="price">Product New Price.</param>
        public void UpdatePrice(int id, decimal price)
        {
            var product = this.GetById(id);
            product.ProductPrice = price;
            this.Context.SaveChanges();
        }
    }
}

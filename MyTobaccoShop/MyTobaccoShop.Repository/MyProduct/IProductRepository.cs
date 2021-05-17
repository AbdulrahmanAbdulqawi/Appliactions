// <copyright file="IProductRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyProduct
{
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Product interface inherit from Repository interface.
    /// </summary>
    public interface IProductRepository : IRepository<Product>
    {
        /// <summary>
        /// Update Product Price Method.
        /// </summary>
        /// <param name="id">product id.</param>
        /// <param name="price">product new price.</param>
        void UpdatePrice(int id, decimal price);
    }
}

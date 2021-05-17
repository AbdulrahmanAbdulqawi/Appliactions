// <copyright file="IOrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyOrder
{
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// order interfac inherit from repository interface.
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// Update Order Quantity Method.
        /// </summary>
        /// <param name="id">Order Id.</param>
        /// <param name="newQuantity"> new quantity.</param>
        void UpdateOrderQuantity(int id, int newQuantity);
    }
}

// <copyright file="OrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyOrder
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Order Repository Implementaion Class.
    /// </summary>
    public class OrderRepository : MyRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public OrderRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get Order By Id.
        /// </summary>
        /// <param name="id">Order id.</param>
        /// <returns>Order.</returns>
        public override Order GetById(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.OrderID == id);
        }

        /// <summary>
        /// Update Order Quantity Method Implementaion.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <param name="newQuantity">new quantity.</param>
        public void UpdateOrderQuantity(int id, int newQuantity)
        {
            var order = this.GetById(id);
            order.OrderQuantity = newQuantity;
            this.Context.SaveChanges();
        }
    }
}

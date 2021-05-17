// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyCustomer
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Customer class to implement the repository class.
    /// </summary>
    public class CustomerRepository : MyRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public CustomerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get customer By Id.
        /// </summary>
        /// <param name="id">customer id.</param>
        /// <returns>customer.</returns>
        public override Customer GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CustomerID == id);
        }

        /// <summary>
        /// Update Customer Email Method Implementation.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="newEmail"> new Customer Email.</param>
        public void UpdateEmail(int id, string newEmail)
        {
            var customer = this.GetById(id);
            customer.CustomerEmail = newEmail;
            this.Context.SaveChanges();
        }
    }
}

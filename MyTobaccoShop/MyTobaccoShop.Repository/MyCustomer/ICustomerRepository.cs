// <copyright file="ICustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyCustomer
{
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Customer interface inherit from repostiory interface.
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Update Customer Email.
        /// </summary>
        /// <param name="id">Customer ID.</param>
        /// <param name="newEmail">new Customer Email.</param>
        void UpdateEmail(int id, string newEmail);
    }
}

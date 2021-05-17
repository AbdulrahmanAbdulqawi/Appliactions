// <copyright file="Customer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Data.Models
{
    /// <summary>
    /// Customer Class.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or Sets Customer ID Property.
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or Sets Customer Name Property.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or Sets Customer Email Property.
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or Sets Customer Contact Property.
        /// </summary>
        public string CustomerContact { get; set; }

        /// <summary>
        /// Gets or Sets Customer Address Property.
        /// </summary>
        public string CustomerAddress { get; set; }
    }
}

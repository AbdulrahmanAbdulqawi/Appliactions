// <copyright file="Order.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Order Class.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or Sets Order ID Property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or Sets Order Quantity Property.
        /// </summary>
        public int OrderQuantity { get; set; }

        /// <summary>
        /// Gets or Sets Customer ID Property.
        /// </summary>
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets Product ID Property.
        /// </summary>
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets Customer Object Property.
        /// </summary>
        [NotMapped]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or Sets Product Object Property.
        /// </summary>
        [NotMapped]
        public virtual Product Product { get; set; }
    }
}

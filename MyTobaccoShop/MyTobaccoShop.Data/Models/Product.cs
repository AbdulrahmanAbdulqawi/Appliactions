// <copyright file="Product.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Product Class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or Sets Product ID Property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or Sets Product Name Property.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets Product Price Property.
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or Sets Category ID Property.
        /// </summary>
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or Sets Category Object Property.
        /// </summary>
        [NotMapped]
        public virtual Category Category { get; set; }
    }
}
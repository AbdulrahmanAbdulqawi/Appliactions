// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// User Class.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or Sets User ID Property.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or Sets User Full Name Property.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string UserFullName { get; set; }

        /// <summary>
        /// Gets or Sets User Email Property.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or Sets User Username Property.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string UserUsername { get; set; }

        /// <summary>
        /// Gets or Sets User Password Property.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or Sets User Type Property.
        /// </summary>
        [MaxLength(10)]
        [Required]
        public string UserType { get; set; }
    }
}

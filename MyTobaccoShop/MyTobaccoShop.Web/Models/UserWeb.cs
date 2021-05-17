// <copyright file="UserWeb.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// User Model class Web App.
    /// </summary>
    public class UserWeb
    {
        /// <summary>
        /// Gets or Sets User ID Property.
        /// </summary>
        [Display(Name = "ID")]
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// Gets or Sets User Full Name Property.
        /// </summary>
        [Display(Name = "Full Name")]
        [Required]
        public string UserFullName { get; set; }

        /// <summary>
        /// Gets or Sets User Email Property.
        /// </summary>
        [Display(Name = "Email")]
        [Required]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or Sets User Username Property.
        /// </summary>
        [Display(Name = "Username")]
        [Required]
        public string UserUsername { get; set; }

        /// <summary>
        /// Gets or Sets User Password Property.
        /// </summary>
        [Display(Name = "Password")]
        [Required]

        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or Sets User Type Property.
        /// </summary>
        [Display(Name = "Type")]
        [Required]
        public string UserType { get; set; }
    }
}

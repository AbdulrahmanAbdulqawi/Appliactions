// <copyright file="UserListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// User View Model.
    /// </summary>
    public class UserListViewModel
    {
        /// <summary>
        /// Gets or Sets EditedUser.
        /// </summary>
        public UserWeb EditedUser { get; set; }

        /// <summary>
        /// Gets or Sets ListOfUsers.
        /// </summary>
        public List<UserWeb> ListOfUsers { get; set; }
    }
}

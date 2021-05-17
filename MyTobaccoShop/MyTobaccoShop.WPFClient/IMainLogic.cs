// <copyright file="IMainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPFClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Defenition of functionalities that MainLogic must implement.
    /// </summary>
    public interface IMainLogic
    {
        /// <summary>
        /// Get all Users.
        /// </summary>
        /// <returns>Any List of type UserVM.</returns>
        public IList<UserVM> ApiGetUsers();

        /// <summary>
        /// Delete A user.
        /// </summary>
        /// <param name="user">user.</param>
        public void ApiDelUser(UserVM user);

        /// <summary>
        /// Edit User.
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="editorFunc">Editor Function.</param>
        public void EditUser(UserVM user, Func<UserVM, bool> editorFunc);
    }
}

// <copyright file="IUserLogicWPF.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPF.BL
{
    using System.Collections.Generic;
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// User Logic Interface.
    /// </summary>
    public interface IUserLogicWPF
    {
        /// <summary>
        /// Get All Users.
        /// </summary>
        /// <param name="users">Collection of Users.</param>
        void GetUsers(IList<UserModel> users);

        /// <summary>
        /// Add New User.
        /// </summary>
        /// <param name="users">Collection of Users.</param>
        void AddUser(IList<UserModel> users);

        /// <summary>
        /// Update User's Info.
        /// </summary>
        /// <param name="user">user obj.</param>
        void UpdateUser(UserModel user);

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="users">Collection Of Users.</param>
        /// <param name="user">uesr obj.</param>
        void DeleteUser(IList<UserModel> users, UserModel user);
    }
}

// <copyright file="IUserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Logic
{
    using System.Collections.Generic;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// User Logic Interface.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Add User Method.
        /// </summary>
        /// <param name="user">User Obj.</param>
        void AddUser(User user);

        /// <summary>
        /// Add a new user based on paramaters.
        /// </summary>
        /// <param name="fullName">Name.</param>
        /// <param name="email">Email.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="type">Type.</param>
        void AddUser(string fullName, string email, string username, string password, string type);

        /// <summary>
        /// Change User.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="fullName">Name.</param>
        /// <param name="email">Email.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="type">Type.</param>
        /// <returns>boolean value.</returns>
        public bool ChangeUser(int id, string fullName, string email, string username, string password, string type);

        /// <summary>
        /// Update User Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="user">New User Obj.</param>
        void UpdateUser(int id, User user);

        /// <summary>
        /// Delete User By ID Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>boolean value.</returns>
        bool DeleteUser(int id);

        /// <summary>
        /// Get One User By ID Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>User.</returns>
        User GetUser(int id);

        /// <summary>
        /// Get ALL Users.
        /// </summary>
        /// <returns>Collection Of Users.</returns>
        IList<User> GetUsers();

        /// <summary>
        /// Update User Type.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="newType">User new Type.</param>
        void UpdateUserType(int id, string newType);
    }
}

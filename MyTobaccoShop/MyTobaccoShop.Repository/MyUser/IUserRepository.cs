// <copyright file="IUserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyUser
{
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// User Interface inherit from repository interface.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Update User Type Method.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <param name="type">User Type.</param>
        void UpdateUserType(int id, string type);

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
        bool ChangeUser(int id, string fullName, string email, string username, string password, string type);
    }
}

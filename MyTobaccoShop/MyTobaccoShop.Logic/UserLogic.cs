// <copyright file="UserLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using MyTobaccoShop.Data.Models;
    using MyTobaccoShop.Repository.MyUser;

    /// <summary>
    /// User Logic Class.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogic"/> class.
        /// </summary>
        /// <param name="userRepository">User repository obj.</param>
        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Add User Method.
        /// </summary>
        /// <param name="user">User Obj.</param>
        public void AddUser(User user)
        {
            this.userRepository.Add(user);
        }

        /// <summary>
        /// Add a new user based on paramaters.
        /// </summary>
        /// <param name="fullName">Name.</param>
        /// <param name="email">Email.</param>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <param name="type">Type.</param>
        public void AddUser(string fullName, string email, string username, string password, string type)
        {
            User newUser = new User
            {
                UserFullName = fullName,
                UserEmail = email,
                UserUsername = username,
                UserPassword = password,
                UserType = type,
            };
            this.userRepository.Add(newUser);
        }

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
        public bool ChangeUser(int id, string fullName, string email, string username, string password, string type)
        {
            return this.userRepository.ChangeUser(id, fullName, email, username, password, type);
        }

        /// <summary>
        /// Delete User By ID Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>boolea value.</returns>
        public bool DeleteUser(int id)
        {
            return this.userRepository.Remove(id);
        }

        /// <summary>
        /// Get One User By ID Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>User.</returns>
        public User GetUser(int id)
        {
            return this.userRepository.GetById(id);
        }

        /// <summary>
        /// Get ALL Users.
        /// </summary>
        /// <returns>Collection Of Users.</returns>
        public IList<User> GetUsers()
        {
            return this.userRepository.GetAll().ToList();
        }

        /// <summary>
        /// Update User Method.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="user">New User Obj.</param>
        public void UpdateUser(int id, User user)
        {
            this.userRepository.Update(user, id);
        }

        /// <summary>
        /// Update User Type.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="newType">User new Type.</param>
        public void UpdateUserType(int id, string newType)
        {
            this.userRepository.UpdateUserType(id, newType);
        }
    }
}

// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyUser
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// User Repository Implementaion Class.
    /// </summary>
    public class UserRepository : MyRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public UserRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get User By Id.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>User.</returns>
        public override User GetById(int id)
        {
            return this.GetAll().FirstOrDefault(x => x.UserID == id);
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
            var newUser = this.GetById(id);
            if (newUser == null)
            {
                return false;
            }

            newUser.UserFullName = fullName;
            newUser.UserEmail = email;
            newUser.UserUsername = username;
            newUser.UserPassword = password;
            newUser.UserType = type;
            this.Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update User Type Method Implementaion.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="type">User New Type.</param>
        public void UpdateUserType(int id, string type)
        {
            var user = this.GetById(id);
            user.UserType = type;
            this.Context.SaveChanges();
        }
    }
}

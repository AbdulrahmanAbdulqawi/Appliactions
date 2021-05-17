// <copyright file="UsersApiController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyTobaccoShop.Data.Models;
    using MyTobaccoShop.Logic;
    using MyTobaccoShop.Web.Models;

    /// <summary>
    /// Users API Controller Class.
    /// </summary>
    public class UsersApiController : Controller
    {
        private IUserLogic logic;
        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersApiController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">Mapper.</param>
        public UsersApiController(IUserLogic logic, IMapper mapper)
        {
            this.logic = logic;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get Users.
        /// </summary>
        /// <returns>Users.</returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.UserWeb> GetAll()
        {
            var users = this.logic.GetUsers();
            return this.mapper.Map<IList<User>, List<UserWeb>>(users);
        }

        /// <summary>
        /// Delete User.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>Boolean value.</returns>
        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOneUser(int id)
        {
            return new ApiResult { OperationResult = this.logic.DeleteUser(id) };
        }

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="newUser">User.</param>
        /// <returns>Boolean value.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOneUser(UserWeb newUser)
        {
            bool success = true;
            try
            {
                if (newUser != null)
                {
                    this.logic.AddUser(newUser.UserFullName, newUser.UserEmail, newUser.UserUsername, newUser.UserPassword, newUser.UserType);
                }
            }
            catch (ArgumentException)
            {
                success = false;
            }

            return new ApiResult() { OperationResult = success };
        }

        /// <summary>
        /// Add User.
        /// </summary>
        /// <param name="user">User.</param>
        /// <returns>Boolean value.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOneCar(UserWeb user)
        {
            if (user == null)
            {
                return new ApiResult() { OperationResult = false };
            }

            return new ApiResult() { OperationResult = this.logic.ChangeUser(user.UserId, user.UserFullName, user.UserEmail, user.UserUsername, user.UserPassword, user.UserType) };
        }
    }
}

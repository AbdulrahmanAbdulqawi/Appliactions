// <copyright file="UsersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Controllers
{
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using MyTobaccoShop.Data.Models;
    using MyTobaccoShop.Logic;
    using MyTobaccoShop.Web.Models;

    /// <summary>
    /// USer Controller.
    /// </summary>
    public class UsersController : Controller
    {
        private readonly IUserLogic logic;
        private readonly IMapper mapper;
        private readonly UserListViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="logic">logic.</param>
        /// <param name="mapper">mapper.</param>
        public UsersController(
            IUserLogic logic,
            IMapper mapper)
        {
            if (logic != null && mapper != null)
            {
                this.logic = logic;
                this.mapper = mapper;
                this.vm = new UserListViewModel
                {
                    EditedUser = new UserWeb(),
                };
                var users = logic.GetUsers();
                this.vm.ListOfUsers = mapper.Map<IList<User>, List<UserWeb>>(users);
            }
        }

        /// <summary>
        /// Index Method.
        /// </summary>
        /// <returns>View of Users.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("UsersIndex", this.vm);
        }

        /// <summary>
        /// User Details.
        /// </summary>
        /// <param name="id">user id.</param>
        /// <returns>user view.</returns>
        public IActionResult Details(int id)
        {
            return this.View("UsersDetails", this.GetUserModel(id));
        }

        /// <summary>
        /// Remove User Method.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>Redirect.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete Fail";
            if (this.logic.DeleteUser(id))
            {
                this.TempData["editResult"] = "Delete OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edit User Method.
        /// </summary>
        /// <param name="id">User id.</param>
        /// <returns>View.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedUser = this.GetUserModel(id);
            return this.View("UsersIndex", this.vm);
        }

        /// <summary>
        /// Edit User.
        /// </summary>
        /// <param name="user">user Obj.</param>
        /// <param name="editAction">action.</param>
        /// <returns>View.</returns>
        [HttpPost]
        public IActionResult Edit(UserWeb user, string editAction)
        {
            if (this.ModelState.IsValid && user != null)
            {
                this.TempData["editResult"] = "Edit Fail";
                if (editAction == "AddNew")
                {
                    this.logic.AddUser(user.UserFullName, user.UserEmail, user.UserUsername, user.UserPassword, user.UserType);
                    this.TempData["editResult"] = "Edit OK";
                }
                else
                {
                    if (this.logic.ChangeUser(user.UserId, user.UserFullName, user.UserEmail, user.UserUsername, user.UserPassword, user.UserType))
                    {
                        this.TempData["editResult"] = "Edit OK";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedUser = user;
                return this.View("UsersIndex", this.vm);
            }
        }

        /// <summary>
        /// Get User Model.
        /// </summary>
        /// <param name="id">USer id.</param>
        /// <returns>User.</returns>
        private UserWeb GetUserModel(int id)
        {
            User oneUser = this.logic.GetUser(id);
            return this.mapper.Map<User, UserWeb>(oneUser);
        }
    }
}

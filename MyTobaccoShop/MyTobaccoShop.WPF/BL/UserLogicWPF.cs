// <copyright file="UserLogicWPF.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF.BL
{
    using System.Collections.Generic;
    using GalaSoft.MvvmLight.Messaging;
    using MyTobaccoShop.Data.Models;
    using MyTobaccoShop.Logic;
    using MyTobaccoShop.Repository.MyUser;
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// User Logic WPF CLass.
    /// </summary>
    public class UserLogicWPF : IUserLogicWPF
    {
        private static readonly MyTobaccoShopDBContext Context = new MyTobaccoShopDBContext();
        private static readonly UserRepository userRepository = new UserRepository(Context);
        private static readonly UserLogic userLogic = new UserLogic(userRepository);

        private readonly IEditorService editorService;
        private readonly IMessenger messenger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogicWPF"/> class.
        /// StationLogic constructor resposible for setting the IEditorService and the IMessenger interfaces.
        /// </summary>
        /// <param name="editorService">EditorService interface.</param>
        /// <param name="messenger">MessengerService interface.</param>
        public UserLogicWPF(IEditorService editorService, IMessenger messenger)
        {
            this.editorService = editorService;
            this.messenger = messenger;
        }

        /// <summary>
        /// Get all Users method responsible.
        /// </summary>
        /// <param name="users">List of users to be displayed.</param>
        public void GetUsers(IList<UserModel> users)
        {
            if (users != null)
            {
                users.Clear();
                IList<UserModel> userModels = EntityToModelConverter(userLogic.GetUsers());
                foreach (UserModel user in userModels)
                {
                    users.Add(user);
                }
            }
        }

        /// <summary>
        /// add user method ressposible for adding users to the UI and DB.
        /// </summary>
        /// <param name="users">List of stations to be added.</param>
        public void AddUser(IList<UserModel> users)
        {
            if (users != null)
            {
                UserModel userModel = new UserModel();
                if (this.editorService.EditUser(userModel) == true)
                {
                    users.Add(userModel);
                    User entityUser = ModelToEntityConverter(userModel);
                    userLogic.AddUser(entityUser);
                    this.GetUsers(users);
                    this.messenger.Send("user added successfully ", "Logic Result");
                }
                else
                {
                    this.messenger.Send("Failed to add a user", "Logic Result");
                }
            }
        }

        /// <summary>
        /// UpdateUser method responsible for updating one user in instance.
        /// </summary>
        /// <param name="user">USer.</param>
        public void UpdateUser(UserModel user)
        {
            if (user == null)
            {
                this.messenger.Send("Failled to modify the user", "Logic Result");
            }

            UserModel clone = new UserModel();
            clone.CopyFrom(user);
            if (this.editorService.EditUser(clone) == true)
            {
                if (user != null)
                {
                    user.CopyFrom(clone);
                    _ = new User
                    {
                        UserID = user.UserId,
                        UserFullName = user.UserFullName,
                        UserEmail = user.UserEmail,
                        UserUsername = user.UserUsername,
                        UserPassword = user.UserPassword,
                        UserType = user.UserType,
                    };
                    this.messenger.Send("user edited successfully ");
                }
            }
            else
            {
                this.messenger.Send("Failled to modify the user", "Logic Result");
            }
        }

        /// <summary>
        /// DeleteUser method responsible for deleting a user from the UI and from the DB.
        /// </summary>
        /// <param name="users">List of all the users in the DB.</param>
        /// <param name="user">user to be deleted.</param>
        public void DeleteUser(IList<UserModel> users, UserModel user)
        {
            if (users != null)
            {
                if (user == null || !users.Remove(user))
                {
                    this.messenger.Send("Failed to delete a user", "Logic Result");
                }
                else
                {
                    userLogic.DeleteUser(user.UserId);
                    this.messenger.Send("user is succesfully removed", "Logic Result");
                }
            }
        }

        private static IList<UserModel> EntityToModelConverter(IList<User> entityUsers)
        {
            IList<UserModel> userModels = new List<UserModel>();
            foreach (User entityUser in entityUsers)
            {
                UserModel currentUser = new UserModel
                {
                    UserId = entityUser.UserID,
                    UserFullName = entityUser.UserFullName,
                    UserEmail = entityUser.UserEmail,
                    UserUsername = entityUser.UserUsername,
                    UserPassword = entityUser.UserPassword,
                    UserType = entityUser.UserType,
                };
                userModels.Add(currentUser);
            }

            return userModels;
        }

        private static User ModelToEntityConverter(UserModel userModel)
        {
            User currentUser = new User
            {
                UserID = userModel.UserId,
                UserFullName = userModel.UserFullName,
                UserEmail = userModel.UserEmail,
                UserUsername = userModel.UserUsername,
                UserPassword = userModel.UserPassword,
                UserType = userModel.UserType,
            };
            return currentUser;
        }
    }
}

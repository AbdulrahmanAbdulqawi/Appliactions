// <copyright file="UserVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPFClient
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// User View Model Class.
    /// </summary>
    public class UserVM : ObservableObject
    {
        private int id;
        private string fullName;
        private string email;
        private string username;
        private string password;
        private string type;

        /// <summary>
        /// Gets Or Sets User ID.
        /// </summary>
        public int UserId { get => this.id; set => this.Set(ref this.id, value); }

        /// <summary>
        /// Gets Or Sets User ID.
        /// </summary>
        public string UserFullName { get => this.fullName; set => this.Set(ref this.fullName, value); }

        /// <summary>
        /// Gets Or Sets User FullName.
        /// </summary>
        public string UserEmail { get => this.email; set => this.Set(ref this.email, value); }

        /// <summary>
        /// Gets Or Sets User Emial.
        /// </summary>
        public string UserUserName { get => this.username; set => this.Set(ref this.username, value); }

        /// <summary>
        /// Gets Or Sets User UserName.
        /// </summary>
        public string UserPassword { get => this.password; set => this.Set(ref this.password, value); }

        /// <summary>
        /// Gets Or Sets User Password.
        /// </summary>
        public string UserType { get => this.type; set => this.Set(ref this.type, value); }

        /// <summary>
        /// CopyFrom method to copy one UserModel instance into a different one.
        /// </summary>
        /// <param name="other">The UserModel instance to copy from.</param>
        public void CopyFrom(UserVM other)
        {
            if (other == null)
            {
                return;
            }

            this.UserId = other.UserId;
            this.UserFullName = other.UserFullName;
            this.UserEmail = other.UserEmail;
            this.UserUserName = other.UserUserName;
            this.UserPassword = other.UserPassword;
            this.UserType = other.UserType;
        }
    }
}

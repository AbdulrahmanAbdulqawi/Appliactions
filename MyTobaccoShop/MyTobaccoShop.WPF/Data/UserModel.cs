// <copyright file="UserModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF.Data
{
    using System.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// User Model Class.
    /// </summary>
    public class UserModel : ObservableObject
    {
        private int userId;
        private string userFullName;
        private string userEmail;
        private string userUsername;
        private string userPassword;
        private string userType;

        /// <summary>
        /// Gets Or Sets User ID.
        /// </summary>
        public int UserId { get => this.userId; set => this.Set(ref this.userId, value); }

        /// <summary>
        /// Gets Or Sets User ID.
        /// </summary>
        public string UserFullName { get => this.userFullName; set => this.Set(ref this.userFullName, value); }

        /// <summary>
        /// Gets Or Sets User FullName.
        /// </summary>
        public string UserEmail { get => this.userEmail; set => this.Set(ref this.userEmail, value); }

        /// <summary>
        /// Gets Or Sets User Emial.
        /// </summary>
        public string UserUsername { get => this.userUsername; set => this.Set(ref this.userUsername, value); }

        /// <summary>
        /// Gets Or Sets User UserName.
        /// </summary>
        public string UserPassword { get => this.userPassword; set => this.Set(ref this.userPassword, value); }

        /// <summary>
        /// Gets Or Sets User Password.
        /// </summary>
        public string UserType { get => this.userType; set => this.Set(ref this.userType, value); }

        /// <summary>
        /// CopyFrom method to copy one UserModel instance into a different one.
        /// </summary>
        /// <param name="other">The UserModel instance to copy from.</param>
        public void CopyFrom(UserModel other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
        }
    }
}

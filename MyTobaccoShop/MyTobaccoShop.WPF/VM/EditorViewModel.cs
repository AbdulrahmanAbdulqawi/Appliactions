// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPF.VM
{
    using GalaSoft.MvvmLight;
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// Editor View Model Class.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        private UserModel user;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.user = new UserModel();
            if (this.IsInDesignMode)
            {
                this.user.UserFullName = "DefaultName";
                this.user.UserEmail = "@gmail.com";
                this.user.UserUsername = "DefaultUserName";
                this.user.UserPassword = "**********";
                this.user.UserType = "Admin";
            }
        }

        /// <summary>
        /// Gets or Sets User.
        /// </summary>
        public UserModel User { get => this.user; set => this.Set(ref this.user, value); }
    }
}

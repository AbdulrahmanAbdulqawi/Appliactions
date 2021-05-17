// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF.VM
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using MyTobaccoShop.WPF.BL;
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// Main View Model Class.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IUserLogicWPF userLogic;
        private UserModel selectedUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="userLogic">userLogic Obj.</param>
        public MainViewModel(IUserLogicWPF userLogic)
        {
            this.userLogic = userLogic;
            this.Users = new ObservableCollection<UserModel>();
            if (this.IsInDesignMode)
            {
                UserModel user2 = new UserModel() { UserFullName = "Abdul", UserEmail = "abdul@gmail.com", UserUsername = "abdul2017", UserPassword = "123456", UserType = "Admin" };
                this.Users.Add(user2);
            }

            this.GetCommand = new RelayCommand(() => this.userLogic.GetUsers(this.Users));
            this.AddCommand = new RelayCommand(() => this.userLogic.AddUser(this.Users));
            this.DeleteCommand = new RelayCommand(() => this.userLogic.DeleteUser(this.Users, this.SelectedUser));
            this.EditeCommand = new RelayCommand(() => this.userLogic.UpdateUser(this.SelectedUser));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
           : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IUserLogicWPF>())
        {
        }

        /// <summary>
        /// Gets or Sets Selected User.
        /// </summary>
        public UserModel SelectedUser { get => this.selectedUser; set => this.Set(ref this.selectedUser, value); }

        /// <summary>
        /// Gets A collection Of Users.
        /// </summary>
        public ObservableCollection<UserModel> Users { get; private set; }

        /// <summary>
        /// Gets get Command.
        /// </summary>
        public ICommand GetCommand { get; private set; }

        /// <summary>
        /// Gets Add Command.
        /// </summary>
        public ICommand AddCommand { get; private set; }

        /// <summary>
        /// Gets Delete Command.
        /// </summary>
        public ICommand DeleteCommand { get; private set; }

        /// <summary>
        /// Gets Edite Command.
        /// </summary>
        public ICommand EditeCommand { get; private set; }
    }
}

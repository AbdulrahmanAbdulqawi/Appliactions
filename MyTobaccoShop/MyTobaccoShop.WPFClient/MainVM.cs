// <copyright file="MainVM.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPFClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// Main View Model Class.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private IMainLogic logic;
        private UserVM selectedUser;
        private ObservableCollection<UserVM> allUsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        /// <param name="logic">MainLogic itself.</param>
        public MainVM(IMainLogic logic)
        {
            this.logic = logic;

            this.LoadCmd = new RelayCommand(() => this.AllUsers = new ObservableCollection<UserVM>(
            this.logic.ApiGetUsers()));
            this.DelCmd = new RelayCommand(() => this.logic.ApiDelUser(this.selectedUser));
            this.AddCmd = new RelayCommand(() => this.logic.EditUser(null, this.EditorFunc));
            this.EditCmd = new RelayCommand(() => this.logic.EditUser(this.selectedUser, this.EditorFunc));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainVM"/> class.
        /// </summary>
        public MainVM()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IMainLogic>())
        {
        }

        /// <summary>
        /// Gets or Sets All Users.
        /// </summary>
        public ObservableCollection<UserVM> AllUsers
        {
            get { return this.allUsers; }
            set { this.Set(ref this.allUsers, value); }
        }

        /// <summary>
        /// Gets or Sets User.
        /// </summary>
        public UserVM SelectedUser
        {
            get { return this.selectedUser; }
            set { this.Set(ref this.selectedUser, value); }
        }

        /// <summary>
        /// Gets or Sets Editor.
        /// </summary>
        public Func<UserVM, bool> EditorFunc { get; set; }

        /// <summary>
        /// Gets ts Add Command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets Del Command.
        /// </summary>
        public ICommand DelCmd { get; private set; }

        /// <summary>
        /// Gets Edit Command.
        /// </summary>
        public ICommand EditCmd { get; private set; }

        /// <summary>
        /// Gets Load Command.
        /// </summary>
        public ICommand LoadCmd { get; private set; }
    }
}

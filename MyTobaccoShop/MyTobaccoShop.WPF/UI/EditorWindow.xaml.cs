// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF.UI
{
    using System.Windows;
    using MyTobaccoShop.Data;
    using MyTobaccoShop.WPF.Data;
    using MyTobaccoShop.WPF.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();
            this.VM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldUser">old user obj.</param>
        public EditorWindow(UserModel oldUser)
           : this()
        {
            this.VM.User = oldUser;
        }

        /// <summary>
        /// Gets User.
        /// </summary>
        public UserModel User { get => this.VM.User; }

        private void OKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

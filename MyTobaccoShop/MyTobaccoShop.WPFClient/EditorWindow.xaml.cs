// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPFClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// Ediotr Window.
        /// </summary>
        /// <param name="user">User.</param>
        public EditorWindow(UserVM user)
            : this()
        {
            this.DataContext = user;
        }

        /// <summary>
        /// OkClick Event.
        /// </summary>
        /// <param name="sender">sendr.</param>
        /// <param name="e">Event Argumanet.</param>
        private void OKClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// CancelClick Event.
        /// </summary>
        /// <param name="sender">sendr.</param>
        /// <param name="e">Event Argumanet.</param>
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

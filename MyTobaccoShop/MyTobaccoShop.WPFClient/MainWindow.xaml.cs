// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Window Loaded Event.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">event Arguments.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, "UserResult", msg =>
             {
                 (this.DataContext as MainVM).LoadCmd.Execute(null);
                 MessageBox.Show(msg);
             });
            (this.DataContext as MainVM).EditorFunc = (user) =>
            {
                EditorWindow win = new EditorWindow(user);
                return win.ShowDialog() == true;
            };
        }

        /// <summary>
        /// Window Closing Event.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">event Arguments.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}

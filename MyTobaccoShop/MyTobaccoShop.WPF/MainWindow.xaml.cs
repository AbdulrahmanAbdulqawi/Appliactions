// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPF
{
    using System;
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// MainWindow zero-parameter constructor.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Register<string>(this, "LogicResult", (msg) =>
            {
                MessageBox.Show(msg);
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}

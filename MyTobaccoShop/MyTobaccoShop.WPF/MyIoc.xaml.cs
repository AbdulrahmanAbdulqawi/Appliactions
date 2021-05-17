// <copyright file="MyIoc.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// MyIoc class which is a custom IoC container.
    /// </summary>
    internal class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets instacle which is a singleton, so that we don't have to worry about the instance creation.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}

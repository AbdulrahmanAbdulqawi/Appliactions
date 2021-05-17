// <copyright file="ICategoriesRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Repository.MyCategory
{
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Categories Repository interface.
    /// </summary>
    public interface ICategoriesRepository : IRepository<Category>
    {
        /// <summary>
        /// Update the Category title Method.
        /// </summary>
        /// <param name="id">Category ID.</param>
        /// <param name="newTitle">new Category Title.</param>
        void UpdateCategoryTitle(int id, string newTitle);
    }
}

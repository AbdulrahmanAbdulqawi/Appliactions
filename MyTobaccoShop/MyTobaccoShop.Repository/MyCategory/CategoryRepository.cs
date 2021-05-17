// <copyright file="CategoryRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Repository.MyCategory
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using MyTobaccoShop.Data.Models;

    /// <summary>
    /// Category class to implement the repository class.
    /// </summary>
    public class CategoryRepository : MyRepository<Category>, ICategoriesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public CategoryRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Get Category By Id.
        /// </summary>
        /// <param name="id">Category id.</param>
        /// <returns>Category.</returns>
        public override Category GetById(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.CategoryID == id);
        }

        /// <summary>
        /// Update Category Title implementation.
        /// </summary>
        /// <param name="id">Catgeory ID.</param>
        /// <param name="newTitle">Category new Title.</param>
        public void UpdateCategoryTitle(int id, string newTitle)
        {
            var category = this.GetById(id);
            category.CategoryTitle = newTitle;
            this.Context.SaveChanges();
        }
    }
}
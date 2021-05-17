// <copyright file="MyRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository Class.
    /// </summary>
    /// <typeparam name="T">Repository Entity.</typeparam>
    public abstract class MyRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyRepository{T}"/> class.
        /// Initializes a new instance of the DbContext.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        protected MyRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets changes the DbContect to protected so all the desendant classes can use it.
        /// </summary>
        protected DbContext Context => this.ctx;

        /// <summary>
        /// abstract method to Add a new entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="entity">new entity.</param>
        public void Add(T entity)
        {
            this.Context.Set<T>().Add(entity);
            this.Context.SaveChanges();
        }

        /// <summary>
        /// Return all entities.
        /// </summary>
        /// <returns>entities.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Context.Set<T>();
        }

        /// <summary>
        /// Return an antity that match the id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>entity.</returns>
        public abstract T GetById(int id);

        /// <summary>
        /// abstract method to Remove an old entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="id">Remove.</param>
        /// <returns>boolean vlaue.</returns>
        public bool Remove(int id)
        {
            T toRemove = this.Context.Set<T>().Find(id);
            if (toRemove == null)
            {
                return false;
            }

            this.Context.Set<T>().Remove(toRemove);
            this.Context.SaveChanges();
            return true;
        }

        /// <summary>
        /// abstract method to Update an entity, the implmentation will be in every specific class.
        /// </summary>
        /// <param name="entity">Update.</param>
        /// <param name="id">id.</param>
        public void Update(T entity, int id)
        {
            var oldCategory = this.GetById(id);
            this.Context.Set<T>().Remove(oldCategory);
            this.Context.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }
    }
}

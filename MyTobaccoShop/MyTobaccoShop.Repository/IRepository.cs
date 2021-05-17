// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.Repository
{
    using System.Linq;

    /// <summary>
    /// Repository Interface.
    /// </summary>
    /// <typeparam name="T">Repository interface.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity">new entity.</param>
        void Add(T entity);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">Update.</param>
        /// <param name="id">id.</param>
        void Update(T entity, int id);

        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="id">Remove.</param>
        /// <returns>boolean vlaue.</returns>
        bool Remove(int id);

        /// <summary>
        /// Return an antity that match the id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>entity.</returns>
        T GetById(int id);

        /// <summary>
        /// Return all entities.
        /// </summary>
        /// <returns>entities.</returns>
        IQueryable<T> GetAll();
    }
}

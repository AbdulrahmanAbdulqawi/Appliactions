// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.WPF.BL
{
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// Editor Service Interface.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// Edit User Method.
        /// </summary>
        /// <param name="user">user ob.</param>
        /// <returns>boolean.</returns>
        bool EditUser(UserModel user);
    }
}

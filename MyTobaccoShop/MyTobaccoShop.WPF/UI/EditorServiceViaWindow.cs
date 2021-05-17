// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace MyTobaccoShop.WPF.UI
{
    using MyTobaccoShop.WPF.BL;
    using MyTobaccoShop.WPF.Data;

    /// <summary>
    /// EditorServiceViaWindow Class.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// Edit User Method.
        /// </summary>
        /// <param name="user">user Obj.</param>
        /// <returns>boolean vakue.</returns>
        public bool EditUser(UserModel user)
        {
            EditorWindow editor = new EditorWindow(user);
            return editor.ShowDialog() ?? false;
        }
    }
}

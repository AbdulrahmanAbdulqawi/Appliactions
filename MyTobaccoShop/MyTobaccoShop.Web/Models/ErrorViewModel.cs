// <copyright file="ErrorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyTobaccoShop.Web.Models
{
    /// <summary>
    /// Error View Model.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or Sets Request Id Property.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets a value indicating whether gets show Request Id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}

// <copyright file="UserProfileSummaryPostDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// User Profile Summary DTO Class.
    /// </summary>
    public class UserProfileSummaryPostDto
    {
        /// <summary>
        /// Gets or sets the users name.
        /// </summary>
        required public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the size of the profile.
        /// </summary>
        public long ProfileSize { get; set; }

        /// <summary>
        /// Gets or sets the temp data size of the profile.
        /// </summary>
        public long TempSize { get; set; }

        /// <summary>
        /// Gets or sets the profile type.
        /// </summary>
        public EUCProfileType ProfileType { get; set; }
    }
}

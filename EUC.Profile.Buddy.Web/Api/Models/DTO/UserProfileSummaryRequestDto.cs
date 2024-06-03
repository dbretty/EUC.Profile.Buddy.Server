// <copyright file="UserProfileSummaryRequestDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// User Profile Summary Request DTO Class.
    /// </summary>
    public class UserProfileSummaryRequestDto
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the users name.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the profile directory.
        /// </summary>
        public string ProfileDirectory { get; set; } = string.Empty;

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

        /// <summary>
        /// Gets or sets the last updated time of this entity.
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the date created time of this entity.
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the profile age of this entity.
        /// </summary>
        public TimeSpan ProfileAge { get; set; }
    }
}

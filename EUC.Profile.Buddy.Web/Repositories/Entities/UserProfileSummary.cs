// <copyright file="UserProfileSummary.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories.Entities
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

	/// <summary>
	/// Class to build the User Profile Summary.
	/// </summary>
	public class UserProfileSummary
	{
		/// <summary>
		/// Gets or sets the Id.
		/// </summary>
		[Key]
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

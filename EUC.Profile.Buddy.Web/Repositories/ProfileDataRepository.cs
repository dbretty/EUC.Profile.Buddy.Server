﻿// <copyright file="ProfileDataRepository.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories
{
    using EUC.Profile.Buddy.Web.Repositories.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// EUC Profile Buddy Data Repository Class.
    /// </summary>
    public class ProfileDataRepository : IdentityDbContext<ApplicationUser>
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileDataRepository"/> class.
        /// </summary>
        /// <param name="options">The DBContext Options.</param>
        public ProfileDataRepository(DbContextOptions<ProfileDataRepository> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the User Profile Summaries.
        /// </summary>
        public DbSet<UserProfileSummary> UserProfileSummary { get; set; }

        /// <summary>
        /// Gets or sets the Task Information.
        /// </summary>
        public DbSet<TaskInformation> TaskInformation { get; set; }
    }
}

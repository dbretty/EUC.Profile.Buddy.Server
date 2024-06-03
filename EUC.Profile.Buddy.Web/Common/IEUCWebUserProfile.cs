// <copyright file="IEUCWebUserProfile.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Common
{
    using EUC.Profile.Buddy.Web.Repositories.Entities;

    /// <summary>
	/// Interface to manage common code for EUC Ewb Tier.
	/// </summary>
    public interface IEUCWebUserProfile
    {
        /// <summary>
        /// Formats the size passed in.
        /// </summary>
        /// <param name="bytes">The total size to format.</param>
        /// <returns>A <see cref="string"/>.</returns>
        string FormatFileSize(long bytes);

        /// <summary>
        /// Gets the total number of profiles.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        int TotalProfiles(List<UserProfileSummary> profiles);

        /// <summary>
        /// Gets the total profile size.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        long TotalProfileSize(List<UserProfileSummary> profiles);

        /// <summary>
        /// Gets the total temp size.
        /// </summary>
        /// <param name="profiles">The profiles array.</param>
        /// <returns>A <see cref="UserProfileSummary"/>.</returns>
        long TotalTempSize(List<UserProfileSummary> profiles);
    }
}
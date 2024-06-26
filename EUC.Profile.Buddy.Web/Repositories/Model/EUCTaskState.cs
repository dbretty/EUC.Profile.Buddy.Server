﻿// <copyright file="EUCTaskState.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories.Model
{
    /// <summary>
	/// Enum to hold the task status.
	/// </summary>
	public enum EUCTaskState
    {
        /// <summary>
        /// Unknown Status.
        /// </summary>
        Unknown,

        /// <summary>
        /// Completed.
        /// </summary>
        Completed,

        /// <summary>
        /// Errored.
        /// </summary>
        Errored,

        /// <summary>
        /// Running
        /// </summary>
        Running,
    }
}

// <copyright file="TaskInformationPostDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// Task Information Post DTO Class.
    /// </summary>
    public class TaskInformationPostDto
    {
        /// <summary>
		/// Gets or sets the users name.
		/// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
		/// Gets or sets the Task Name.
		/// </summary>
        public string? TaskName { get; set; }

        /// <summary>
		/// Gets or sets the task state.
		/// </summary>
        public EUCTaskState TaskState { get; set; }
    }
}

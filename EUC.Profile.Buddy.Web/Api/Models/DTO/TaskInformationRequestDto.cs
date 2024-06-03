// <copyright file="TaskInformationRequestDto.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models.DTO
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
    /// Task Information Request DTO Class.
    /// </summary>
    public class TaskInformationRequestDto
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
		/// Gets or sets the Task Name.
		/// </summary>
        public string? TaskName { get; set; }

        /// <summary>
		/// Gets or sets the task executed date and time.
		/// </summary>
        public DateTime TaskExecuted { get; set; }

        /// <summary>
		/// Gets or sets the task state.
		/// </summary>
        public EUCTaskState TaskState { get; set; }

        /// <summary>
		/// Gets or sets the task run time.
		/// </summary>
        public TimeSpan TaskRunTime { get; set; }
    }
}

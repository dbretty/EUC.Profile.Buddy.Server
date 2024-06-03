// <copyright file="TaskInformation.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Repositories.Entities
{
    using System.ComponentModel.DataAnnotations;
    using EUC.Profile.Buddy.Web.Repositories.Model;

    /// <summary>
	/// Class to build the Task Information.
	/// </summary>
    public class TaskInformation
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
		/// Gets or sets the Task Name.
		/// </summary>
        public string TaskName { get; set; } = string.Empty;

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

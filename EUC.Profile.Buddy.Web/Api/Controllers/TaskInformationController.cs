// <copyright file="TaskInformationController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories;
    using EUC.Profile.Buddy.Web.Repositories.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Task Information Controller Class.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskInformationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProfileDataRepository _profileDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskInformationController"/> class.
        /// </summary>
        /// <param name="mapper">The automapper.</param>
        /// <param name="profileDataRepository">The Datasource.</param>
        public TaskInformationController(IMapper mapper, ProfileDataRepository profileDataRepository)
        {
            this._mapper = mapper;
            this._profileDataRepository = profileDataRepository;
        }

        /// <summary>
        /// Gets all the Task Information records.
        /// </summary>
        /// <returns>A <see cref="Task{TaskInformationRequestDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TaskInformation
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task Information records.</response>
        /// <response code="404">Returns if the no Task Records are found.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpGet]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<TaskInformationRequestDto>>> GetTaskInformation()
        {
            var taskInformation = await this._profileDataRepository.TaskInformation
                .OrderByDescending(x => x.TaskExecuted)
                .AsNoTracking()
                .ToListAsync();

            if (taskInformation.Count == 0)
            {
                return this.NotFound("No tasks available");
            }
            else
            {
                try
                {
                    var returnData = this._mapper.Map<List<TaskInformationRequestDto>>(taskInformation);
                    return this.Ok(returnData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Gets a single Task Information record by ID.
        /// </summary>
        /// <param name="id">The Task Information record ID.</param>
        /// <returns>A <see cref="Task{TaskInformationRequestDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TaskInformation/id/{id}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task Information record.</response>
        /// <response code="404">Returns if the no Task Records are found.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpGet("id/{id:guid}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<TaskInformationRequestDto>>> GetTaskInformationByID(Guid id)
        {
            var existingTaskID = await this._profileDataRepository.TaskInformation
                .OrderByDescending(x => x.TaskExecuted)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .ToListAsync();

            if (existingTaskID.Count == 0)
            {
                return this.NotFound($"Task ID {id} not found");
            }
            else
            {
                try
                {
                    var returnData = this._mapper.Map<List<TaskInformationRequestDto>>(existingTaskID);
                    return this.Ok(returnData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Gets all the Task Information records by User Name.
        /// </summary>
        /// <param name="username">The Task Information record User Name.</param>
        /// <returns>A <see cref="Task{TaskInformationRequestDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TaskInformation/username/{username}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task Information records.</response>
        /// <response code="404">Returns if the no Task Records are found.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpGet("username/{username}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<TaskInformationRequestDto>>> GetTaskInformationByUserName(string username)
        {
            var existingTask = await this._profileDataRepository.TaskInformation
                .OrderByDescending(x => x.TaskExecuted)
                .Where(x => x.UserName == username)
                .AsNoTracking()
                .ToListAsync();

            if (existingTask.Count == 0)
            {
                return this.NotFound($"No Task Information records for {username} found");
            }
            else
            {
                try
                {
                    var returnData = this._mapper.Map<List<TaskInformationRequestDto>>(existingTask);
                    return this.Ok(returnData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Adds a Task Information record.
        /// </summary>
        /// <param name="taskInformationPostDto">The request body for the operation.</param>
        /// <returns>A <see cref="Task{taskInformationPostDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /TaskInformation
        ///     {
        ///         UserName: "Dave Brett"
        ///         TaskName: "Task 1"
        ///         TaskState: 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the Task Information record.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> AddTaskInformation([FromBody] TaskInformationPostDto taskInformationPostDto)
        {
            try
            {
                var taskInformationData = this._mapper.Map<TaskInformation>(taskInformationPostDto);
                taskInformationData.TaskExecuted = DateTime.UtcNow;
                taskInformationData.TaskRunTime = DateTime.UtcNow - taskInformationData.TaskExecuted;
                this._profileDataRepository.TaskInformation.Add(taskInformationData);
                await this._profileDataRepository.SaveChangesAsync();
                return this.Ok(taskInformationData);
            }
            catch (HttpRequestException ex)
            {
                return this.BadRequest($"HTTP exception thrown: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates a Task Information record.
        /// </summary>
        /// <param name="id">The Task Information ID.</param>
        /// <param name="taskInformationPostDto">The request body for the operation.</param>
        /// <returns>A <see cref="Task{taskInformationPostDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /TaskInformation/id/{id}
        ///     {
        ///         UserName: "Dave Brett"
        ///         TaskName: "Task 1"
        ///         TaskState: 1
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated Task Information record.</response>
        /// <response code="404">Returns if the Task Record does not exist.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpPost("id/{id}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<IActionResult> UpdateTaskInformation(Guid id, [FromBody] TaskInformationPostDto taskInformationPostDto)
        {
            var existingTask = await this._profileDataRepository.TaskInformation
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (existingTask is null)
            {
                return this.BadRequest($"Unable to find task with TaskID: {id}");
            }
            else
            {
                try
                {
                    var taskInformationData = this._mapper.Map<TaskInformation>(taskInformationPostDto);
                    taskInformationData.Id = existingTask.Id;
                    taskInformationData.TaskExecuted = existingTask.TaskExecuted;
                    taskInformationData.TaskRunTime = DateTime.UtcNow - existingTask.TaskExecuted;
                    if (existingTask.TaskState != taskInformationPostDto.TaskState)
                    {
                        taskInformationData.TaskState = taskInformationPostDto.TaskState;
                    }

                    if (!string.IsNullOrEmpty(taskInformationPostDto.UserName))
                    {
                        taskInformationData.UserName = taskInformationPostDto.UserName;
                    }
                    else
                    {
                        taskInformationData.UserName = existingTask.UserName;
                    }

                    if (!string.IsNullOrEmpty(taskInformationPostDto.TaskName))
                    {
                        taskInformationData.TaskName = taskInformationPostDto.TaskName;
                    }
                    else
                    {
                        taskInformationData.TaskName = existingTask.TaskName;
                    }

                    this._profileDataRepository.TaskInformation.Update(taskInformationData);
                    await this._profileDataRepository.SaveChangesAsync();
                    return this.Ok(taskInformationData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Deletes a Task Information record.
        /// </summary>
        /// <param name="id">The Task Information ID.</param>
        /// <returns>A <see cref="Task{TaskInformationDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /TaskInformation{id}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the deleted Task Information ID.</response>
        /// <response code="404">Returns if the Task Record does not exist.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpDelete("id/{id}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(TaskInformationRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<IActionResult> DeleteTaskInformation(Guid id)
        {
            var existingTask = await this._profileDataRepository.TaskInformation
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (existingTask is null)
            {
                return this.BadRequest($"Unable to find task with TaskID: {id}");
            }
            else
            {
                try
                {
                    this._profileDataRepository.TaskInformation.Remove(existingTask);
                    await this._profileDataRepository.SaveChangesAsync();
                    return this.Ok(id);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }
    }
}

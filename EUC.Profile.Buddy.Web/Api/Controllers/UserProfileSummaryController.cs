﻿// <copyright file="UserProfileSummaryController.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Controllers
{
    using System.Net;
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories;
    using EUC.Profile.Buddy.Web.Repositories.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// User Profile Summary Controller Class.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserProfileSummaryController : ControllerBase
	{
        private readonly IMapper _mapper;
        private readonly ProfileDataRepository _profileDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileSummaryController"/> class.
        /// </summary>
        /// <param name="mapper">The automapper.</param>
        /// <param name="profileDataRepository">The Datasource.</param>
        public UserProfileSummaryController(IMapper mapper, ProfileDataRepository profileDataRepository)
        {
            this._mapper = mapper;
            this._profileDataRepository = profileDataRepository;
        }

        /// <summary>
        /// Gets all the User Profile records.
        /// </summary>
        /// <returns>A <see cref="Task{UserProfileSummaryRequestDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /UserProfileSummary
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the User Profile Summary records.</response>
        /// <response code="404">Returns if the no User Profile Summary Records are found.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpGet]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfileSummaryRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<UserProfileSummaryRequestDto>>> GetUserProfiles()
        {
            var userInformation = await this._profileDataRepository.UserProfileSummary
                .OrderByDescending(x => x.DateCreated)
                .AsNoTracking()
                .ToListAsync();

            if (userInformation.Count == 0)
            {
                return this.NotFound("No user profiles available");
            }
            else
            {
                try
                {
                    var returnData = this._mapper.Map<List<UserProfileSummaryRequestDto>>(userInformation);
                    return this.Ok(returnData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Gets a single User Profile Summary record by ID.
        /// </summary>
        /// <param name="id">The User Profile Summary record ID.</param>
        /// <returns>A <see cref="Task{UserProfileSummaryRequestDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /UserProfileSummary/id/{id}
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the User Profile Summary record.</response>
        /// <response code="404">Returns if the no User Profile Summary records are found.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpGet("id/{id:guid}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfileSummaryRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.NotFound, type: typeof(string))]
        public async Task<ActionResult<List<UserProfileSummaryRequestDto>>> GetUserProfileSummaryByID(Guid id)
        {
            var existingUserProfileID = await this._profileDataRepository.UserProfileSummary
                .OrderByDescending(x => x.DateCreated)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .ToListAsync();

            if (existingUserProfileID.Count == 0)
            {
                return this.NotFound($"User Profile Summary ID {id} not found");
            }
            else
            {
                try
                {
                    var returnData = this._mapper.Map<List<UserProfileSummaryRequestDto>>(existingUserProfileID);
                    return this.Ok(returnData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Adds a User Profile record.
        /// </summary>
        /// <param name="userProfileSummaryPostDto"> the request for the operation.</param>
        /// <returns>A <see cref="Task{userProfileSummaryPostDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /UserProfileSummary
        ///     {
        ///         UserName: "Dave Brett"
        ///         ProfileSize: 1000324
        ///         TempSize: 321773
        ///         ProfileType: 0
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the newly created item.</response>
        /// <response code="400">If the item already exists.</response>
        [HttpPost]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfileSummaryRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> AddUserProfile([FromBody] UserProfileSummaryPostDto userProfileSummaryPostDto)
		{
            try
            {
                var userProfileSummaryData = this._mapper.Map<UserProfileSummary>(userProfileSummaryPostDto);
                userProfileSummaryData.DateCreated = DateTime.UtcNow;
                userProfileSummaryData.LastUpdated = DateTime.UtcNow;
                userProfileSummaryData.ProfileAge = userProfileSummaryData.DateCreated - DateTime.UtcNow;
                userProfileSummaryData.ProfileDirectory = Path.Join("C:\\Users", userProfileSummaryData.UserName);
                this._profileDataRepository.UserProfileSummary.Add(userProfileSummaryData);
                await this._profileDataRepository.SaveChangesAsync();
                return this.Ok(userProfileSummaryData);
            }
            catch (HttpRequestException ex)
            {
                return this.BadRequest($"HTTP exception thrown: {ex.Message}");
            }
		}

        /// <summary>
        /// Updates a User Profile record.
        /// </summary>
        /// <param name="id">The User Profile ID.</param>
        /// <param name="userProfileSummaryPostDto">The request body for the operation.</param>
        /// <returns>A <see cref="Task{userProfileSummaryPostDto}"/> representing the result of the asynchronous operation.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /UserProfileSummary/id/{id}
        ///     {
        ///         UserName: "DaveBrettUpdated"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated User Profile record.</response>
        /// <response code="404">Returns if the User Profile does not exist.</response>
        /// <response code="400">Returns the HTTP exception.</response>
        [HttpPost("id/{id}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, type: typeof(UserProfileSummaryRequestDto))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, type: typeof(string))]
        public async Task<IActionResult> UpdateUserProfile(Guid id, [FromBody] UserProfileSummaryPostDto userProfileSummaryPostDto)
        {
            var existingUser = await this._profileDataRepository.UserProfileSummary
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (existingUser is null)
            {
                return this.BadRequest($"Unable to find user with ID: {id}");
            }
            else
            {
                try
                {
                    var userInformationData = this._mapper.Map<UserProfileSummary>(userProfileSummaryPostDto);
                    userInformationData.Id = existingUser.Id;
                    userInformationData.DateCreated = existingUser.DateCreated;
                    userInformationData.LastUpdated = DateTime.UtcNow;
                    userInformationData.ProfileAge = DateTime.UtcNow - existingUser.DateCreated;
                    userInformationData.ProfileDirectory = existingUser.ProfileDirectory;

                    if (userInformationData.ProfileType != userProfileSummaryPostDto.ProfileType)
                    {
                        userInformationData.ProfileType = userProfileSummaryPostDto.ProfileType;
                    }

                    if (!string.IsNullOrEmpty(userProfileSummaryPostDto.UserName))
                    {
                        userInformationData.UserName = userProfileSummaryPostDto.UserName;
                    }
                    else
                    {
                        userInformationData.UserName = existingUser.UserName;
                    }

                    if (userProfileSummaryPostDto.ProfileSize != 0)
                    {
                        userInformationData.ProfileSize = userProfileSummaryPostDto.ProfileSize;
                    }
                    else
                    {
                        userInformationData.ProfileSize = existingUser.ProfileSize;
                    }

                    if (userProfileSummaryPostDto.TempSize != 0)
                    {
                        userInformationData.TempSize = userProfileSummaryPostDto.TempSize;
                    }
                    else
                    {
                        userInformationData.TempSize = existingUser.TempSize;
                    }

                    this._profileDataRepository.UserProfileSummary.Update(userInformationData);
                    await this._profileDataRepository.SaveChangesAsync();
                    return this.Ok(userInformationData);
                }
                catch (HttpRequestException ex)
                {
                    return this.BadRequest($"HTTP exception thrown: {ex.Message}");
                }
            }
        }
    }
}

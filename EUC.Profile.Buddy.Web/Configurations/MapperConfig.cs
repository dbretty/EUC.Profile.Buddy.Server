// <copyright file="MapperConfig.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Configurations
{
    using AutoMapper;
    using EUC.Profile.Buddy.Web.Api.Models.DTO;
    using EUC.Profile.Buddy.Web.Repositories.Entities;

    /// <summary>
    /// Mapper Config Class.
    /// </summary>
    public class MapperConfig : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperConfig"/> class.
        /// </summary>
        public MapperConfig()
        {
            this.CreateMap<TaskInformation, TaskInformationPostDto>()
                .ReverseMap();

            this.CreateMap<TaskInformation, TaskInformationRequestDto>()
                .ReverseMap();

            this.CreateMap<UserProfileSummary, UserProfileSummaryPostDto>()
                .ReverseMap();

            this.CreateMap<UserProfileSummary, UserProfileSummaryRequestDto>()
                .ReverseMap();
        }
    }
}

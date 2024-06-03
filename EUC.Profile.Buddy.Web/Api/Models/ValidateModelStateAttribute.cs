// <copyright file="ValidateModelStateAttribute.cs" company="bretty.me.uk">
// Copyright (c) bretty.me.uk. All rights reserved.
// </copyright>

namespace EUC.Profile.Buddy.Web.Api.Models
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    /// Model state validation attribute.
    /// </summary>
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="context">The executing context.</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}

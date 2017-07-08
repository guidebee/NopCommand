// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CategoryTemplateCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Catalog;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CategoryTemplateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CategoryTemplateCommands
    {
        /// <summary>
        /// Gets the category template by identifier.
        /// </summary>
        /// <param name="categoryTemplateId">The category template identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCategoryTemplateById(int categoryTemplateId)
        {
            var categoryTemplateService = EngineContext.Current.Resolve<ICategoryTemplateService>();
            var categoryTemplateCore = categoryTemplateService.GetCategoryTemplateById(categoryTemplateId);
            var categoryTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.CategoryTemplate>(categoryTemplateCore);
            return JsonConvert.SerializeObject(categoryTemplate, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ManufacturerTemplateCommands.cs" company="Guidebee IT">
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
    /// Class ManufacturerTemplateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ManufacturerTemplateCommands
    {
        /// <summary>
        /// Gets the manufacturer template by identifier.
        /// </summary>
        /// <param name="manufacturerTemplateId">The manufacturer template identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetManufacturerTemplateById(int manufacturerTemplateId)
        {
            var manufacturerTemplateService = EngineContext.Current.Resolve<IManufacturerTemplateService>();
            var manufacturerTemplateCore = manufacturerTemplateService.GetManufacturerTemplateById(manufacturerTemplateId);
            var manufacturerTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ManufacturerTemplate>(manufacturerTemplateCore);
            return JsonConvert.SerializeObject(manufacturerTemplate, Formatting.Indented);
        }

    }
}

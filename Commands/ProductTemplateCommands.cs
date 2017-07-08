// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ProductTemplateCommands.cs" company="Guidebee IT">
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
    /// Class ProductTemplateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ProductTemplateCommands
    {
        /// <summary>
        /// Gets the product template by identifier.
        /// </summary>
        /// <param name="productTemplateId">The product template identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductTemplateById(int productTemplateId)
        {
            var productTemplateService = EngineContext.Current.Resolve<IProductTemplateService>();
            var productTemplateCore = productTemplateService.GetProductTemplateById(productTemplateId);
            var productTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductTemplate>(productTemplateCore);
            return JsonConvert.SerializeObject(productTemplate, Formatting.Indented);
        }

    }
}

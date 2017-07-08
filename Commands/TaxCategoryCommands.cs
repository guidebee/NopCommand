// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="TaxCategoryCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Tax;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class TaxCategoryCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class TaxCategoryCommands
    {
        /// <summary>
        /// Gets the tax category by identifier.
        /// </summary>
        /// <param name="taxCategoryId">The tax category identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTaxCategoryById(int taxCategoryId)
        {
            var taxCategoryService = EngineContext.Current.Resolve<ITaxCategoryService>();
            var taxCategoryCore = taxCategoryService.GetTaxCategoryById(taxCategoryId);
            var taxCategory = AutoMapperConfiguration.Mapper.Map<Domain.Tax.TaxCategory>(taxCategoryCore);
            return JsonConvert.SerializeObject(taxCategory, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="RecentlyViewedProductsCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Catalog;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class RecentlyViewedProductsCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class RecentlyViewedProductsCommands
    {
        /// <summary>
        /// Gets the recently viewed products.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRecentlyViewedProducts(int number)
        {
            var recentlyViewedProductsService = EngineContext.Current.Resolve<IRecentlyViewedProductsService>();
            var productCore = recentlyViewedProductsService.GetRecentlyViewedProducts(number);
            var product = productCore.MapSource<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(product, Formatting.Indented);
        }


    }
}

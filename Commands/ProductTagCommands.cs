// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ProductTagCommands.cs" company="Guidebee IT">
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
    /// Class ProductTagCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ProductTagCommands
    {
        /// <summary>
        /// Gets the product tag by identifier.
        /// </summary>
        /// <param name="productTagId">The product tag identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductTagById(int productTagId)
        {
            var productTagService = EngineContext.Current.Resolve<IProductTagService>();
            var productTagCore = productTagService.GetProductTagById(productTagId);
            var productTag = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductTag>(productTagCore);
            return JsonConvert.SerializeObject(productTag, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the product tag by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductTagByName(string name)
        {
            var productTagService = EngineContext.Current.Resolve<IProductTagService>();
            var productTagCore = productTagService.GetProductTagByName(name);
            var productTag = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductTag>(productTagCore);
            return JsonConvert.SerializeObject(productTag, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product count.
        /// </summary>
        /// <param name="productTagId">The product tag identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductCount(int productTagId, int storeId)
        {
            var productTagService = EngineContext.Current.Resolve<IProductTagService>();
            var primitiveCore = productTagService.GetProductCount(productTagId, storeId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

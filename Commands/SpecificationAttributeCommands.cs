// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="SpecificationAttributeCommands.cs" company="Guidebee IT">
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
    /// Class SpecificationAttributeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class SpecificationAttributeCommands
    {
        /// <summary>
        /// Gets the specification attribute by identifier.
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSpecificationAttributeById(int specificationAttributeId)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var specificationAttributeCore = specificationAttributeService.GetSpecificationAttributeById(specificationAttributeId);
            var specificationAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.SpecificationAttribute>(specificationAttributeCore);
            return JsonConvert.SerializeObject(specificationAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the specification attributes.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSpecificationAttributes(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var specificationAttributeCore = specificationAttributeService.GetSpecificationAttributes(pageIndex, pageSize);
            var specificationAttribute = specificationAttributeCore.MapSourcePageList<Nop.Core.Domain.Catalog.SpecificationAttribute, Domain.Catalog.SpecificationAttribute>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(specificationAttribute, Formatting.Indented, new PageListConverter<Domain.Catalog.SpecificationAttribute>());
        }

        /// <summary>
        /// Gets the specification attribute option by identifier.
        /// </summary>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSpecificationAttributeOptionById(int specificationAttributeOptionId)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var specificationAttributeOptionCore = specificationAttributeService.GetSpecificationAttributeOptionById(specificationAttributeOptionId);
            var specificationAttributeOption = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.SpecificationAttributeOption>(specificationAttributeOptionCore);
            return JsonConvert.SerializeObject(specificationAttributeOption, Formatting.Indented);
        }

        /// <summary>
        /// Gets the specification attribute options by specification attribute.
        /// </summary>
        /// <param name="specificationAttributeId">The specification attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSpecificationAttributeOptionsBySpecificationAttribute(int specificationAttributeId)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var specificationAttributeOptionCore = specificationAttributeService.GetSpecificationAttributeOptionsBySpecificationAttribute(specificationAttributeId);
            var specificationAttributeOption = specificationAttributeOptionCore.MapSource<Nop.Core.Domain.Catalog.SpecificationAttributeOption, Domain.Catalog.SpecificationAttributeOption>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(specificationAttributeOption, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product specification attributes.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier.</param>
        /// <param name="allowFiltering">if set to <c>true</c> [allow filtering].</param>
        /// <param name="showOnProductPage">if set to <c>true</c> [show on product page].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductSpecificationAttributes(int productId = 0, int specificationAttributeOptionId = 0, bool? allowFiltering = null, bool? showOnProductPage = null)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var productSpecificationAttributeCore = specificationAttributeService.GetProductSpecificationAttributes(productId, specificationAttributeOptionId, allowFiltering, showOnProductPage);
            var productSpecificationAttribute = productSpecificationAttributeCore.MapSource<Nop.Core.Domain.Catalog.ProductSpecificationAttribute, Domain.Catalog.ProductSpecificationAttribute>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productSpecificationAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product specification attribute by identifier.
        /// </summary>
        /// <param name="productSpecificationAttributeId">The product specification attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductSpecificationAttributeById(int productSpecificationAttributeId)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var productSpecificationAttributeCore = specificationAttributeService.GetProductSpecificationAttributeById(productSpecificationAttributeId);
            var productSpecificationAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductSpecificationAttribute>(productSpecificationAttributeCore);
            return JsonConvert.SerializeObject(productSpecificationAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product specification attribute count.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="specificationAttributeOptionId">The specification attribute option identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductSpecificationAttributeCount(int productId = 0, int specificationAttributeOptionId = 0)
        {
            var specificationAttributeService = EngineContext.Current.Resolve<ISpecificationAttributeService>();
            var primitiveCore = specificationAttributeService.GetProductSpecificationAttributeCount(productId, specificationAttributeOptionId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

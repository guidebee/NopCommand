// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ManufacturerCommands.cs" company="Guidebee IT">
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
    /// Class ManufacturerCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ManufacturerCommands
    {
        /// <summary>
        /// Gets all manufacturers.
        /// </summary>
        /// <param name="manufacturerName">Name of the manufacturer.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllManufacturers(string manufacturerName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var manufacturerService = EngineContext.Current.Resolve<IManufacturerService>();
            var manufacturerCore = manufacturerService.GetAllManufacturers(manufacturerName, storeId, pageIndex, pageSize, showHidden);
            var manufacturer = manufacturerCore.MapSourcePageList<Nop.Core.Domain.Catalog.Manufacturer, Domain.Catalog.Manufacturer>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(manufacturer, Formatting.Indented, new PageListConverter<Domain.Catalog.Manufacturer>());
        }

        /// <summary>
        /// Gets the manufacturer by identifier.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetManufacturerById(int manufacturerId)
        {
            var manufacturerService = EngineContext.Current.Resolve<IManufacturerService>();
            var manufacturerCore = manufacturerService.GetManufacturerById(manufacturerId);
            var manufacturer = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.Manufacturer>(manufacturerCore);
            return JsonConvert.SerializeObject(manufacturer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product manufacturers by manufacturer identifier.
        /// </summary>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductManufacturersByManufacturerId(int manufacturerId, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var manufacturerService = EngineContext.Current.Resolve<IManufacturerService>();
            var productManufacturerCore = manufacturerService.GetProductManufacturersByManufacturerId(manufacturerId, pageIndex, pageSize, showHidden);
            var productManufacturer = productManufacturerCore.MapSourcePageList<Nop.Core.Domain.Catalog.ProductManufacturer, Domain.Catalog.ProductManufacturer>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productManufacturer, Formatting.Indented, new PageListConverter<Domain.Catalog.ProductManufacturer>());
        }

        /// <summary>
        /// Gets the product manufacturers by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductManufacturersByProductId(int productId, bool showHidden = false)
        {
            var manufacturerService = EngineContext.Current.Resolve<IManufacturerService>();
            var productManufacturerCore = manufacturerService.GetProductManufacturersByProductId(productId, showHidden);
            var productManufacturer = productManufacturerCore.MapSource<Nop.Core.Domain.Catalog.ProductManufacturer, Domain.Catalog.ProductManufacturer>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productManufacturer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product manufacturer by identifier.
        /// </summary>
        /// <param name="productManufacturerId">The product manufacturer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductManufacturerById(int productManufacturerId)
        {
            var manufacturerService = EngineContext.Current.Resolve<IManufacturerService>();
            var productManufacturerCore = manufacturerService.GetProductManufacturerById(productManufacturerId);
            var productManufacturer = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductManufacturer>(productManufacturerCore);
            return JsonConvert.SerializeObject(productManufacturer, Formatting.Indented);
        }

    }
}

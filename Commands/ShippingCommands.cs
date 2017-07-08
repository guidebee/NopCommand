// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ShippingCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Shipping;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ShippingCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ShippingCommands
    {
        /// <summary>
        /// Loads the name of the shipping rate computation method by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadShippingRateComputationMethodBySystemName(string systemName)
        {
            var shippingService = EngineContext.Current.Resolve<IShippingService>();
            var iShippingRateComputationMethodCore = shippingService.LoadShippingRateComputationMethodBySystemName(systemName);
            var iShippingRateComputationMethod = AutoMapperConfiguration.Mapper.Map<IShippingRateComputationMethod>(iShippingRateComputationMethodCore);
            return JsonConvert.SerializeObject(iShippingRateComputationMethod, Formatting.Indented);
        }

        /// <summary>
        /// Gets the shipping method by identifier.
        /// </summary>
        /// <param name="shippingMethodId">The shipping method identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetShippingMethodById(int shippingMethodId)
        {
            var shippingService = EngineContext.Current.Resolve<IShippingService>();
            var shippingMethodCore = shippingService.GetShippingMethodById(shippingMethodId);
            var shippingMethod = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.ShippingMethod>(shippingMethodCore);
            return JsonConvert.SerializeObject(shippingMethod, Formatting.Indented);
        }

        /// <summary>
        /// Gets all shipping methods.
        /// </summary>
        /// <param name="filterByCountryId">The filter by country identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllShippingMethods(int? filterByCountryId = null)
        {
            var shippingService = EngineContext.Current.Resolve<IShippingService>();
            var shippingMethodCore = shippingService.GetAllShippingMethods(filterByCountryId);
            var shippingMethod = shippingMethodCore.MapSource<Nop.Core.Domain.Shipping.ShippingMethod, Domain.Shipping.ShippingMethod>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(shippingMethod, Formatting.Indented);
        }

        /// <summary>
        /// Gets the warehouse by identifier.
        /// </summary>
        /// <param name="warehouseId">The warehouse identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetWarehouseById(int warehouseId)
        {
            var shippingService = EngineContext.Current.Resolve<IShippingService>();
            var warehouseCore = shippingService.GetWarehouseById(warehouseId);
            var warehouse = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.Warehouse>(warehouseCore);
            return JsonConvert.SerializeObject(warehouse, Formatting.Indented);
        }

        /// <summary>
        /// Loads the name of the pickup point provider by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadPickupPointProviderBySystemName(string systemName)
        {
            var shippingService = EngineContext.Current.Resolve<IShippingService>();
            var iPickupPointProviderCore = shippingService.LoadPickupPointProviderBySystemName(systemName);
            var iPickupPointProvider = AutoMapperConfiguration.Mapper.Map<Nop.Services.Shipping.Pickup.IPickupPointProvider>(iPickupPointProviderCore);
            return JsonConvert.SerializeObject(iPickupPointProvider, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="ShipmentCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Shipping;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ShipmentCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ShipmentCommands
    {
        /// <summary>
        /// Gets all shipments.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="warehouseId">The warehouse identifier.</param>
        /// <param name="shippingCountryId">The shipping country identifier.</param>
        /// <param name="shippingStateId">The shipping state identifier.</param>
        /// <param name="shippingCity">The shipping city.</param>
        /// <param name="trackingNumber">The tracking number.</param>
        /// <param name="loadNotShipped">if set to <c>true</c> [load not shipped].</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllShipments(int vendorId = 0, int warehouseId = 0, int shippingCountryId = 0, int shippingStateId = 0, string shippingCity = null, string trackingNumber = null, bool loadNotShipped = false, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var shipmentService = EngineContext.Current.Resolve<IShipmentService>();
            var shipmentCore = shipmentService.GetAllShipments(vendorId, warehouseId, shippingCountryId, shippingStateId, shippingCity, trackingNumber, loadNotShipped, createdFromUtc, createdToUtc, pageIndex, pageSize);
            var shipment = shipmentCore.MapSourcePageList<Nop.Core.Domain.Shipping.Shipment, Domain.Shipping.Shipment>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(shipment, Formatting.Indented, new PageListConverter<Domain.Shipping.Shipment>());
        }

        /// <summary>
        /// Gets the shipment by identifier.
        /// </summary>
        /// <param name="shipmentId">The shipment identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetShipmentById(int shipmentId)
        {
            var shipmentService = EngineContext.Current.Resolve<IShipmentService>();
            var shipmentCore = shipmentService.GetShipmentById(shipmentId);
            var shipment = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.Shipment>(shipmentCore);
            return JsonConvert.SerializeObject(shipment, Formatting.Indented);
        }

        /// <summary>
        /// Gets the shipment item by identifier.
        /// </summary>
        /// <param name="shipmentItemId">The shipment item identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetShipmentItemById(int shipmentItemId)
        {
            var shipmentService = EngineContext.Current.Resolve<IShipmentService>();
            var shipmentItemCore = shipmentService.GetShipmentItemById(shipmentItemId);
            var shipmentItem = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.ShipmentItem>(shipmentItemCore);
            return JsonConvert.SerializeObject(shipmentItem, Formatting.Indented);
        }

    }
}

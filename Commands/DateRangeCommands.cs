// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="DateRangeCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Shipping.Date;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class DateRangeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class DateRangeCommands
    {
        /// <summary>
        /// Gets the delivery date by identifier.
        /// </summary>
        /// <param name="deliveryDateId">The delivery date identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDeliveryDateById(int deliveryDateId)
        {
            var dateRangeService = EngineContext.Current.Resolve<IDateRangeService>();
            var deliveryDateCore = dateRangeService.GetDeliveryDateById(deliveryDateId);
            var deliveryDate = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.DeliveryDate>(deliveryDateCore);
            return JsonConvert.SerializeObject(deliveryDate, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product availability range by identifier.
        /// </summary>
        /// <param name="productAvailabilityRangeId">The product availability range identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductAvailabilityRangeById(int productAvailabilityRangeId)
        {
            var dateRangeService = EngineContext.Current.Resolve<IDateRangeService>();
            var productAvailabilityRangeCore = dateRangeService.GetProductAvailabilityRangeById(productAvailabilityRangeId);
            var productAvailabilityRange = AutoMapperConfiguration.Mapper.Map<Domain.Shipping.ProductAvailabilityRange>(productAvailabilityRangeCore);
            return JsonConvert.SerializeObject(productAvailabilityRange, Formatting.Indented);
        }

    }
}

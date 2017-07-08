// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CheckoutAttributeCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CheckoutAttributeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CheckoutAttributeCommands
    {
        /// <summary>
        /// Gets all checkout attributes.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="excludeShippableAttributes">if set to <c>true</c> [exclude shippable attributes].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCheckoutAttributes(int storeId = 0, bool excludeShippableAttributes = false)
        {
            var checkoutAttributeService = EngineContext.Current.Resolve<ICheckoutAttributeService>();
            var checkoutAttributeCore = checkoutAttributeService.GetAllCheckoutAttributes(storeId, excludeShippableAttributes);
            var checkoutAttribute = checkoutAttributeCore.MapSource<Nop.Core.Domain.Orders.CheckoutAttribute, Domain.Orders.CheckoutAttribute>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(checkoutAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the checkout attribute by identifier.
        /// </summary>
        /// <param name="checkoutAttributeId">The checkout attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCheckoutAttributeById(int checkoutAttributeId)
        {
            var checkoutAttributeService = EngineContext.Current.Resolve<ICheckoutAttributeService>();
            var checkoutAttributeCore = checkoutAttributeService.GetCheckoutAttributeById(checkoutAttributeId);
            var checkoutAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Orders.CheckoutAttribute>(checkoutAttributeCore);
            return JsonConvert.SerializeObject(checkoutAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the checkout attribute values.
        /// </summary>
        /// <param name="checkoutAttributeId">The checkout attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCheckoutAttributeValues(int checkoutAttributeId)
        {
            var checkoutAttributeService = EngineContext.Current.Resolve<ICheckoutAttributeService>();
            var checkoutAttributeValueCore = checkoutAttributeService.GetCheckoutAttributeValues(checkoutAttributeId);
            var checkoutAttributeValue = checkoutAttributeValueCore.MapSource<Nop.Core.Domain.Orders.CheckoutAttributeValue, Domain.Orders.CheckoutAttributeValue>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(checkoutAttributeValue, Formatting.Indented);
        }

        /// <summary>
        /// Gets the checkout attribute value by identifier.
        /// </summary>
        /// <param name="checkoutAttributeValueId">The checkout attribute value identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCheckoutAttributeValueById(int checkoutAttributeValueId)
        {
            var checkoutAttributeService = EngineContext.Current.Resolve<ICheckoutAttributeService>();
            var checkoutAttributeValueCore = checkoutAttributeService.GetCheckoutAttributeValueById(checkoutAttributeValueId);
            var checkoutAttributeValue = AutoMapperConfiguration.Mapper.Map<Domain.Orders.CheckoutAttributeValue>(checkoutAttributeValueCore);
            return JsonConvert.SerializeObject(checkoutAttributeValue, Formatting.Indented);
        }

    }
}

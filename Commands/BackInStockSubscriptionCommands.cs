// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="BackInStockSubscriptionCommands.cs" company="Guidebee IT">
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
    /// Class BackInStockSubscriptionCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class BackInStockSubscriptionCommands
    {
        /// <summary>
        /// Gets all subscriptions by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllSubscriptionsByCustomerId(int customerId,int storeId = 0,int pageIndex = 0,int pageSize = int.MaxValue)
        {
            var backInStockSubscriptionService = EngineContext.Current.Resolve<IBackInStockSubscriptionService>();
            var backInStockSubscriptionCore = backInStockSubscriptionService.GetAllSubscriptionsByCustomerId( customerId, storeId, pageIndex, pageSize);
            var backInStockSubscription = backInStockSubscriptionCore.MapSourcePageList<Nop.Core.Domain.Catalog.BackInStockSubscription, Domain.Catalog.BackInStockSubscription> (AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(backInStockSubscription, Formatting.Indented, new PageListConverter<Domain.Catalog.BackInStockSubscription>());
        }

        /// <summary>
        /// Gets all subscriptions by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllSubscriptionsByProductId(int productId,int storeId = 0,int pageIndex = 0,int pageSize = int.MaxValue)
        {
            var backInStockSubscriptionService = EngineContext.Current.Resolve<IBackInStockSubscriptionService>();
            var backInStockSubscriptionCore = backInStockSubscriptionService.GetAllSubscriptionsByProductId( productId, storeId, pageIndex, pageSize);
            var backInStockSubscription = backInStockSubscriptionCore.MapSourcePageList<Nop.Core.Domain.Catalog.BackInStockSubscription, Domain.Catalog.BackInStockSubscription> (AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(backInStockSubscription, Formatting.Indented, new PageListConverter<Domain.Catalog.BackInStockSubscription>());
        }

        /// <summary>
        /// Finds the subscription.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string FindSubscription(int customerId,int productId,int storeId)
        {
            var backInStockSubscriptionService = EngineContext.Current.Resolve<IBackInStockSubscriptionService>();
            var backInStockSubscriptionCore = backInStockSubscriptionService.FindSubscription( customerId, productId, storeId);
            var backInStockSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.BackInStockSubscription>(backInStockSubscriptionCore);
            return JsonConvert.SerializeObject(backInStockSubscription, Formatting.Indented);
        }

        /// <summary>
        /// Gets the subscription by identifier.
        /// </summary>
        /// <param name="subscriptionId">The subscription identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSubscriptionById(int subscriptionId)
        {
            var backInStockSubscriptionService = EngineContext.Current.Resolve<IBackInStockSubscriptionService>();
            var backInStockSubscriptionCore = backInStockSubscriptionService.GetSubscriptionById( subscriptionId);
            var backInStockSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.BackInStockSubscription>(backInStockSubscriptionCore);
            return JsonConvert.SerializeObject(backInStockSubscription, Formatting.Indented);
        }

    }
}

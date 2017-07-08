// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="NewsLetterSubscriptionCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Messages;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class NewsLetterSubscriptionCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class NewsLetterSubscriptionCommands
    {
        /// <summary>
        /// Gets the news letter subscription by identifier.
        /// </summary>
        /// <param name="newsLetterSubscriptionId">The news letter subscription identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNewsLetterSubscriptionById(int newsLetterSubscriptionId)
        {
            var newsLetterSubscriptionService = EngineContext.Current.Resolve<INewsLetterSubscriptionService>();
            var newsLetterSubscriptionCore = newsLetterSubscriptionService.GetNewsLetterSubscriptionById(newsLetterSubscriptionId);
            var newsLetterSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Messages.NewsLetterSubscription>(newsLetterSubscriptionCore);
            return JsonConvert.SerializeObject(newsLetterSubscription, Formatting.Indented);
        }

        /// <summary>
        /// Gets the news letter subscription by unique identifier.
        /// </summary>
        /// <param name="newsLetterSubscriptionGuid">The news letter subscription unique identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNewsLetterSubscriptionByGuid(Guid newsLetterSubscriptionGuid)
        {
            var newsLetterSubscriptionService = EngineContext.Current.Resolve<INewsLetterSubscriptionService>();
            var newsLetterSubscriptionCore = newsLetterSubscriptionService.GetNewsLetterSubscriptionByGuid(newsLetterSubscriptionGuid);
            var newsLetterSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Messages.NewsLetterSubscription>(newsLetterSubscriptionCore);
            return JsonConvert.SerializeObject(newsLetterSubscription, Formatting.Indented);
        }

        /// <summary>
        /// Gets the news letter subscription by email and store identifier.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNewsLetterSubscriptionByEmailAndStoreId(string email, int storeId)
        {
            var newsLetterSubscriptionService = EngineContext.Current.Resolve<INewsLetterSubscriptionService>();
            var newsLetterSubscriptionCore = newsLetterSubscriptionService.GetNewsLetterSubscriptionByEmailAndStoreId(email, storeId);
            var newsLetterSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Messages.NewsLetterSubscription>(newsLetterSubscriptionCore);
            return JsonConvert.SerializeObject(newsLetterSubscription, Formatting.Indented);
        }

        /// <summary>
        /// Gets all news letter subscriptions.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="customerRoleId">The customer role identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllNewsLetterSubscriptions(string email = null, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int storeId = 0, bool? isActive = null, int customerRoleId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var newsLetterSubscriptionService = EngineContext.Current.Resolve<INewsLetterSubscriptionService>();
            var newsLetterSubscriptionCore = newsLetterSubscriptionService.GetAllNewsLetterSubscriptions(email, createdFromUtc, createdToUtc, storeId, isActive, customerRoleId, pageIndex, pageSize);
            var newsLetterSubscription = newsLetterSubscriptionCore.MapSourcePageList<Nop.Core.Domain.Messages.NewsLetterSubscription, Domain.Messages.NewsLetterSubscription>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(newsLetterSubscription, Formatting.Indented, new PageListConverter<Domain.Messages.NewsLetterSubscription>());
        }

    }
}

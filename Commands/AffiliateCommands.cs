// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="AffiliateCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Affiliates;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class AffiliateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class AffiliateCommands
    {
        /// <summary>
        /// Gets the affiliate by identifier.
        /// </summary>
        /// <param name="affiliateId">The affiliate identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAffiliateById(int affiliateId)
        {
            var affiliateService = EngineContext.Current.Resolve<IAffiliateService>();
            var affiliateCore = affiliateService.GetAffiliateById(affiliateId);
            var affiliate = AutoMapperConfiguration.Mapper.Map<Domain.Affiliates.Affiliate>(affiliateCore);
            return JsonConvert.SerializeObject(affiliate, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the affiliate by friendly URL.
        /// </summary>
        /// <param name="friendlyUrlName">Name of the friendly URL.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAffiliateByFriendlyUrlName(string friendlyUrlName)
        {
            var affiliateService = EngineContext.Current.Resolve<IAffiliateService>();
            var affiliateCore = affiliateService.GetAffiliateByFriendlyUrlName(friendlyUrlName);
            var affiliate = AutoMapperConfiguration.Mapper.Map<Domain.Affiliates.Affiliate>(affiliateCore);
            return JsonConvert.SerializeObject(affiliate, Formatting.Indented);
        }

        /// <summary>
        /// Gets all affiliates.
        /// </summary>
        /// <param name="friendlyUrlName">Name of the friendly URL.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="loadOnlyWithOrders">if set to <c>true</c> [load only with orders].</param>
        /// <param name="ordersCreatedFromUtc">The orders created from UTC.</param>
        /// <param name="ordersCreatedToUtc">The orders created to UTC.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllAffiliates(string friendlyUrlName = null, string firstName = null, string lastName = null, bool loadOnlyWithOrders = false, DateTime? ordersCreatedFromUtc = null, DateTime? ordersCreatedToUtc = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var affiliateService = EngineContext.Current.Resolve<IAffiliateService>();
            var affiliateCore = affiliateService.GetAllAffiliates(friendlyUrlName, firstName, lastName, loadOnlyWithOrders, ordersCreatedFromUtc, ordersCreatedToUtc, pageIndex, pageSize, showHidden);
            var affiliate = affiliateCore.MapSourcePageList<Nop.Core.Domain.Affiliates.Affiliate, Domain.Affiliates.Affiliate>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(affiliate, Formatting.Indented, new PageListConverter<Domain.Affiliates.Affiliate>());
        }

    }
}

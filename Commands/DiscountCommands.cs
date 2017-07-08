// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="DiscountCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Domain.Discounts;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Discounts;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class DiscountCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class DiscountCommands
    {
        /// <summary>
        /// Gets the discount by identifier.
        /// </summary>
        /// <param name="discountId">The discount identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDiscountById(int discountId)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountCore = discountService.GetDiscountById(discountId);
            var discount = AutoMapperConfiguration.Mapper.Map<Domain.Discounts.Discount>(discountCore);
            return JsonConvert.SerializeObject(discount, Formatting.Indented);
        }

        /// <summary>
        /// Gets all discounts.
        /// </summary>
        /// <param name="discountType">Type of the discount.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <param name="discountName">Name of the discount.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllDiscounts(DiscountType? discountType = null, string couponCode = "", string discountName = "", bool showHidden = false)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountCore = discountService.GetAllDiscounts(discountType, couponCode, discountName, showHidden);
            var discount = discountCore.MapSource<Discount, Domain.Discounts.Discount>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(discount, Formatting.Indented);
        }

        /// <summary>
        /// Gets all discounts for caching.
        /// </summary>
        /// <param name="discountType">Type of the discount.</param>
        /// <param name="couponCode">The coupon code.</param>
        /// <param name="discountName">Name of the discount.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllDiscountsForCaching(DiscountType? discountType = null, string couponCode = "", string discountName = "", bool showHidden = false)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountForCachingCore = discountService.GetAllDiscountsForCaching(discountType, couponCode, discountName, showHidden);
            var discountForCaching = discountForCachingCore.MapSource<DiscountForCaching, DiscountForCaching>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(discountForCaching, Formatting.Indented);
        }

        /// <summary>
        /// Gets all discount requirements.
        /// </summary>
        /// <param name="discountId">The discount identifier.</param>
        /// <param name="topLevelOnly">if set to <c>true</c> [top level only].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllDiscountRequirements(int discountId = 0, bool topLevelOnly = false)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountRequirementCore = discountService.GetAllDiscountRequirements(discountId, topLevelOnly);
            var discountRequirement = discountRequirementCore.MapSource<DiscountRequirement, Domain.Discounts.DiscountRequirement>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(discountRequirement, Formatting.Indented);
        }

        /// <summary>
        /// Loads the name of the discount requirement rule by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadDiscountRequirementRuleBySystemName(string systemName)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var iDiscountRequirementRuleCore = discountService.LoadDiscountRequirementRuleBySystemName(systemName);
            var iDiscountRequirementRule = AutoMapperConfiguration.Mapper.Map<IDiscountRequirementRule>(iDiscountRequirementRuleCore);
            return JsonConvert.SerializeObject(iDiscountRequirementRule, Formatting.Indented);
        }

        /// <summary>
        /// Gets the discount usage history by identifier.
        /// </summary>
        /// <param name="discountUsageHistoryId">The discount usage history identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountUsageHistoryCore = discountService.GetDiscountUsageHistoryById(discountUsageHistoryId);
            var discountUsageHistory = AutoMapperConfiguration.Mapper.Map<Domain.Discounts.DiscountUsageHistory>(discountUsageHistoryCore);
            return JsonConvert.SerializeObject(discountUsageHistory, Formatting.Indented);
        }

        /// <summary>
        /// Gets all discount usage history.
        /// </summary>
        /// <param name="discountId">The discount identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllDiscountUsageHistory(int? discountId = null, int? customerId = null, int? orderId = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var discountService = EngineContext.Current.Resolve<IDiscountService>();
            var discountUsageHistoryCore = discountService.GetAllDiscountUsageHistory(discountId, customerId, orderId, pageIndex, pageSize);
            var discountUsageHistory = discountUsageHistoryCore.MapSourcePageList<DiscountUsageHistory, Domain.Discounts.DiscountUsageHistory>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(discountUsageHistory, Formatting.Indented, new PageListConverter<Domain.Discounts.DiscountUsageHistory>());
        }

    }
}

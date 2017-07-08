// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="GiftCardCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class GiftCardCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class GiftCardCommands
    {
        /// <summary>
        /// Gets the gift card by identifier.
        /// </summary>
        /// <param name="giftCardId">The gift card identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetGiftCardById(int giftCardId)
        {
            var giftCardService = EngineContext.Current.Resolve<IGiftCardService>();
            var giftCardCore = giftCardService.GetGiftCardById(giftCardId);
            var giftCard = AutoMapperConfiguration.Mapper.Map<Domain.Orders.GiftCard>(giftCardCore);
            return JsonConvert.SerializeObject(giftCard, Formatting.Indented);
        }

        /// <summary>
        /// Gets all gift cards.
        /// </summary>
        /// <param name="purchasedWithOrderId">The purchased with order identifier.</param>
        /// <param name="usedWithOrderId">The used with order identifier.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="isGiftCardActivated">if set to <c>true</c> [is gift card activated].</param>
        /// <param name="giftCardCouponCode">The gift card coupon code.</param>
        /// <param name="recipientName">Name of the recipient.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllGiftCards(int? purchasedWithOrderId = null, int? usedWithOrderId = null, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, bool? isGiftCardActivated = null, string giftCardCouponCode = null, string recipientName = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var giftCardService = EngineContext.Current.Resolve<IGiftCardService>();
            var giftCardCore = giftCardService.GetAllGiftCards(purchasedWithOrderId, usedWithOrderId, createdFromUtc, createdToUtc, isGiftCardActivated, giftCardCouponCode, recipientName, pageIndex, pageSize);
            var giftCard = giftCardCore.MapSourcePageList<Nop.Core.Domain.Orders.GiftCard, Domain.Orders.GiftCard>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(giftCard, Formatting.Indented, new PageListConverter<Domain.Orders.GiftCard>());
        }

        /// <summary>
        /// Gets the gift cards by purchased with order item identifier.
        /// </summary>
        /// <param name="purchasedWithOrderItemId">The purchased with order item identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetGiftCardsByPurchasedWithOrderItemId(int purchasedWithOrderItemId)
        {
            var giftCardService = EngineContext.Current.Resolve<IGiftCardService>();
            var giftCardCore = giftCardService.GetGiftCardsByPurchasedWithOrderItemId(purchasedWithOrderItemId);
            var giftCard = giftCardCore.MapSource<Nop.Core.Domain.Orders.GiftCard, Domain.Orders.GiftCard>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(giftCard, Formatting.Indented);
        }

    }
}

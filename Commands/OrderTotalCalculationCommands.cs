// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="OrderTotalCalculationCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class OrderTotalCalculationCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class OrderTotalCalculationCommands
    {
        /// <summary>
        /// Converts the reward points to amount.
        /// </summary>
        /// <param name="rewardPoints">The reward points.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ConvertRewardPointsToAmount(int rewardPoints)
        {
            var orderTotalCalculationService = EngineContext.Current.Resolve<IOrderTotalCalculationService>();
            var primitiveCore = orderTotalCalculationService.ConvertRewardPointsToAmount(rewardPoints);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Converts the amount to reward points.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ConvertAmountToRewardPoints(decimal amount)
        {
            var orderTotalCalculationService = EngineContext.Current.Resolve<IOrderTotalCalculationService>();
            var primitiveCore = orderTotalCalculationService.ConvertAmountToRewardPoints(amount);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Checks the minimum reward points to use requirement.
        /// </summary>
        /// <param name="rewardPoints">The reward points.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string CheckMinimumRewardPointsToUseRequirement(int rewardPoints)
        {
            var orderTotalCalculationService = EngineContext.Current.Resolve<IOrderTotalCalculationService>();
            var primitiveCore = orderTotalCalculationService.CheckMinimumRewardPointsToUseRequirement(rewardPoints);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Calculates the applicable order total for reward points.
        /// </summary>
        /// <param name="orderShippingInclTax">The order shipping incl tax.</param>
        /// <param name="orderTotal">The order total.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string CalculateApplicableOrderTotalForRewardPoints(decimal orderShippingInclTax, decimal orderTotal)
        {
            var orderTotalCalculationService = EngineContext.Current.Resolve<IOrderTotalCalculationService>();
            var primitiveCore = orderTotalCalculationService.CalculateApplicableOrderTotalForRewardPoints(orderShippingInclTax, orderTotal);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

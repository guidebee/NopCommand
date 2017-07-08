// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="RewardPointCommands.cs" company="Guidebee IT">
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
    /// Class RewardPointCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class RewardPointCommands
    {
        /// <summary>
        /// Gets the reward points history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <param name="showNotActivated">if set to <c>true</c> [show not activated].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRewardPointsHistory(int customerId = 0, bool showHidden = false, bool showNotActivated = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var rewardPointService = EngineContext.Current.Resolve<IRewardPointService>();
            var rewardPointsHistoryCore = rewardPointService.GetRewardPointsHistory(customerId, showHidden, showNotActivated, pageIndex, pageSize);
            var rewardPointsHistory = rewardPointsHistoryCore.MapSourcePageList<Nop.Core.Domain.Customers.RewardPointsHistory, Domain.Customers.RewardPointsHistory>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(rewardPointsHistory, Formatting.Indented, new PageListConverter<Domain.Customers.RewardPointsHistory>());
        }

        /// <summary>
        /// Gets the reward points balance.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRewardPointsBalance(int customerId, int storeId)
        {
            var rewardPointService = EngineContext.Current.Resolve<IRewardPointService>();
            var primitiveCore = rewardPointService.GetRewardPointsBalance(customerId, storeId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the reward points history entry by identifier.
        /// </summary>
        /// <param name="rewardPointsHistoryId">The reward points history identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRewardPointsHistoryEntryById(int rewardPointsHistoryId)
        {
            var rewardPointService = EngineContext.Current.Resolve<IRewardPointService>();
            var rewardPointsHistoryCore = rewardPointService.GetRewardPointsHistoryEntryById(rewardPointsHistoryId);
            var rewardPointsHistory = AutoMapperConfiguration.Mapper.Map<Domain.Customers.RewardPointsHistory>(rewardPointsHistoryCore);
            return JsonConvert.SerializeObject(rewardPointsHistory, Formatting.Indented);
        }

    }
}

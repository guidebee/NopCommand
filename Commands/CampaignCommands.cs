// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CampaignCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Messages;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CampaignCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CampaignCommands
    {
        /// <summary>
        /// Gets the campaign by identifier.
        /// </summary>
        /// <param name="campaignId">The campaign identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCampaignById(int campaignId)
        {
            var campaignService = EngineContext.Current.Resolve<ICampaignService>();
            var campaignCore = campaignService.GetCampaignById(campaignId);
            var campaign = AutoMapperConfiguration.Mapper.Map<Domain.Messages.Campaign>(campaignCore);
            return JsonConvert.SerializeObject(campaign, Formatting.Indented);
        }

        /// <summary>
        /// Gets all campaigns.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCampaigns(int storeId = 0)
        {
            var campaignService = EngineContext.Current.Resolve<ICampaignService>();
            var campaignCore = campaignService.GetAllCampaigns(storeId);
            var campaign = campaignCore.MapSource<Nop.Core.Domain.Messages.Campaign, Domain.Messages.Campaign>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(campaign, Formatting.Indented);
        }

    }
}

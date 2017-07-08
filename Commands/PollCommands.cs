// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="PollCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Polls;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class PollCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class PollCommands
    {
        /// <summary>
        /// Gets the poll by identifier.
        /// </summary>
        /// <param name="pollId">The poll identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPollById(int pollId)
        {
            var pollService = EngineContext.Current.Resolve<IPollService>();
            var pollCore = pollService.GetPollById(pollId);
            var poll = AutoMapperConfiguration.Mapper.Map<Domain.Polls.Poll>(pollCore);
            return JsonConvert.SerializeObject(poll, Formatting.Indented);
        }

        /// <summary>
        /// Gets the polls.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="loadShownOnHomePageOnly">if set to <c>true</c> [load shown on home page only].</param>
        /// <param name="systemKeyword">The system keyword.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPolls(int languageId = 0, bool loadShownOnHomePageOnly = false, string systemKeyword = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var pollService = EngineContext.Current.Resolve<IPollService>();
            var pollCore = pollService.GetPolls(languageId, loadShownOnHomePageOnly, systemKeyword, pageIndex, pageSize, showHidden);
            var poll = pollCore.MapSourcePageList<Nop.Core.Domain.Polls.Poll, Domain.Polls.Poll>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(poll, Formatting.Indented, new PageListConverter<Domain.Polls.Poll>());
        }

        /// <summary>
        /// Gets the poll answer by identifier.
        /// </summary>
        /// <param name="pollAnswerId">The poll answer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPollAnswerById(int pollAnswerId)
        {
            var pollService = EngineContext.Current.Resolve<IPollService>();
            var pollAnswerCore = pollService.GetPollAnswerById(pollAnswerId);
            var pollAnswer = AutoMapperConfiguration.Mapper.Map<Domain.Polls.PollAnswer>(pollAnswerCore);
            return JsonConvert.SerializeObject(pollAnswer, Formatting.Indented);
        }

        /// <summary>
        /// Alreadies the voted.
        /// </summary>
        /// <param name="pollId">The poll identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string AlreadyVoted(int pollId, int customerId)
        {
            var pollService = EngineContext.Current.Resolve<IPollService>();
            var primitiveCore = pollService.AlreadyVoted(pollId, customerId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="QueuedEmailCommands.cs" company="Guidebee IT">
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
    /// Class QueuedEmailCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class QueuedEmailCommands
    {
        /// <summary>
        /// Gets the queued email by identifier.
        /// </summary>
        /// <param name="queuedEmailId">The queued email identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetQueuedEmailById(int queuedEmailId)
        {
            var queuedEmailService = EngineContext.Current.Resolve<IQueuedEmailService>();
            var queuedEmailCore = queuedEmailService.GetQueuedEmailById(queuedEmailId);
            var queuedEmail = AutoMapperConfiguration.Mapper.Map<Domain.Messages.QueuedEmail>(queuedEmailCore);
            return JsonConvert.SerializeObject(queuedEmail, Formatting.Indented);
        }

        /// <summary>
        /// Searches the emails.
        /// </summary>
        /// <param name="fromEmail">From email.</param>
        /// <param name="toEmail">To email.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="loadNotSentItemsOnly">if set to <c>true</c> [load not sent items only].</param>
        /// <param name="loadOnlyItemsToBeSent">if set to <c>true</c> [load only items to be sent].</param>
        /// <param name="maxSendTries">The maximum send tries.</param>
        /// <param name="loadNewest">if set to <c>true</c> [load newest].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SearchEmails(string fromEmail, string toEmail, DateTime? createdFromUtc, DateTime? createdToUtc, bool loadNotSentItemsOnly, bool loadOnlyItemsToBeSent, int maxSendTries, bool loadNewest, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var queuedEmailService = EngineContext.Current.Resolve<IQueuedEmailService>();
            var queuedEmailCore = queuedEmailService.SearchEmails(fromEmail, toEmail, createdFromUtc, createdToUtc, loadNotSentItemsOnly, loadOnlyItemsToBeSent, maxSendTries, loadNewest, pageIndex, pageSize);
            var queuedEmail = queuedEmailCore.MapSourcePageList<Nop.Core.Domain.Messages.QueuedEmail, Domain.Messages.QueuedEmail>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(queuedEmail, Formatting.Indented, new PageListConverter<Domain.Messages.QueuedEmail>());
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="MessageTemplateCommands.cs" company="Guidebee IT">
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
    /// Class MessageTemplateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class MessageTemplateCommands
    {
        /// <summary>
        /// Gets the message template by identifier.
        /// </summary>
        /// <param name="messageTemplateId">The message template identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMessageTemplateById(int messageTemplateId)
        {
            var messageTemplateService = EngineContext.Current.Resolve<IMessageTemplateService>();
            var messageTemplateCore = messageTemplateService.GetMessageTemplateById(messageTemplateId);
            var messageTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Messages.MessageTemplate>(messageTemplateCore);
            return JsonConvert.SerializeObject(messageTemplate, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the message template by.
        /// </summary>
        /// <param name="messageTemplateName">Name of the message template.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMessageTemplateByName(string messageTemplateName, int storeId)
        {
            var messageTemplateService = EngineContext.Current.Resolve<IMessageTemplateService>();
            var messageTemplateCore = messageTemplateService.GetMessageTemplateByName(messageTemplateName, storeId);
            var messageTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Messages.MessageTemplate>(messageTemplateCore);
            return JsonConvert.SerializeObject(messageTemplate, Formatting.Indented);
        }

        /// <summary>
        /// Gets all message templates.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllMessageTemplates(int storeId)
        {
            var messageTemplateService = EngineContext.Current.Resolve<IMessageTemplateService>();
            var messageTemplateCore = messageTemplateService.GetAllMessageTemplates(storeId);
            var messageTemplate = messageTemplateCore.MapSource<Nop.Core.Domain.Messages.MessageTemplate, Domain.Messages.MessageTemplate>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(messageTemplate, Formatting.Indented);
        }

    }
}

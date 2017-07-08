// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="TopicTemplateCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Topics;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class TopicTemplateCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class TopicTemplateCommands
    {
        /// <summary>
        /// Gets the topic template by identifier.
        /// </summary>
        /// <param name="topicTemplateId">The topic template identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTopicTemplateById(int topicTemplateId)
        {
            var topicTemplateService = EngineContext.Current.Resolve<ITopicTemplateService>();
            var topicTemplateCore = topicTemplateService.GetTopicTemplateById(topicTemplateId);
            var topicTemplate = AutoMapperConfiguration.Mapper.Map<Domain.Topics.TopicTemplate>(topicTemplateCore);
            return JsonConvert.SerializeObject(topicTemplate, Formatting.Indented);
        }

    }
}

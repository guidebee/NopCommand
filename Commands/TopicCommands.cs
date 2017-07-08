// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="TopicCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Topics;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class TopicCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class TopicCommands
    {
        /// <summary>
        /// Gets the topic by identifier.
        /// </summary>
        /// <param name="topicId">The topic identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTopicById(int topicId)
        {
            var topicService = EngineContext.Current.Resolve<ITopicService>();
            var topicCore = topicService.GetTopicById(topicId);
            var topic = AutoMapperConfiguration.Mapper.Map<Domain.Topics.Topic>(topicCore);
            return JsonConvert.SerializeObject(topic, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the topic by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTopicBySystemName(string systemName, int storeId = 0)
        {
            var topicService = EngineContext.Current.Resolve<ITopicService>();
            var topicCore = topicService.GetTopicBySystemName(systemName, storeId);
            var topic = AutoMapperConfiguration.Mapper.Map<Domain.Topics.Topic>(topicCore);
            return JsonConvert.SerializeObject(topic, Formatting.Indented);
        }

        /// <summary>
        /// Gets all topics.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="ignorAcl">if set to <c>true</c> [ignor acl].</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllTopics(int storeId, bool ignorAcl = false, bool showHidden = false)
        {
            var topicService = EngineContext.Current.Resolve<ITopicService>();
            var topicCore = topicService.GetAllTopics(storeId, ignorAcl, showHidden);
            var topic = topicCore.MapSource<Nop.Core.Domain.Topics.Topic, Domain.Topics.Topic>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(topic, Formatting.Indented);
        }

    }
}

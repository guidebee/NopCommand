// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ForumCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Domain.Forums;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Forums;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ForumCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ForumCommands
    {
        /// <summary>
        /// Gets the forum group by identifier.
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetForumGroupById(int forumGroupId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumGroupCore = forumService.GetForumGroupById(forumGroupId);
            var forumGroup = AutoMapperConfiguration.Mapper.Map<Domain.Forums.ForumGroup>(forumGroupCore);
            return JsonConvert.SerializeObject(forumGroup, Formatting.Indented);
        }

        /// <summary>
        /// Gets the forum by identifier.
        /// </summary>
        /// <param name="forumId">The forum identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetForumById(int forumId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumCore = forumService.GetForumById(forumId);
            var forum = AutoMapperConfiguration.Mapper.Map<Domain.Forums.Forum>(forumCore);
            return JsonConvert.SerializeObject(forum, Formatting.Indented);
        }

        /// <summary>
        /// Gets all forums by group identifier.
        /// </summary>
        /// <param name="forumGroupId">The forum group identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllForumsByGroupId(int forumGroupId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumCore = forumService.GetAllForumsByGroupId(forumGroupId);
            var forum = forumCore.MapSource<Forum, Domain.Forums.Forum>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(forum, Formatting.Indented);
        }


        /// <summary>
        /// Gets the topic by identifier.
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier.</param>
        /// <param name="increaseViews">if set to <c>true</c> [increase views].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTopicById(int forumTopicId, bool increaseViews = false)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumTopicCore = forumService.GetTopicById(forumTopicId, increaseViews);
            var forumTopic = AutoMapperConfiguration.Mapper.Map<Domain.Forums.ForumTopic>(forumTopicCore);
            return JsonConvert.SerializeObject(forumTopic, Formatting.Indented);
        }

        /// <summary>
        /// Gets all topics.
        /// </summary>
        /// <param name="forumId">The forum identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="keywords">The keywords.</param>
        /// <param name="searchType">Type of the search.</param>
        /// <param name="limitDays">The limit days.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllTopics(int forumId = 0, int customerId = 0, string keywords = "", ForumSearchType searchType = ForumSearchType.All, int limitDays = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumTopicCore = forumService.GetAllTopics(forumId, customerId, keywords, searchType, limitDays, pageIndex, pageSize);
            var forumTopic = forumTopicCore.MapSourcePageList<ForumTopic, Domain.Forums.ForumTopic>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(forumTopic, Formatting.Indented, new PageListConverter<Domain.Forums.ForumTopic>());
        }

        /// <summary>
        /// Gets the active topics.
        /// </summary>
        /// <param name="forumId">The forum identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetActiveTopics(int forumId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumTopicCore = forumService.GetActiveTopics(forumId, pageIndex, pageSize);
            var forumTopic = forumTopicCore.MapSourcePageList<ForumTopic, Domain.Forums.ForumTopic>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(forumTopic, Formatting.Indented, new PageListConverter<Domain.Forums.ForumTopic>());
        }

        /// <summary>
        /// Moves the topic.
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier.</param>
        /// <param name="newForumId">The new forum identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string MoveTopic(int forumTopicId, int newForumId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumTopicCore = forumService.MoveTopic(forumTopicId, newForumId);
            var forumTopic = AutoMapperConfiguration.Mapper.Map<Domain.Forums.ForumTopic>(forumTopicCore);
            return JsonConvert.SerializeObject(forumTopic, Formatting.Indented);
        }

        /// <summary>
        /// Gets the post by identifier.
        /// </summary>
        /// <param name="forumPostId">The forum post identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPostById(int forumPostId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumPostCore = forumService.GetPostById(forumPostId);
            var forumPost = AutoMapperConfiguration.Mapper.Map<Domain.Forums.ForumPost>(forumPostCore);
            return JsonConvert.SerializeObject(forumPost, Formatting.Indented);
        }


        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="keywords">The keywords.</param>
        /// <param name="ascSort">if set to <c>true</c> [asc sort].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllPosts(int forumTopicId = 0, int customerId = 0, string keywords = "", bool ascSort = false, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumPostCore = forumService.GetAllPosts(forumTopicId, customerId, keywords, ascSort, pageIndex, pageSize);
            var forumPost = forumPostCore.MapSourcePageList<ForumPost, Domain.Forums.ForumPost>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(forumPost, Formatting.Indented, new PageListConverter<Domain.Forums.ForumPost>());
        }

        /// <summary>
        /// Gets the private message by identifier.
        /// </summary>
        /// <param name="privateMessageId">The private message identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPrivateMessageById(int privateMessageId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var privateMessageCore = forumService.GetPrivateMessageById(privateMessageId);
            var privateMessage = AutoMapperConfiguration.Mapper.Map<Domain.Forums.PrivateMessage>(privateMessageCore);
            return JsonConvert.SerializeObject(privateMessage, Formatting.Indented);
        }

        /// <summary>
        /// Gets all private messages.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="fromCustomerId">From customer identifier.</param>
        /// <param name="toCustomerId">To customer identifier.</param>
        /// <param name="isRead">if set to <c>true</c> [is read].</param>
        /// <param name="isDeletedByAuthor">if set to <c>true</c> [is deleted by author].</param>
        /// <param name="isDeletedByRecipient">if set to <c>true</c> [is deleted by recipient].</param>
        /// <param name="keywords">The keywords.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllPrivateMessages(int storeId, int fromCustomerId, int toCustomerId, bool? isRead, bool? isDeletedByAuthor, bool? isDeletedByRecipient, string keywords, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var privateMessageCore = forumService.GetAllPrivateMessages(storeId, fromCustomerId, toCustomerId, isRead, isDeletedByAuthor, isDeletedByRecipient, keywords, pageIndex, pageSize);
            var privateMessage = privateMessageCore.MapSourcePageList<PrivateMessage, Domain.Forums.PrivateMessage>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(privateMessage, Formatting.Indented, new PageListConverter<Domain.Forums.PrivateMessage>());
        }

        /// <summary>
        /// Gets the subscription by identifier.
        /// </summary>
        /// <param name="forumSubscriptionId">The forum subscription identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSubscriptionById(int forumSubscriptionId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumSubscriptionCore = forumService.GetSubscriptionById(forumSubscriptionId);
            var forumSubscription = AutoMapperConfiguration.Mapper.Map<Domain.Forums.ForumSubscription>(forumSubscriptionCore);
            return JsonConvert.SerializeObject(forumSubscription, Formatting.Indented);
        }

        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="forumId">The forum identifier.</param>
        /// <param name="topicId">The topic identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllSubscriptions(int customerId = 0, int forumId = 0, int topicId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var forumSubscriptionCore = forumService.GetAllSubscriptions(customerId, forumId, topicId, pageIndex, pageSize);
            var forumSubscription = forumSubscriptionCore.MapSourcePageList<ForumSubscription, Domain.Forums.ForumSubscription>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(forumSubscription, Formatting.Indented, new PageListConverter<Domain.Forums.ForumSubscription>());
        }

        /// <summary>
        /// Calculates the index of the topic page.
        /// </summary>
        /// <param name="forumTopicId">The forum topic identifier.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="postId">The post identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string CalculateTopicPageIndex(int forumTopicId, int pageSize, int postId)
        {
            var forumService = EngineContext.Current.Resolve<IForumService>();
            var primitiveCore = forumService.CalculateTopicPageIndex(forumTopicId, pageSize, postId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

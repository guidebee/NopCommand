// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="NewsCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.News;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class NewsCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class NewsCommands
    {
        /// <summary>
        /// Gets the news by identifier.
        /// </summary>
        /// <param name="newsId">The news identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNewsById(int newsId)
        {
            var newsService = EngineContext.Current.Resolve<INewsService>();
            var newsItemCore = newsService.GetNewsById(newsId);
            var newsItem = AutoMapperConfiguration.Mapper.Map<Domain.News.NewsItem>(newsItemCore);
            return JsonConvert.SerializeObject(newsItem, Formatting.Indented);
        }

        /// <summary>
        /// Gets all news.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllNews(int languageId = 0, int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var newsService = EngineContext.Current.Resolve<INewsService>();
            var newsItemCore = newsService.GetAllNews(languageId, storeId, pageIndex, pageSize, showHidden);
            var newsItem = newsItemCore.MapSourcePageList<Nop.Core.Domain.News.NewsItem, Domain.News.NewsItem>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(newsItem, Formatting.Indented, new PageListConverter<Domain.News.NewsItem>());
        }

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="newsItemId">The news item identifier.</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="fromUtc">From UTC.</param>
        /// <param name="toUtc">To UTC.</param>
        /// <param name="commentText">The comment text.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllComments(int customerId = 0, int storeId = 0, int? newsItemId = null, bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var newsService = EngineContext.Current.Resolve<INewsService>();
            var newsCommentCore = newsService.GetAllComments(customerId, storeId, newsItemId, approved, fromUtc, toUtc, commentText);
            var newsComment = newsCommentCore.MapSource<Nop.Core.Domain.News.NewsComment, Domain.News.NewsComment>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(newsComment, Formatting.Indented);
        }

        /// <summary>
        /// Gets the news comment by identifier.
        /// </summary>
        /// <param name="newsCommentId">The news comment identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNewsCommentById(int newsCommentId)
        {
            var newsService = EngineContext.Current.Resolve<INewsService>();
            var newsCommentCore = newsService.GetNewsCommentById(newsCommentId);
            var newsComment = AutoMapperConfiguration.Mapper.Map<Domain.News.NewsComment>(newsCommentCore);
            return JsonConvert.SerializeObject(newsComment, Formatting.Indented);
        }

    }
}

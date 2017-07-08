// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="BlogCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Blogs;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class BlogCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class BlogCommands
    {
        /// <summary>
        /// Gets the blog post by identifier.
        /// </summary>
        /// <param name="blogPostId">The blog post identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetBlogPostById(int blogPostId)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogPostCore = blogService.GetBlogPostById(blogPostId);
            var blogPost = AutoMapperConfiguration.Mapper.Map<Domain.Blogs.BlogPost>(blogPostCore);
            return JsonConvert.SerializeObject(blogPost, Formatting.Indented);
        }

        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="dateFrom">The date from.</param>
        /// <param name="dateTo">The date to.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllBlogPosts(int storeId = 0, int languageId = 0, DateTime? dateFrom = null, DateTime? dateTo = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogPostCore = blogService.GetAllBlogPosts(storeId, languageId, dateFrom, dateTo, pageIndex, pageSize, showHidden);
            var blogPost = blogPostCore.MapSourcePageList<Nop.Core.Domain.Blogs.BlogPost, Domain.Blogs.BlogPost>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(blogPost, Formatting.Indented, new PageListConverter<Domain.Blogs.BlogPost>());
        }

        /// <summary>
        /// Gets all blog posts by tag.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllBlogPostsByTag(int storeId = 0, int languageId = 0, string tag = "", int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogPostCore = blogService.GetAllBlogPostsByTag(storeId, languageId, tag, pageIndex, pageSize, showHidden);
            var blogPost = blogPostCore.MapSourcePageList<Nop.Core.Domain.Blogs.BlogPost, Domain.Blogs.BlogPost>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(blogPost, Formatting.Indented, new PageListConverter<Domain.Blogs.BlogPost>());
        }

        /// <summary>
        /// Gets all blog post tags.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllBlogPostTags(int storeId, int languageId, bool showHidden = false)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogPostTagCore = blogService.GetAllBlogPostTags(storeId, languageId, showHidden);
            var blogPostTag = blogPostTagCore.MapSource<Nop.Core.Domain.Blogs.BlogPostTag, Domain.Blogs.BlogPostTag>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(blogPostTag, Formatting.Indented);
        }

        /// <summary>
        /// Gets all comments.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="blogPostId">The blog post identifier.</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="fromUtc">From UTC.</param>
        /// <param name="toUtc">To UTC.</param>
        /// <param name="commentText">The comment text.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllComments(int customerId = 0, int storeId = 0, int? blogPostId = null, bool? approved = null, DateTime? fromUtc = null, DateTime? toUtc = null, string commentText = null)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogCommentCore = blogService.GetAllComments(customerId, storeId, blogPostId, approved, fromUtc, toUtc, commentText);
            var blogComment = blogCommentCore.MapSource<Nop.Core.Domain.Blogs.BlogComment, Domain.Blogs.BlogComment>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(blogComment, Formatting.Indented);
        }

        /// <summary>
        /// Gets the blog comment by identifier.
        /// </summary>
        /// <param name="blogCommentId">The blog comment identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetBlogCommentById(int blogCommentId)
        {
            var blogService = EngineContext.Current.Resolve<IBlogService>();
            var blogCommentCore = blogService.GetBlogCommentById(blogCommentId);
            var blogComment = AutoMapperConfiguration.Mapper.Map<Domain.Blogs.BlogComment>(blogCommentCore);
            return JsonConvert.SerializeObject(blogComment, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-05-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-06-2017
// ***********************************************************************
// <copyright file="PageListExtensions.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Nop.Core;

namespace NopCommand.Helpers
{

    /// <summary>
    /// Class PageListSurrogate.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Guidebee IT</remarks>
    internal class PageListSurrogate<T>
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>The list.</value>
        /// <remarks>Guidebee IT</remarks>
        public List<T> List { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        /// <remarks>Guidebee IT</remarks>
        public int PageIndex { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        /// <remarks>Guidebee IT</remarks>
        public int PageSize { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>The total count.</value>
        /// <remarks>Guidebee IT</remarks>
        public int TotalCount { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>The total pages.</value>
        /// <remarks>Guidebee IT</remarks>
        public int TotalPages { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets a value indicating whether this instance has previous page.
        /// </summary>
        /// <value><c>true</c> if this instance has previous page; otherwise, <c>false</c>.</value>
        /// <remarks>Guidebee IT</remarks>
        public bool HasPreviousPage { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        /// <summary>
        /// Gets or sets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        /// <remarks>Guidebee IT</remarks>
        public bool HasNextPage { get; set; }


    }

    /// <summary>
    /// Class PageListConverter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Newtonsoft.Json.JsonConverter" />
    /// <remarks>Guidebee IT</remarks>
    public class PageListConverter<T> : JsonConverter
    {
        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <remarks>Guidebee IT</remarks>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var pageList = value as IPagedList<T>;
            if (pageList != null)
            {
                var surrogate = new PageListSurrogate<T>
                {
                    List = pageList.ToList(),
                    PageIndex = pageList.PageIndex,
                    PageSize = pageList.PageSize,
                    TotalCount = pageList.TotalCount,
                    TotalPages = pageList.TotalPages,
                    HasNextPage = pageList.HasNextPage,
                    HasPreviousPage = pageList.HasPreviousPage
                };
                serializer.Serialize(writer, surrogate);
            }
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <remarks>Guidebee IT</remarks>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
        /// <remarks>Guidebee IT</remarks>
        public override bool CanConvert(Type objectType)
        {
            var can = objectType.FullName.StartsWith("Nop.Core.PagedList");
            return can;
        }
    }


    /// <summary>
    /// Class PageListExtensions.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class PageListExtensions
    {
        /// <summary>
        /// Maps the source page list.
        /// </summary>
        /// <typeparam name="TSrc">The type of the t source.</typeparam>
        /// <typeparam name="TDest">The type of the t dest.</typeparam>
        /// <param name="src">The source.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>IPagedList&lt;TDest&gt;.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static IPagedList<TDest> MapSourcePageList<TSrc, TDest>(this IPagedList<TSrc> src, IMapper mapper)
        {
            var returnList = new List<TDest>();
            IPagedList<TDest> pageList = null;
            if (src != null)
            {
                foreach (var item in src)
                {
                    returnList.Add(mapper.Map<TSrc, TDest>(item));
                }
                pageList = new PagedList<TDest>(returnList, src.PageIndex, src.PageSize, src.TotalCount);

            }

            return pageList;
        }

        /// <summary>
        /// Maps the source.
        /// </summary>
        /// <typeparam name="TSrc">The type of the t source.</typeparam>
        /// <typeparam name="TDest">The type of the t dest.</typeparam>
        /// <param name="src">The source.</param>
        /// <param name="mapper">The mapper.</param>
        /// <returns>IList&lt;TDest&gt;.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static IList<TDest> MapSource<TSrc, TDest>(this IList<TSrc> src, IMapper mapper)
        {
            var returnList = new List<TDest>();

            if (src != null)
            {
                foreach (var item in src)
                {
                    returnList.Add(mapper.Map<TSrc, TDest>(item));
                }

            }

            return returnList;

        }
    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="UrlRecordCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Seo;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class UrlRecordCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class UrlRecordCommands
    {
        /// <summary>
        /// Gets the URL record by identifier.
        /// </summary>
        /// <param name="urlRecordId">The URL record identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetUrlRecordById(int urlRecordId)
        {
            var urlRecordService = EngineContext.Current.Resolve<IUrlRecordService>();
            var urlRecordCore = urlRecordService.GetUrlRecordById(urlRecordId);
            var urlRecord = AutoMapperConfiguration.Mapper.Map<Domain.Seo.UrlRecord>(urlRecordCore);
            return JsonConvert.SerializeObject(urlRecord, Formatting.Indented);
        }

        /// <summary>
        /// Gets the by slug.
        /// </summary>
        /// <param name="slug">The slug.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetBySlug(string slug)
        {
            var urlRecordService = EngineContext.Current.Resolve<IUrlRecordService>();
            var urlRecordCore = urlRecordService.GetBySlug(slug);
            var urlRecord = AutoMapperConfiguration.Mapper.Map<Domain.Seo.UrlRecord>(urlRecordCore);
            return JsonConvert.SerializeObject(urlRecord, Formatting.Indented);
        }


        /// <summary>
        /// Gets all URL records.
        /// </summary>
        /// <param name="slug">The slug.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllUrlRecords(string slug = "", int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var urlRecordService = EngineContext.Current.Resolve<IUrlRecordService>();
            var urlRecordCore = urlRecordService.GetAllUrlRecords(slug, pageIndex, pageSize);
            var urlRecord = urlRecordCore.MapSourcePageList<Nop.Core.Domain.Seo.UrlRecord, Domain.Seo.UrlRecord>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(urlRecord, Formatting.Indented, new PageListConverter<Domain.Seo.UrlRecord>());
        }

        /// <summary>
        /// Gets the active slug.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetActiveSlug(int entityId, string entityName, int languageId)
        {
            var urlRecordService = EngineContext.Current.Resolve<IUrlRecordService>();
            var primitiveCore = urlRecordService.GetActiveSlug(entityId, entityName, languageId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

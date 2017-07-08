// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="SearchTermCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Common;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class SearchTermCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class SearchTermCommands
    {
        /// <summary>
        /// Gets the search term by identifier.
        /// </summary>
        /// <param name="searchTermId">The search term identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSearchTermById(int searchTermId)
        {
            var searchTermService = EngineContext.Current.Resolve<ISearchTermService>();
            var searchTermCore = searchTermService.GetSearchTermById(searchTermId);
            var searchTerm = AutoMapperConfiguration.Mapper.Map<Domain.Common.SearchTerm>(searchTermCore);
            return JsonConvert.SerializeObject(searchTerm, Formatting.Indented);
        }

        /// <summary>
        /// Gets the search term by keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSearchTermByKeyword(string keyword, int storeId)
        {
            var searchTermService = EngineContext.Current.Resolve<ISearchTermService>();
            var searchTermCore = searchTermService.GetSearchTermByKeyword(keyword, storeId);
            var searchTerm = AutoMapperConfiguration.Mapper.Map<Domain.Common.SearchTerm>(searchTermCore);
            return JsonConvert.SerializeObject(searchTerm, Formatting.Indented);
        }

        /// <summary>
        /// Gets the stats.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStats(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var searchTermService = EngineContext.Current.Resolve<ISearchTermService>();
            var searchTermReportLineCore = searchTermService.GetStats(pageIndex, pageSize);
            var searchTermReportLine = searchTermReportLineCore.MapSourcePageList<Nop.Core.Domain.Common.SearchTermReportLine, Domain.Common.SearchTermReportLine>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(searchTermReportLine, Formatting.Indented, new PageListConverter<Domain.Common.SearchTermReportLine>());
        }

    }
}

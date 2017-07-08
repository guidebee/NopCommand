// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="DownloadCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Media;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class DownloadCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class DownloadCommands
    {
        /// <summary>
        /// Gets the download by identifier.
        /// </summary>
        /// <param name="downloadId">The download identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDownloadById(int downloadId)
        {
            var downloadService = EngineContext.Current.Resolve<IDownloadService>();
            var downloadCore = downloadService.GetDownloadById(downloadId);
            var download = AutoMapperConfiguration.Mapper.Map<Domain.Media.Download>(downloadCore);
            return JsonConvert.SerializeObject(download, Formatting.Indented);
        }

        /// <summary>
        /// Gets the download by unique identifier.
        /// </summary>
        /// <param name="downloadGuid">The download unique identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDownloadByGuid(Guid downloadGuid)
        {
            var downloadService = EngineContext.Current.Resolve<IDownloadService>();
            var downloadCore = downloadService.GetDownloadByGuid(downloadGuid);
            var download = AutoMapperConfiguration.Mapper.Map<Domain.Media.Download>(downloadCore);
            return JsonConvert.SerializeObject(download, Formatting.Indented);
        }

    }
}

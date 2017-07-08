// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="SettingCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Configuration;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class SettingCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class SettingCommands
    {
        /// <summary>
        /// Gets the setting by identifier.
        /// </summary>
        /// <param name="settingId">The setting identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSettingById(int settingId)
        {
            var settingService = EngineContext.Current.Resolve<ISettingService>();
            var settingCore = settingService.GetSettingById(settingId);
            var setting = AutoMapperConfiguration.Mapper.Map<Domain.Configuration.Setting>(settingCore);
            return JsonConvert.SerializeObject(setting, Formatting.Indented);
        }

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="loadSharedValueIfNotFound">if set to <c>true</c> [load shared value if not found].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetSetting(string key, int storeId = 0, bool loadSharedValueIfNotFound = false)
        {
            var settingService = EngineContext.Current.Resolve<ISettingService>();
            var settingCore = settingService.GetSetting(key, storeId, loadSharedValueIfNotFound);
            var setting = AutoMapperConfiguration.Mapper.Map<Domain.Configuration.Setting>(settingCore);
            return JsonConvert.SerializeObject(setting, Formatting.Indented);
        }

    }
}

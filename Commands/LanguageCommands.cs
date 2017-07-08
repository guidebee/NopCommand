// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="LanguageCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Localization;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class LanguageCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class LanguageCommands
    {
        /// <summary>
        /// Gets all languages.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllLanguages(bool showHidden = false, int storeId = 0)
        {
            var languageService = EngineContext.Current.Resolve<ILanguageService>();
            var languageCore = languageService.GetAllLanguages(showHidden, storeId);
            var language = languageCore.MapSource<Nop.Core.Domain.Localization.Language, Domain.Localization.Language>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(language, Formatting.Indented);
        }

        /// <summary>
        /// Gets the language by identifier.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetLanguageById(int languageId)
        {
            var languageService = EngineContext.Current.Resolve<ILanguageService>();
            var languageCore = languageService.GetLanguageById(languageId);
            var language = AutoMapperConfiguration.Mapper.Map<Domain.Localization.Language>(languageCore);
            return JsonConvert.SerializeObject(language, Formatting.Indented);
        }

    }
}

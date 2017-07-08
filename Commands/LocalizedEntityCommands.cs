// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="LocalizedEntityCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Localization;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class LocalizedEntityCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class LocalizedEntityCommands
    {
        /// <summary>
        /// Gets the localized property by identifier.
        /// </summary>
        /// <param name="localizedPropertyId">The localized property identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetLocalizedPropertyById(int localizedPropertyId)
        {
            var localizedEntityService = EngineContext.Current.Resolve<ILocalizedEntityService>();
            var localizedPropertyCore = localizedEntityService.GetLocalizedPropertyById(localizedPropertyId);
            var localizedProperty = AutoMapperConfiguration.Mapper.Map<Domain.Localization.LocalizedProperty>(localizedPropertyCore);
            return JsonConvert.SerializeObject(localizedProperty, Formatting.Indented);
        }

        /// <summary>
        /// Gets the localized value.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="localeKeyGroup">The locale key group.</param>
        /// <param name="localeKey">The locale key.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetLocalizedValue(int languageId, int entityId, string localeKeyGroup, string localeKey)
        {
            var localizedEntityService = EngineContext.Current.Resolve<ILocalizedEntityService>();
            var primitiveCore = localizedEntityService.GetLocalizedValue(languageId, entityId, localeKeyGroup, localeKey);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

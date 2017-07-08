// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="StateProvinceCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Directory;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class StateProvinceCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class StateProvinceCommands
    {
        /// <summary>
        /// Gets the state province by identifier.
        /// </summary>
        /// <param name="stateProvinceId">The state province identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStateProvinceById(int stateProvinceId)
        {
            var stateProvinceService = EngineContext.Current.Resolve<IStateProvinceService>();
            var stateProvinceCore = stateProvinceService.GetStateProvinceById(stateProvinceId);
            var stateProvince = AutoMapperConfiguration.Mapper.Map<Domain.Directory.StateProvince>(stateProvinceCore);
            return JsonConvert.SerializeObject(stateProvince, Formatting.Indented);
        }

        /// <summary>
        /// Gets the state province by abbreviation.
        /// </summary>
        /// <param name="abbreviation">The abbreviation.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStateProvinceByAbbreviation(string abbreviation)
        {
            var stateProvinceService = EngineContext.Current.Resolve<IStateProvinceService>();
            var stateProvinceCore = stateProvinceService.GetStateProvinceByAbbreviation(abbreviation);
            var stateProvince = AutoMapperConfiguration.Mapper.Map<Domain.Directory.StateProvince>(stateProvinceCore);
            return JsonConvert.SerializeObject(stateProvince, Formatting.Indented);
        }

        /// <summary>
        /// Gets the state provinces by country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStateProvincesByCountryId(int countryId, int languageId = 0, bool showHidden = false)
        {
            var stateProvinceService = EngineContext.Current.Resolve<IStateProvinceService>();
            var stateProvinceCore = stateProvinceService.GetStateProvincesByCountryId(countryId, languageId, showHidden);
            var stateProvince = stateProvinceCore.MapSource<Nop.Core.Domain.Directory.StateProvince, Domain.Directory.StateProvince>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(stateProvince, Formatting.Indented);
        }

        /// <summary>
        /// Gets the state provinces.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStateProvinces(bool showHidden = false)
        {
            var stateProvinceService = EngineContext.Current.Resolve<IStateProvinceService>();
            var stateProvinceCore = stateProvinceService.GetStateProvinces(showHidden);
            var stateProvince = stateProvinceCore.MapSource<Nop.Core.Domain.Directory.StateProvince, Domain.Directory.StateProvince>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(stateProvince, Formatting.Indented);
        }

    }
}

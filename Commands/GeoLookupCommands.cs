// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="GeoLookupCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Directory;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class GeoLookupCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class GeoLookupCommands
    {
        /// <summary>
        /// Lookups the country iso code.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LookupCountryIsoCode(string ipAddress)
        {
            var geoLookupService = EngineContext.Current.Resolve<IGeoLookupService>();
            var primitiveCore = geoLookupService.LookupCountryIsoCode(ipAddress);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Lookups the name of the country.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LookupCountryName(string ipAddress)
        {
            var geoLookupService = EngineContext.Current.Resolve<IGeoLookupService>();
            var primitiveCore = geoLookupService.LookupCountryName(ipAddress);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

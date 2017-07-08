// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CountryCommands.cs" company="Guidebee IT">
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
    /// Class CountryCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CountryCommands
    {
        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCountries(int languageId = 0, bool showHidden = false)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetAllCountries(languageId, showHidden);
            var country = countryCore.MapSource<Nop.Core.Domain.Directory.Country, Domain.Directory.Country>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Gets all countries for billing.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCountriesForBilling(int languageId = 0, bool showHidden = false)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetAllCountriesForBilling(languageId, showHidden);
            var country = countryCore.MapSource<Nop.Core.Domain.Directory.Country, Domain.Directory.Country>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Gets all countries for shipping.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCountriesForShipping(int languageId = 0, bool showHidden = false)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetAllCountriesForShipping(languageId, showHidden);
            var country = countryCore.MapSource<Nop.Core.Domain.Directory.Country, Domain.Directory.Country>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Gets the country by identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCountryById(int countryId)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetCountryById(countryId);
            var country = AutoMapperConfiguration.Mapper.Map<Domain.Directory.Country>(countryCore);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Gets the country by two letter iso code.
        /// </summary>
        /// <param name="twoLetterIsoCode">The two letter iso code.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCountryByTwoLetterIsoCode(string twoLetterIsoCode)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetCountryByTwoLetterIsoCode(twoLetterIsoCode);
            var country = AutoMapperConfiguration.Mapper.Map<Domain.Directory.Country>(countryCore);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Gets the country by three letter iso code.
        /// </summary>
        /// <param name="threeLetterIsoCode">The three letter iso code.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCountryByThreeLetterIsoCode(string threeLetterIsoCode)
        {
            var countryService = EngineContext.Current.Resolve<ICountryService>();
            var countryCore = countryService.GetCountryByThreeLetterIsoCode(threeLetterIsoCode);
            var country = AutoMapperConfiguration.Mapper.Map<Domain.Directory.Country>(countryCore);
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

    }
}

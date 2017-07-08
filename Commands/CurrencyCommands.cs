// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CurrencyCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Directory;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CurrencyCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CurrencyCommands
    {
        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCurrencyById(int currencyId)
        {
            var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
            var currencyCore = currencyService.GetCurrencyById(currencyId);
            var currency = AutoMapperConfiguration.Mapper.Map<Domain.Directory.Currency>(currencyCore);
            return JsonConvert.SerializeObject(currency, Formatting.Indented);
        }

        /// <summary>
        /// Gets the currency by code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCurrencyByCode(string currencyCode)
        {
            var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
            var currencyCore = currencyService.GetCurrencyByCode(currencyCode);
            var currency = AutoMapperConfiguration.Mapper.Map<Domain.Directory.Currency>(currencyCore);
            return JsonConvert.SerializeObject(currency, Formatting.Indented);
        }

        /// <summary>
        /// Gets all currencies.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCurrencies(bool showHidden = false, int storeId = 0)
        {
            var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
            var currencyCore = currencyService.GetAllCurrencies(showHidden, storeId);
            var currency = currencyCore.MapSource<Nop.Core.Domain.Directory.Currency, Domain.Directory.Currency>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(currency, Formatting.Indented);
        }

        /// <summary>
        /// Converts the currency.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ConvertCurrency(decimal amount, decimal exchangeRate)
        {
            var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
            var primitiveCore = currencyService.ConvertCurrency(amount, exchangeRate);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Loads the name of the exchange rate provider by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadExchangeRateProviderBySystemName(string systemName)
        {
            var currencyService = EngineContext.Current.Resolve<ICurrencyService>();
            var iExchangeRateProviderCore = currencyService.LoadExchangeRateProviderBySystemName(systemName);
            var iExchangeRateProvider = AutoMapperConfiguration.Mapper.Map<IExchangeRateProvider>(iExchangeRateProviderCore);
            return JsonConvert.SerializeObject(iExchangeRateProvider, Formatting.Indented);
        }

    }
}

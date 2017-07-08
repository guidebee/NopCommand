// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="TaxCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Tax;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class TaxCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class TaxCommands
    {
        /// <summary>
        /// Loads the name of the tax provider by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadTaxProviderBySystemName(string systemName)
        {
            var taxService = EngineContext.Current.Resolve<ITaxService>();
            var iTaxProviderCore = taxService.LoadTaxProviderBySystemName(systemName);
            var iTaxProvider = AutoMapperConfiguration.Mapper.Map<ITaxProvider>(iTaxProviderCore);
            return JsonConvert.SerializeObject(iTaxProvider, Formatting.Indented);
        }



        /// <summary>
        /// Gets the vat number status.
        /// </summary>
        /// <param name="twoLetterIsoCode">The two letter iso code.</param>
        /// <param name="vatNumber">The vat number.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetVatNumberStatus(string twoLetterIsoCode, string vatNumber)
        {
            var taxService = EngineContext.Current.Resolve<ITaxService>();
            var primitiveCore = taxService.GetVatNumberStatus(twoLetterIsoCode, vatNumber);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

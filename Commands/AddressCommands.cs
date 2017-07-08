// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="AddressCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Common;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class AddressCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class AddressCommands
    {
        /// <summary>
        /// Gets the address total by country identifier.
        /// </summary>
        /// <param name="countryId">The country identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressTotalByCountryId(int countryId)
        {
            var addressService = EngineContext.Current.Resolve<IAddressService>();
            var primitiveCore = addressService.GetAddressTotalByCountryId(countryId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the address total by state province identifier.
        /// </summary>
        /// <param name="stateProvinceId">The state province identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressTotalByStateProvinceId(int stateProvinceId)
        {
            var addressService = EngineContext.Current.Resolve<IAddressService>();
            var primitiveCore = addressService.GetAddressTotalByStateProvinceId(stateProvinceId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the address by identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressById(int addressId)
        {
            var addressService = EngineContext.Current.Resolve<IAddressService>();
            var addressCore = addressService.GetAddressById(addressId);
            var address = AutoMapperConfiguration.Mapper.Map<Domain.Common.Address>(addressCore);
            return JsonConvert.SerializeObject(address, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="AddressAttributeCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Common;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class AddressAttributeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class AddressAttributeCommands
    {
        /// <summary>
        /// Gets the address attribute by identifier.
        /// </summary>
        /// <param name="addressAttributeId">The address attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressAttributeById(int addressAttributeId)
        {
            var addressAttributeService = EngineContext.Current.Resolve<IAddressAttributeService>();
            var addressAttributeCore = addressAttributeService.GetAddressAttributeById(addressAttributeId);
            var addressAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Common.AddressAttribute>(addressAttributeCore);
            return JsonConvert.SerializeObject(addressAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets all address attributes.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllAddressAttributes()
        {
            var addressAttributeService = EngineContext.Current.Resolve<IAddressAttributeService>();
            var addressAttributeValueCore = addressAttributeService.GetAllAddressAttributes();
            var addressAttributeValue = addressAttributeValueCore.MapSource<Nop.Core.Domain.Common.AddressAttribute, Domain.Common.AddressAttribute>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(addressAttributeValue, Formatting.Indented);
        }


        /// <summary>
        /// Gets the address attribute values.
        /// </summary>
        /// <param name="addressAttributeId">The address attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressAttributeValues(int addressAttributeId)
        {
            var addressAttributeService = EngineContext.Current.Resolve<IAddressAttributeService>();
            var addressAttributeValueCore = addressAttributeService.GetAddressAttributeValues(addressAttributeId);
            var addressAttributeValue = addressAttributeValueCore.MapSource<Nop.Core.Domain.Common.AddressAttributeValue, Domain.Common.AddressAttributeValue>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(addressAttributeValue, Formatting.Indented);
        }

        /// <summary>
        /// Gets the address attribute value by identifier.
        /// </summary>
        /// <param name="addressAttributeValueId">The address attribute value identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAddressAttributeValueById(int addressAttributeValueId)
        {
            var addressAttributeService = EngineContext.Current.Resolve<IAddressAttributeService>();
            var addressAttributeValueCore = addressAttributeService.GetAddressAttributeValueById(addressAttributeValueId);
            var addressAttributeValue = AutoMapperConfiguration.Mapper.Map<Domain.Common.AddressAttributeValue>(addressAttributeValueCore);
            return JsonConvert.SerializeObject(addressAttributeValue, Formatting.Indented);
        }

    }
}

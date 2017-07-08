// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="StoreMappingCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Stores;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class StoreMappingCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class StoreMappingCommands
    {
        /// <summary>
        /// Gets the store mapping by identifier.
        /// </summary>
        /// <param name="storeMappingId">The store mapping identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStoreMappingById(int storeMappingId)
        {
            var storeMappingService = EngineContext.Current.Resolve<IStoreMappingService>();
            var storeMappingCore = storeMappingService.GetStoreMappingById(storeMappingId);
            var storeMapping = AutoMapperConfiguration.Mapper.Map<Domain.Stores.StoreMapping>(storeMappingCore);
            return JsonConvert.SerializeObject(storeMapping, Formatting.Indented);
        }

    }
}

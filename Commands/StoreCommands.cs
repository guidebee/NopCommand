// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="StoreCommands.cs" company="Guidebee IT">
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
    /// Class StoreCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class StoreCommands
    {
        /// <summary>
        /// Gets the store by identifier.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetStoreById(int storeId)
        {
            var storeService = EngineContext.Current.Resolve<IStoreService>();
            var storeCore = storeService.GetStoreById(storeId);
            var store = AutoMapperConfiguration.Mapper.Map<Domain.Stores.Store>(storeCore);
            return JsonConvert.SerializeObject(store, Formatting.Indented);
        }

    }
}

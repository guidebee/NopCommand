// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ShoppingCartCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ShoppingCartCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ShoppingCartCommands
    {
        /// <summary>
        /// Deletes the expired shopping cart items.
        /// </summary>
        /// <param name="olderThanUtc">The older than UTC.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string DeleteExpiredShoppingCartItems(DateTime olderThanUtc)
        {
            var shoppingCartService = EngineContext.Current.Resolve<IShoppingCartService>();
            var primitiveCore = shoppingCartService.DeleteExpiredShoppingCartItems(olderThanUtc);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

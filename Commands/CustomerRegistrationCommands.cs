// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CustomerRegistrationCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Customers;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CustomerRegistrationCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CustomerRegistrationCommands
    {
        /// <summary>
        /// Validates the customer.
        /// </summary>
        /// <param name="usernameOrEmail">The username or email.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ValidateCustomer(string usernameOrEmail, string password)
        {
            var customerRegistrationService = EngineContext.Current.Resolve<ICustomerRegistrationService>();
            var primitiveCore = customerRegistrationService.ValidateCustomer(usernameOrEmail, password);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

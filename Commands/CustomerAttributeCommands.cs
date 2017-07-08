// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CustomerAttributeCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Customers;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CustomerAttributeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CustomerAttributeCommands
    {
        /// <summary>
        /// Gets the customer attribute by identifier.
        /// </summary>
        /// <param name="customerAttributeId">The customer attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerAttributeById(int customerAttributeId)
        {
            var customerAttributeService = EngineContext.Current.Resolve<ICustomerAttributeService>();
            var customerAttributeCore = customerAttributeService.GetCustomerAttributeById(customerAttributeId);
            var customerAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Customers.CustomerAttribute>(customerAttributeCore);
            return JsonConvert.SerializeObject(customerAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer attribute values.
        /// </summary>
        /// <param name="customerAttributeId">The customer attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerAttributeValues(int customerAttributeId)
        {
            var customerAttributeService = EngineContext.Current.Resolve<ICustomerAttributeService>();
            var customerAttributeValueCore = customerAttributeService.GetCustomerAttributeValues(customerAttributeId);
            var customerAttributeValue = customerAttributeValueCore.MapSource<Nop.Core.Domain.Customers.CustomerAttributeValue, Domain.Customers.CustomerAttributeValue>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(customerAttributeValue, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer attribute value by identifier.
        /// </summary>
        /// <param name="customerAttributeValueId">The customer attribute value identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerAttributeValueById(int customerAttributeValueId)
        {
            var customerAttributeService = EngineContext.Current.Resolve<ICustomerAttributeService>();
            var customerAttributeValueCore = customerAttributeService.GetCustomerAttributeValueById(customerAttributeValueId);
            var customerAttributeValue = AutoMapperConfiguration.Mapper.Map<Domain.Customers.CustomerAttributeValue>(customerAttributeValueCore);
            return JsonConvert.SerializeObject(customerAttributeValue, Formatting.Indented);
        }

    }
}

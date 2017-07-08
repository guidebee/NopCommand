// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CustomerCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Domain.Customers;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Customers;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CustomerCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CustomerCommands
    {
        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerById(int customerId)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerCore = customerService.GetCustomerById(customerId);
            var customer = AutoMapperConfiguration.Mapper.Map<Domain.Customers.Customer>(customerCore);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer by unique identifier.
        /// </summary>
        /// <param name="customerGuid">The customer unique identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerByGuid(Guid customerGuid)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerCore = customerService.GetCustomerByGuid(customerGuid);
            var customer = AutoMapperConfiguration.Mapper.Map<Domain.Customers.Customer>(customerCore);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerByEmail(string email)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerCore = customerService.GetCustomerByEmail(email);
            var customer = AutoMapperConfiguration.Mapper.Map<Domain.Customers.Customer>(customerCore);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the customer by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerBySystemName(string systemName)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerCore = customerService.GetCustomerBySystemName(systemName);
            var customer = AutoMapperConfiguration.Mapper.Map<Domain.Customers.Customer>(customerCore);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerByUsername(string username)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerCore = customerService.GetCustomerByUsername(username);
            var customer = AutoMapperConfiguration.Mapper.Map<Domain.Customers.Customer>(customerCore);
            return JsonConvert.SerializeObject(customer, Formatting.Indented);
        }

        /// <summary>
        /// Deletes the guest customers.
        /// </summary>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="onlyWithoutShoppingCart">if set to <c>true</c> [only without shopping cart].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var primitiveCore = customerService.DeleteGuestCustomers(createdFromUtc, createdToUtc, onlyWithoutShoppingCart);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer role by identifier.
        /// </summary>
        /// <param name="customerRoleId">The customer role identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerRoleById(int customerRoleId)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerRoleCore = customerService.GetCustomerRoleById(customerRoleId);
            var customerRole = AutoMapperConfiguration.Mapper.Map<Domain.Customers.CustomerRole>(customerRoleCore);
            return JsonConvert.SerializeObject(customerRole, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the customer role by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerRoleBySystemName(string systemName)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerRoleCore = customerService.GetCustomerRoleBySystemName(systemName);
            var customerRole = AutoMapperConfiguration.Mapper.Map<Domain.Customers.CustomerRole>(customerRoleCore);
            return JsonConvert.SerializeObject(customerRole, Formatting.Indented);
        }

        /// <summary>
        /// Gets all customer roles.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCustomerRoles(bool showHidden = false)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerRoleCore = customerService.GetAllCustomerRoles(showHidden);
            var customerRole = customerRoleCore.MapSource<CustomerRole, Domain.Customers.CustomerRole>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(customerRole, Formatting.Indented);
        }

        /// <summary>
        /// Gets the customer passwords.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="passwordFormat">The password format.</param>
        /// <param name="passwordsToReturn">The passwords to return.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCustomerPasswords(int? customerId = null, PasswordFormat? passwordFormat = null, int? passwordsToReturn = null)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerPasswordCore = customerService.GetCustomerPasswords(customerId, passwordFormat, passwordsToReturn);
            var customerPassword = customerPasswordCore.MapSource<CustomerPassword, Domain.Customers.CustomerPassword>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(customerPassword, Formatting.Indented);
        }

        /// <summary>
        /// Gets the current password.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCurrentPassword(int customerId)
        {
            var customerService = EngineContext.Current.Resolve<ICustomerService>();
            var customerPasswordCore = customerService.GetCurrentPassword(customerId);
            var customerPassword = AutoMapperConfiguration.Mapper.Map<Domain.Customers.CustomerPassword>(customerPasswordCore);
            return JsonConvert.SerializeObject(customerPassword, Formatting.Indented);
        }

    }
}

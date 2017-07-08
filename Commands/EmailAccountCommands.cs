// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="EmailAccountCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Messages;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class EmailAccountCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class EmailAccountCommands
    {
        /// <summary>
        /// Gets the email account by identifier.
        /// </summary>
        /// <param name="emailAccountId">The email account identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetEmailAccountById(int emailAccountId)
        {
            var emailAccountService = EngineContext.Current.Resolve<IEmailAccountService>();
            var emailAccountCore = emailAccountService.GetEmailAccountById(emailAccountId);
            var emailAccount = AutoMapperConfiguration.Mapper.Map<Domain.Messages.EmailAccount>(emailAccountCore);
            return JsonConvert.SerializeObject(emailAccount, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="OpenAuthenticationCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Authentication.External;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class OpenAuthenticationCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class OpenAuthenticationCommands
    {
        /// <summary>
        /// Loads the name of the external authentication method by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadExternalAuthenticationMethodBySystemName(string systemName)
        {
            var openAuthenticationService = EngineContext.Current.Resolve<IOpenAuthenticationService>();
            var iExternalAuthenticationMethodCore = openAuthenticationService.LoadExternalAuthenticationMethodBySystemName(systemName);
            var iExternalAuthenticationMethod = AutoMapperConfiguration.Mapper.Map<IExternalAuthenticationMethod>(iExternalAuthenticationMethodCore);
            return JsonConvert.SerializeObject(iExternalAuthenticationMethod, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="AclCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Security;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class AclCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class AclCommands
    {
        /// <summary>
        /// Gets the acl record by identifier.
        /// </summary>
        /// <param name="aclRecordId">The acl record identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAclRecordById(int aclRecordId)
        {
            var aclService = EngineContext.Current.Resolve<IAclService>();
            var aclRecordCore = aclService.GetAclRecordById(aclRecordId);
            var aclRecord = AutoMapperConfiguration.Mapper.Map<Domain.Security.AclRecord>(aclRecordCore);
            return JsonConvert.SerializeObject(aclRecord, Formatting.Indented);
        }

    }
}

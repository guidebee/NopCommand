// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="PermissionCommands.cs" company="Guidebee IT">
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
    /// Class PermissionCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class PermissionCommands
    {
        /// <summary>
        /// Gets the permission record by identifier.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPermissionRecordById(int permissionId)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var permissionRecordCore = permissionService.GetPermissionRecordById(permissionId);
            var permissionRecord = AutoMapperConfiguration.Mapper.Map<Domain.Security.PermissionRecord>(permissionRecordCore);
            return JsonConvert.SerializeObject(permissionRecord, Formatting.Indented);
        }

        /// <summary>
        /// Gets the name of the permission record by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetPermissionRecordBySystemName(string systemName)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var permissionRecordCore = permissionService.GetPermissionRecordBySystemName(systemName);
            var permissionRecord = AutoMapperConfiguration.Mapper.Map<Domain.Security.PermissionRecord>(permissionRecordCore);
            return JsonConvert.SerializeObject(permissionRecord, Formatting.Indented);
        }

        /// <summary>
        /// Authorizes the specified permission record system name.
        /// </summary>
        /// <param name="permissionRecordSystemName">Name of the permission record system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string Authorize(string permissionRecordSystemName)
        {
            var permissionService = EngineContext.Current.Resolve<IPermissionService>();
            var primitiveCore = permissionService.Authorize(permissionRecordSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

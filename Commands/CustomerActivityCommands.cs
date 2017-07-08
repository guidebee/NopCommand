// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CustomerActivityCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Logging;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CustomerActivityCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CustomerActivityCommands
    {
        /// <summary>
        /// Gets the activity type by identifier.
        /// </summary>
        /// <param name="activityLogTypeId">The activity log type identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetActivityTypeById(int activityLogTypeId)
        {
            var customerActivityService = EngineContext.Current.Resolve<ICustomerActivityService>();
            var activityLogTypeCore = customerActivityService.GetActivityTypeById(activityLogTypeId);
            var activityLogType = AutoMapperConfiguration.Mapper.Map<Domain.Logging.ActivityLogType>(activityLogTypeCore);
            return JsonConvert.SerializeObject(activityLogType, Formatting.Indented);
        }

        /// <summary>
        /// Gets all activities.
        /// </summary>
        /// <param name="createdOnFrom">The created on from.</param>
        /// <param name="createdOnTo">The created on to.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="activityLogTypeId">The activity log type identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllActivities(DateTime? createdOnFrom = null, DateTime? createdOnTo = null, int? customerId = null, int activityLogTypeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, string ipAddress = null)
        {
            var customerActivityService = EngineContext.Current.Resolve<ICustomerActivityService>();
            var activityLogCore = customerActivityService.GetAllActivities(createdOnFrom, createdOnTo, customerId, activityLogTypeId, pageIndex, pageSize, ipAddress);
            var activityLog = activityLogCore.MapSourcePageList<Nop.Core.Domain.Logging.ActivityLog, Domain.Logging.ActivityLog>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(activityLog, Formatting.Indented, new PageListConverter<Domain.Logging.ActivityLog>());
        }

        /// <summary>
        /// Gets the activity by identifier.
        /// </summary>
        /// <param name="activityLogId">The activity log identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetActivityById(int activityLogId)
        {
            var customerActivityService = EngineContext.Current.Resolve<ICustomerActivityService>();
            var activityLogCore = customerActivityService.GetActivityById(activityLogId);
            var activityLog = AutoMapperConfiguration.Mapper.Map<Domain.Logging.ActivityLog>(activityLogCore);
            return JsonConvert.SerializeObject(activityLog, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ScheduleTaskCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Tasks;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ScheduleTaskCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ScheduleTaskCommands
    {
        /// <summary>
        /// Gets the task by identifier.
        /// </summary>
        /// <param name="taskId">The task identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTaskById(int taskId)
        {
            var scheduleTaskService = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTaskCore = scheduleTaskService.GetTaskById(taskId);
            var scheduleTask = AutoMapperConfiguration.Mapper.Map<Domain.Tasks.ScheduleTask>(scheduleTaskCore);
            return JsonConvert.SerializeObject(scheduleTask, Formatting.Indented);
        }

        /// <summary>
        /// Gets the type of the task by.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTaskByType(string type)
        {
            var scheduleTaskService = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTaskCore = scheduleTaskService.GetTaskByType(type);
            var scheduleTask = AutoMapperConfiguration.Mapper.Map<Domain.Tasks.ScheduleTask>(scheduleTaskCore);
            return JsonConvert.SerializeObject(scheduleTask, Formatting.Indented);
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllTasks(bool showHidden = false)
        {
            var scheduleTaskService = EngineContext.Current.Resolve<IScheduleTaskService>();
            var scheduleTaskCore = scheduleTaskService.GetAllTasks(showHidden);
            var scheduleTask = scheduleTaskCore.MapSource<Nop.Core.Domain.Tasks.ScheduleTask, Domain.Tasks.ScheduleTask>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(scheduleTask, Formatting.Indented);
        }

    }
}

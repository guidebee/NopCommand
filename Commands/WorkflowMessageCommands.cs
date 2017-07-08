// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="WorkflowMessageCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Services.Messages;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class WorkflowMessageCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class WorkflowMessageCommands
    {
        /// <summary>
        /// Sends the contact us message.
        /// </summary>
        /// <param name="languageId">The language identifier.</param>
        /// <param name="senderEmail">The sender email.</param>
        /// <param name="senderName">Name of the sender.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SendContactUsMessage(int languageId, string senderEmail, string senderName, string subject, string body)
        {
            var workflowMessageService = EngineContext.Current.Resolve<IWorkflowMessageService>();
            var primitiveCore = workflowMessageService.SendContactUsMessage(languageId, senderEmail, senderName, subject, body);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

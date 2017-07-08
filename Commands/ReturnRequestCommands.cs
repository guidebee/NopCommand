// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ReturnRequestCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ReturnRequestCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ReturnRequestCommands
    {
        /// <summary>
        /// Gets the return request by identifier.
        /// </summary>
        /// <param name="returnRequestId">The return request identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetReturnRequestById(int returnRequestId)
        {
            var returnRequestService = EngineContext.Current.Resolve<IReturnRequestService>();
            var returnRequestCore = returnRequestService.GetReturnRequestById(returnRequestId);
            var returnRequest = AutoMapperConfiguration.Mapper.Map<Domain.Orders.ReturnRequest>(returnRequestCore);
            return JsonConvert.SerializeObject(returnRequest, Formatting.Indented);
        }

        /// <summary>
        /// Searches the return requests.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderItemId">The order item identifier.</param>
        /// <param name="customNumber">The custom number.</param>
        /// <param name="rs">The rs.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SearchReturnRequests(int storeId = 0, int customerId = 0, int orderItemId = 0, string customNumber = "", ReturnRequestStatus? rs = null, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var returnRequestService = EngineContext.Current.Resolve<IReturnRequestService>();
            var returnRequestCore = returnRequestService.SearchReturnRequests(storeId, customerId, orderItemId, customNumber, rs, createdFromUtc, createdToUtc, pageIndex, pageSize);
            var returnRequest = returnRequestCore.MapSourcePageList<ReturnRequest, Domain.Orders.ReturnRequest>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(returnRequest, Formatting.Indented, new PageListConverter<Domain.Orders.ReturnRequest>());
        }

        /// <summary>
        /// Gets the return request action by identifier.
        /// </summary>
        /// <param name="returnRequestActionId">The return request action identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetReturnRequestActionById(int returnRequestActionId)
        {
            var returnRequestService = EngineContext.Current.Resolve<IReturnRequestService>();
            var returnRequestActionCore = returnRequestService.GetReturnRequestActionById(returnRequestActionId);
            var returnRequestAction = AutoMapperConfiguration.Mapper.Map<Domain.Orders.ReturnRequestAction>(returnRequestActionCore);
            return JsonConvert.SerializeObject(returnRequestAction, Formatting.Indented);
        }

        /// <summary>
        /// Gets the return request reason by identifier.
        /// </summary>
        /// <param name="returnRequestReasonId">The return request reason identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetReturnRequestReasonById(int returnRequestReasonId)
        {
            var returnRequestService = EngineContext.Current.Resolve<IReturnRequestService>();
            var returnRequestReasonCore = returnRequestService.GetReturnRequestReasonById(returnRequestReasonId);
            var returnRequestReason = AutoMapperConfiguration.Mapper.Map<Domain.Orders.ReturnRequestReason>(returnRequestReasonCore);
            return JsonConvert.SerializeObject(returnRequestReason, Formatting.Indented);
        }

    }
}

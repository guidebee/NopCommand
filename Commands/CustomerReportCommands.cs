// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CustomerReportCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Core.Domain.Shipping;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Customers;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CustomerReportCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CustomerReportCommands
    {
        /// <summary>
        /// Gets the best customers report.
        /// </summary>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="os">The os.</param>
        /// <param name="ps">The ps.</param>
        /// <param name="ss">The ss.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetBestCustomersReport(DateTime? createdFromUtc, DateTime? createdToUtc, OrderStatus? os, PaymentStatus? ps, ShippingStatus? ss, int orderBy, int pageIndex = 0, int pageSize = 214748364)
        {
            var customerReportService = EngineContext.Current.Resolve<ICustomerReportService>();
            var bestCustomerReportLineCore = customerReportService.GetBestCustomersReport(createdFromUtc, createdToUtc, os, ps, ss, orderBy, pageIndex, pageSize);
            var bestCustomerReportLine = bestCustomerReportLineCore.MapSourcePageList<Nop.Core.Domain.Customers.BestCustomerReportLine, Domain.Customers.BestCustomerReportLine>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(bestCustomerReportLine, Formatting.Indented, new PageListConverter<Domain.Customers.BestCustomerReportLine>());
        }

        /// <summary>
        /// Gets the registered customers report.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRegisteredCustomersReport(int days)
        {
            var customerReportService = EngineContext.Current.Resolve<ICustomerReportService>();
            var primitiveCore = customerReportService.GetRegisteredCustomersReport(days);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

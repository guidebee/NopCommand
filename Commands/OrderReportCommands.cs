// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="OrderReportCommands.cs" company="Guidebee IT">
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
using Nop.Services.Orders;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class OrderReportCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class OrderReportCommands
    {
        /// <summary>
        /// Gets the country report.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="os">The os.</param>
        /// <param name="ps">The ps.</param>
        /// <param name="ss">The ss.</param>
        /// <param name="startTimeUtc">The start time UTC.</param>
        /// <param name="endTimeUtc">The end time UTC.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCountryReport(int storeId = 0, OrderStatus? os = null, PaymentStatus? ps = null, ShippingStatus? ss = null, DateTime? startTimeUtc = null, DateTime? endTimeUtc = null)
        {
            var orderReportService = EngineContext.Current.Resolve<IOrderReportService>();
            var orderByCountryReportLineCore = orderReportService.GetCountryReport(storeId, os, ps, ss, startTimeUtc, endTimeUtc);
            var orderByCountryReportLine = orderByCountryReportLineCore.MapSource<OrderByCountryReportLine, Domain.Orders.OrderByCountryReportLine>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(orderByCountryReportLine, Formatting.Indented);
        }

        /// <summary>
        /// Orders the average report.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="os">The os.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string OrderAverageReport(int storeId, OrderStatus os)
        {
            var orderReportService = EngineContext.Current.Resolve<IOrderReportService>();
            var orderAverageReportLineSummaryCore = orderReportService.OrderAverageReport(storeId, os);
            var orderAverageReportLineSummary = AutoMapperConfiguration.Mapper.Map<Domain.Orders.OrderAverageReportLineSummary>(orderAverageReportLineSummaryCore);
            return JsonConvert.SerializeObject(orderAverageReportLineSummary, Formatting.Indented);
        }

        /// <summary>
        /// Bests the sellers report.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="os">The os.</param>
        /// <param name="ps">The ps.</param>
        /// <param name="ss">The ss.</param>
        /// <param name="billingCountryId">The billing country identifier.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string BestSellersReport(int categoryId = 0, int manufacturerId = 0, int storeId = 0, int vendorId = 0, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, OrderStatus? os = null, PaymentStatus? ps = null, ShippingStatus? ss = null, int billingCountryId = 0, int orderBy = 1, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var orderReportService = EngineContext.Current.Resolve<IOrderReportService>();
            var bestsellersReportLineCore = orderReportService.BestSellersReport(categoryId, manufacturerId, storeId, vendorId, createdFromUtc, createdToUtc, os, ps, ss, billingCountryId, orderBy, pageIndex, pageSize, showHidden);
            var bestsellersReportLine = bestsellersReportLineCore.MapSourcePageList<BestsellersReportLine, Domain.Orders.BestsellersReportLine>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(bestsellersReportLine, Formatting.Indented, new PageListConverter<Domain.Orders.BestsellersReportLine>());
        }

        /// <summary>
        /// Gets the also purchased products ids.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="recordsToReturn">The records to return.</param>
        /// <param name="visibleIndividuallyOnly">if set to <c>true</c> [visible individually only].</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAlsoPurchasedProductsIds(int storeId, int productId, int recordsToReturn = 5, bool visibleIndividuallyOnly = true, bool showHidden = false)
        {
            var orderReportService = EngineContext.Current.Resolve<IOrderReportService>();
            var int32Core = orderReportService.GetAlsoPurchasedProductsIds(storeId, productId, recordsToReturn, visibleIndividuallyOnly, showHidden);
            return JsonConvert.SerializeObject(int32Core, Formatting.Indented);
        }

        /// <summary>
        /// Productses the never sold.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="manufacturerId">The manufacturer identifier.</param>
        /// <param name="createdFromUtc">The created from UTC.</param>
        /// <param name="createdToUtc">The created to UTC.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ProductsNeverSold(int vendorId = 0, int storeId = 0, int categoryId = 0, int manufacturerId = 0, DateTime? createdFromUtc = null, DateTime? createdToUtc = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var orderReportService = EngineContext.Current.Resolve<IOrderReportService>();
            var productCore = orderReportService.ProductsNeverSold(vendorId, storeId, categoryId, manufacturerId, createdFromUtc, createdToUtc, pageIndex, pageSize, showHidden);
            var product = productCore.MapSourcePageList<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(product, Formatting.Indented, new PageListConverter<Domain.Catalog.Product>());
        }

    }
}

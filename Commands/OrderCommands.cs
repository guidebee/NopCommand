// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="OrderCommands.cs" company="Guidebee IT">
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
    /// Class OrderCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class OrderCommands
    {
        /// <summary>
        /// Gets the order by identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderById(int orderId)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderCore = orderService.GetOrderById(orderId);
            var order = AutoMapperConfiguration.Mapper.Map<Domain.Orders.Order>(orderCore);
            return JsonConvert.SerializeObject(order, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order by custom order number.
        /// </summary>
        /// <param name="customOrderNumber">The custom order number.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderByCustomOrderNumber(string customOrderNumber)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderCore = orderService.GetOrderByCustomOrderNumber(customOrderNumber);
            var order = AutoMapperConfiguration.Mapper.Map<Domain.Orders.Order>(orderCore);
            return JsonConvert.SerializeObject(order, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order by unique identifier.
        /// </summary>
        /// <param name="orderGuid">The order unique identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderByGuid(Guid orderGuid)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderCore = orderService.GetOrderByGuid(orderGuid);
            var order = AutoMapperConfiguration.Mapper.Map<Domain.Orders.Order>(orderCore);
            return JsonConvert.SerializeObject(order, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order by authorization transaction identifier and payment method.
        /// </summary>
        /// <param name="authorizationTransactionId">The authorization transaction identifier.</param>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderByAuthorizationTransactionIdAndPaymentMethod(string authorizationTransactionId, string paymentMethodSystemName)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderCore = orderService.GetOrderByAuthorizationTransactionIdAndPaymentMethod(authorizationTransactionId, paymentMethodSystemName);
            var order = AutoMapperConfiguration.Mapper.Map<Domain.Orders.Order>(orderCore);
            return JsonConvert.SerializeObject(order, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order item by identifier.
        /// </summary>
        /// <param name="orderItemId">The order item identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderItemById(int orderItemId)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderItemCore = orderService.GetOrderItemById(orderItemId);
            var orderItem = AutoMapperConfiguration.Mapper.Map<Domain.Orders.OrderItem>(orderItemCore);
            return JsonConvert.SerializeObject(orderItem, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order item by unique identifier.
        /// </summary>
        /// <param name="orderItemGuid">The order item unique identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderItemByGuid(Guid orderItemGuid)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderItemCore = orderService.GetOrderItemByGuid(orderItemGuid);
            var orderItem = AutoMapperConfiguration.Mapper.Map<Domain.Orders.OrderItem>(orderItemCore);
            return JsonConvert.SerializeObject(orderItem, Formatting.Indented);
        }

        /// <summary>
        /// Gets the downloadable order items.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetDownloadableOrderItems(int customerId)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderItemCore = orderService.GetDownloadableOrderItems(customerId);
            var orderItem = orderItemCore.MapSource<OrderItem, Domain.Orders.OrderItem>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(orderItem, Formatting.Indented);
        }

        /// <summary>
        /// Gets the order note by identifier.
        /// </summary>
        /// <param name="orderNoteId">The order note identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetOrderNoteById(int orderNoteId)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var orderNoteCore = orderService.GetOrderNoteById(orderNoteId);
            var orderNote = AutoMapperConfiguration.Mapper.Map<Domain.Orders.OrderNote>(orderNoteCore);
            return JsonConvert.SerializeObject(orderNote, Formatting.Indented);
        }

        /// <summary>
        /// Gets the recurring payment by identifier.
        /// </summary>
        /// <param name="recurringPaymentId">The recurring payment identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRecurringPaymentById(int recurringPaymentId)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var recurringPaymentCore = orderService.GetRecurringPaymentById(recurringPaymentId);
            var recurringPayment = AutoMapperConfiguration.Mapper.Map<Domain.Orders.RecurringPayment>(recurringPaymentCore);
            return JsonConvert.SerializeObject(recurringPayment, Formatting.Indented);
        }

        /// <summary>
        /// Searches the recurring payments.
        /// </summary>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="initialOrderId">The initial order identifier.</param>
        /// <param name="initialOrderStatus">The initial order status.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SearchRecurringPayments(int storeId = 0, int customerId = 0, int initialOrderId = 0, OrderStatus? initialOrderStatus = null, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var orderService = EngineContext.Current.Resolve<IOrderService>();
            var recurringPaymentCore = orderService.SearchRecurringPayments(storeId, customerId, initialOrderId, initialOrderStatus, pageIndex, pageSize, showHidden);
            var recurringPayment = recurringPaymentCore.MapSourcePageList<RecurringPayment, Domain.Orders.RecurringPayment>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(recurringPayment, Formatting.Indented, new PageListConverter<Domain.Orders.RecurringPayment>());
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="PaymentCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using Nop.Services.Payments;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class PaymentCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class PaymentCommands
    {
        /// <summary>
        /// Loads the name of the payment method by system.
        /// </summary>
        /// <param name="systemName">Name of the system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string LoadPaymentMethodBySystemName(string systemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var iPaymentMethodCore = paymentService.LoadPaymentMethodBySystemName(systemName);
            var iPaymentMethod = AutoMapperConfiguration.Mapper.Map<IPaymentMethod>(iPaymentMethodCore);
            return JsonConvert.SerializeObject(iPaymentMethod, Formatting.Indented);
        }

        /// <summary>
        /// Supports the capture.
        /// </summary>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SupportCapture(string paymentMethodSystemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.SupportCapture(paymentMethodSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Supports the partially refund.
        /// </summary>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SupportPartiallyRefund(string paymentMethodSystemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.SupportPartiallyRefund(paymentMethodSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Supports the refund.
        /// </summary>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SupportRefund(string paymentMethodSystemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.SupportRefund(paymentMethodSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Supports the void.
        /// </summary>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string SupportVoid(string paymentMethodSystemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.SupportVoid(paymentMethodSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the type of the recurring payment.
        /// </summary>
        /// <param name="paymentMethodSystemName">Name of the payment method system.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRecurringPaymentType(string paymentMethodSystemName)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.GetRecurringPaymentType(paymentMethodSystemName);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the masked credit card number.
        /// </summary>
        /// <param name="creditCardNumber">The credit card number.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetMaskedCreditCardNumber(string creditCardNumber)
        {
            var paymentService = EngineContext.Current.Resolve<IPaymentService>();
            var primitiveCore = paymentService.GetMaskedCreditCardNumber(creditCardNumber);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-06-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="DataCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Domain.Affiliates;

using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class DataCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class DataCommands
    {

        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="top">The top.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ReadTable(string tableName, int id = -1, int top = 10)
        {

            var coreType = GetTableType(tableName);
            var repoType = typeof(IRepository<>).MakeGenericType(coreType);

            var repo = EngineContext.Current.Resolve(repoType);

            var result = GetResultAsJson(tableName, repo, id, top);

            return result;
        }

        /// <summary>
        /// Reads the table by page.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string ReadTableByPage(string tableName, int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var coreType = GetTableType(tableName);
            var repoType = typeof(IRepository<>).MakeGenericType(coreType);

            var repo = EngineContext.Current.Resolve(repoType);

            var result = GetResultAsJsonByPage(tableName, repo, pageIndex, pageSize);

            return result;
        }

        public static string Help(string commandName = "")
        {
            List<string> commands=new List<string>();
            if (string.IsNullOrEmpty(commandName))
            {
                //show all top command
                foreach (var commandLibrary in Program.CommandLibraries)
                {
                    commands.Add(commandLibrary.Key);
                }

            }
            else
            {
                if (Program.CommandLibraries.ContainsKey(commandName))
                {
                    foreach (var subcommand in Program.CommandLibraries[commandName])
                    {
                        commands.Add(subcommand.Key);
                    }
                }
                else
                {
                    commands.Add("Command not found");
                }
            }

            return JsonConvert.SerializeObject(commands, Formatting.Indented);
        }

        /// <summary>
        /// The core domain assembly
        /// </summary>
        private static readonly Assembly CoreDomainAssembly;

        /// <summary>
        /// Initializes static members of the <see cref="DataCommands" /> class.
        /// </summary>
        /// <remarks>Guidebee IT</remarks>
        static DataCommands()
        {
            CoreDomainAssembly = Assembly.GetAssembly(typeof(Affiliate));
        }


        /// <summary>
        /// Gets the type of the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>Type.</returns>
        /// <exception cref="System.ArgumentException">Invalid table nane</exception>
        /// <remarks>Guidebee IT</remarks>
        private static Type GetTableType(string tableName)
        {
            Type coreType = null;
            foreach (var type in CoreDomainAssembly.ExportedTypes)
            {
                var names = type.FullName.Split('.');

                if (names[names.Length - 1] == (tableName))
                {
                    coreType = type;
                    break;
                }
            }
            if (coreType == null) throw new ArgumentException("Invalid table name");
            return coreType;
        }

        /// <summary>
        /// Gets the result as json generic.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="top">The top.</param>
        /// <returns>System.String.</returns>
        private static string GetResultAsJsonGeneric(string type, string tableName, object repo, int id = -1, int top = 10)
        {
            var result = string.Empty;
            switch (tableName)
            {
                case "Setting": result = GetResultGeneric<Nop.Core.Domain.Configuration.Setting, Domain.Configuration.Setting>(type, repo, id, top); break;
                case "TaxCategory": result = GetResultGeneric<Nop.Core.Domain.Tax.TaxCategory, Domain.Tax.TaxCategory>(type, repo, id, top); break;
                case "Download": result = GetResultGeneric<Nop.Core.Domain.Media.Download, Domain.Media.Download>(type, repo, id, top); break;
                case "Picture": result = GetResultGeneric<Nop.Core.Domain.Media.Picture, Domain.Media.Picture>(type, repo, id, top); break;
                case "ActivityLog": result = GetResultGeneric<Nop.Core.Domain.Logging.ActivityLog, Domain.Logging.ActivityLog>(type, repo, id, top); break;
                case "ActivityLogType": result = GetResultGeneric<Nop.Core.Domain.Logging.ActivityLogType, Domain.Logging.ActivityLogType>(type, repo, id, top); break;
                case "Log": result = GetResultGeneric<Nop.Core.Domain.Logging.Log, Domain.Logging.Log>(type, repo, id, top); break;
                case "LocalizedProperty": result = GetResultGeneric<Nop.Core.Domain.Localization.LocalizedProperty, Domain.Localization.LocalizedProperty>(type, repo, id, top); break;
                case "Language": result = GetResultGeneric<Nop.Core.Domain.Localization.Language, Domain.Localization.Language>(type, repo, id, top); break;
                case "LocaleStringResource": result = GetResultGeneric<Nop.Core.Domain.Localization.LocaleStringResource, Domain.Localization.LocaleStringResource>(type, repo, id, top); break;
                case "Affiliate": result = GetResultGeneric<Affiliate, Domain.Affiliates.Affiliate>(type, repo, id, top); break;
                case "PollVotingRecord": result = GetResultGeneric<Nop.Core.Domain.Polls.PollVotingRecord, Domain.Polls.PollVotingRecord>(type, repo, id, top); break;
                case "PollAnswer": result = GetResultGeneric<Nop.Core.Domain.Polls.PollAnswer, Domain.Polls.PollAnswer>(type, repo, id, top); break;
                case "Poll": result = GetResultGeneric<Nop.Core.Domain.Polls.Poll, Domain.Polls.Poll>(type, repo, id, top); break;
                case "ScheduleTask": result = GetResultGeneric<Nop.Core.Domain.Tasks.ScheduleTask, Domain.Tasks.ScheduleTask>(type, repo, id, top); break;
                case "AclRecord": result = GetResultGeneric<Nop.Core.Domain.Security.AclRecord, Domain.Security.AclRecord>(type, repo, id, top); break;
                case "PermissionRecord": result = GetResultGeneric<Nop.Core.Domain.Security.PermissionRecord, Domain.Security.PermissionRecord>(type, repo, id, top); break;
                case "StoreMapping": result = GetResultGeneric<Nop.Core.Domain.Stores.StoreMapping, Domain.Stores.StoreMapping>(type, repo, id, top); break;
                case "Store": result = GetResultGeneric<Nop.Core.Domain.Stores.Store, Domain.Stores.Store>(type, repo, id, top); break;
                case "VendorNote": result = GetResultGeneric<Nop.Core.Domain.Vendors.VendorNote, Domain.Vendors.VendorNote>(type, repo, id, top); break;
                case "Vendor": result = GetResultGeneric<Nop.Core.Domain.Vendors.Vendor, Domain.Vendors.Vendor>(type, repo, id, top); break;
                case "TopicTemplate": result = GetResultGeneric<Nop.Core.Domain.Topics.TopicTemplate, Domain.Topics.TopicTemplate>(type, repo, id, top); break;
                case "Topic": result = GetResultGeneric<Nop.Core.Domain.Topics.Topic, Domain.Topics.Topic>(type, repo, id, top); break;
                case "ProductAvailabilityRange": result = GetResultGeneric<Nop.Core.Domain.Shipping.ProductAvailabilityRange, Domain.Shipping.ProductAvailabilityRange>(type, repo, id, top); break;
                case "Warehouse": result = GetResultGeneric<Nop.Core.Domain.Shipping.Warehouse, Domain.Shipping.Warehouse>(type, repo, id, top); break;
                case "DeliveryDate": result = GetResultGeneric<Nop.Core.Domain.Shipping.DeliveryDate, Domain.Shipping.DeliveryDate>(type, repo, id, top); break;
                case "ShipmentItem": result = GetResultGeneric<Nop.Core.Domain.Shipping.ShipmentItem, Domain.Shipping.ShipmentItem>(type, repo, id, top); break;
                case "Shipment": result = GetResultGeneric<Nop.Core.Domain.Shipping.Shipment, Domain.Shipping.Shipment>(type, repo, id, top); break;
                case "ShippingMethod": result = GetResultGeneric<Nop.Core.Domain.Shipping.ShippingMethod, Domain.Shipping.ShippingMethod>(type, repo, id, top); break;
                case "UrlRecord": result = GetResultGeneric<Nop.Core.Domain.Seo.UrlRecord, Domain.Seo.UrlRecord>(type, repo, id, top); break;
                case "ReturnRequestReason": result = GetResultGeneric<Nop.Core.Domain.Orders.ReturnRequestReason, Domain.Orders.ReturnRequestReason>(type, repo, id, top); break;
                case "ReturnRequestAction": result = GetResultGeneric<Nop.Core.Domain.Orders.ReturnRequestAction, Domain.Orders.ReturnRequestAction>(type, repo, id, top); break;
                case "OrderNote": result = GetResultGeneric<Nop.Core.Domain.Orders.OrderNote, Domain.Orders.OrderNote>(type, repo, id, top); break;
                case "OrderItem": result = GetResultGeneric<Nop.Core.Domain.Orders.OrderItem, Domain.Orders.OrderItem>(type, repo, id, top); break;
                case "RecurringPayment": result = GetResultGeneric<Nop.Core.Domain.Orders.RecurringPayment, Domain.Orders.RecurringPayment>(type, repo, id, top); break;
                case "RecurringPaymentHistory": result = GetResultGeneric<Nop.Core.Domain.Orders.RecurringPaymentHistory, Domain.Orders.RecurringPaymentHistory>(type, repo, id, top); break;
                case "ReturnRequest": result = GetResultGeneric<Nop.Core.Domain.Orders.ReturnRequest, Domain.Orders.ReturnRequest>(type, repo, id, top); break;
                case "CheckoutAttribute": result = GetResultGeneric<Nop.Core.Domain.Orders.CheckoutAttribute, Domain.Orders.CheckoutAttribute>(type, repo, id, top); break;
                case "CheckoutAttributeValue": result = GetResultGeneric<Nop.Core.Domain.Orders.CheckoutAttributeValue, Domain.Orders.CheckoutAttributeValue>(type, repo, id, top); break;
                case "GiftCard": result = GetResultGeneric<Nop.Core.Domain.Orders.GiftCard, Domain.Orders.GiftCard>(type, repo, id, top); break;
                case "GiftCardUsageHistory": result = GetResultGeneric<Nop.Core.Domain.Orders.GiftCardUsageHistory, Domain.Orders.GiftCardUsageHistory>(type, repo, id, top); break;
                case "Order": result = GetResultGeneric<Nop.Core.Domain.Orders.Order, Domain.Orders.Order>(type, repo, id, top); break;
                case "ShoppingCartItem": result = GetResultGeneric<Nop.Core.Domain.Orders.ShoppingCartItem, Domain.Orders.ShoppingCartItem>(type, repo, id, top); break;
                case "NewsComment": result = GetResultGeneric<Nop.Core.Domain.News.NewsComment, Domain.News.NewsComment>(type, repo, id, top); break;
                case "NewsItem": result = GetResultGeneric<Nop.Core.Domain.News.NewsItem, Domain.News.NewsItem>(type, repo, id, top); break;
                case "Campaign": result = GetResultGeneric<Nop.Core.Domain.Messages.Campaign, Domain.Messages.Campaign>(type, repo, id, top); break;
                case "EmailAccount": result = GetResultGeneric<Nop.Core.Domain.Messages.EmailAccount, Domain.Messages.EmailAccount>(type, repo, id, top); break;
                case "MessageTemplate": result = GetResultGeneric<Nop.Core.Domain.Messages.MessageTemplate, Domain.Messages.MessageTemplate>(type, repo, id, top); break;
                case "NewsLetterSubscription": result = GetResultGeneric<Nop.Core.Domain.Messages.NewsLetterSubscription, Domain.Messages.NewsLetterSubscription>(type, repo, id, top); break;
                case "QueuedEmail": result = GetResultGeneric<Nop.Core.Domain.Messages.QueuedEmail, Domain.Messages.QueuedEmail>(type, repo, id, top); break;
                case "ForumPostVote": result = GetResultGeneric<Nop.Core.Domain.Forums.ForumPostVote, Domain.Forums.ForumPostVote>(type, repo, id, top); break;
                case "Forum": result = GetResultGeneric<Nop.Core.Domain.Forums.Forum, Domain.Forums.Forum>(type, repo, id, top); break;
                case "ForumGroup": result = GetResultGeneric<Nop.Core.Domain.Forums.ForumGroup, Domain.Forums.ForumGroup>(type, repo, id, top); break;
                case "ForumPost": result = GetResultGeneric<Nop.Core.Domain.Forums.ForumPost, Domain.Forums.ForumPost>(type, repo, id, top); break;
                case "ForumSubscription": result = GetResultGeneric<Nop.Core.Domain.Forums.ForumSubscription, Domain.Forums.ForumSubscription>(type, repo, id, top); break;
                case "ForumTopic": result = GetResultGeneric<Nop.Core.Domain.Forums.ForumTopic, Domain.Forums.ForumTopic>(type, repo, id, top); break;
                case "PrivateMessage": result = GetResultGeneric<Nop.Core.Domain.Forums.PrivateMessage, Domain.Forums.PrivateMessage>(type, repo, id, top); break;
                case "Country": result = GetResultGeneric<Nop.Core.Domain.Directory.Country, Domain.Directory.Country>(type, repo, id, top); break;
                case "Currency": result = GetResultGeneric<Nop.Core.Domain.Directory.Currency, Domain.Directory.Currency>(type, repo, id, top); break;
                case "MeasureDimension": result = GetResultGeneric<Nop.Core.Domain.Directory.MeasureDimension, Domain.Directory.MeasureDimension>(type, repo, id, top); break;
                case "MeasureWeight": result = GetResultGeneric<Nop.Core.Domain.Directory.MeasureWeight, Domain.Directory.MeasureWeight>(type, repo, id, top); break;
                case "StateProvince": result = GetResultGeneric<Nop.Core.Domain.Directory.StateProvince, Domain.Directory.StateProvince>(type, repo, id, top); break;
                case "DiscountUsageHistory": result = GetResultGeneric<Nop.Core.Domain.Discounts.DiscountUsageHistory, Domain.Discounts.DiscountUsageHistory>(type, repo, id, top); break;
                case "DiscountRequirement": result = GetResultGeneric<Nop.Core.Domain.Discounts.DiscountRequirement, Domain.Discounts.DiscountRequirement>(type, repo, id, top); break;
                case "Discount": result = GetResultGeneric<Nop.Core.Domain.Discounts.Discount, Domain.Discounts.Discount>(type, repo, id, top); break;
                case "CustomerPassword": result = GetResultGeneric<Nop.Core.Domain.Customers.CustomerPassword, Domain.Customers.CustomerPassword>(type, repo, id, top); break;
                case "CustomerAttribute": result = GetResultGeneric<Nop.Core.Domain.Customers.CustomerAttribute, Domain.Customers.CustomerAttribute>(type, repo, id, top); break;
                case "CustomerAttributeValue": result = GetResultGeneric<Nop.Core.Domain.Customers.CustomerAttributeValue, Domain.Customers.CustomerAttributeValue>(type, repo, id, top); break;
                case "ExternalAuthenticationRecord": result = GetResultGeneric<Nop.Core.Domain.Customers.ExternalAuthenticationRecord, Domain.Customers.ExternalAuthenticationRecord>(type, repo, id, top); break;
                case "RewardPointsHistory": result = GetResultGeneric<Nop.Core.Domain.Customers.RewardPointsHistory, Domain.Customers.RewardPointsHistory>(type, repo, id, top); break;
                case "Customer": result = GetResultGeneric<Nop.Core.Domain.Customers.Customer, Domain.Customers.Customer>(type, repo, id, top); break;
                case "PredefinedProductAttributeValue": result = GetResultGeneric<Nop.Core.Domain.Catalog.PredefinedProductAttributeValue, Domain.Catalog.PredefinedProductAttributeValue>(type, repo, id, top); break;
                case "StockQuantityHistory": result = GetResultGeneric<Nop.Core.Domain.Catalog.StockQuantityHistory, Domain.Catalog.StockQuantityHistory>(type, repo, id, top); break;
                case "ProductWarehouseInventory": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductWarehouseInventory, Domain.Catalog.ProductWarehouseInventory>(type, repo, id, top); break;
                case "BackInStockSubscription": result = GetResultGeneric<Nop.Core.Domain.Catalog.BackInStockSubscription, Domain.Catalog.BackInStockSubscription>(type, repo, id, top); break;
                case "ManufacturerTemplate": result = GetResultGeneric<Nop.Core.Domain.Catalog.ManufacturerTemplate, Domain.Catalog.ManufacturerTemplate>(type, repo, id, top); break;
                case "CategoryTemplate": result = GetResultGeneric<Nop.Core.Domain.Catalog.CategoryTemplate, Domain.Catalog.CategoryTemplate>(type, repo, id, top); break;
                case "ProductTemplate": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductTemplate, Domain.Catalog.ProductTemplate>(type, repo, id, top); break;
                case "ProductTag": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductTag, Domain.Catalog.ProductTag>(type, repo, id, top); break;
                case "ProductReviewHelpfulness": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductReviewHelpfulness, Domain.Catalog.ProductReviewHelpfulness>(type, repo, id, top); break;
                case "ProductReview": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductReview, Domain.Catalog.ProductReview>(type, repo, id, top); break;
                case "Category": result = GetResultGeneric<Nop.Core.Domain.Catalog.Category, Domain.Catalog.Category>(type, repo, id, top); break;
                case "CrossSellProduct": result = GetResultGeneric<Nop.Core.Domain.Catalog.CrossSellProduct, Domain.Catalog.CrossSellProduct>(type, repo, id, top); break;
                case "Manufacturer": result = GetResultGeneric<Nop.Core.Domain.Catalog.Manufacturer, Domain.Catalog.Manufacturer>(type, repo, id, top); break;
                case "Product": result = GetResultGeneric<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(type, repo, id, top); break;
                case "ProductAttribute": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductAttribute, Domain.Catalog.ProductAttribute>(type, repo, id, top); break;
                case "ProductCategory": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductCategory, Domain.Catalog.ProductCategory>(type, repo, id, top); break;
                case "ProductManufacturer": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductManufacturer, Domain.Catalog.ProductManufacturer>(type, repo, id, top); break;
                case "ProductPicture": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductPicture, Domain.Catalog.ProductPicture>(type, repo, id, top); break;
                case "ProductSpecificationAttribute": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductSpecificationAttribute, Domain.Catalog.ProductSpecificationAttribute>(type, repo, id, top); break;
                case "ProductAttributeMapping": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductAttributeMapping, Domain.Catalog.ProductAttributeMapping>(type, repo, id, top); break;
                case "ProductAttributeCombination": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductAttributeCombination, Domain.Catalog.ProductAttributeCombination>(type, repo, id, top); break;
                case "ProductAttributeValue": result = GetResultGeneric<Nop.Core.Domain.Catalog.ProductAttributeValue, Domain.Catalog.ProductAttributeValue>(type, repo, id, top); break;
                case "RelatedProduct": result = GetResultGeneric<Nop.Core.Domain.Catalog.RelatedProduct, Domain.Catalog.RelatedProduct>(type, repo, id, top); break;
                case "SpecificationAttribute": result = GetResultGeneric<Nop.Core.Domain.Catalog.SpecificationAttribute, Domain.Catalog.SpecificationAttribute>(type, repo, id, top); break;
                case "SpecificationAttributeOption": result = GetResultGeneric<Nop.Core.Domain.Catalog.SpecificationAttributeOption, Domain.Catalog.SpecificationAttributeOption>(type, repo, id, top); break;
                case "TierPrice": result = GetResultGeneric<Nop.Core.Domain.Catalog.TierPrice, Domain.Catalog.TierPrice>(type, repo, id, top); break;
                case "AddressAttribute": result = GetResultGeneric<Nop.Core.Domain.Common.AddressAttribute, Domain.Common.AddressAttribute>(type, repo, id, top); break;
                case "AddressAttributeValue": result = GetResultGeneric<Nop.Core.Domain.Common.AddressAttributeValue, Domain.Common.AddressAttributeValue>(type, repo, id, top); break;
                case "SearchTerm": result = GetResultGeneric<Nop.Core.Domain.Common.SearchTerm, Domain.Common.SearchTerm>(type, repo, id, top); break;
                case "GenericAttribute": result = GetResultGeneric<Nop.Core.Domain.Common.GenericAttribute, Domain.Common.GenericAttribute>(type, repo, id, top); break;
                case "Address": result = GetResultGeneric<Nop.Core.Domain.Common.Address, Domain.Common.Address>(type, repo, id, top); break;
                case "BlogPost": result = GetResultGeneric<Nop.Core.Domain.Blogs.BlogPost, Domain.Blogs.BlogPost>(type, repo, id, top); break;
                case "BlogComment": result = GetResultGeneric<Nop.Core.Domain.Blogs.BlogComment, Domain.Blogs.BlogComment>(type, repo, id, top); break;



            }
            return result;
        }


        /// <summary>
        /// Gets the result as json.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="top">The top.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string GetResultAsJson(string tableName, object repo, int id = -1, int top = 10)
        {
            return GetResultAsJsonGeneric("Default", tableName, repo, id, top);
        }


        /// <summary>
        /// Gets the result as json by page.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string GetResultAsJsonByPage(string tableName, object repo, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return GetResultAsJsonGeneric("ByPage", tableName, repo, pageIndex, pageSize);
        }


        /// <summary>
        /// Gets the result generic.
        /// </summary>
        /// <typeparam name="TSrc">The type of the t source.</typeparam>
        /// <typeparam name="TDest">The type of the t dest.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="repo">The repo.</param>
        /// <param name="para1">The para1.</param>
        /// <param name="para2">The para2.</param>
        /// <returns>System.String.</returns>
        private static string GetResultGeneric<TSrc, TDest>(string type, object repo, int para1, int para2) where TSrc : BaseEntity
        {
            switch (type)
            {
                case "ByPage":
                    return GetResultByPage<TSrc, TDest>(repo, para1, para2);

                default:
                    return GetResult<TSrc, TDest>(repo, para1, para2);
            }
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <typeparam name="TSrc">The type of the t source.</typeparam>
        /// <typeparam name="TDest">The type of the t dest.</typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="top">The top.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string GetResult<TSrc, TDest>(object repo, int id = -1, int top = 10) where TSrc : BaseEntity
        {
            var result = string.Empty;
            var mapper = AutoMapperConfiguration.Mapper;
            var repo1 = repo as IRepository<TSrc>;
            if (repo1 != null)
            {
                var resultList = repo1.Table.Where(r => r.Id == id || id < 0).Take(top).ToList();
                var result1 = resultList.MapSource<TSrc, TDest>(mapper);
                result = JsonConvert.SerializeObject(result1, Formatting.Indented);
            }
            return result;
        }

        /// <summary>
        /// Gets the result by page.
        /// </summary>
        /// <typeparam name="TSrc">The type of the t source.</typeparam>
        /// <typeparam name="TDest">The type of the t dest.</typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string GetResultByPage<TSrc, TDest>(object repo, int pageIndex = 0, int pageSize = int.MaxValue) where TSrc : BaseEntity
        {
            var result = string.Empty;
            var mapper = AutoMapperConfiguration.Mapper;
            var repo1 = repo as IRepository<TSrc>;
            if (repo1 != null)
            {
                var resultList = new PagedList<TSrc>(repo1.Table.OrderBy(r => r.Id), pageIndex, pageSize);
                var result1 = resultList.MapSourcePageList<TSrc, TDest>(mapper);
                result = JsonConvert.SerializeObject(result1, Formatting.Indented, new PageListConverter<TDest>());
            }
            return result;
        }


    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="ProductCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Catalog;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class ProductCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class ProductCommands
    {
        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductById(int productId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productCore = productService.GetProductById(productId);
            var product = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.Product>(productCore);
            return JsonConvert.SerializeObject(product, Formatting.Indented);
        }

        /// <summary>
        /// Gets the products by product atribute identifier.
        /// </summary>
        /// <param name="productAttributeId">The product attribute identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductsByProductAtributeId(int productAttributeId, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productCore = productService.GetProductsByProductAtributeId(productAttributeId, pageIndex, pageSize);
            var product = productCore.MapSourcePageList<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(product, Formatting.Indented, new PageListConverter<Domain.Catalog.Product>());
        }

        /// <summary>
        /// Gets the associated products.
        /// </summary>
        /// <param name="parentGroupedProductId">The parent grouped product identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAssociatedProducts(int parentGroupedProductId, int storeId = 0, int vendorId = 0, bool showHidden = false)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productCore = productService.GetAssociatedProducts(parentGroupedProductId, storeId, vendorId, showHidden);
            var product = productCore.MapSource<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(product, Formatting.Indented);
        }

        /// <summary>
        /// Gets the low stock products.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetLowStockProducts(int vendorId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productCore = productService.GetLowStockProducts(vendorId, pageIndex, pageSize);
            var product = productCore.MapSourcePageList<Nop.Core.Domain.Catalog.Product, Domain.Catalog.Product>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(product, Formatting.Indented, new PageListConverter<Domain.Catalog.Product>());
        }

        /// <summary>
        /// Gets the low stock product combinations.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetLowStockProductCombinations(int vendorId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productAttributeCombinationCore = productService.GetLowStockProductCombinations(vendorId, pageIndex, pageSize);
            var productAttributeCombination = productAttributeCombinationCore.MapSourcePageList<Nop.Core.Domain.Catalog.ProductAttributeCombination, Domain.Catalog.ProductAttributeCombination>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productAttributeCombination, Formatting.Indented, new PageListConverter<Domain.Catalog.ProductAttributeCombination>());
        }

        /// <summary>
        /// Gets the product by sku.
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductBySku(string sku)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productCore = productService.GetProductBySku(sku);
            var product = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.Product>(productCore);
            return JsonConvert.SerializeObject(product, Formatting.Indented);
        }

        /// <summary>
        /// Gets the number of products by vendor identifier.
        /// </summary>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetNumberOfProductsByVendorId(int vendorId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var primitiveCore = productService.GetNumberOfProductsByVendorId(vendorId);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        /// <summary>
        /// Gets the related products by product id1.
        /// </summary>
        /// <param name="productId1">The product id1.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRelatedProductsByProductId1(int productId1, bool showHidden = false)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var relatedProductCore = productService.GetRelatedProductsByProductId1(productId1, showHidden);
            var relatedProduct = relatedProductCore.MapSource<Nop.Core.Domain.Catalog.RelatedProduct, Domain.Catalog.RelatedProduct>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(relatedProduct, Formatting.Indented);
        }

        /// <summary>
        /// Gets the related product by identifier.
        /// </summary>
        /// <param name="relatedProductId">The related product identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetRelatedProductById(int relatedProductId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var relatedProductCore = productService.GetRelatedProductById(relatedProductId);
            var relatedProduct = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.RelatedProduct>(relatedProductCore);
            return JsonConvert.SerializeObject(relatedProduct, Formatting.Indented);
        }

        /// <summary>
        /// Gets the cross sell products by product id1.
        /// </summary>
        /// <param name="productId1">The product id1.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCrossSellProductsByProductId1(int productId1, bool showHidden = false)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var crossSellProductCore = productService.GetCrossSellProductsByProductId1(productId1, showHidden);
            var crossSellProduct = crossSellProductCore.MapSource<Nop.Core.Domain.Catalog.CrossSellProduct, Domain.Catalog.CrossSellProduct>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(crossSellProduct, Formatting.Indented);
        }

        /// <summary>
        /// Gets the cross sell product by identifier.
        /// </summary>
        /// <param name="crossSellProductId">The cross sell product identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCrossSellProductById(int crossSellProductId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var crossSellProductCore = productService.GetCrossSellProductById(crossSellProductId);
            var crossSellProduct = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.CrossSellProduct>(crossSellProductCore);
            return JsonConvert.SerializeObject(crossSellProduct, Formatting.Indented);
        }

        /// <summary>
        /// Gets the tier price by identifier.
        /// </summary>
        /// <param name="tierPriceId">The tier price identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetTierPriceById(int tierPriceId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var tierPriceCore = productService.GetTierPriceById(tierPriceId);
            var tierPrice = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.TierPrice>(tierPriceCore);
            return JsonConvert.SerializeObject(tierPrice, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product pictures by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductPicturesByProductId(int productId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productPictureCore = productService.GetProductPicturesByProductId(productId);
            var productPicture = productPictureCore.MapSource<Nop.Core.Domain.Catalog.ProductPicture, Domain.Catalog.ProductPicture>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productPicture, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product picture by identifier.
        /// </summary>
        /// <param name="productPictureId">The product picture identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductPictureById(int productPictureId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productPictureCore = productService.GetProductPictureById(productPictureId);
            var productPicture = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductPicture>(productPictureCore);
            return JsonConvert.SerializeObject(productPicture, Formatting.Indented);
        }

        /// <summary>
        /// Gets all product reviews.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        /// <param name="fromUtc">From UTC.</param>
        /// <param name="toUtc">To UTC.</param>
        /// <param name="message">The message.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllProductReviews(int customerId, bool? approved, DateTime? fromUtc = null, DateTime? toUtc = null, string message = null, int storeId = 0, int productId = 0, int vendorId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productReviewCore = productService.GetAllProductReviews(customerId, approved, fromUtc, toUtc, message, storeId, productId, vendorId, pageIndex, pageSize);
            var productReview = productReviewCore.MapSourcePageList<Nop.Core.Domain.Catalog.ProductReview, Domain.Catalog.ProductReview>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productReview, Formatting.Indented, new PageListConverter<Domain.Catalog.ProductReview>());
        }

        /// <summary>
        /// Gets the product review by identifier.
        /// </summary>
        /// <param name="productReviewId">The product review identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductReviewById(int productReviewId)
        {
            var productService = EngineContext.Current.Resolve<IProductService>();
            var productReviewCore = productService.GetProductReviewById(productReviewId);
            var productReview = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductReview>(productReviewCore);
            return JsonConvert.SerializeObject(productReview, Formatting.Indented);
        }

    }
}

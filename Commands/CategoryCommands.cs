// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="CategoryCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Catalog;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class CategoryCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CategoryCommands
    {
        /// <summary>
        /// Gets all categories.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCategories(string categoryName = "", int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var categoryCore = categoryService.GetAllCategories(categoryName, storeId, pageIndex, pageSize, showHidden);
            var category = categoryCore.MapSourcePageList<Nop.Core.Domain.Catalog.Category, Domain.Catalog.Category>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(category, Formatting.Indented, new PageListConverter<Domain.Catalog.Category>());
        }

        /// <summary>
        /// Gets all categories by parent category identifier.
        /// </summary>
        /// <param name="parentCategoryId">The parent category identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <param name="includeAllLevels">if set to <c>true</c> [include all levels].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCategoriesByParentCategoryId(int parentCategoryId, bool showHidden = false, bool includeAllLevels = false)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var categoryCore = categoryService.GetAllCategoriesByParentCategoryId(parentCategoryId, showHidden, includeAllLevels);
            var category = categoryCore.MapSource<Nop.Core.Domain.Catalog.Category, Domain.Catalog.Category>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(category, Formatting.Indented);
        }

        /// <summary>
        /// Gets all categories displayed on home page.
        /// </summary>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAllCategoriesDisplayedOnHomePage(bool showHidden = false)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var categoryCore = categoryService.GetAllCategoriesDisplayedOnHomePage(showHidden);
            var category = categoryCore.MapSource<Nop.Core.Domain.Catalog.Category, Domain.Catalog.Category>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(category, Formatting.Indented);
        }

        /// <summary>
        /// Gets the category by identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetCategoryById(int categoryId)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var categoryCore = categoryService.GetCategoryById(categoryId);
            var category = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.Category>(categoryCore);
            return JsonConvert.SerializeObject(category, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product categories by category identifier.
        /// </summary>
        /// <param name="categoryId">The category identifier.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductCategoriesByCategoryId(int categoryId, int pageIndex = 0, int pageSize = int.MaxValue, bool showHidden = false)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var productCategoryCore = categoryService.GetProductCategoriesByCategoryId(categoryId, pageIndex, pageSize, showHidden);
            var productCategory = productCategoryCore.MapSourcePageList<Nop.Core.Domain.Catalog.ProductCategory, Domain.Catalog.ProductCategory>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productCategory, Formatting.Indented, new PageListConverter<Domain.Catalog.ProductCategory>());
        }



        /// <summary>
        /// Gets the product categories by product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="storeId">The store identifier.</param>
        /// <param name="showHidden">if set to <c>true</c> [show hidden].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductCategoriesByProductId(int productId, int storeId = 0, bool showHidden = false)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var productCategoryCore = categoryService.GetProductCategoriesByProductId(productId, storeId, showHidden);
            var productCategory = productCategoryCore.MapSource<Nop.Core.Domain.Catalog.ProductCategory, Domain.Catalog.ProductCategory>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productCategory, Formatting.Indented);
        }

        /// <summary>
        /// Gets the product category by identifier.
        /// </summary>
        /// <param name="productCategoryId">The product category identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetProductCategoryById(int productCategoryId)
        {
            var categoryService = EngineContext.Current.Resolve<ICategoryService>();
            var productCategoryCore = categoryService.GetProductCategoryById(productCategoryId);
            var productCategory = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductCategory>(productCategoryCore);
            return JsonConvert.SerializeObject(productCategory, Formatting.Indented);
        }

    }
}

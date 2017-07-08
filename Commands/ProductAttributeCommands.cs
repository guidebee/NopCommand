using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Catalog;

namespace NopCommand.Commands
{
    public static class ProductAttributeCommands
    {
        public static string GetAllProductAttributes(int pageIndex = 0,int pageSize = int.MaxValue)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeCore = productAttributeService.GetAllProductAttributes( pageIndex, pageSize);
            var productAttribute = productAttributeCore.MapSourcePageList<Nop.Core.Domain.Catalog.ProductAttribute, Domain.Catalog.ProductAttribute> (AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productAttribute, Formatting.Indented, new PageListConverter<Domain.Catalog.ProductAttribute>());
        }

        public static string GetProductAttributeById(int productAttributeId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeCore = productAttributeService.GetProductAttributeById( productAttributeId);
            var productAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductAttribute>(productAttributeCore);
            return JsonConvert.SerializeObject(productAttribute, Formatting.Indented);
        }

        public static string GetProductAttributeMappingsByProductId(int productId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeMappingCore = productAttributeService.GetProductAttributeMappingsByProductId( productId);
            var productAttributeMapping = productAttributeMappingCore.MapSource<Nop.Core.Domain.Catalog.ProductAttributeMapping, Domain.Catalog.ProductAttributeMapping>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productAttributeMapping, Formatting.Indented);
        }

        public static string GetProductAttributeMappingById(int productAttributeMappingId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeMappingCore = productAttributeService.GetProductAttributeMappingById( productAttributeMappingId);
            var productAttributeMapping = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductAttributeMapping>(productAttributeMappingCore);
            return JsonConvert.SerializeObject(productAttributeMapping, Formatting.Indented);
        }

        public static string GetProductAttributeValues(int productAttributeMappingId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeValueCore = productAttributeService.GetProductAttributeValues( productAttributeMappingId);
            var productAttributeValue = productAttributeValueCore.MapSource<Nop.Core.Domain.Catalog.ProductAttributeValue, Domain.Catalog.ProductAttributeValue>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productAttributeValue, Formatting.Indented);
        }

        public static string GetProductAttributeValueById(int productAttributeValueId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeValueCore = productAttributeService.GetProductAttributeValueById( productAttributeValueId);
            var productAttributeValue = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductAttributeValue>(productAttributeValueCore);
            return JsonConvert.SerializeObject(productAttributeValue, Formatting.Indented);
        }

        public static string GetPredefinedProductAttributeValues(int productAttributeId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var predefinedProductAttributeValueCore = productAttributeService.GetPredefinedProductAttributeValues( productAttributeId);
            var predefinedProductAttributeValue = predefinedProductAttributeValueCore.MapSource<Nop.Core.Domain.Catalog.PredefinedProductAttributeValue, Domain.Catalog.PredefinedProductAttributeValue>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(predefinedProductAttributeValue, Formatting.Indented);
        }

        public static string GetPredefinedProductAttributeValueById(int id)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var predefinedProductAttributeValueCore = productAttributeService.GetPredefinedProductAttributeValueById( id);
            var predefinedProductAttributeValue = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.PredefinedProductAttributeValue>(predefinedProductAttributeValueCore);
            return JsonConvert.SerializeObject(predefinedProductAttributeValue, Formatting.Indented);
        }

        public static string GetAllProductAttributeCombinations(int productId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeCombinationCore = productAttributeService.GetAllProductAttributeCombinations( productId);
            var productAttributeCombination = productAttributeCombinationCore.MapSource<Nop.Core.Domain.Catalog.ProductAttributeCombination, Domain.Catalog.ProductAttributeCombination>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(productAttributeCombination, Formatting.Indented);
        }

        public static string GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeCombinationCore = productAttributeService.GetProductAttributeCombinationById( productAttributeCombinationId);
            var productAttributeCombination = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductAttributeCombination>(productAttributeCombinationCore);
            return JsonConvert.SerializeObject(productAttributeCombination, Formatting.Indented);
        }

        public static string GetProductAttributeCombinationBySku(string sku)
        {
            var productAttributeService = EngineContext.Current.Resolve<IProductAttributeService>();
            var productAttributeCombinationCore = productAttributeService.GetProductAttributeCombinationBySku( sku);
            var productAttributeCombination = AutoMapperConfiguration.Mapper.Map<Domain.Catalog.ProductAttributeCombination>(productAttributeCombinationCore);
            return JsonConvert.SerializeObject(productAttributeCombination, Formatting.Indented);
        }

    }
}

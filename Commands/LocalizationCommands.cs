using System;
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Localization;

namespace NopCommand.Commands
{
    public static class LocalizationCommands
    {
        public static string GetLocaleStringResourceById(int localeStringResourceId)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var localeStringResourceCore = localizationService.GetLocaleStringResourceById( localeStringResourceId);
            var localeStringResource = AutoMapperConfiguration.Mapper.Map<Domain.Localization.LocaleStringResource>(localeStringResourceCore);
            return JsonConvert.SerializeObject(localeStringResource, Formatting.Indented);
        }

        public static string GetLocaleStringResourceByName(string resourceName)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var localeStringResourceCore = localizationService.GetLocaleStringResourceByName( resourceName);
            var localeStringResource = AutoMapperConfiguration.Mapper.Map<Domain.Localization.LocaleStringResource>(localeStringResourceCore);
            return JsonConvert.SerializeObject(localeStringResource, Formatting.Indented);
        }

        public static string GetLocaleStringResourceByName(string resourceName,int languageId,bool logIfNotFound = true)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var localeStringResourceCore = localizationService.GetLocaleStringResourceByName( resourceName, languageId, logIfNotFound);
            var localeStringResource = AutoMapperConfiguration.Mapper.Map<Domain.Localization.LocaleStringResource>(localeStringResourceCore);
            return JsonConvert.SerializeObject(localeStringResource, Formatting.Indented);
        }

        public static string GetAllResources(int languageId)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var localeStringResourceCore = localizationService.GetAllResources( languageId);
            var localeStringResource = localeStringResourceCore.MapSource<Nop.Core.Domain.Localization.LocaleStringResource, Domain.Localization.LocaleStringResource>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(localeStringResource, Formatting.Indented);
        }

        public static string GetAllResourceValues(int languageId)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var 0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]Core = localizationService.GetAllResourceValues( languageId);
            var 0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] = AutoMapperConfiguration.Mapper.Map<System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Collections.Generic.KeyValuePair`2[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]>(0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]Core);
            return JsonConvert.SerializeObject(0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], Formatting.Indented);
        }

        public static string GetResource(string resourceKey)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var primitiveCore = localizationService.GetResource( resourceKey);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

        public static string GetResource(string resourceKey,int languageId,bool logIfNotFound = true,string defaultValue = "",bool returnEmptyIfNotFound = false)
        {
            var localizationService = EngineContext.Current.Resolve<ILocalizationService>();
            var primitiveCore = localizationService.GetResource( resourceKey, languageId, logIfNotFound, defaultValue, returnEmptyIfNotFound);
            return JsonConvert.SerializeObject(primitiveCore, Formatting.Indented);
        }

    }
}

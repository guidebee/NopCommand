// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-08-2017
// ***********************************************************************
// <copyright file="GenericAttributeCommands.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.Mapper;
using NopCommand.Helpers;
using Nop.Services.Common;

namespace NopCommand.Commands
{
    /// <summary>
    /// Class GenericAttributeCommands.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class GenericAttributeCommands
    {
        /// <summary>
        /// Gets the attribute by identifier.
        /// </summary>
        /// <param name="attributeId">The attribute identifier.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAttributeById(int attributeId)
        {
            var genericAttributeService = EngineContext.Current.Resolve<IGenericAttributeService>();
            var genericAttributeCore = genericAttributeService.GetAttributeById(attributeId);
            var genericAttribute = AutoMapperConfiguration.Mapper.Map<Domain.Common.GenericAttribute>(genericAttributeCore);
            return JsonConvert.SerializeObject(genericAttribute, Formatting.Indented);
        }

        /// <summary>
        /// Gets the attributes for entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="keyGroup">The key group.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GetAttributesForEntity(int entityId, string keyGroup)
        {
            var genericAttributeService = EngineContext.Current.Resolve<IGenericAttributeService>();
            var genericAttributeCore = genericAttributeService.GetAttributesForEntity(entityId, keyGroup);
            var genericAttribute = genericAttributeCore.MapSource<Nop.Core.Domain.Common.GenericAttribute, Domain.Common.GenericAttribute>(AutoMapperConfiguration.Mapper);
            return JsonConvert.SerializeObject(genericAttribute, Formatting.Indented);
        }

    }
}

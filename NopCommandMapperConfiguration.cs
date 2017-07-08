// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-05-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="NopCommandMapperConfiguration.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Nop.Core.Domain.Affiliates;
using Nop.Core.Infrastructure.Mapper;


namespace NopCommand
{
    /// <summary>
    /// Class NopCommandMapperConfiguration.
    /// </summary>
    /// <seealso cref="Nop.Core.Infrastructure.Mapper.IMapperConfiguration" />
    /// <remarks>Guidebee IT</remarks>
    public class NopCommandMapperConfiguration : IMapperConfiguration
    {
        /// <summary>
        /// Get configuration
        /// </summary>
        /// <returns>Mapper configuration action</returns>
        /// <remarks>Guidebee IT</remarks>
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                cfg.ShouldMapProperty = pi => pi.GetMethod != null && pi.GetMethod.IsPublic &&
                                              (!pi.GetMethod.IsVirtual);
                const string nopspace = "NopCommand.Domain";
                var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.Namespace != null && (t.IsClass && t.Namespace.StartsWith(nopspace))
                        select t;

                const string corespace = "Nop.Core.Domain";
                var coreDomainList = from t in Assembly.GetAssembly(typeof(Affiliate)).GetTypes()
                                     where t.Namespace != null && (t.IsClass && t.Namespace.StartsWith(corespace))
                                     select t;

                var dictionary = new Dictionary<string, Type>();
                foreach (var domainType in coreDomainList)
                {
                    dictionary[domainType.Name] = domainType;

                }

                q.ToList().ForEach(t =>
                {
                    if (dictionary.ContainsKey(t.Name))
                    {
                        cfg.CreateMap(dictionary[t.Name], t);
                    }
                });


            };


            return action;

        }


        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        /// <value>The order.</value>
        /// <remarks>Guidebee IT</remarks>
        public int Order => 0;
    }
}

// ***********************************************************************
// Assembly         : NopCommand
// Author           : James Shen
// Created          : 07-07-2017
//
// Last Modified By : James Shen
// Last Modified On : 07-07-2017
// ***********************************************************************
// <copyright file="CommandCodeGenerator.cs" company="Guidebee IT">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Nop.Services.Catalog;

namespace NopCommand.CodeGen
{

    /// <summary>
    /// Enum ReturnType
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public enum ReturnType
    {
        /// <summary>
        /// The default
        /// </summary>
        Default,
        /// <summary>
        /// The paged list
        /// </summary>
        PagedList,
        /// <summary>
        /// The list
        /// </summary>
        List,
        /// <summary>
        /// The primitive
        /// </summary>
        Primitive

    }

    /// <summary>
    /// Class ParameterDesc.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public class ParameterDesc
    {
        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        /// <remarks>Guidebee IT</remarks>
        public string ParameterName { get; set; }
        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        /// <value>The type of the parameter.</value>
        /// <remarks>Guidebee IT</remarks>
        public string ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the type of the original.
        /// </summary>
        /// <value>The type of the original.</value>
        /// <remarks>Guidebee IT</remarks>
        public ParameterInfo OriginalType { get; set; }
    }

    /// <summary>
    /// Class MethodDesc.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public class MethodDesc
    {
        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>The type of the return.</value>
        /// <remarks>Guidebee IT</remarks>
        public ReturnType ReturnType { get; set; }
        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>The name of the method.</value>
        /// <remarks>Guidebee IT</remarks>
        public string MethodName { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        /// <remarks>Guidebee IT</remarks>
        public List<ParameterDesc> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the type of the destination.
        /// </summary>
        /// <value>The type of the destination.</value>
        /// <remarks>Guidebee IT</remarks>
        public string DestinationType { get; set; }

    }

    /// <summary>
    /// Class CommandCodeGenerator.
    /// </summary>
    /// <remarks>Guidebee IT</remarks>
    public static class CommandCodeGenerator
    {
        /// <summary>
        /// The using clause
        /// </summary>
        public const string UsingClause =
            "using System;\r\n" +
            "using Newtonsoft.Json;\r\n" +
            "using Nop.Core.Infrastructure;\r\n" +
            "using Nop.Core.Infrastructure.Mapper;\r\n" +
            "using NopCommand.Helpers;";

        /// <summary>
        /// The name space header
        /// </summary>
        public const string NameSpaceHeader = "namespace NopCommand.Commands";

        /// <summary>
        /// The class definition
        /// </summary>
        public const string ClassDefinition = "public static class";
        /// <summary>
        /// The method defintion
        /// </summary>
        public const string MethodDefintion = "public static string";
        /// <summary>
        /// The tab space
        /// </summary>
        public const string TabSpace = "    ";
        /// <summary>
        /// The space
        /// </summary>
        public const string Space = " ";

        /// <summary>
        /// The template type0
        /// </summary>
        public const string TemplateType0 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "var [VARIABLE] = AutoMapperConfiguration.Mapper.Map<[DESTINATIONTYPE]>([SERVICECOREVARIABLE]);\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented);";

        /// <summary>
        /// The template type1
        /// </summary>
        public const string TemplateType1 =
                TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
                TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
                TabSpace + TabSpace + TabSpace + "var [VARIABLE] = [SERVICECOREVARIABLE].MapSourcePageList<[SOURCETYPE], [DESTINATIONTYPE]> (AutoMapperConfiguration.Mapper);\r\n" +
                TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented, new PageListConverter<[DESTINATIONTYPE]>());"
            ;

        /// <summary>
        /// The template type2
        /// </summary>
        public const string TemplateType2 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "var [VARIABLE] = [SERVICECOREVARIABLE].MapSource<[SOURCETYPE], [DESTINATIONTYPE]>(AutoMapperConfiguration.Mapper);\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([VARIABLE], Formatting.Indented);";

        /// <summary>
        /// The template type3
        /// </summary>
        public const string TemplateType3 =
            TabSpace + TabSpace + TabSpace + "var [SERVICEVARIABLE] = EngineContext.Current.Resolve<[SERVICEINTERFACE]>();\r\n" +
            TabSpace + TabSpace + TabSpace + "var [SERVICECOREVARIABLE] = [METHODNAME];\r\n" +
            TabSpace + TabSpace + TabSpace + "return JsonConvert.SerializeObject([SERVICECOREVARIABLE], Formatting.Indented);";

        /// <summary>
        /// The service assembly
        /// </summary>
        private static Assembly _serviceAssembly;

        /// <summary>
        /// To the camel case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string ToCamelCase(this string name)
        {
            return char.ToLowerInvariant(name[0]) + name.Substring(1);
        }

        /// <summary>
        /// To the name of the type.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string ToTypeName(this string name)
        {
            return name.Substring(1);
        }

        /// <summary>
        /// Mappings the type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string MappingType(this string type)
        {
            return type.Replace("String", "string").Replace("Int32", "int").Replace("Boolean", "bool");
        }

        /// <summary>
        /// Defaults the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        private static string DefaultValue(this string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            return value.Replace("False", "false").Replace("2147483647", "int.MaxValue").Replace("True","true");
        }

        /// <summary>
        /// Generates the code for services.
        /// </summary>
        /// <remarks>Guidebee IT</remarks>
        public static void GenerateCodeForServices()
        {
            _serviceAssembly = Assembly.GetAssembly(typeof(ICategoryTemplateService));
            var coreServiceList = from t in _serviceAssembly.GetTypes()
                where t.Namespace != null && (t.IsInterface && t.Namespace.StartsWith("Nop.Services") && t.Name.EndsWith("Service"))
                select t;

            foreach (var service in coreServiceList)
            {
                var serviceInterface = service.Name;
                var typeName = serviceInterface.ToTypeName();
                var fileName = "..\\\\..\\\\Commands\\\\"+typeName.Replace("Service", "Commands")+".cs";
                
                
                var code = GenerateCodeForService(service);
                File.WriteAllText(fileName,code);
              
            }
        }


        /// <summary>
        /// Generates the code for service.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Guidebee IT</remarks>
        public static string GenerateCodeForService(Type service)
        {
            var strBuiler = new StringBuilder();


            var serviceInterface = service.Name;
            var serviceUsingClause = "using "+service.FullName.Replace("." + service.Name, string.Empty)+";\r\n";
            var typeName = serviceInterface.ToTypeName();
            strBuiler.Append(UsingClause);
            strBuiler.Append("\r\n");
            strBuiler.Append(serviceUsingClause);
            strBuiler.Append("\r\n");
            strBuiler.Append(NameSpaceHeader);
            strBuiler.Append("\r\n");
            strBuiler.Append("{\r\n");

            strBuiler.Append(TabSpace + ClassDefinition + Space + typeName.Replace("Service", "Commands") + "\r\n");
            strBuiler.Append(TabSpace + "{\r\n");
            foreach (var methodInfo in service.GetMethods())
            {
                if(methodInfo.IsGenericMethod) continue;
                bool containNonPrimitiveType = false;
                foreach (var parameter in methodInfo.GetParameters())
                {
                    if (!(parameter.ParameterType.IsValueType || parameter.ParameterType == typeof(string)))
                    {
                        containNonPrimitiveType = true;
                    }


                }
                if (!containNonPrimitiveType)
                {

                    var methodDesc = new MethodDesc
                    {
                        Parameters = new List<ParameterDesc>(),
                        MethodName = methodInfo.Name
                    };

                    foreach (var parameter in methodInfo.GetParameters())
                    {
                        if (!parameter.ParameterType.FullName.StartsWith("System.Nullable"))
                        {

                            methodDesc.Parameters.Add(new ParameterDesc
                            {
                                ParameterType = parameter.ParameterType.Name,
                                ParameterName = parameter.Name,
                                OriginalType = parameter

                            });

                        }
                        else
                        {

                            methodDesc.Parameters.Add(new ParameterDesc
                            {
                                ParameterType = parameter.ParameterType.GenericTypeArguments[0].Name + "?",
                                ParameterName = parameter.Name,
                                OriginalType = parameter
                            });
                        }



                    }

                    if (methodInfo.ReturnType.FullName.StartsWith("System.Collections.Generic.IList"))
                    {

                        methodDesc.ReturnType = ReturnType.List;
                        methodDesc.DestinationType = methodInfo.ReturnType.GenericTypeArguments[0].FullName;


                    }
                    else if (methodInfo.ReturnType.FullName.StartsWith("Nop.Core.IPagedList"))
                    {

                        methodDesc.ReturnType = ReturnType.PagedList;
                        methodDesc.DestinationType = methodInfo.ReturnType.GenericTypeArguments[0].FullName;
                    }
                    else
                    {

                        methodDesc.ReturnType = ReturnType.Default;
                        if (methodInfo.ReturnType.IsValueType || methodInfo.ReturnType==typeof(string))
                        {
                            methodDesc.DestinationType = "Primitive";
                            methodDesc.ReturnType=ReturnType.Primitive;
                        }
                        else
                        {
                            methodDesc.DestinationType = methodInfo.ReturnType.FullName;
                        }
                        
                    }


                    if (methodDesc.Parameters.Count > 0)
                    {
                        //var jsonString = JsonConvert.SerializeObject(methodDesc, Formatting.Indented);
                        // strBuiler.Append(jsonString);


                        var serviceVariable = typeName.ToCamelCase();
                        var names = methodDesc.DestinationType.Split('.');
                        var destinationTypeName = names[names.Length - 1];
                        var variable = destinationTypeName.ToCamelCase();
                        var serivceCoreVariable = variable + "Core";
                        var template = string.Empty;
                        var sourceType = methodDesc.DestinationType;
                        var destinationType = sourceType.Replace("Nop.Core.Domain", "Domain");

                        switch (methodDesc.ReturnType)
                        {
                            case ReturnType.Default:
                                template = TemplateType0;

                                break;
                            case ReturnType.PagedList:
                                template = TemplateType1;
                                break;
                            case ReturnType.List:
                                template = TemplateType2;
                                break;
                             case ReturnType.Primitive:
                                    template = TemplateType3;
                                    break;
                        }

                        var generatedMethod = TabSpace + TabSpace + MethodDefintion + Space + methodDesc.MethodName + "(";
                        var methodName = serviceVariable + "." + methodDesc.MethodName + "("; 
                        foreach (var parameter in methodDesc.Parameters)
                        {
                            generatedMethod += parameter.ParameterType.MappingType() + Space + parameter.ParameterName;
                            if (parameter.OriginalType.HasDefaultValue)
                            {
                                if (parameter.OriginalType.DefaultValue == null)
                                {
                                    generatedMethod += " = null";
                                }
                                else
                                {
                                    generatedMethod +=
                                        " = " + parameter.OriginalType.DefaultValue.ToString().DefaultValue();
                                }
                                
                            }
                            generatedMethod += ",";
                            methodName += Space + parameter.ParameterName + ",";
                        }
                        generatedMethod = generatedMethod.Substring(0, generatedMethod.Length - 1);
                        methodName = methodName.Substring(0, methodName.Length - 1);
                        generatedMethod += ")\r\n" + TabSpace + TabSpace + "{\r\n";
                        methodName += ")";

                        generatedMethod += template.Replace("[SERVICEVARIABLE]", serviceVariable)
                            .Replace("[SERVICEINTERFACE]", serviceInterface)
                            .Replace("[SERVICECOREVARIABLE]", serivceCoreVariable)
                            .Replace("[METHODNAME]", methodName)
                            .Replace("[VARIABLE]", variable)
                            .Replace("[SOURCETYPE]", sourceType)
                            .Replace("[DESTINATIONTYPE]", destinationType);

                        generatedMethod += "\r\n" + TabSpace + TabSpace + "}\r\n";
                        strBuiler.Append(generatedMethod);
                        strBuiler.Append("\r\n");


                    }
                }


            }
            strBuiler.Append(TabSpace + "}\r\n");
            strBuiler.Append("}\r\n");

            return strBuiler.ToString();

        }


    }
}

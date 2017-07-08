using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nop.Core;
using Nop.Core.Data;
using Nop.Core.Infrastructure;

namespace NopCommand
{
    class Program
    {
        const string CommandNamespace = "NopCommand.Commands";
        static Dictionary<string, Dictionary<string, IEnumerable<ParameterInfo>>> _commandLibraries;

        public static Dictionary<string, Dictionary<string, IEnumerable<ParameterInfo>>> CommandLibraries => _commandLibraries;

        private static bool exit = false;
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Name;
            //initialize engine context
            EngineContext.Initialize(false);

            bool databaseInstalled = DataSettingsHelper.DatabaseIsInstalled();

            var nopVersion = NopVersion.CurrentVersion;


            if (!databaseInstalled)
            {
                Console.WriteLine("Database is not installed, copy Settings.txt to App_Data directory");
                return;
            }

            Console.WriteLine("Welcome to NopCommand for NopCommerce " + nopVersion);

            // Any static classes containing commands for use from the 
            // console are located in the Commands namespace. Load 
            // references to each type in that namespace via reflection:
            _commandLibraries = new Dictionary<string, Dictionary<string,
                    IEnumerable<ParameterInfo>>>();

            // Use reflection to load all of the classes in the Commands namespace:
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == CommandNamespace && (!t.Name.StartsWith("<>"))
                    select t;
            var commandClasses = q.ToList();

            foreach (var commandClass in commandClasses)
            {
                // Load the method info from each class into a dictionary:
                var methods = commandClass.GetMethods(BindingFlags.Static | BindingFlags.Public);
                var methodDictionary = new Dictionary<string, IEnumerable<ParameterInfo>>();
                foreach (var method in methods)
                {
                    var commandName = method.Name;
                    methodDictionary.Add(commandName, method.GetParameters());
                }
                // Add the dictionary of methods for the current class into a dictionary of command classes:
                _commandLibraries.Add(commandClass.Name, methodDictionary);
            }
            Run();
        }


        
        private static void Run()
        {
            while (!exit)
            {
                var consoleInput = ReadFromConsole();
                if (string.IsNullOrWhiteSpace(consoleInput)) continue;
                if (string.Compare(consoleInput.ToLower(), "exit", StringComparison.Ordinal) == 0)
                {
                    exit = true;
                }
                else
                {
                    try
                    {
                        // Create a ConsoleCommand instance:
                        var cmd = new ConsoleCommand(consoleInput);

                        // Execute the command:
                        var result = Execute(cmd);

                        // Write out the result:
                        WriteToConsole(result);
                    }
                    catch (Exception ex)
                    {
                        // OOPS! Something went wrong - Write out the problem:
                        WriteToConsole(ex.Message);
                    }
                }
            }
        }


        private static string Execute(ConsoleCommand command)
        {
            // Validate the class name and command name:
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            var badCommandMessage = $"Unrecognized command \'{command.LibraryClassName}.{command.Name}\'. " +
                                       "Please type a valid command.";

            // Validate the command name:
            if (!_commandLibraries.ContainsKey(command.LibraryClassName))
            {
                return badCommandMessage;
            }
            var methodDictionary = _commandLibraries[command.LibraryClassName];
            if (!methodDictionary.ContainsKey(command.Name))
            {
                return badCommandMessage;
            }

            // Make sure the corret number of required arguments are provided:
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            var methodParameterValueList = new List<object>();
            IEnumerable<ParameterInfo> paramInfoList = methodDictionary[command.Name].ToList();

            // Validate proper # of required arguments provided. Some may be optional:
            var requiredParams = paramInfoList.Where(p => p.IsOptional == false);
            var optionalParams = paramInfoList.Where(p => p.IsOptional);
            var requiredCount = requiredParams.Count();
            var optionalCount = optionalParams.Count();
            var providedCount = command.Arguments.Count();

            if (requiredCount > providedCount)
            {
                return
                    $"Missing required argument. {requiredCount} required, {optionalCount} optional, {providedCount} provided";
            }

            // Make sure all arguments are coerced to the proper type, and that there is a 
            // value for every emthod parameter. The InvokeMember method fails if the number 
            // of arguments provided does not match the number of parameters in the 
            // method signature, even if some are optional:
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            if (paramInfoList.Any())
            {
                // Populate the list with default values:
                foreach (var param in paramInfoList)
                {
                    // This will either add a null object reference if the param is required 
                    // by the method, or will set a default value for optional parameters. in 
                    // any case, there will be a value or null for each method argument 
                    // in the method signature:
                    methodParameterValueList.Add(param.DefaultValue);
                }

                // Now walk through all the arguments passed from the console and assign 
                // accordingly. Any optional arguments not provided have already been set to 
                // the default specified by the method signature:
                for (var i = 0; i < command.Arguments.Count(); i++)
                {
                    var methodParam = paramInfoList.ElementAt(i);
                    var typeRequired = methodParam.ParameterType;
                    try
                    {
                        // Coming from the Console, all of our arguments are passed in as 
                        // strings. Coerce to the type to match the method paramter:
                        var value = CoerceArgument(typeRequired, command.Arguments.ElementAt(i));
                        methodParameterValueList.RemoveAt(i);
                        methodParameterValueList.Insert(i, value);
                    }
                    catch (ArgumentException)
                    {
                        var argumentName = methodParam.Name;
                        var argumentTypeName = typeRequired.Name;
                        var message =
                            $"The value passed for argument '{argumentName}' cannot be parsed to type '{argumentTypeName}'";
                        throw new ArgumentException(message);
                    }
                }
            }

            // Set up to invoke the method using reflection:
            // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            var current = typeof(Program).Assembly;

            // Need the full Namespace for this:
            var commandLibaryClass =
                current.GetType(CommandNamespace + "." + command.LibraryClassName);

            object[] inputArgs = null;
            if (methodParameterValueList.Count > 0)
            {
                inputArgs = methodParameterValueList.ToArray();
            }
            var typeInfo = commandLibaryClass;

            // This will throw if the number of arguments provided does not match the number 
            // required by the method signature, even if some are optional:
            try
            {
                var result = typeInfo.InvokeMember(
                    command.Name,
                    BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public,
                    null, null, inputArgs);
                return result.ToString();
            }
            catch (TargetInvocationException ex)
            {
                if (ex.InnerException != null) throw ex.InnerException;
            }
            return string.Empty;
        }


        private static object CoerceArgument(Type requiredType, string inputValue)
        {
            var requiredTypeCode = Type.GetTypeCode(requiredType);
            var exceptionMessage =
                $"Cannnot coerce the input argument {inputValue} to required type {requiredType.Name}";

            object result;
            switch (requiredTypeCode)
            {
                case TypeCode.String:
                    result = inputValue;
                    break;

                case TypeCode.Int16:
                    short number16;
                    if (short.TryParse(inputValue, out number16))
                    {
                        result = number16;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.Int32:
                    int number32;
                    if (int.TryParse(inputValue, out number32))
                    {
                        result = number32;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.Int64:
                    long number64;
                    if (long.TryParse(inputValue, out number64))
                    {
                        result = number64;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.Boolean:
                    bool trueFalse;
                    if (bool.TryParse(inputValue, out trueFalse))
                    {
                        result = trueFalse;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.Byte:
                    byte byteValue;
                    if (byte.TryParse(inputValue, out byteValue))
                    {
                        result = byteValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.Char:
                    char charValue;
                    if (char.TryParse(inputValue, out charValue))
                    {
                        result = charValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;

                case TypeCode.DateTime:
                    DateTime dateValue;
                    if (DateTime.TryParse(inputValue, out dateValue))
                    {
                        result = dateValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Decimal:
                    decimal decimalValue;
                    if (decimal.TryParse(inputValue, out decimalValue))
                    {
                        result = decimalValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Double:
                    double doubleValue;
                    if (double.TryParse(inputValue, out doubleValue))
                    {
                        result = doubleValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.Single:
                    float singleValue;
                    if (float.TryParse(inputValue, out singleValue))
                    {
                        result = singleValue;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt16:
                    ushort uInt16Value;
                    if (ushort.TryParse(inputValue, out uInt16Value))
                    {
                        result = uInt16Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt32:
                    uint uInt32Value;
                    if (uint.TryParse(inputValue, out uInt32Value))
                    {
                        result = uInt32Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                case TypeCode.UInt64:
                    ulong uInt64Value;
                    if (ulong.TryParse(inputValue, out uInt64Value))
                    {
                        result = uInt64Value;
                    }
                    else
                    {
                        throw new ArgumentException(exceptionMessage);
                    }
                    break;
                default:
                    throw new ArgumentException(exceptionMessage);
            }
            return result;
        }


        public static void WriteToConsole(string message = "")
        {
            if (message.Length > 0)
            {
                Console.WriteLine(message);
            }
        }


        const string ReadPrompt = "NopCommand> ";
        public static string ReadFromConsole(string promptMessage = "")
        {
            // Show a prompt, and get input:
            Console.Write(ReadPrompt + promptMessage);
            return Console.ReadLine();
        }
    }
}

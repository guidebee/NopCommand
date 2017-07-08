using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NopCommand
{
    public class ConsoleCommand
    {
        public ConsoleCommand(string input)
        {
            // Ugly regex to split string on spaces, but preserve quoted text intact:
            var stringArray = 
                Regex.Split(input, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            _arguments = new List<string>();
            for (var i = 0; i < stringArray.Length; i++)
            {
                // The first element is always the command:
                if (i == 0)
                {
                    Name = stringArray[i];

                    // Set the default:
                    LibraryClassName = "DataCommands";
                    var s = stringArray[0].Split('.');
                    if (s.Length == 2)
                    {
                        LibraryClassName = s[0];
                        Name = s[1];
                    }
                }
                else
                {
                    var inputArgument = stringArray[i];

                    // Assume that most of the time, the input argument is NOT quoted text:
                    var argument = inputArgument;

                    // Is the argument a quoted text string?
                    var regex = new Regex("\"(.*?)\"", RegexOptions.Singleline);
                    var match = regex.Match(inputArgument);

                    // If it IS quoted, there will be at least one capture:
                    if (match.Captures.Count > 0)
                    {
                        // Get the unquoted text from within the qoutes:
                        var captureQuotedText = new Regex("[^\"]*[^\"]");
                        var quoted = captureQuotedText.Match(match.Captures[0].Value);

                        // The argument should include all text from between the quotes
                        // as a single string:
                        argument = quoted.Captures[0].Value;
                    }
                    _arguments.Add(argument);
                }
            }
        }

        public string Name { get; set; }
        public string LibraryClassName { get; set; }

        private List<string> _arguments;
        public IEnumerable<string> Arguments
        {
            get
            {
                return _arguments;
            }
        }
    }

}

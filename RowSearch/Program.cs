using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace RowSearch
{
    internal class Program
    {
        private static string _searchPath;
        private static readonly string FILE_PATH_REGEX = @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$";

        public static void Main(string[] args)
        {
            _searchPath = string.Empty;

            if (args.Length > 0)
            {
                if (IsValidPath(args[0]))
                {
                    _searchPath = args[0];
                }
            }

            if (string.IsNullOrEmpty(_searchPath))
            {
                Console.WriteLine("Specify file location");
                do
                {
                    var userEnteredPath = Console.ReadLine();

                    if (IsValidPath(userEnteredPath))
                    {
                        _searchPath = userEnteredPath;
                    }
                } while (string.IsNullOrEmpty(_searchPath));
            }

            var lines = File.ReadAllLines(_searchPath);
            var util = new SearchUtil(lines);

            PrintResult(util.MaxSumRowNumber, util.NotValidRowsNumbers);

            Console.ReadLine();
        }

        private static void PrintResult(int? maxSumRowNumber, IList<int> notValidRowsNubmers)
        {
            if (maxSumRowNumber != null)
                Console.WriteLine("Max sum line number: " + maxSumRowNumber.Value);
            
            foreach (var number in notValidRowsNubmers)
            {
                Console.WriteLine("Line number not valid line: " + number);
            }
        }

        private static bool IsValidPath(string cmdArgument)
        {
            return Regex.IsMatch(cmdArgument, FILE_PATH_REGEX);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace RowSearch
{
    internal class Program
    {
        private static string _searchPath;
        private const string FilePathRegex = @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$";

        public static void Main(string[] args)
        {
            SetFilePath(args);

            var lines = File.ReadAllLines(_searchPath);
            var util = new SearchUtil(lines);

            PrintResult(util.MaxSumRowNumber, util.NotValidRowsNumbers);

            Console.ReadLine();
        }

        private static void SetFilePath(string[] args)
        {
            _searchPath = string.Empty;

            if (args.Length > 0)
            {
                if (IsValidFilePath(args[0]))
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

                    if (IsValidFilePath(userEnteredPath))
                    {
                        _searchPath = userEnteredPath;
                    }
                    else
                    {
                        Console.WriteLine("Wrong path. Try again");
                    }
                } while (string.IsNullOrEmpty(_searchPath));
            }
        }

        private static void PrintResult(int? maxSumRowNumber, IList<int> notValidRowsNumbers)
        {
            Console.WriteLine("Results for file:" + _searchPath
                              );
            
            if (maxSumRowNumber != null)
                Console.WriteLine("Max sum line number: " + maxSumRowNumber.Value);

            foreach (var number in notValidRowsNumbers)
            {
                Console.WriteLine("Line number not valid line: " + number);
            }
        }

        private static bool IsValidFilePath(string filePath)
        {
            return Regex.IsMatch(filePath, FilePathRegex);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace RowSearch
{
    public class SearchUtil
    {
        private readonly IList<Row> _searchCollection;

        public SearchUtil(string[] lines)
        {
            _searchCollection = CreateSearchCollection(lines);
        }

        private static IList<Row> CreateSearchCollection(string[] lines)
        {
            var rows = new List<Row>();
           
            
            for (int i = 0; i < lines.Length; i++)
            {
                var row = Row.Create(lines[i]);
                row.RowNumber = i + 1;
                rows.Add(row);
            }

            return rows;
        }

        public int? MaxSumRowNumber
        {
            get
            {
                if (_searchCollection.All(r => !r.IsValid))
                {
                    return null;
                }

                return _searchCollection.SingleOrDefault(r => r.RowSum == _searchCollection.Max(el => el.RowSum)).RowNumber;
            }
        }

        public IList<int> NotValidRowsNumbers
        {
            get { return _searchCollection.Where(r => !r.IsValid).Select(r => r.RowNumber).ToList(); }
        }
    }
}
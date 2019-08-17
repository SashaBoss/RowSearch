using System.Collections.Generic;
using System.Linq;

namespace RowSearch
{
    public class Row
    {
        private const char RowItemsSeparator = ',';

        private Row()
        {
        }

        public static Row Create(string rowText)
        {
            var row = new Row {RowText = rowText, RowItems = CreateRowItems(rowText)};
            row.IsValid = row.RowItems.All(ri => ri.IsNumber);

            if (row.IsValid)
                row.RowSum = row.RowItems.Select(ri => ri.Value).Sum();

            return row;
        }
        private static IList<RowItem> CreateRowItems(string row)
        {
            return row.Split(RowItemsSeparator).Select(RowItem.Create).ToList();
        }

        public int RowNumber { get; set; }
        private string RowText { get; set; }
        private IList<RowItem> RowItems { get; set; }
        public bool IsValid { get; private set; }
        public float? RowSum { get; private set; }
    }
}
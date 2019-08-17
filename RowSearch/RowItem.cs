using System.Globalization;

namespace RowSearch
{
    public class RowItem
    {
        public bool IsNumber { get; private set; }

        public float? Value { get; private set; }

        private RowItem()
        {
        }

        public static RowItem Create(string lineItem)
        {
            var rowItem = new RowItem
            {
                IsNumber = float.TryParse(lineItem, NumberStyles.Any, CultureInfo.InvariantCulture,
                    out float parsedValue)
            };

            if (rowItem.IsNumber)
                rowItem.Value = parsedValue;

            return rowItem;
        }
    }
}
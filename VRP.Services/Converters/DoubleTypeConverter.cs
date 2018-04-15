using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace VRP.Services.Converters {
    public class DoubleTypeConverter : DoubleConverter {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }

            if (double.TryParse(text, out var result)) {
                return result;
            }

            return null;
        }
    }
}

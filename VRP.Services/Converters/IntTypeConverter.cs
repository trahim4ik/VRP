using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace VRP.Services.Converters {
    public class IntTypeConverter : DoubleConverter {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }

            if (int.TryParse(text, out var result)) {
                return result;
            }

            return null;
        }
    }
}

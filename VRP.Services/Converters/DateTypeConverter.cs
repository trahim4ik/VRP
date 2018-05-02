using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace VRP.Services.Converters {
    public class DateTypeConverter : DateTimeConverter {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData) {
            if (string.IsNullOrEmpty(text)) {
                return null;
            }

            if (DateTime.TryParse(text, out var result)) {
                return result;
            }

            return null;
        }
    }
}

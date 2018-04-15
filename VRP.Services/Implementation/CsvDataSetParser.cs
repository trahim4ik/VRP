using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using VRP.Dtos;
using VRP.Services.CsvMaps;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class CsvDataSetParser : IDataSetParser {

        #region Implementation IDataSetParser

        public IEnumerable<DataSetItemModel> Parse(string file) {
            if (string.IsNullOrEmpty(file)) {
                throw new ArgumentNullException(nameof(file));
            }

            if (!File.Exists(file)) {
                throw new InvalidDataException($"Invalid file path provided. Path : {file}");
            }

            using (TextReader reader = File.OpenText(file)) {
                var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<DataSetItemMap>();
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
                return csv.GetRecords<DataSetItemModel>().ToList();
            }
        }

        #endregion

    }
}

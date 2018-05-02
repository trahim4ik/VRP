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

            try {

                using (var stream = File.OpenRead(file)) {
                    using (var reader = new StreamReader(stream)) {
                        var csv = new CsvReader(reader);
                        csv.Configuration.RegisterClassMap<DataSetItemMap>();
                        csv.Configuration.HeaderValidated = null;
                        csv.Configuration.ReadingExceptionOccurred = exception => {
                            var a = exception;

                        };
                        csv.Configuration.MissingFieldFound = null;
                        var records = csv.GetRecords<DataSetItemModel>().ToList();
                        return records;
                    }
                }
            } catch (Exception e) {
                throw;
            }
        }

        #endregion

    }
}

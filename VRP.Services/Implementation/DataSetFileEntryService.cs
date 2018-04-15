using System;
using VRP.Dtos;
using VRP.Entities;
using VRP.Services.Core;
using VRP.Services.Interfaces;

namespace VRP.Services.Implementation {
    public class DataSetFileEntryService : BaseService<DataSetFileEntry, DataSetFileEntryModel>, IDataSetFileEntryService {
        public DataSetFileEntryService(IServiceProvider serviceProvider) : base(serviceProvider) {
        }
    }
}

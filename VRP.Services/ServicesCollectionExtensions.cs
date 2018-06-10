using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VRP.Services.Core;
using VRP.Services.Implementation;
using VRP.Services.Interfaces;

namespace VRP.Services {
    public static class ServicesCollectionExtensions {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddAutoMapper();

            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddScoped(typeof(IDataSetFileEntryService), typeof(DataSetFileEntryService));
            services.AddScoped(typeof(IDataSetItemService), typeof(DataSetItemService));
            services.AddScoped(typeof(IDataSetParser), typeof(CsvDataSetParser));
            services.AddScoped(typeof(IDataSetService), typeof(DataSetService));
            services.AddScoped(typeof(IDataSetService), typeof(DataSetService));
            services.AddScoped(typeof(IDataSetNetworkService), typeof(DataSetNetworkService));
            services.AddScoped(typeof(IDataSetPredictService), typeof(DataSetPredictService));
            services.AddScoped(typeof(IFileHandlerService), typeof(FileHandlerService));
            services.AddScoped(typeof(IFileEntryService), typeof(FileEntryService));
            services.AddScoped(typeof(IRealtyService), typeof(RealtyService));
            services.AddScoped(typeof(IUserService), typeof(UserService));

            return services;
        }

    }
}

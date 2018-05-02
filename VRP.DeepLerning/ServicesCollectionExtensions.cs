using Microsoft.Extensions.DependencyInjection;


namespace VRP.NeuronNetwork {
    public static class ServicesCollectionExtensions {

        public static IServiceCollection AddNeuronNetworkServices(this IServiceCollection services) {

            services.AddScoped(typeof(INetwork), typeof(Network));

            return services;
        }

    }
}

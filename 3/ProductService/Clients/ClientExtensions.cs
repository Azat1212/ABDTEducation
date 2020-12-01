using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;

namespace ProductService.Clients
{
    /*
    public class ClientExtensions
    {
        private const string ImageServiceUrlKey = "Api:ImageServiceURL";
        private const string PriceServiceUrlKey = "Api:PriceServiceURL";

        public static IServiceCollection AddServiceClients(this IServiceCollection services,
            IConfiguration configuration)
        {
            var refitSettings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore
                })
            };

            //services.AddApiClient<IImageClient>(configuration, refitSettings, ImageServiceUrlKey);
            //services.AddApiClient<IPriceClient>(configuration, refitSettings, PriceServiceUrlKey);

            return services;
        }
    }
    */
}

using System;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AuthenticationBase;
using ImageService.Interfaces;
using ImageService.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Refit;

namespace ImageService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppAuthentication(Configuration);

            services.AddMvc().AddNewtonsoftJson();
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen();

            var yandexConfig = Configuration.GetSection("YandexDisk");
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IImageService, Services.ImageService>();
            services.AddTransient<IYandexDiskService, Services.YandexDiskService>();
            services.Configure<YandexDiskConfig>(yandexConfig);

            var refitSettings = new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            };

            services.TryAddTransient(_ => RestService.For<IPoligonClient>(new HttpClient()
            {
                //BaseAddress = new Uri(yandexConfig.Value)
                BaseAddress = new Uri("https://cloud-api.yandex.net")
            }, refitSettings));

            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("Image");
            services.AddEntityFrameworkSqlServer().AddDbContext<ImageContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", $"Image Service API");
                c.RoutePrefix = string.Empty;
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

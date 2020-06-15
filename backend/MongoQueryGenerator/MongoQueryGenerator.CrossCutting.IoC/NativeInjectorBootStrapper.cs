using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoQueryGenerator.Domain.Interfaces;
using MongoQueryGenerator.Infra.Data.Mongo;
using MongoQueryGenerator.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoQueryGenerator.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Mongo
            services.AddSingleton<IMongoSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.AddScoped<IQueryGeneratorService, QueryGeneratorService>();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoQueryGenerator.Infra.Data.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoQueryGenerator.WebAPI.Configurations
{
    public static class MongoSetup
    {
        public static void AddMongoSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(
                configuration.GetSection(nameof(MongoSettings)));
        }
    }
}

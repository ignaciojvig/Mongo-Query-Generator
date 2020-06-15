﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;

namespace MongoQueryGenerator.API.Configurations
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mongo Query Generator",
                    Description = "Mongo Query Generator API Swagger Interface",
                    Contact = new OpenApiContact
                    {
                        Name = "João Victor Ignacio",
                        Email = "ignaciojvig@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/ignaciojv/")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/ignaciojvig/Mongo-Query-Generator/blob/master/LICENSE")
                    }

                });
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mongo Query Generator");
            });
        }
    }
}

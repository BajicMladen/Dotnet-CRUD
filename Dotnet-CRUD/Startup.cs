using Dotnet_CRUD.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyPolicy = "_myPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyPolicy,
                 builder =>
                 {
                     builder.WithOrigins("http://example.com",
                                         "http://www.contoso.com",
                                         "https://cors1.azurewebsites.net",
                                         "https://cors3.azurewebsites.net",
                                         "https://localhost:44398",
                                         "https://localhost:5001",
                                         "https://localhost:5000")
                            .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                            .WithMethods("PUT", "DELETE", "GET", "OPTIONS");
                 });
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  app.UseHttpsRedirection();

           

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(MyPolicy);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment hostEnv) => _env = hostEnv;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRepository>(provider =>
            {
                if (_env.IsDevelopment())
                {
                    var x = provider.GetService<MemoryRepository>();
                    return x;
                }
                else
                {
                    return new AlternateRepository();
                }
            });
            services.AddTransient<MemoryRepository>();
            services.AddTransient<IModelStorage, DictionaryStorage>();
            services.AddTransient<ProductTotalizer>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}

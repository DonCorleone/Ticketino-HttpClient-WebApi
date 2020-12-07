using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kinderkultur_TicketinoClient.Contracts;
using Kinderkultur_TicketinoClient.Repositories;
using Kinderkultur_TicketinoClient.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Kinderkultur_TicketinoClient
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

            services.Configure<EventDatabaseSettings>(
                Configuration.GetSection(nameof(EventDatabaseSettings)));

            services.AddSingleton<IEventDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<EventDatabaseSettings>>().Value);
    
            services.AddSingleton<EventGroupInfoService>();
            services.AddControllers();

            services.AddScoped<IMergeService, MergeService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kinderkultur_TicketinoClient", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kinderkultur_TicketinoClient v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

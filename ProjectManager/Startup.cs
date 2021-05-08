using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjectManager.Storage;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjectManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services
                .AddControllers()
                .AddJsonOptions(ConfigureJsonGenOptions);

            services
                .AddDbContext<ProjectManagerContext>(ConfigureDbContextOptions)
                .AddCors(ConfigureCorsOptions)
                .AddSwaggerGen(ConfigureSwaggerGenOptions);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectManager v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        #region Configure Options

        private Action<DbContextOptionsBuilder> ConfigureDbContextOptions => options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("ProjectManagerContext"),
                x =>
                {
                    x.MigrationsHistoryTable(ProjectManagerContext.MigrationHistoryTable);
                    x.MigrationsAssembly("ProjectManager.Storage");
                });
        };

        private Action<CorsOptions> ConfigureCorsOptions => options =>
        {
            options.AddPolicy("AllowedOrigins",
                builder => builder.WithOrigins(Configuration.GetSection("CorsOrigins").Get<string[]>())
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        };

        private static Action<SwaggerGenOptions> ConfigureSwaggerGenOptions => options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo {Title = "ProjectManager", Version = "v1"});
        };

        private static Action<JsonOptions> ConfigureJsonGenOptions => options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        };

        #endregion
    }
}
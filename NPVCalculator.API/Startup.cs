using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NPVCalculator.Application.Infrastructure.Automapper;
using NPVCalculator.Application.Interfaces;
using NPVCalculator.Application.Projections.Queries;
using NPVCalculator.Persistence;
using Swashbuckle.AspNetCore.Swagger;

namespace NPVCalculator.API
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
            services.AddAutoMapper(new Assembly[] { typeof(AutomapperProfile).GetTypeInfo().Assembly });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddMediatR(typeof(GetAllProjectionsQueryHandler).GetTypeInfo().Assembly);
            services.AddDbContext<INPVCalculatorDbContext, NPVCalculatorDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("NPVCalculatorDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "NPV Calculator", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NPV Calculator");
            });
        }
    }
}

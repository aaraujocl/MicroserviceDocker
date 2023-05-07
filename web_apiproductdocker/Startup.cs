using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using web_apiproductdocker.Aplicacion;
using web_apiproductdocker.Persistencia;
using System.Net.Http;
using web_apiproductdocker.Service;
using web_apiproductdocker.Service.Implementation;

namespace web_apiproductdocker
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "web_apiproductdocker", Version = "v1" });
            });
            services.AddDbContext<ContextoDocker>(option => {

                option.UseNpgsql(Configuration.GetConnectionString("ConexionDocker"));
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Nuevo).GetTypeInfo().Assembly));
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddHttpClient("Categoria", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Categoria"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "web_apiproductdocker v1"));
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

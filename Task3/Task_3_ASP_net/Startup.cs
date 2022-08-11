using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeixeLegal.Src.Contextos;
using PeixeLegal.Src.Repositorios;
using PeixeLegal.Src.Repositorios.Implementacoes;

namespace PeixeLegal
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
            // Configuração de Banco de dados
            services.AddDbContext<Contexto>(opt =>opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));

            // Repositorios
            services.AddScoped<IUsuarios, UsuarioRepositorio>();
            services.AddScoped<IProdutos, ProdutosRepositorio>();

            // Controladores
            services.AddControllers();
            services.AddCors();
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Contexto contexto)
        {
            if (env.IsDevelopment())
            {
                contexto.Database.EnsureCreated();

                app.UseDeveloperExceptionPage();
            }

            contexto.Database.EnsureCreated();

            app.UseRouting();
            app.UseCors(c => c
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

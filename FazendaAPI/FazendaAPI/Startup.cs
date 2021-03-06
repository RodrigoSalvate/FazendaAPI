
using AutoMapper;
using Dominio._0_Reposit�rio;
using Dominio._1_Entidades;
using Infraestrutura._0_Context;
using Infraestrutura._1_Reposit�rio;
using Infraestrutura._2_UnidadeDeTrabalho;
using Infraestrutura._2_UnidadeDeTrabalho.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Negocio.AutoMapper.Profiles;
using Negocio.DTOs;
using Negocio.Servi�o;
using Negocio.Servi�o.Interface;


namespace FazendaAPI
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

            DbContext(services);

            InjecaoDeDependencia(services);

            AutoMapper(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fazenda Brasil WEB_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AnimalProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void InjecaoDeDependencia(IServiceCollection services)
        {
            services.AddTransient<IServiceBase<AnimalDTO>, AnimalService>();
            services.AddTransient<IRepositorioGenerico<Animal>, RepositorioGenerico<Animal>>();
            services.AddTransient<IUnidadeDeTrabalho, UnidadeDeTrabalho>();

            services.AddScoped<IValidacaoService, ValidacaoService>();
        }

        private static void DbContext(IServiceCollection services)
        {
            services.AddDbContext<SqlServerContext>(options =>
                                   options.UseSqlServer(@"Server=tcp:sqlserversalvate.database.windows.net,1433;Initial Catalog=fazendaapi;Persist Security Info=False;User ID=Rsalvate;Password=RS&stSD$1019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Data;
using Microsoft.EntityFrameworkCore;
using IDataAccess.Candidatos;
using IDataAccess.Evaluaciones;
using IBusinessLogic.Candidatos;
using IBusinessLogic.Evaluaciones;
using BusinessLogic.Candidatos;
using BusinessLogic.Evaluaciones;
using DataAccess.Candidatos;
using DataAccess.Evaluaciones;
using Database.OperationResult;
using BusinessLogic;
using IDataAccess.IBaseData;
using DataAccess.BaseData;
using IBusinessLogic.IBaseService;
using BusinessLogic.BaseService;

namespace PracticaSimetrica
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
            services.AddControllersWithViews();

            services.AddScoped<ICandidatosService, CandidatosService>();
            services.AddScoped<IEvaluacionesService, EvaluacionesService>();
            services.AddScoped<IDataCandidatos, DataCandidatos>();
            services.AddScoped<IDataEvaluaciones, DataEvaluaciones>();

            services.AddScoped<IOperationResult, OperationResult>();
            services.AddScoped(typeof(IValidacion<>), (typeof(Validacion<>)));

            services.AddScoped(typeof(IBaseService<>), (typeof(BaseService<>)));
            services.AddScoped(typeof(IBaseData<>), (typeof(BaseData<>)));



            services.AddDbContext<EvaluacionContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EvaluacionContext")));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

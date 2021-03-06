using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using McqueenDoctor.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using McqueenDoctor.Core.Interfaces;
using McqueenDoctor.Core.Services;
using McqueenDoctor.Infrastructure.Repositories;
using AutoMapper;
using McqueenDoctor.Infrastructure.Mappings;

namespace McqueenDoctor.API
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
            var mapingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });

            IMapper mapper = mapingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();

            //Conectar con base de datos
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("McqueenDoctor"),
                x => x.MigrationsAssembly("McqueenDoctor.Infrastructure"))
            );

            //Definir la inyeccion de dependencias
            services.AddTransient<IVehicleRegisterService, VehicleRegisterService>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IVehicleRegisterRepository, VehicleRegisterRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

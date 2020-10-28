using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
using RatesCalculator.Data.Models;
using RatesCalculator.Infrastructure.Interfaces;
using RatesCalculator.Infrastructure.Repositories;
using RatesCalculator.Service;
using RatesCalculator.Service.Interfaces;

namespace RatesCalculator.Intranet
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
            services.AddDbContext<RatesTariffsContext>(cfg =>
            {
                cfg.UseSqlServer(
                    Configuration
                    .GetConnectionString("DefaultConnectionString"));
            });
            services.AddScoped<IAuditEntityRepository, AuditEntityRepository>();
            services.AddScoped<IAuditEntityFieldRepository, AuditEntityFieldRepository>();
            services.AddScoped<IRefuseRepository, RefuseRepository>();
            services.AddScoped<IRefuseRebatesRepository, RefuseRebatesRepository>();
            services.AddScoped<IRefuseRebatesIndigentRepository, RefuseRebatesIndigentRepository>();
            services.AddScoped<ICentInRandRepository, CentInRandRepository>();
            services.AddScoped<IElectricityRepository, ElectricityRepository>();
            services.AddScoped<IElectricityFreeBenefitRepository, ElectricityFreeBenefitRepository>();
            services.AddScoped<IPersonTypeRepository, PersonTypeRepository>();
            services.AddScoped<IPropertyRebatesRepository, PropertyRebatesRepository>();
            services.AddScoped<IPropertyValueRefuseRebatesRepository, PropertyValueRefuseRebatesRepository>();
            services.AddScoped<IRefuseResidentialTypeRepository, RefuseResidentialTypeRepository>();
            services.AddScoped<IResidentWasteCollectionRepository, ResidentWasteCollectionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISanitationRepository, SanitationRepository>();
            services.AddScoped<ISanitationFreeBenefitRepository, SanitationFreeBenefitRepository>();
            services.AddScoped<IWaterRepository, WaterRepository>();
            services.AddScoped<IWaterMeterRepository, WaterMeterRepository>();
            services.AddScoped<IWaterPropertyBenefitRepository, WaterPropertyBenefitRepository>();
            services.AddScoped<IWaterFixedChargesRepository, WaterFixedChargesRepository>();
            services.AddScoped<IVatRepository, VatRepository>();
            services.AddScoped<IIndigentIncomeRepository, IndigentIncomeRepository>();
            services.AddScoped<IIncomeDisbaledPensionerRepository, IncomeDisabledPensionerRepository>();
            //api services

            services.AddScoped<IRefuseService, RefuseService>();
            services.AddScoped<ISanitationService, SanitationService>();
            services.AddScoped<IWaterService, WaterService>();
            services.AddScoped<IElectricityService, ElectricityService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo
                {
                    Title = "Rates And Tariffs API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Admin",
                        Email = "support@capetown.gov.za",


                    },
                    Description = "Rates and Tariffs API for computing  residential rates",
                    License = new OpenApiLicense
                    {
                        Name = "License name",
                        Url = new Uri("http://www.capetown.gov.za")
                    },
                    TermsOfService = new Uri("http://www.capetown.gov.za")
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rates And Tariffs V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

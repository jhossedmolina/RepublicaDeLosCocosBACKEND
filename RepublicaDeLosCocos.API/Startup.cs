using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RepublicaDeLosCocos.Core.Interfaces;
using RepublicaDeLosCocos.Core.Services;
using RepublicaDeLosCocos.Infraestructure.Data;
using RepublicaDeLosCocos.Infraestructure.Filters;
using RepublicaDeLosCocos.Infraestructure.Repositories;
using System;

namespace RepublicaDeLosCocos.API
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
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddDbContext<RepublicaDeLosCocosDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RepublicaDeLosCocosDB"))
            );

            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientRepository, PatientRepository>();

            services.AddTransient<ISurgeryService, SurgeryService>();
            services.AddTransient<ISurgeryRepository, SurgeryRepository>();

            services.AddTransient<IAssignPatientService, AssignPatientService>();
            services.AddTransient<IAssignPatientRepository, AssignPatientRepository>();

            services.AddTransient<IPatientInCareService, PatientInCareService>();
            services.AddTransient<IPatientInCareRepository, PatientInCareRepository>();

            services.AddTransient<IRecoveredPatientService, RecoveredPatientService>();
            services.AddTransient<IRecoveredPatientRepository, RecoveredPatientRepository>();

            services.AddTransient<IMedicalConsultationService, MedicalConsultationService>();
            services.AddTransient<IMedicalConsultationRepository, MedicalConsultationRepository>();

            services.AddTransient<IVirusTestRepository, VirusTestRepository>();

            services.AddTransient<ITriageService, TriageService>();
            services.AddTransient<ITriageRepository, TriageRepository>();
            


            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("V1", new OpenApiInfo { Title = "Republica De Los Cocos API", Version = "V1" });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Republica De Los Cocos API V1");
                options.RoutePrefix = string.Empty;
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

using AutoMapper;
using MedUnify.Inpatient.API.Services.Interfaces;
using MedUnify.Inpatient.API.Services;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using MedUnify.Inpatient.DAL.Repository;

namespace MedUnify.Inpatient.API
{
    public static class DIResolver
    {
        public static void ConfigureDIResolver(this IServiceCollection services)
        {
            var autoConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            services.AddSingleton(sp => autoConfig.CreateMapper());

            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientVisitService, PatientVisitService>();
            services.AddScoped<IOrganizationService, OrganisationService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientVisitRepository, PatientVisitRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

        }
    }
}

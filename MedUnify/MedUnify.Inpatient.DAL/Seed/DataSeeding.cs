using MedUnify.Inpatient.DAL;
using MedUnify.Inpatient.DAL.Seed;
using MedUnify.Inpatient.SharedModel.Settings;
using Newtonsoft.Json;

namespace MedUnify.Inpatient.API.Data
{
    public static class DataSeeding
    {
        private static SeedModels? SeedData;

        static DataSeeding()
        {
            var fileName = "common-settings.json";
            var json = File.ReadAllText(fileName);
            var CommonSettings = JsonConvert.DeserializeObject<CommonSettings>(json);
            json = File.ReadAllText($"{CommonSettings?.SeedPath}{CommonSettings?.SeedVersion}.json");
            SeedData = JsonConvert.DeserializeObject<SeedModels>(json);
        }

        public static void SeedInitialData(this InpatientDbContext context)
        {
            SeedOrganization(context);
            SeedPatients(context);
        }

        public static void SeedOrganization(this InpatientDbContext context)
        {
            if (!context.Organizations.Any() && SeedData != null && SeedData.Organizations != null && SeedData.Organizations.Any()) // OR check with id for each items from repo to either update or add new
            {
                foreach (var org in SeedData.Organizations)
                {
                    org.CreatedAt = DateTime.Now;
                    org.CreatedBy = "SYSTEM";
                    context.Add(org);
                }
                context.SaveChanges();
            }
        }
        public static void SeedPatients(this InpatientDbContext context)
        {
            if (!context.Patients.Any() && SeedData != null && SeedData.Patients != null && SeedData.Patients.Any())
            {
                foreach (var patient in SeedData.Patients)
                {
                    patient.CreatedAt = DateTime.Now;
                    patient.CreatedBy = "SYSTEM";
                }

                context.AddRange(SeedData.Patients);
                context.SaveChanges();

            }
        }

    }
}

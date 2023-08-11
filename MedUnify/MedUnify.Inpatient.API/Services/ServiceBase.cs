using MedUnify.Inpatient.DAL;

namespace MedUnify.Inpatient.API.Services
{
    public abstract class ServiceBase
    {
        protected readonly InpatientDbContext inPatientDbContext;
        public ServiceBase(InpatientDbContext dbContext)
        {
            inPatientDbContext = dbContext;
        }
    }
}

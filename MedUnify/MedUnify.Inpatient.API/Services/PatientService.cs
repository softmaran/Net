using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedUnify.Inpatient.DAL;
using HNMC.Phoenix.Library.Services;
using MedUnify.Inpatient.ViewModel;
using MedUnify.Inpatient.DAL.Repository.Interfaces;

namespace MedUnify.Inpatient.API.Services
{
    public class PatientService : BaseService<PatientViewModel, Patient>, IPatientService
    {
        public PatientService(IPatientRepository patientRepository, IServiceProvider serviceProvider) : base(patientRepository, serviceProvider)
        {

        }
    }
}

using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedUnify.Inpatient.DAL;
using HNMC.Phoenix.Library.Services;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using MedUnify.Inpatient.ViewModel;

namespace MedUnify.Inpatient.API.Services
{
    public class PatientVisitService : BaseService<PatientVisitViewModel, PatientVisit>, IPatientVisitService
    {
        private readonly IPatientVisitRepository patientRepository;

        public PatientVisitService(IPatientVisitRepository patientRepository, IServiceProvider serviceProvider) : base(patientRepository, serviceProvider)
        {
            this.patientRepository = patientRepository;
        }

        public async Task<List<PatientVisitViewModel>> GetVisitsByPatientIdAsync(int patientId)
        {
            var res = await this.patientRepository.GetListByPatientIdAsync(patientId);
            return MapViewModels(res);
        }
    }
}

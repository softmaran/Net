using HNMC.Phoenix.Library.Services;
using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.ViewModel;

namespace MedUnify.Inpatient.API.Services.Interfaces
{
    public interface IPatientVisitService : IBaseService<PatientVisitViewModel>
    {
        Task<List<PatientVisitViewModel>> GetVisitsByPatientIdAsync(int patientId);
    }
}

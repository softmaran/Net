using MedUnify.Inpatient.ViewModel;

namespace MedUnify.WebUI.Repository
{
    public interface IPatientHttpRepository
    {
        Task<List<PatientViewModel>> GetPatients();
    }
}
using MedUnify.Inpatient.ViewModel;

namespace MedUnify.WebUI.Repository
{
    public interface IPatientHttpRepository
    {
        Task<bool> Delete(string id);
        Task<List<PatientViewModel>> GetPatients();
    }
}
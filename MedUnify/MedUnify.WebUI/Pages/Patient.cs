using MedUnify.Inpatient.ViewModel;
using MedUnify.WebUI.Repository;
using Microsoft.AspNetCore.Components;

namespace MedUnify.WebUI.Pages
{
    public partial class Patient
    {
        public List<PatientViewModel> PatientList { get; set; } = new List<PatientViewModel>();
        [Inject]
        public IPatientHttpRepository PatientRepo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            PatientList = await PatientRepo.GetPatients();
            //just for testing

        }
    }
}

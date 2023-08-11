using MedUnify.Inpatient.ViewModel;
using MedUnify.WebUI.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MedUnify.WebUI.Pages.Components
{
    public partial class PatientContainer
    {
        [Inject]
        public IPatientHttpRepository PatientRepo { get; set; }
        [Parameter]
        public List<PatientViewModel> Patients { get; set; }

        protected async Task OnDeletePatient(MouseEventArgs mouseEventArgs, PatientViewModel patient)
        {
            if (Patients?.Any(n => n == patient) ?? false)
            {
                if (await PatientRepo.Delete(patient.ID.ToString()))
                {
                    Patients.Remove(Patients.First(n => n == patient));
                }
            }
        }

    }
}

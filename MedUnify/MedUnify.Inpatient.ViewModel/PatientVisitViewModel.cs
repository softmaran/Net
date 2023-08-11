namespace MedUnify.Inpatient.ViewModel
{
    public class PatientVisitViewModel : TableAuditViewModel
    {
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public List<ProgressNoteViewModel>? ProgressNotes { get; set; }
    }
}

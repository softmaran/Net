namespace MedUnify.Inpatient.ViewModel
{
    public class ProgressNoteViewModel : TableAuditViewModel
    {
        public long PatientVisitId { get; set; }
        public string SectionName { get; set; } = "";
        public string SectionText { get; set; } = "";
    }
}

namespace MedUnify.Inpatient.DAL.Model
{
    public class PatientVisit : TableAudit
    {
        public int PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public List<ProgressNote>? ProgressNotes { get; set; }
    }
}

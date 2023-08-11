namespace MedUnify.Inpatient.DAL.Model
{
    public class ProgressNote : TableAudit
    {
        public long PatientVisitId { get; set; }
        public string SectionName { get; set; } = "";
        public string SectionText { get; set; } = "";

        public PatientVisit? PatientVisit { get; set; }
    }
}

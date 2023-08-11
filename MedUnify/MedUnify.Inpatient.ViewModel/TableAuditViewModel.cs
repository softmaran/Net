namespace MedUnify.Inpatient.ViewModel
{
    public class TableAuditViewModel
    {
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

    }
}

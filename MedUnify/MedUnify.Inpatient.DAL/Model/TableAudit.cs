namespace MedUnify.Inpatient.DAL.Model
{
    public abstract class TableAudit
    {
        public virtual long ID { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
                
        public virtual string? CreatedBy { get; set; }
        public virtual string? UpdatedBy { get; set; }
        public virtual bool? IsDeleted { get; set; }

        public virtual bool IsActive
        {
            get
            {
                return !(IsDeleted.HasValue && IsDeleted.Value);
            }
        }

    }
}

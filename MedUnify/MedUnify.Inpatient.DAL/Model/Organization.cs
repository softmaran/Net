namespace MedUnify.Inpatient.DAL.Model
{
    public class Organization : TableAudit
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}

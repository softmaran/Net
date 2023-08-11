namespace MedUnify.Inpatient.ViewModel
{
    public class OrganizationViewModel : TableAuditViewModel
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}

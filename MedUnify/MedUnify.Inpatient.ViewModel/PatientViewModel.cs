namespace MedUnify.Inpatient.ViewModel
{
    public class PatientViewModel : TableAuditViewModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string State { get; set; } = default!;
        public string City { get; set; } = default!;
        public long? OrganizationId { get; set; }

    }
}

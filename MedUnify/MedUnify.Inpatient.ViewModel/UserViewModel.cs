namespace MedUnify.Inpatient.ViewModel
{
    public class UserViewModel : TableAuditViewModel
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ClientId { get; set; } = "";
    }
}

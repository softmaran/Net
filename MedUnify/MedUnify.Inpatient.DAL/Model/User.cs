namespace MedUnify.Inpatient.DAL.Model
{
    public class User : TableAudit
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ClientId { get; set; } = "";
    }
}

using MedUnify.Inpatient.ViewModel;
using System.Text.Json;

namespace MedUnify.WebUI.Repository
{
    public class PatientHttpRepository : IPatientHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public PatientHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<PatientViewModel>> GetPatients()
        {
            var response = await _client.GetAsync("patients");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var patients = JsonSerializer.Deserialize<List<PatientViewModel>>(content, _options);
            return patients;
        }
    }
}

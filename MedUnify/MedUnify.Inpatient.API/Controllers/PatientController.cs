using MedUnify.Inpatient.API.Services.Interfaces;
using MedUnify.Inpatient.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedUnify.Inpatient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService patientService;
        private readonly IPatientVisitService patientVisitService;
        // GET: api/<PatientController>
        public PatientController(IPatientService ptService, IPatientVisitService visitService)
        {
            patientService = ptService;
            patientVisitService = visitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await patientService.GetAllAsync());
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await patientService.GetAsync(id));
        }

        // POST api/<PatientController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PatientViewModel patient)
        {
            return Ok(await patientService.AddAsync(patient));
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] PatientViewModel patient)
        {
            return Ok(await patientService.UpdateAsync(patient));
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await patientService.DeleteAsync(id, User.Identity.Name));
        }

        [HttpGet("{id}/Visit")]
        public async Task<IActionResult> GetVisitAsync(int id)
        {
            return Ok(await patientVisitService.GetVisitsByPatientIdAsync(id));
        }

    }
}

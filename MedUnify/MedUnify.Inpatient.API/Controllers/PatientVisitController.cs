using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MedUnify.Inpatient.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace MedUnify.Inpatient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientVisitController : ControllerBase
    {
        private readonly IPatientVisitService patientVisitService;
        public PatientVisitController(IPatientVisitService visitService)
        {
            patientVisitService = visitService;
        }
        // GET: api/PatientVisit
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await patientVisitService.GetAllActiveAsync());
        }
        // GET: api/PatientVisit/1
        [HttpGet("{patientVisitId}")]
        public async Task<IActionResult> GetAsync(int patientVisitId)
        {
            return Ok(await patientVisitService.GetAsync(patientVisitId));
        }

        // POST api/<PatientVisitController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PatientVisitViewModel patientVisit)
        {
            return Ok(await patientVisitService.AddAsync(patientVisit));
        }

    }
}

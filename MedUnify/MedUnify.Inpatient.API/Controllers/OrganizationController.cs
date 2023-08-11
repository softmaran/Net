using MedUnify.Inpatient.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedUnify.Inpatient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organisationService;
        public OrganizationController(IOrganizationService organisationService)
        {
            this.organisationService = organisationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            return Ok(await organisationService.GetAllAsync());
        }

    }
}

using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MedUnify.Inpatient.DAL;
using HNMC.Phoenix.Library.Services;
using MedUnify.Inpatient.ViewModel;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using MedUnify.Inpatient.DAL.Repository;

namespace MedUnify.Inpatient.API.Services
{
    public class OrganisationService : BaseService<OrganizationViewModel,Organization>, IOrganizationService
    {
        public OrganisationService(IOrganizationRepository repostory,IServiceProvider serviceProvider ) : base(repostory,serviceProvider)
        {
        }

    }
}

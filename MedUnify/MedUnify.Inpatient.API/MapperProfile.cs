using AutoMapper;
using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.ViewModel;

namespace MedUnify.Inpatient.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();
            CreateMap<Organization, OrganizationViewModel>()
                .ReverseMap();
            CreateMap<Patient, PatientViewModel>()
                .ReverseMap();
            CreateMap<PatientVisit, PatientVisitViewModel>()
                .ReverseMap();
            CreateMap<ProgressNote, ProgressNoteViewModel>()
                .ReverseMap();
            CreateMap<TableAudit, TableAuditViewModel>() 
                .ReverseMap();

        }
    }
}

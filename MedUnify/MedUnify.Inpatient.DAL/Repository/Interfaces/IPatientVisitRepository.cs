using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedUnify.Inpatient.DAL.Repository.Interfaces
{
    public interface IPatientVisitRepository : IBaseRepository<PatientVisit>
    {
        Task<List<PatientVisit>> GetListByPatientIdAsync(int patientId);
    }
}

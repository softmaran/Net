using MedUnify.Inpatient.DAL.Model;
using MedUnify.Inpatient.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedUnify.Inpatient.DAL.Repository
{
    public class PatientVisitRepository : BaseRepository<PatientVisit>, IPatientVisitRepository
    {
        private InpatientDbContext dbContext;
        public PatientVisitRepository(InpatientDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;

        }
        public override IQueryable<PatientVisit> IncludeChain(IQueryable<PatientVisit> chain)
        {
            return base.IncludeChain(chain.Include(x => x.ProgressNotes));
        }
        public async Task<List<PatientVisit>> GetListByPatientIdAsync(int patientId)
        {
            var res = await this.dbContext.PatientVisits.Include(x => x.ProgressNotes)
                .Where(x => x.PatientId == patientId).ToListAsync();
            return res;
        }
    }
}

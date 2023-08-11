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
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private InpatientDbContext dbContext;

        public PatientRepository(InpatientDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

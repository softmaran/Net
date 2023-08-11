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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(InpatientDbContext dbContext) : base(dbContext)
        {
        }
    }
}

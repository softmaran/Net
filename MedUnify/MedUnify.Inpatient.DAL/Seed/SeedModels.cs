using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedUnify.Inpatient.DAL.Model;

namespace MedUnify.Inpatient.DAL.Seed
{
    public class SeedModels
    {
        public List<Organization>? Organizations { get; set; }
        public List<Patient>? Patients { get; set; }
    }
}

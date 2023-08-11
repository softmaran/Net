using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedUnify.Inpatient.SharedModel.Settings
{
    public class EntityConnections
    {
        public string? ConnectionString { get; set; }
        public int CommandTimeout { get; set; }
    }
}

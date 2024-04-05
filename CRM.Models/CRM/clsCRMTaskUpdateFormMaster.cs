using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMTaskUpdateFormMaster
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string LeadName { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskAssign { get; set; }
        public DateTime TaskAssignDate { get; set; }
        public DateTime TaskCompletebyDate { get; set; }
        public string TaskStage { get; set; }
        
    }
}

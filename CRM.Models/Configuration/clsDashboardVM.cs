using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.Configuration
{
    public class clsDashboardVM
    {
        public string  UserName { get; set; }
        public List<clsEzWorkflowMaster> EzWorkflowMasterList { get; set; }
    }
}

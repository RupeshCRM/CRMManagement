using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using CRM.Models;
using EZMasterSetup;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMContactInformationMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMContactInformationMaster CRMContactInformationMaster { get; set; }
    }
}

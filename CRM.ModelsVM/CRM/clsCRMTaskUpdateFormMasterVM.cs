using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using EZMasterSetup;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMTaskUpdateFormMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMTaskUpdateFormMaster CRMTaskUpdateFormMaster { get; set; }
        public clsControlsVM ControlsVM { get; set; }
    }
}


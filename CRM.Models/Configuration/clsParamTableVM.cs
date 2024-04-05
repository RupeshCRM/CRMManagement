using CRM.Models.EzUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZMasterSetup;

namespace CRM.Models.Configuration
{
    public class clsParamTableVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsParamTable ParamTable { get; set; }
    }
}

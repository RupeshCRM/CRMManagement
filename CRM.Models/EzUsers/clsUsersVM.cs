using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.EzUsers
{
    public class clsUsersVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsUsers users { get; set; }
        public List<clsUserWorkflowRights> userWorkflowRightsList { get; set; }

    }
}

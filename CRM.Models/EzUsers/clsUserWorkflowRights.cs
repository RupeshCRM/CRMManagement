using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.EzUsers
{
    public class clsUserWorkflowRights
    {
        public string CmpyCode { get; set; }
        public int Sno { get; set; }
        public string LoginUserName { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleDesc { get; set; }
        public string WorkflowCode { get; set; }
        public string WorkflowDesc { get; set; }
        public string ControllerName { get; set; }
        public string DefaultActionMethod { get; set; }
        
        public int AllRights { get; set; }
        public int CreateRights { get; set; }
        public int EditRights { get; set; }
        public int DeleteRights { get; set; }
        public int SaveRights { get; set; }
        public int PostRights { get; set; }
                
    }
}

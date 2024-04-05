using CRM.Models.CRM;
using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMHistoryDetailVM
    {
        public clsCRMHistoryDetail CRMHistoryDetail { get; set; }

        public clsUserRequest userRequest { get; set; }
        
        public List<clsCRMHistoryDetail> CRMHistoryDetailList{ get; set; }
    }
}

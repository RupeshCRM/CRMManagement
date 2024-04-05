using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.Models;
using CRM.Models.CRM;
using EZMasterSetup;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMLeadCaptureMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMLeadCaptureMaster CRMLeadCaptureMaster { get; set; }
        public clsControlsVM ControlsVM { get; set; }
        public List<SelectListItem> ContactTypeList { get; set; }
        public List<SelectListItem> MarriedStatusList { get; set; }
        public List<SelectListItem> ProfessionCodeList { get; set; }
        public List<SelectListItem> DesignationTypeList { get; set; }
        public List<SelectListItem> IncomeTypeList { get; set; }
        public List<SelectListItem> EmploymentTypeList { get; set; }
        public List<SelectListItem> AccountTypeList { get; set; }
        public List<SelectListItem> LeadGenrationTypeList { get; set; }
        public List<SelectListItem> LeadSourceOutboundList { get; set; }
        public List<SelectListItem> LeadSourceInboundList { get; set; }
        public List<SelectListItem> LeadSubSourceList { get; set; }
        public List<SelectListItem> SubStageList { get; set; }

    }
}

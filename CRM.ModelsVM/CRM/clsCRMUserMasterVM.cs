using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CRM.Models;
using CRM.Models.CRM;
using CRM.ModelsVM.EzUtility;
using EZMasterSetup;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMUserMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMUserMaster CRMUserMaster { get; set; }
        public clsDocumentAttachmentVM DocumentAttachmentMaster { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> TargetTypeList { get; set; }
        public List<SelectListItem> TargetCalculatedTypeList { get; set; }
        public List<SelectListItem> CRMCommissionTypeList { get; set; }
        public clsControlsVM ControlsVM { get; set; }
    }
}

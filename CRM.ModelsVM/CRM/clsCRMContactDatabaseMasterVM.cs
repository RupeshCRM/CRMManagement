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
    public class clsCRMContactDatabaseMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMContactDatabaseMaster CRMContactDatabaseMaster { get; set; }
        public List<SelectListItem> ContactTypeList { get; set; }
        public List<SelectListItem> MarriedStatusList { get; set; }
        public List<SelectListItem> ProfessionCodeList { get; set; }
        public List<SelectListItem> DesignationTypeList { get; set; }
        public List<SelectListItem> IncomeTypeList { get; set; }
        public List<SelectListItem> EmploymentTypeList { get; set; }
        public List<SelectListItem> ContactSubTypeList { get; set; }
        public List<SelectListItem> AccountTypeList { get; set; }
        public List<SelectListItem> PropertyUseList { get; set; }
        public List<SelectListItem> PropertyTypeList { get; set; }
        public List<SelectListItem> StreetList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public clsControlsVM ControlsVM { get; set; }

    }
}

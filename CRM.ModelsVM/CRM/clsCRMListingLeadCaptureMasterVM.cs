using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using EZMasterSetup;
using System.Web.Mvc;

namespace CRM.ModelsVM.CRM
{
    public class clsCRMListingLeadCaptureMasterVM
    {

        public clsUserRequest userRequest { get; set; }
        public clsCRMListingLeadCaptureMaster CRMListingLeadCaptureMaster { get; set; }
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
        public List<SelectListItem> LeadStatusList { get; set; }
        public List<SelectListItem> PropertyNameList{ get; set; }
        public List<SelectListItem> PropertyUseList { get; set; }
        public List<SelectListItem> PropertyTypeList { get; set; }
        public List<SelectListItem> StreetList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        
        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> ListingTypeList { get; set; }
        public List<SelectListItem> RentalPriceTypeList { get; set; }



    }
}


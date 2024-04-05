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
    public class clsCRMListingPageInfoMasterVM
    {
        public clsUserRequest userRequest { get; set; }
        public clsCRMListingPageInfoMaster CRMListingPageInfoMaster { get; set; }
        public List<SelectListItem> PropertyUseList { get; set; }
        public List<SelectListItem> PropertyTypeList { get; set; }
        public List<SelectListItem> StreetList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> StateList { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> AmenitiesList { get; set; }
        public List<SelectListItem> ListingTypeList { get; set; }
        public List<SelectListItem> RentalPriceTypeList { get; set; }
        public List<SelectListItem> PostToVariousPortalsList { get; set; }
        public clsControlsVM ControlsVM { get; set; }
    }
}

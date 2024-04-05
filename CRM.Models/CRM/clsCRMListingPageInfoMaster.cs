using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMListingPageInfoMaster
    {
        public string Cmpycode { get; set; }
        public string Code { get; set; }
        public string PropertyName { get; set; }
        public string ProjectName { get; set; }
        public string PropertyUse { get; set; }
        public string PropertyType { get; set; }
        public string BedsBath { get; set; }
        public string PropertySize { get; set; }
        public string PropertyLocation { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Amenities { get; set; }
        public string Notes { get; set; }
        public string CustomAttributes { get; set; }
        public string ListingType { get; set; }
        public double RentalPrice { get; set; }
        public string RentalPriceType { get; set; }
        public double SalePrice { get; set; }
        public bool PostToPortal { get; set; }
        public string PostToVariousPortals { get; set; }
        public string SaleRepContactID { get; set; }
        public string SalesRepEmail { get; set; }
        public string URL { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMListingLeadCaptureMaster
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string LeadStatus { get; set; }
        public string LeadID { get; set; }
        public string LeadName { get; set; }
        public DateTime Dates { get; set; }
        public string CreatedBy { get; set; }
        public string ContactType { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MarriedStatus { get; set; }
        public string ProfessionCode { get; set; }
        public string DesignationType { get; set; }
        public string TelePhone { get; set; }
        public string CellPhone { get; set; }
        public string EmailID1 { get; set; }
        public string EmailID2 { get; set; }
        public double Income { get; set; }
        public string IncomeType { get; set; }
        public string Hobbies { get; set; }
        public string EmploymentType { get; set; }
        public string CompanyName { get; set; }
        public string MainPhoneNumber { get; set; }
        public string MainFaxNumber { get; set; }
        public string MainEmailID { get; set; }
        public string URL { get; set; }
        public string Industry { get; set; }
        public double YearlyTurnover { get; set; }
        public int NumberOfEmployees { get; set; }
        public string PSDescription { get; set; }
        public string AccountType { get; set; }
        public string LeadGeneration { get; set; }
        public string LeadSourceOutBound { get; set; }
        public string LeadSourceInBound { get; set; }
        public string LeadSubSource { get; set; }
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
        public string CustomAttribute { get; set; }
        public string ListingType { get; set; }
        public double RentalPrice { get; set; }
        public string RentalPriceType { get; set; }
        public double SalePrice { get; set; }
        public bool ListingConfirmed { get; set; }
        public DateTime DateConfirmed { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EZMasterSetup;

namespace CRM.Models.CRM
{
    public class clsCRMContactDatabaseMaster
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string ContactID { get; set; }
        public string ContactType { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MarriedStatus { get; set; }
        public string ProfessionCode { get; set; }
        public string Designation { get; set; }
        public string TeliPhone { get; set; }
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
        public string MainEmail { get; set; }
        public string URL { get; set; }
        public string Industry { get; set; }
        public double YearlyTurnover { get; set; }
        public int NumberOfEmployees { get; set; }
        public string ContactSubType { get; set; }
        public string AccountType { get; set; }
        public string PropertyName { get; set; }
        public string ProjectName { get; set; }
        public string PropertyUse { get; set; }
        public string PropertyType { get; set; }
        public string BedsBath { get; set; }
        public string PropertySize { get; set; }
        public string PropertyLocation { get; set; }
        public string street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Amenities { get; set; }
        public string PSDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMLeadCaptureMaster
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
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
        public string AccountType { get; set; }
        public string LeadGenrationType { get; set; }
        public string LeadSourceOutbound { get; set; }
        public string LeadSourceInbound { get; set; }
        public string LeadSubSource { get; set; }
        public string PSDescription { get; set; }
        public double ApproximateDealValue { get; set; }
        public DateTime ApproximateDealClouserDate { get; set; }
        public string SubStage { get; set; }
        public string PipelineName { get; set; }
        public string DealSubStage { get; set; }

    }
}

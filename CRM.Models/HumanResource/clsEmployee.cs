using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.HumanResource
{
    public class clsEmployee
    {

        ///
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        //Personal Information
        public string Salutaion { get; set; }
        public string BadgeID { get; set; }
        public string EmpMolId { get; set; }
        public string AttDeviceNo { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string AddressLocal { get; set; }
        public string ContactNo { get; set; }
        public string EmContactNo { get; set; }
        public DateTime DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Sex { get; set; }

        //Company Related detail
        public string ShiftAllocation { get; set; }
        public string LeaveStatus { get; set; }
        public string ShiftCode { get; set; }
             public DateTime JoiningDate { get; set; }
        public DateTime LastRetDate { get; set; }
        public DateTime JoiningForLeave { get; set; }
        public string WorkingStatus { get; set; }
        public string PmyType { get; set; }
        public string EMail { get; set; }
        public string VisaStatus { get; set; }

        //General Tab Information
        public string DivisionCode { get; set; }
        public string ProfCode { get; set; }
        public string Religion { get; set; }
        public string ProjectCode { get; set; }
        //Bank Detail
        public string BankCode { get; set; }
        public string BankAccNo { get; set; }
        public string BranchCode { get; set; }
        public string PayRule { get; set; }
        public string AttType { get; set; }
        public string ReportingEmp { get; set; }
        public string DepartmentCode { get; set; }
        public string WO1 { get; set; }
        public string WO2 { get; set; }
        public string HalfDay { get; set; }
        public string LoanGLAcc { get; set; }
        public string AccNo { get; set; }

        //Additional Information

        public string ShortName { get; set; }
        public string Nationality { get; set; }
        public string Dicipline { get; set; }
        public string SubTrade { get; set; }
        public string VisaLocation { get; set; }
        public string Classification { get; set; }
        public string SupervisorYN { get; set; }
        public string LanguageKnown { get; set; }
        public DateTime LeaveSettlementDate { get; set; }
        public DateTime LastIncrementDate { get; set; }
        public string SalaryType { get; set; }
        public string PayRuleGroup { get; set; }
        public string Location { get; set; }
    }
}

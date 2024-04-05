using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMUserMaster
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string EmployeeID { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CategoryID { get; set; }
        public string ReportingTo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        //public byte[] Photo { get; set; } Used in Edit mode to upload documents , do not uncomment
        public string TargetType { get; set; }
        public double TargetValue { get; set; }
        public string TargetCalculatedType { get; set; }
        public double TargetCalculated { get; set; }
        public string CommissionType { get; set; }
        public double CommissionTypeValue { get; set; }
        public DateTime StartAccrualFromDate { get; set; }
        public double AccruedAmountToDate { get; set; }
        public double PaidToDate { get; set; }
        public double Balance { get; set; }
        public string Notes { get; set; }

    }
}

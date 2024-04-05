using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMLeadUpdateSection
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public int Sno { get; set; }
        public string LeadID { get; set; }
        public string ActionNotes { get; set; }
        public string SubStageID { get; set; }
        public DateTime DealDate { get; set; }
        public string NextActionID { get; set; }
        public DateTime NextActionDate { get; set; }
        public string AssignTo { get; set; }

     


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class clsMReqHeader
    {
        public string CmpyCode { get; set; }
        public string MRCode { get; set; }
        public DateTime Dates { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public string EmpCode { get; set; }
        public string ProjectCode { get; set; }
        public string ResourceType { get; set; }
        public string PreparedBy { get; set; }
        public int ApprovalYN { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models
{
    public  class clsMReqDetail
    {
        public string CmpyCode { get; set; }
        public string MRCode { get; set; }
        public int SNo { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public string Unit { get; set; }
        public double Qty { get; set; }
        public double QtyReceived { get; set; }
        public DateTime Dates { get; set; }
        public string status { get; set; }
        public string ApprovalYN { get; set; }

    }
}

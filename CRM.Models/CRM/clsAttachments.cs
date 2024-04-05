using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models
{
    public class clsAttachments
    {
        public string Code { get; set; }
        public string Sno { get; set; }
        public string RefNumber { get; set; }
        public string docCode { get; set; }
        public string docDescription { get; set; }
        public DateTime docIssuesDate { get; set; }
        public DateTime docExpiryDate { get; set; }
        public string docHyperlink { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.EzSystem
{
    public class clsDocumentAttachment
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string RefNo { get; set; }
        public string DocCode { get; set; }
        public string Specification { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public byte[] Attachment { get; set; }
                
    }
}

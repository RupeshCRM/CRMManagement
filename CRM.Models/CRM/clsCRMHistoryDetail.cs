using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.CRM
{
    public class clsCRMHistoryDetail
    {
        public string CmpyCode { get; set; }
        public string EntryType { get; set; }
        //public string HistoryRef { get; set; }
        public string DocReferenceNo { get; set; }
        public DateTime Dates { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDescription { get; set; }
        public string UserName { get; set; }

    }
}

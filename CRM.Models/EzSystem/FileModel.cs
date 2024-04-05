using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Models.EzSystem
{
    public class FileModel
    { 
        public string FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }

    }
}

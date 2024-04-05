
using CRM.Models.EzSystem;
using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRM.ModelsVM.EzUtility
{
    public class clsDocumentAttachmentVM
    {
        public clsDocumentAttachment DocumentAttachment { get; set; }
        public clsUserRequest userRequest { get; set; }
        public clsControlsVM ControlsVM{ get; set; }
        public List<clsDocumentAttachment> DocumentAttachmentList { get; set; }
        public List<SelectListItem> DocumentList{ get; set; }
        public List<SelectListItem> DocumentSourceList{ get; set; }

    }
}

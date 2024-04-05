
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.EzSystem;
using CRM.ModelsVM.EzUtility;
using CRM.BAL.EzUtility;
using EZMasterSetup;

namespace CRM.Models.CommonImplementation
{
    public partial class clsCommonImplementation
    {   
        clsCommonFunction comFunction;
        public clsDocumentAttachmentVM DocumentAttachmentVM(string CmpyCode,string RefNo)
        {  
            comFunction = new clsCommonFunction();
            clsDocumentAttachmentVM DocumentAttachmentVM=new clsDocumentAttachmentVM();
            clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL();
            clsDocumentAttachment DocumentAttachment=new clsDocumentAttachment();

            DocumentAttachmentVM.DocumentList= comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code"," LookUpType='DocumentTypeMaster'"); 
            DocumentAttachmentVM.DocumentSourceList= comFunction.FillControls("uVw_DocumentReference", "Description", "Reference", CmpyCode, " order by Reference",""); 
            DocumentAttachmentVM.DocumentAttachmentList = DocumentAttachmentBAL.GetByIdList(RefNo,"RefNo");
            DocumentAttachmentVM.DocumentAttachment= DocumentAttachmentBAL.ReadSingle(RefNo);
            DocumentAttachment.RefNo=RefNo;
            DocumentAttachment.CmpyCode=CmpyCode;
            //DocumentAttachmentVM.DocumentAttachment=DocumentAttachment;

            return (DocumentAttachmentVM);

        }
    }
}

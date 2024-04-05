using CRM.BAL.CRM;
using CRM.BAL.EzUsers;
using CRM.BAL.EzUtility;
using CRM.Models.CommonImplementation;
using CRM.Models.CRM;
using CRM.Models.EzSystem;
using CRM.Models.EzUsers;
using CRM.ModelsVM.CRM;
using CRM.ModelsVM.EzUtility;
using CRMManagement.Models;
using EZMasterSetup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace CRMManagement.Controllers.EzUtility
{ 
    [SessionExpireFilter]
    public class DocumentAttachmentController : Controller
    {
        // GET: DocumentAttachment
        clsDocumentAttachment DocumentAttachment;
        clsCRMContactInformationMasterBAL ezContactMasterBAL;
        clsUserWorkflowRightsBAL ezUserWorkflowRightsBAL;
        clsUserRequestHandler UserRequestHandler;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsUserWorkflowRights userWorkflowRights;
        clsControlsVM ControlsVM;
        clsCommonImplementation comImplementation;
        clsCommonFunction comFunction;

        public ActionResult Index(string CmpyCode, string Id, string userName)
        {
           try
            {
                createEditUserRequestHandler = new clsCreateEditUserRequestHandler();
                ControlsVM = createEditUserRequestHandler.DisplayRecord(Id, userName, CmpyCode);
                ViewBag.SectionId = Id;
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            return View(ControlsVM);
        }

        // GET: DocumentAttachment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentAttachment/Create
        public ActionResult Create(string CmpyCode, string Id, string userName)
        {
             try
            {
                createEditUserRequestHandler=new clsCreateEditUserRequestHandler();
                ControlsVM = new clsControlsVM();
                comImplementation=new clsCommonImplementation();
                clsDocumentAttachmentVM DocumentAttachmentVM=comImplementation.DocumentAttachmentVM(CmpyCode,"Code");
                comFunction = new clsCommonFunction();
                DocumentAttachmentVM.DocumentAttachment.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                DocumentAttachmentVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;

                if (ControlsVM != null)
                    return View(DocumentAttachmentVM);
                else
                    return View();

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: DocumentAttachment/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file,string SectionId,string CmpyCode,string userName, clsDocumentAttachment DocumentAttachment)
        {
             try
            {
                if (file != null && file.ContentLength > 0)
                {
                    clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
                    clsDocumentAttachment DocumentAttachmentLocal=new clsDocumentAttachment();
                    comFunction=new clsCommonFunction ();
                    var memoryStream = new MemoryStream();
                    file.InputStream.CopyTo(memoryStream);
                    byte[] fileData = memoryStream.ToArray();
                    DocumentAttachmentLocal.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", SectionId, CmpyCode);
                    DocumentAttachmentLocal.CmpyCode=DocumentAttachment.CmpyCode;
                    DocumentAttachmentLocal.RefNo=DocumentAttachment.RefNo;
                    DocumentAttachmentLocal.DocCode=DocumentAttachment.DocCode;
                    DocumentAttachmentLocal.Specification=DocumentAttachment.Specification;
                    DocumentAttachmentLocal.IssueDate=DocumentAttachment.IssueDate;
                    DocumentAttachmentLocal.ExpiryDate=DocumentAttachment.ExpiryDate;
                    DocumentAttachmentLocal.Attachment=fileData;
                    DocumentAttachmentBAL.Insert(DocumentAttachmentLocal);
                }
                // Assuming your processing is successful
                //return Json(new { success = true, message = "File uploaded successfully" });
                return Json(new { redirectUrl = Url.Action("Index", "DocumentAttachment", new { CmpyCode = CmpyCode, Id = SectionId, userName = userName }) });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = "Error uploading file: " + ex.Message });
            }
        }

        // GET: DocumentAttachment/Edit/5
        public ActionResult Edit(string CmpyCode, string SectionId, string Id, string userName)
        {
            clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
            
            clsDocumentAttachment DocumentAttachmentLocal=new clsDocumentAttachment();
            createEditUserRequestHandler=new clsCreateEditUserRequestHandler();
            ControlsVM = new clsControlsVM();

            comFunction=new clsCommonFunction ();
            clsCommonImplementation comImplementation=new clsCommonImplementation();
            clsDocumentAttachmentVM DocumentAttachmentVM=comImplementation.DocumentAttachmentVM(CmpyCode,Id);
            DocumentAttachmentVM.ControlsVM = createEditUserRequestHandler.CreateHandler(SectionId, userName, CmpyCode);
            ViewBag.oprType = "Edit";
            ViewBag.SectionId = SectionId;

                if (ControlsVM != null)
                    return View(DocumentAttachmentVM);
                else
                    return View();
            
        }

        // POST: DocumentAttachment/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,string SectionId,string CmpyCode,string userName, clsDocumentAttachment DocumentAttachment)
        {
             try
            {
                if (file != null && file.ContentLength > 0)
                {
                    clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
                    clsDocumentAttachment DocumentAttachmentLocal=new clsDocumentAttachment();
                    comFunction=new clsCommonFunction ();
                    var memoryStream = new MemoryStream();
                    file.InputStream.CopyTo(memoryStream);
                    byte[] fileData = memoryStream.ToArray();
                    //DocumentAttachmentLocal.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE", SectionId, CmpyCode);
                    DocumentAttachmentLocal.CmpyCode=DocumentAttachment.CmpyCode;
                    DocumentAttachmentLocal.RefNo=DocumentAttachment.RefNo;
                    DocumentAttachmentLocal.DocCode=DocumentAttachment.DocCode;
                    DocumentAttachmentLocal.Specification=DocumentAttachment.Specification;
                    DocumentAttachmentLocal.IssueDate=DocumentAttachment.IssueDate;
                    DocumentAttachmentLocal.ExpiryDate=DocumentAttachment.ExpiryDate;
                    DocumentAttachmentLocal.Attachment=fileData;
                    DocumentAttachmentBAL.Update(DocumentAttachmentLocal,"Code", DocumentAttachmentLocal.Code);
                }
                // Assuming your processing is successful
                //return Json(new { success = true, message = "File uploaded successfully" });
                return Json(new { redirectUrl = Url.Action("Index", "DocumentAttachment", new { CmpyCode = CmpyCode, Id = SectionId, userName = userName }) });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = "Error uploading file: " + ex.Message });
            }
        }

        // GET: DocumentAttachment/Delete/5
        public ActionResult Delete(string CmpyCode, string SectionId, string Id, string userName)
        {
          clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
            
            clsDocumentAttachment DocumentAttachmentLocal=new clsDocumentAttachment();
            createEditUserRequestHandler=new clsCreateEditUserRequestHandler();
            ControlsVM = new clsControlsVM();

            comFunction=new clsCommonFunction ();
            clsCommonImplementation comImplementation=new clsCommonImplementation();
            clsDocumentAttachmentVM DocumentAttachmentVM=comImplementation.DocumentAttachmentVM(CmpyCode,Id);
            DocumentAttachmentVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
            ViewBag.oprType = "Delete";
            ViewBag.SectionId = Id;

                if (ControlsVM != null)
                    return View(DocumentAttachmentVM);
                else
                    return View();
        }

        // POST: DocumentAttachment/Delete/5
        [HttpPost]
        public ActionResult Delete(HttpPostedFileBase file,string SectionId,string CmpyCode,string userName, clsDocumentAttachment DocumentAttachment)
        {
            try
            {
               clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
               DocumentAttachmentBAL.Delete(DocumentAttachment.Code);
               return Json(new { redirectUrl = Url.Action("Index", "DocumentAttachment", new { CmpyCode = CmpyCode, Id = SectionId, userName = userName }) });
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult DocumentUpload(HttpPostedFileBase file, clsDocumentAttachment DocumentAttachment)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    clsDocumentAttachmentBAL DocumentAttachmentBAL=new clsDocumentAttachmentBAL(); 
                    string connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
                    var memoryStream = new MemoryStream();
                    file.InputStream.CopyTo(memoryStream);
                    byte[] fileData = memoryStream.ToArray();
                    DocumentAttachment.Attachment = fileData;
                    DocumentAttachmentBAL.Insert(DocumentAttachment);
                }
                // Assuming your processing is successful
                return Json(new { success = true, message = "File uploaded successfully" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = "Error uploading file: " + ex.Message });
            }
        }
               
        public ActionResult DownloadFile(string Code)
        {
            FileModel file = GetFileById(Code);

            if (file != null)
            {
                return File(file.FileData, "application/octet-stream", file.FileName);
            }

            return HttpNotFound();
        }
        private FileModel GetFileById(string fileId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT  Attachment FROM DocumentAttachment WHERE Code = ? and Attachment is not null";

                    using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", fileId);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FileModel file = new FileModel
                                {
                                    //FileId = Convert.ToString(reader["EmployeeId"]),
                                    //FileName = reader["FirstName"].ToString(),
                                    FileData = (byte[])reader["Attachment"]
                                };
                                return file;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;

            }

            return null;
        }


    }
}

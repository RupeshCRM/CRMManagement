using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.BAL.CRM;
using CRM.BAL.EzUsers;
using CRM.Models;
using CRM.Models.CommonImplementation;
using CRM.Models.CRM;
using CRM.Models.EzSystem;
using CRM.Models.EzUsers;
using CRM.ModelsVM.CRM;

using CRMManagement.Models;
using EZMasterSetup;

namespace CRMManagement.Controllers.CRM
{
    [SessionExpireFilter]
    public class CRMUserMasterController : Controller
    {

        clsCRMUserMasterBAL ezCRMUserMasterBAL;
        clsUserWorkflowRightsBAL ezUserWorkflowRightsBAL;
        clsUserRequestHandler UserRequestHandler;
        clsCreateEditUserRequestHandler createEditUserRequestHandler;
        clsUserWorkflowRights userWorkflowRights;
        clsControlsVM ControlsVM;
        clsCRMUserMasterVM CRMUserMasterVM;
        clsCommonFunction comFunction;
        clsCommonImplementation comImplementation;
        public clsCRMUserMasterVM CommonFunctionality(string CmpyCode)
        {
            CRMUserMasterVM=new clsCRMUserMasterVM();  
             comFunction = new clsCommonFunction();
            CRMUserMasterVM.EmployeeList = comFunction.FillControls("uVw_Employee", "EmployeeName", "EmployeeID", CmpyCode, " order by EmployeeID",""); 
            CRMUserMasterVM.CategoryList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code"," LookUpType='CRMCategoryMaster'"); 
            CRMUserMasterVM.CRMCommissionTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode,  "order by Code", "LookUpType='CRMCommissionTypeMaster'");
            CRMUserMasterVM.CityList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code", "LookUpType='CityMaster'");
            CRMUserMasterVM.StateList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code", "LookUpType='StateMaster'");
            CRMUserMasterVM.CountryList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code", "LookUpType='CountryMaster'");
            CRMUserMasterVM.TargetTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Sno", "LookUpType='CRMTargetType'");
            CRMUserMasterVM.TargetCalculatedTypeList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Sno", "LookUpType='CRMTargetCalculatedType'");
            //CRMUserMasterVM.DocumentAttachmentMaster.DocumentList = comFunction.FillControls("EzCommonMaster", "Description", "Code", CmpyCode, " order by Code", "LookUpType='DocumentTypeMaster'");
            return CRMUserMasterVM;
        }
      
        // GET: Users
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

    
        // GET: EzSectionFieldMaster/Create
        public ActionResult Create(string CmpyCode, string Id, string userName)
        {
            try
            {
                clsCRMUserMasterVM CRMUserMasterVM=CommonFunctionality(CmpyCode);
                clsCRMUserMaster CRMUserMaster=new clsCRMUserMaster();

                ControlsVM = new clsControlsVM();
                createEditUserRequestHandler=new clsCreateEditUserRequestHandler();
                comFunction = new clsCommonFunction();
                comImplementation=new clsCommonImplementation();
                
                CRMUserMaster.CommissionType = "PER";
                CRMUserMasterVM.CRMUserMaster = CRMUserMaster;
                CRMUserMasterVM.CRMUserMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("", Id, CmpyCode);
                CRMUserMasterVM.DocumentAttachmentMaster=comImplementation.DocumentAttachmentVM(CmpyCode,"Code");
                //comFunction = new clsCommonFunction();
                 CRMUserMasterVM.ControlsVM = createEditUserRequestHandler.CreateHandler(Id, userName, CmpyCode);
                //CRMUserMasterVM.ControlsVM = comFunction.GetData_In_CreateMode("uVw_UsersNewEntry", Id, userName, "SectionCode", CmpyCode);
                ViewBag.oprType = "Create";
                ViewBag.SectionId = Id;
                if (CRMUserMasterVM != null)
                    return View(CRMUserMasterVM);
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        // POST: EzSectionFieldMaster/Create
        [HttpPost]
        public ActionResult Create(clsCRMUserMasterVM CRMUserMasterVM)
        {
            try
            {

                object ezCRMUserMaster = new clsCRMUserMaster();
                ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                comFunction = new clsCommonFunction();
                CRMUserMasterVM.CRMUserMaster.Code = comFunction.GF_Get_AutoCode_ParamTable("SAVE",  CRMUserMasterVM.userRequest.SectionId,  CRMUserMasterVM.userRequest.CompanyCode);
               /* Guid newGuid = Guid.NewGuid();
                CRMUserMasterVM.CRMUserMaster.EmployeeID = newGuid.ToString();*/
                ezCRMUserMaster = comFunction.CopyProperties(CRMUserMasterVM.CRMUserMaster, ezCRMUserMaster);
                ezCRMUserMasterBAL.Insert(ezCRMUserMaster);
                return Json(new { redirectUrl = Url.Action("Index", "CRMUserMaster", new { CmpyCode = CRMUserMasterVM.userRequest.CompanyCode, Id = CRMUserMasterVM.userRequest.SectionId, UserName = CRMUserMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }


        }
        // GET: EzSectionFieldMaster/Edit/5
        public ActionResult Edit(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                clsCRMUserMasterVM CRMUserMasterVM = CommonFunctionality(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMUserMaster CRMUserMaster = new clsCRMUserMaster();
                ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                comFunction = new clsCommonFunction();
                comImplementation=new clsCommonImplementation();

                CRMUserMasterVM.DocumentAttachmentMaster=comImplementation.DocumentAttachmentVM(CmpyCode,Id);
                CRMUserMaster = ezCRMUserMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "EmployeeID", CmpyCode);
                CRMUserMasterVM.ControlsVM = ControlsVM;
                CRMUserMasterVM.CRMUserMaster = CRMUserMaster;


                ViewBag.oprType = "Edit";
                ViewBag.SectionId = SectionId;
                return View(CRMUserMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            
        }
        // Method to copy properties using reflection

        // POST: EzSectionFieldMaster/Edit/5
        [HttpPost]
        public ActionResult Edit(clsCRMUserMasterVM CRMUserMasterVM)
        {
            try
            {
                object CRMUserMaster = new clsCRMUserMaster();
                ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                comFunction = new clsCommonFunction();
                CRMUserMaster = comFunction.CopyProperties(CRMUserMasterVM.CRMUserMaster, CRMUserMaster);
                //ezUserMasterBAL.Update(ContactMaster, "Code", ContactMasterVM.ContactMaster.Code);
                ezCRMUserMasterBAL.Update(CRMUserMaster, CRMUserMasterVM.CRMUserMaster.EmployeeID, "EmployeeID");
                return Json(new { redirectUrl = Url.Action("Index", "CRMUserMaster", new { CmpyCode = CRMUserMasterVM.userRequest.CompanyCode, Id = CRMUserMasterVM.userRequest.SectionId, UserName = CRMUserMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        // GET: EzSectionFieldMaster/Delete/5
        public ActionResult Delete(string CmpyCode, string SectionId, string Id, string userName)
        {
            try
            {
                clsCRMUserMasterVM CRMUserMasterVM =CommonFunctionality(CmpyCode);
                ControlsVM = new clsControlsVM();
                clsCRMUserMaster CRMUserMaster = new clsCRMUserMaster();
                ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                comFunction = new clsCommonFunction();
                CRMUserMaster = ezCRMUserMasterBAL.ReadSingle(Id);
                ControlsVM = comFunction.GetData_In_EditMode(SectionId, Id, userName, "EmployeeID", CmpyCode);
                CRMUserMasterVM.ControlsVM = ControlsVM;
                CRMUserMasterVM.CRMUserMaster = CRMUserMaster;
                
                ViewBag.oprType = "Delete";
                ViewBag.SectionId = SectionId;
                return View(CRMUserMasterVM);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // POST: EzSectionFieldMaster/Delete/5
        [HttpPost]
        public ActionResult Delete(clsCRMUserMasterVM CRMUserMasterVM)
        {
            try
            {
                object CRMUserMaster = new clsCRMUserMaster();
                ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                comFunction = new clsCommonFunction();
                //ezCRMUserMasterBAL = new clsCRMUserMasterBAL();
                ezCRMUserMasterBAL.Delete(CRMUserMasterVM.CRMUserMaster.EmployeeID);

                return Json(new { redirectUrl = Url.Action("Index", "CRMUserMaster", new { CmpyCode = CRMUserMasterVM.userRequest.CompanyCode, Id = CRMUserMasterVM.userRequest.SectionId, UserName = CRMUserMasterVM.userRequest.UserName }) });
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }



        
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file,string CmpyCode, string EmployeeID)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
                if (file != null && file.ContentLength > 0)
                        {
                            using (OleDbConnection connection = new OleDbConnection(connectionString))
                            {
                                connection.Open();

                                // Insert file data into the database using a parameterized query
                                string insertQuery = "Update CRMUserMaster Set Photo=FileName where  CmpyCode=@CmpyCode and EmployeeId=@EmployeeId VALUES (?, ?)";
                                using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@FileName", file.FileName);

                                    using (var memoryStream = new MemoryStream())
                                    {
                                        file.InputStream.CopyTo(memoryStream);
                                        byte[] fileData = memoryStream.ToArray();
                                        command.Parameters.AddWithValue("@FileData", fileData);
                                    }

                                    command.ExecuteNonQuery();
                                }
                            }
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
        [HttpPost]
        public JsonResult UploadFile1(HttpPostedFileBase file, string CmpyCode, string Code)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;

                    if (file != null && file.ContentLength > 0)
                    {
                        using (OleDbConnection connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            // Update file data in the database using a parameterized query
                            string updateQuery = "Update CRMUserMaster Set Photo=? where CmpyCode=? and Code=?";
                            using (OleDbCommand command = new OleDbCommand(updateQuery, connection))
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.InputStream.CopyTo(memoryStream);
                                    byte[] fileData = memoryStream.ToArray();

                                    // Using OleDbParameter for positional parameters
                                    command.Parameters.Add(new OleDbParameter("@Photo", OleDbType.VarBinary) { Value = fileData });
                                    command.Parameters.Add(new OleDbParameter("@CmpyCode", OleDbType.VarChar) { Value = CmpyCode });
                                    command.Parameters.Add(new OleDbParameter("@Code", OleDbType.VarChar) { Value = Code});

                                    command.ExecuteNonQuery();
                                }
                            }
                        }
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
        public ActionResult DownloadFile(string EmployeeId)
        {
            FileModel file = GetFileById(EmployeeId);

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
                    string selectQuery = "SELECT  EmployeeId,FirstName,Photo FROM CRMUserMaster WHERE EmployeeId = ? and Photo is not null";

                    using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", fileId);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FileModel file = new FileModel
                                {
                                    FileId = Convert.ToString(reader["EmployeeId"]),
                                    FileName = reader["FirstName"].ToString(),
                                    FileData = (byte[])reader["Photo"]
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

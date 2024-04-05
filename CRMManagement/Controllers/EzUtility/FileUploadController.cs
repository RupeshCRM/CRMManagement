using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMManagement.Controllers.EzUtility
{
    public class FileUploadController : Controller
    {
          private readonly string connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
        public ActionResult Index()
        {
            List<FileModel> files = GetFiles();
            return View(files);
        }

        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                        {
                            using (OleDbConnection connection = new OleDbConnection(connectionString))
                            {
                                connection.Open();

                                // Insert file data into the database using a parameterized query
                                string insertQuery = "INSERT INTO Files (FileName, FileData) VALUES (?, ?)";
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

        public ActionResult DownloadFile(int fileId)
        {
            FileModel file = GetFileById(fileId);

            if (file != null)
            {
                return File(file.FileData, "application/octet-stream", file.FileName);
            }

            return HttpNotFound();
        }

        // Helper method to retrieve files from the database
        private List<FileModel> GetFiles()
        {
            List<FileModel> files = new List<FileModel>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT FileId, FileName FROM Files";

                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FileModel file = new FileModel
                            {
                                FileId = Convert.ToString(reader["FileId"]),
                                FileName = reader["FileName"].ToString()
                            };
                            files.Add(file);
                        }
                    }
                }
            }

            return files;
        }

        // Helper method to retrieve a file by its ID from the database
        private FileModel GetFileById(int fileId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT FileId, FileName, FileData FROM Files WHERE FileId = ?";

                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileId", fileId);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FileModel file = new FileModel
                            {
                                FileId = Convert.ToString(reader["FileId"]),
                                FileName = reader["FileName"].ToString(),
                                FileData = (byte[])reader["FileData"]
                            };
                            return file;
                        }
                    }
                }
            }

            return null;
        }
    }
}
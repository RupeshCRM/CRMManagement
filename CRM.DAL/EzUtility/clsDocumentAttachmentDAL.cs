using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.EzSystem
{
    public class clsDocumentAttachmentDAL
    {
         string tableName = "DocumentAttachment";
        IDataAccess<clsDocumentAttachment> dataAccess = new clsDataAccessHelper<clsDocumentAttachment>();
        public List<clsDocumentAttachment> GetAll()
        {
            List<clsDocumentAttachment> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsDocumentAttachment ReadSingle(string idColumnName, string Id)
        {
            clsDocumentAttachment lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsDocumentAttachment> GetByIdList(string idColumnName, string Id)
        {

            List<clsDocumentAttachment> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "Code", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(clsDocumentAttachment objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsDocumentAttachment objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
        public DataSet GetAllData_DataSet(string idColumnName, string id)
        {
            return (dataAccess.GetAllData_DataSet(tableName, idColumnName, id));
        }
        public DataTable GetAllData_DataTable(string idColumnName, string id)
        {
            return (dataAccess.GetAllData_DataTable(tableName, idColumnName, id));

        }
    }
}

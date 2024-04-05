using CRM.DAL.EzSystem;
using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BAL.EzUtility
{
    public class clsDocumentAttachmentBAL
    {
          private clsDocumentAttachmentDAL dataAccessLayer = new DAL.EzSystem.clsDocumentAttachmentDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsDocumentAttachment> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsDocumentAttachment ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsDocumentAttachment> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsDocumentAttachment> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccessLayer.Delete(id);
        }

        public void DeleteAll()
        {
            dataAccessLayer.DeleteAll();
        }

        public int Insert(clsDocumentAttachment objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public int Insert(object objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsDocumentAttachment objIns, string idColumnName, string id)
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public DataSet GetAllData_DataSet(string idColumnName, string id)
        {
            return (dataAccessLayer.GetAllData_DataSet(idColumnName, id));
        }

        public DataTable GetAllData_DataTable(string idColumnName, string id)
        {
            return (dataAccessLayer.GetAllData_DataTable(idColumnName, id));
        }
    }
}

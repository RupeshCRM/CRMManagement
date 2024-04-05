using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using CRM.DAL.CRM;
using System.Data;

namespace CRM.BAL.CRM
{
    public class clsCRMContactDatabaseMasterBAL
    {
        private clsCRMContactDatabaseMasterDAL dataAccessLayer = new DAL.CRM.clsCRMContactDatabaseMasterDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMContactDatabaseMaster> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMContactDatabaseMaster ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsCRMContactDatabaseMaster> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsCRMContactDatabaseMaster> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(object objIns)
        {
            return dataAccessLayer.Create(objIns);
        }

        public int Insert(clsCRMContactDatabaseMaster objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMContactDatabaseMaster objIns, string id, string idColumnName = "Code")
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string id, string idColumnName = "Code")
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

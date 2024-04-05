using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;

namespace CRM.DAL.CRM
{
    public class clsCRMTaskUpdateFormMasterDAL
    {
        string tableName = "CRMTaskUpdateFormMaster";
        IDataAccess<clsCRMTaskUpdateFormMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMTaskUpdateFormMaster>();
        public List<clsCRMTaskUpdateFormMaster> GetAll()
        {
            List<clsCRMTaskUpdateFormMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMTaskUpdateFormMaster ReadSingle(string idColumnName, string Id)
        {
            clsCRMTaskUpdateFormMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMTaskUpdateFormMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMTaskUpdateFormMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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

        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(clsCRMTaskUpdateFormMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMTaskUpdateFormMaster objIns, string idColumnName, string id)
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

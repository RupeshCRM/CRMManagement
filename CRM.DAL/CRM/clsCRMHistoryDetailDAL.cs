using CRM.Models.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.CRM
{
    public  class clsCRMHistoryDetailDAL
    {
        
        string tableName = "CRMHistoryDetail";
        IDataAccess<clsCRMHistoryDetail> dataAccess = new clsDataAccessHelper<clsCRMHistoryDetail>();
        public List<clsCRMHistoryDetail> GetAll()
        {
            List<clsCRMHistoryDetail> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMHistoryDetail ReadSingle(string idColumnName, string Id)
        {
            clsCRMHistoryDetail lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMHistoryDetail> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMHistoryDetail> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "HistoryRef", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(clsCRMHistoryDetail objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMHistoryDetail objIns, string idColumnName, string id)
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

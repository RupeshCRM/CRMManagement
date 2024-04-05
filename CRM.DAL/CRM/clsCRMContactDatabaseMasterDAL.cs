using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using EZMasterSetup;

namespace CRM.DAL.CRM
{
    public class clsCRMContactDatabaseMasterDAL
    {

        string tableName = "CRMContactDatabaseMaster";
        IDataAccess<clsCRMContactDatabaseMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMContactDatabaseMaster>();
        public List<clsCRMContactDatabaseMaster> GetAll()
        {
            List<clsCRMContactDatabaseMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMContactDatabaseMaster ReadSingle(string idColumnName, string Id)
        {
            clsCRMContactDatabaseMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMContactDatabaseMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMContactDatabaseMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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
        public int Create(clsCRMContactDatabaseMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMContactDatabaseMaster objIns, string idColumnName, string id)
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

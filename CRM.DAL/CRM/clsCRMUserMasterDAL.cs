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
    public class clsCRMUserMasterDAL
    {
        string tableName = "CRMUserMaster";
        IDataAccess<clsCRMUserMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMUserMaster>();
        public List<clsCRMUserMaster> GetAll()
        {
            List<clsCRMUserMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMUserMaster ReadSingle(string idColumnName, string Id)
        {
            clsCRMUserMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMUserMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMUserMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "EmployeeID", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(clsCRMUserMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMUserMaster objIns, string idColumnName, string id)
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

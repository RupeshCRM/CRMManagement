using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.EzSystem
{
    public class clsEzLookUpMasterDAL
    {

        string tableName = "EzLookUpMaster";
        IDataAccess<clsEzLookUpMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsEzLookUpMaster>();
        public List<clsEzLookUpMaster> GetAll()
        {
            List<clsEzLookUpMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsEzLookUpMaster ReadSingle(string idColumnName, string Id)
        {
            clsEzLookUpMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsEzLookUpMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsEzLookUpMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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

        public int Create(clsEzLookUpMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsEzLookUpMaster objIns, string idColumnName, string id)
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

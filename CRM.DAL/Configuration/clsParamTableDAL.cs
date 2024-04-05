using CRM.Models.Configuration;
using CRM.Models.EzUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Configuration
{
    public class clsParamTableDAL
    {
        string tableName = "ParamTable";
        IDataAccess<clsParamTable> dataAccess = new clsDataAccessHelperWithoutCompany<clsParamTable>();
        public List<clsParamTable> GetAll()
        {
            List<clsParamTable> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsParamTable ReadSingle(string idColumnName, string Id)
        {
            clsParamTable lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsParamTable> GetByIdList(string idColumnName, string Id)
        {

            List<clsParamTable> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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
        public int Create(clsParamTable objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsParamTable objIns, string idColumnName, string id)
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

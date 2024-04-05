using CRM.Models;
using CRM.Models.EzUsers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.EzUsers;

namespace CRM.DAL.EzUsers
{
    public class clsUsersDAL
    {
        string tableName = "Users";
        IDataAccess<clsUsers> dataAccess = new clsDataAccessHelperWithoutCompany<clsUsers>();
        public List<clsUsers> GetAll()
        {
            List<clsUsers> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsUsers ReadSingle(string idColumnName, string Id)
        {
            clsUsers lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsUsers> GetByIdList(string idColumnName, string Id)
        {

            List<clsUsers> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "LoginUserName", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(clsUsers objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsUsers objIns, string idColumnName, string id)
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

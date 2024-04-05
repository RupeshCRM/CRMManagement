using CRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.EzUsers;
namespace CRM.DAL.EzUsers
{
    public class clsUserWorkflowRightsDAL
    {
        string tableName = "UserWorkflowRights";
        IDataAccess<clsUserWorkflowRights> dataAccess = new clsDataAccessHelperWithoutCompany<clsUserWorkflowRights>();

        public List<clsUserWorkflowRights> GetAll()
        {
            List<clsUserWorkflowRights> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsUserWorkflowRights ReadSingle(string idColumnName, string Id)
        {
            clsUserWorkflowRights lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsUserWorkflowRights> GetByIdList(string idColumnName, string Id)
        {

            List<clsUserWorkflowRights> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }
        public List<clsUserWorkflowRights> GetByIdList_Admin(string Id, string idColumnName = "LoginUserName")
        {

            List<clsUserWorkflowRights> lst = dataAccess.GetByIdList(Id, "uVw_Users", idColumnName);
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

        public int Create(clsUserWorkflowRights objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsUserWorkflowRights objIns, string idColumnName, string id)
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

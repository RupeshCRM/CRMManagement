using CRM.DAL;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL.EzUsers;
using CRM.Models.EzUsers;

namespace CRM.BAL.EzUsers
{
    public class clsUserWorkflowRightsBAL
    {

        private clsUserWorkflowRightsDAL dataAccessLayer = new DAL.EzUsers.clsUserWorkflowRightsDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsUserWorkflowRights> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsUserWorkflowRights ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("LoginUserName", Id);
        }

        public List<clsUserWorkflowRights> GetByIdList(string Id, string ColumnName = "LoginUserName")
        {

            List<clsUserWorkflowRights> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
            return lst;
        }
        public List<clsUserWorkflowRights> GetByIdList_Admin(string Id, string ColumnName = "LoginUserName")
        {
            List<clsUserWorkflowRights> lst = dataAccessLayer.GetByIdList_Admin(Id, ColumnName);
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

        public int Insert(clsUserWorkflowRights objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public int Insert(object objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsUserWorkflowRights objIns, string id, string idColumnName = "LoginUserName")
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

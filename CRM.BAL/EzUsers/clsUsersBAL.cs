using CRM.DAL;
using CRM.DAL.EzUsers;
using CRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.BAL.EzUsers;
using CRM.Models.EzUsers;

namespace CRM.BAL.EzUsers
{
    public class clsUsersBAL
    {

        private clsUsersDAL dataAccessLayer = new DAL.EzUsers.clsUsersDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsUsers> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsUsers ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("LoginUserName", Id);
        }

        public List<clsUsers> GetByIdList(string Id, string ColumnName = "LoginUserName")
        {

            List<clsUsers> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsUsers objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsUsers objIns, string id, string idColumnName = "LoginUserName")
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string id, string idColumnName = "LoginUserName")
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

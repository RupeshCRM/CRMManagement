using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using EZMasterSetup;
using CRM.DAL.CRM;
using System.Data;

namespace CRM.BAL.CRM
{
    public class clsCRMUserMasterBAL
    {
        private clsCRMUserMasterDAL dataAccessLayer = new DAL.CRM.clsCRMUserMasterDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMUserMaster> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMUserMaster ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("EmployeeID", Id);
        }

        public List<clsCRMUserMaster> GetByIdList(string Id, string ColumnName = "EmployeeID")
        {

            List<clsCRMUserMaster> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsCRMUserMaster objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMUserMaster objIns, string id, string idColumnName = "EmployeeID")
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string id, string idColumnName = "EmployeeID")
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

using CRM.DAL.EzSystem;
using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BAL.EzSystem
{
    public class clsEzLookUpMasterBAL
    {
        private clsEzLookUpMasterDAL dataAccessLayer = new DAL.EzSystem.clsEzLookUpMasterDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsEzLookUpMaster> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsEzLookUpMaster ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsEzLookUpMaster> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsEzLookUpMaster> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsEzLookUpMaster objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public int Insert(object objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsEzLookUpMaster objIns, string idColumnName, string id)
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
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

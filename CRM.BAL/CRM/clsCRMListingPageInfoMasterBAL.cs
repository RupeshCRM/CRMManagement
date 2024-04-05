using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL.CRM;
using CRM.Models.CRM;

namespace CRM.BAL.CRM
{
    public class clsCRMListingPageInfoMasterBAL
    {
        private clsCRMListingPageInfoMasterDAL dataAccessLayer = new DAL.CRM.clsCRMListingPageInfoMasterDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMListingPageInfoMaster> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMListingPageInfoMaster ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsCRMListingPageInfoMaster> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsCRMListingPageInfoMaster> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsCRMListingPageInfoMaster objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMListingPageInfoMaster objIns, string id, string idColumnName = "Code")
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string id, string idColumnName = "Code")
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;
using CRM.DAL.CRM;
using System.Data;
using EZMasterSetup;

namespace CRM.BAL.CRM
{
    public class clsCRMContactInformationMasterBAL
    {
        private clsCRMContactInformationMasterDAL dataAccessLayer = new DAL.CRM.clsCRMContactInformationMasterDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMContactInformationMaster> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMContactInformationMaster ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsCRMContactInformationMaster> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsCRMContactInformationMaster> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsCRMContactInformationMaster objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMContactInformationMaster objIns, string id, string idColumnName = "Code")
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

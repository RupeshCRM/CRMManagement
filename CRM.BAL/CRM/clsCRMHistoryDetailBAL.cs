using CRM.DAL.CRM;
using CRM.Models.CRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BAL.CRM
{
    public class clsCRMHistoryDetailBAL
    {
         private clsCRMHistoryDetailDAL dataAccessLayer = new DAL.CRM.clsCRMHistoryDetailDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMHistoryDetail> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMHistoryDetail ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("HistoryRef", Id);
        }

        public List<clsCRMHistoryDetail> GetByIdList(string Id, string ColumnName = "HistoryRef")
        {

            List<clsCRMHistoryDetail> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsCRMHistoryDetail objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMHistoryDetail objIns, string id, string idColumnName = "HistoryRef")
        {
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string id, string idColumnName = "HistoryRef")
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

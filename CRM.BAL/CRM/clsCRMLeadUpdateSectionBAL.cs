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
    public class clsCRMLeadUpdateSectionBAL
    {
        private clsCRMLeadUpdateSectionDAL dataAccessLayer = new DAL.CRM.clsCRMLeadUpdateSectionDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsCRMLeadUpdateSection> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsCRMLeadUpdateSection ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsCRMLeadUpdateSection> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsCRMLeadUpdateSection> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsCRMLeadUpdateSection objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCRMLeadUpdateSection objIns, string id, string idColumnName = "Code")
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

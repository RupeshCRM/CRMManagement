using CRM.DAL.Configuration;
using CRM.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.BAL.Configuration
{
    public class clsParamTableBAL
    {
        private clsParamTableDAL dataAccessLayer = new DAL.Configuration.clsParamTableDAL();
        public bool blnCompanyFilter { get; set; } = true;
        public string ColumnName { get; set; }
        public List<clsParamTable> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsParamTable ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public List<clsParamTable> GetByIdList(string Id, string ColumnName = "Code")
        {

            List<clsParamTable> lst = dataAccessLayer.GetByIdList(ColumnName, Id);
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

        public int Insert(clsParamTable objIns)
        {
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsParamTable objIns, string id, string idColumnName = "Code")
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

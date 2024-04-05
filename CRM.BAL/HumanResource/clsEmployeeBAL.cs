using CRM.DAL.HumanResource;
using CRM.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.BAL.HumanResource
{
    public class clsEmployeeBAL
    {
        private clsEmployeeDAL dataAccessLayer = new DAL.HumanResource.clsEmployeeDAL();

        public List<clsEmployee> GetAll()
        {
            return dataAccessLayer.GetAll();
        }

        public clsEmployee ReadSingle(string Id)
        {
            return dataAccessLayer.ReadSingle("EmpCode", Id);
        }

        public List<clsEmployee> GetByIdList(string Id)
        {
            List<clsEmployee> lst = dataAccessLayer.GetByIdList("EmpCode", Id);
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

        public int Insert(clsEmployee objIns)
        {
            return dataAccessLayer.Create(objIns);
        }

        public void Update(clsEmployee objIns, string idColumnName, string id)
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

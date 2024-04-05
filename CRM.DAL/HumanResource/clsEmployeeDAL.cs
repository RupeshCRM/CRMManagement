using CRM.Models.HumanResource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.HumanResource
{
    public class clsEmployeeDAL
    {
        string tableName = "Employee";
        IDataAccess<clsEmployee> dataAccess = new clsDataAccessHelper<clsEmployee>();
        //IDataAccess<clsLeaveApplicationVM> dataAccessDisplay = new clsDataAccessHelper<clsLeaveApplicationVM>();
        public List<clsEmployee> GetAll()
        {
            List<clsEmployee> lst = dataAccess.ReadAll(tableName);
            return lst;
        }
        //public List<clsLeaveApplicationVM> ReadAll()
        //{
        //    List<clsLeaveApplicationVM> lst = dataAccessDisplay.ReadAll("");
        //    return lst;
        //}

        public clsEmployee ReadSingle(string idColumnName, string Id)
        {
            clsEmployee lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsEmployee> GetByIdList(string idColumnName, string Id)
        {
            List<clsEmployee> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "EmpCode", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(clsEmployee objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }

        public void Update(clsEmployee objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
        public DataSet GetAllData_DataSet(string idColumnName, string id)
        {
            return (dataAccess.GetAllData_DataSet(tableName, idColumnName, id));
        }
        public DataTable GetAllData_DataTable(string idColumnName, string id)
        {
            return (dataAccess.GetAllData_DataTable(tableName, idColumnName, id));
        }
    }
}

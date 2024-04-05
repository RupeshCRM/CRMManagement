using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;

namespace CRM.DAL.CRM
{
    public class clsCRMLeadUpdateSectionDAL
    {
        string tableName = "CRMLeadUpdateSection";
        IDataAccess<clsCRMLeadUpdateSection> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMLeadUpdateSection>();
        public List<clsCRMLeadUpdateSection> GetAll()
        {
            List<clsCRMLeadUpdateSection> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMLeadUpdateSection ReadSingle(string idColumnName, string Id)
        {
            clsCRMLeadUpdateSection lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMLeadUpdateSection> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMLeadUpdateSection> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
            return lst;
        }

        public void Delete(string id)
        {
            dataAccess.Delete(tableName, "Code", id);
        }

        public void DeleteAll()
        {
            dataAccess.DeleteAll(tableName);
        }

        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(clsCRMLeadUpdateSection objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMLeadUpdateSection objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
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

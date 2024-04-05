using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;

namespace CRM.DAL.CRM
{
    public class clsCRMListingPageInfoMasterDAL
    {

        string tableName = "CRMListingPageInfoMaster";
        IDataAccess<clsCRMListingPageInfoMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMListingPageInfoMaster>();
        public List<clsCRMListingPageInfoMaster> GetAll()
        {
            List<clsCRMListingPageInfoMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMListingPageInfoMaster ReadSingle(string idColumnName, string Id)
        {
            clsCRMListingPageInfoMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMListingPageInfoMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMListingPageInfoMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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
        public int Create(clsCRMListingPageInfoMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMListingPageInfoMaster objIns, string idColumnName, string id)
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



using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.CRM;

namespace CRM.DAL.CRM
{
    public class clsCRMListingLeadCaptureMasterDAL
    {
        string tableName = "CRMListingLeadCaptureMaster";
        IDataAccess<clsCRMListingLeadCaptureMaster> dataAccess = new clsDataAccessHelperWithoutCompany<clsCRMListingLeadCaptureMaster>();
        public List<clsCRMListingLeadCaptureMaster> GetAll()
        {
            List<clsCRMListingLeadCaptureMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCRMListingLeadCaptureMaster ReadSingle(string idColumnName, string Id)
        {
            clsCRMListingLeadCaptureMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
            return lst;
        }

        public List<clsCRMListingLeadCaptureMaster> GetByIdList(string idColumnName, string Id)
        {

            List<clsCRMListingLeadCaptureMaster> lst = dataAccess.GetByIdList(Id, tableName, idColumnName);
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
        public int Create(clsCRMListingLeadCaptureMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCRMListingLeadCaptureMaster objIns, string idColumnName, string id)
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

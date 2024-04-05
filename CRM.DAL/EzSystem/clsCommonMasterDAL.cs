using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.EzSystem;

namespace CRM.DAL.EzSystem
{
    public class clsCommonMasterDAL
    {
        public string tableName= "EzCommonMaster";
        

        IDataAccess<clsCommonMaster> dataAccess = new clsDataAccessHelper<clsCommonMaster>();

        public List<clsCommonMaster> GetAll()
        {
            List<clsCommonMaster> lst = dataAccess.ReadAll(tableName);
            return lst;
        }

        public clsCommonMaster ReadSingle(string idColumnName, string Id)
        {
            clsCommonMaster lst = dataAccess.ReadSingle(tableName, idColumnName, Id);
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

        public int Create(clsCommonMaster objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public int Create(object objIns)
        {
            return dataAccess.Create(objIns, tableName);
        }
        public void Update(clsCommonMaster objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
        {
            dataAccess.Update(objIns, tableName, idColumnName, id);
        }
    }
}

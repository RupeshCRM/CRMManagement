using CRM.DAL.EzSystem;
using CRM.Models.EzSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BAL.EzSystem
{
    public  class clsCommonMasterBAL
    {
        public string tableName { get; set; }

        private clsCommonMasterDAL dataAccessLayer = new clsCommonMasterDAL();

        public List<clsCommonMaster> GetAll()
        {
            // dataAccessLayer.tableName = tableName;
            return dataAccessLayer.GetAll();
        }

        public clsCommonMaster ReadSingle(string Id)
        {
            // dataAccessLayer.tableName = tableName;
            return dataAccessLayer.ReadSingle("Code", Id);
        }

        public void Delete(string id)
        {
            // dataAccessLayer.tableName = tableName;
            dataAccessLayer.Delete(id);
        }

        public void DeleteAll()
        {
            dataAccessLayer.DeleteAll();
        }

        public int Insert(clsCommonMaster objIns)
        {
            // dataAccessLayer.tableName = tableName;
            return dataAccessLayer.Create(objIns);
        }
        public int Insert(object objIns)
        {
            // dataAccessLayer.tableName = tableName;
            return dataAccessLayer.Create(objIns);
        }
        public void Update(clsCommonMaster objIns, string idColumnName, string id)
        {
            // dataAccessLayer.tableName = tableName;
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
        public void Update(object objIns, string idColumnName, string id)
        {
            // dataAccessLayer.tableName = tableName;
            dataAccessLayer.Update(objIns, idColumnName, id);
        }
    }

}

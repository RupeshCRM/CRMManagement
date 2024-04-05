using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL
{
    public interface IDataAccess<T>
    {
        
        int Create(T record, string tableName);
        int Create(object record, string tableName);
        List<T> ReadAll(string tableName);
        T ReadSingle(string tableName, string idColumnName, string Id);
        List<T> FillDropdown(string tableName, string CodeColumn, string DescriptionColumn, string condition, Boolean chkCompanyFlag = true);
        void Update(T record, string tableName, string idColumnName, string id);
        void Update(object record, string tableName, string idColumnName, string id);
        void Delete(string tableName, string idColumnName, string id);
        T GetById(int id, string tableName, string idColumnName, string OrderByColumnName = "");
        List<T> GetByIdList(string id, string tableName, string idColumnName, string OrderByColumnName = "");
        List<TResult> ExecuteQuery<TResult>(string query) where TResult : new();
        void DeleteAll(string tableName);
        DataTable GetAllData_DataTable(string tableName, string idColumnName, string Id);
        DataSet GetAllData_DataSet(string tableName, string idColumnName, string Id);
        DataTable GetDataByQuery(string QueryString);

    }
}

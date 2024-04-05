using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Data.OleDb;
using EZMasterSetup;
using System.IO;

namespace CRM.DAL
{
    public class clsDataAccessHelper<T> : IDataAccess<T> where T : new()
    {
        private string connectionString;
        public bool blnCompanyFilter { get; set; } = true;
        public clsDataAccessHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString; // Replace fileDSNPath with the appropriate connection string
                                                                                                          //connectionString = ConfigurationManager.ConnectionStrings["EMCCDB"].ConnectionString;

        }

        public T GetById(int id, string tableName, string idColumnName, string OrderByColumnName = "")
        {
            T record = new T();
            string query = "";
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    if (string.IsNullOrWhiteSpace(OrderByColumnName))
                    {
                        query = $"SELECT * FROM {tableName} WHERE CmpyCode=? and {idColumnName} = ?";
                    }
                    else
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ? ORDER BY {OrderByColumnName}";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CmpyCode", GlobalVariable.CmpyCode);
                        command.Parameters.AddWithValue("@ID", id);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                foreach (PropertyInfo prop in typeof(T).GetProperties())
                                {
                                    object value = reader[prop.Name];

                                    if (!Convert.IsDBNull(value))
                                    {
                                        if (prop.PropertyType == typeof(int))
                                        {
                                            prop.SetValue(record, Convert.ToInt32(value));
                                        }
                                        else if (prop.PropertyType == typeof(string))
                                        {
                                            prop.SetValue(record, Convert.ToString(value));
                                        }
                                        else if (prop.PropertyType == typeof(double))
                                        {
                                            prop.SetValue(record, Convert.ToDouble(value));
                                        }
                                        else if (prop.PropertyType == typeof(DateTime))
                                        {
                                            prop.SetValue(record, Convert.ToDateTime(value));
                                        }
                                        else if (prop.PropertyType == typeof(decimal))
                                        {
                                            prop.SetValue(record, Convert.ToDecimal(value));
                                        }
                                        else if (prop.PropertyType == typeof(long))
                                        {
                                            prop.SetValue(record, Convert.ToInt64(value));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return record;
        }

        public List<T> GetByIdList(string id, string tableName, string idColumnName, string OrderByColumnName = "")
        {
            List<T> records = new List<T>();
            string query = "";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                if (string.IsNullOrWhiteSpace(OrderByColumnName))
                {
                    if (blnCompanyFilter == true)
                    {
                        query = $"SELECT * FROM {tableName} WHERE cmpycode=? and {idColumnName} = ?";
                    }
                    else
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ?";
                    }
                }
                else
                {
                    if (blnCompanyFilter == true)
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ? ORDER BY {OrderByColumnName}";
                    }
                    else
                    {
                        query = $"SELECT * FROM {tableName} WHERE cmpycode=? and {idColumnName} = ? ORDER BY {OrderByColumnName}";
                    }
                }

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CmpyCode", GlobalVariable.CmpyCode);
                    command.Parameters.AddWithValue("@ID", id);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = new T();
                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                object value = reader[prop.Name];

                                if (!Convert.IsDBNull(value))
                                {
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        prop.SetValue(record, Convert.ToInt32(value));
                                    }
                                    else if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(record, Convert.ToString(value));
                                    }
                                    else if (prop.PropertyType == typeof(double))
                                    {
                                        prop.SetValue(record, Convert.ToDouble(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        prop.SetValue(record, Convert.ToDecimal(value));
                                    }
                                    else if (prop.PropertyType == typeof(long))
                                    {
                                        prop.SetValue(record, Convert.ToInt64(value));
                                    }
                                }
                            }

                            records.Add(record);
                        }
                    }
                }
            }
            return records;
        }


        public bool IsIdentityField(PropertyInfo propertyInfo, string tableName)
        {
            // Implement the logic to determine if a property is an identity field in the specified table
            // You may need to retrieve this information from the database schema
            return false; // Replace with your implementation
        }

        public string GetIdentityColumnFromSchema(string tableName)
        {
            // Implement the logic to retrieve the identity column name for the specified table from the database schema
            return ""; // Replace with your implementation
        }



        public int Create(T record, string tableName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string columns = string.Join(", ", typeof(T).GetProperties()
                        .Where(p => !IsIdentityField(p, tableName))
                        .Select(p => p.Name));
                    string values = string.Join(", ", typeof(T).GetProperties()
                        .Where(p => !IsIdentityField(p, tableName))
                        .Select(p => "?"));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        foreach (var prop in typeof(T).GetProperties().Where(p => !IsIdentityField(p, tableName)))
                        {
                            if (prop.PropertyType == typeof(string) && prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, "");
                            }
                            else if (prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                            }
                            else
                            {
                                if (prop.PropertyType == typeof(DateTime) && (DateTime)prop.GetValue(record) == DateTime.MinValue)
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                                }
                                else if (prop.PropertyType == typeof(bool))
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record));
                                }
                               else if (prop.PropertyType == typeof(Byte[]))
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record));
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record).ToString().Trim());
                                }
                            }
                        }

                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT @@IDENTITY";
                        int newId = 1;//Convert.ToInt32(command.ExecuteScalar());

                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public int Create(object record, string tableName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string columns = string.Join(", ", record.GetType().GetProperties()
                        .Where(p => !IsIdentityField(p, tableName))
                        .Select(p => p.Name));
                    string values = string.Join(", ", record.GetType().GetProperties()
                        .Where(p => !IsIdentityField(p, tableName))
                        .Select(p => "?"));

                    string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        foreach (var prop in record.GetType().GetProperties().Where(p => !IsIdentityField(p, tableName)))
                        {
                            if (prop.PropertyType == typeof(string) && prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, "");
                            }
                            else if (prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                            }
                            else
                            {
                                if (prop.PropertyType == typeof(DateTime) && (DateTime)prop.GetValue(record) == DateTime.MinValue)
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                                }
                                else if (prop.PropertyType == typeof(bool))
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record));
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record).ToString().Trim());
                                }
                            }
                        }

                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT @@IDENTITY";
                        int newId = Convert.ToInt32(command.ExecuteScalar());

                        return newId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public List<T> ReadAll(string tableName)
        {
            List<T> records = new List<T>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "";
                //bool columnExists = CheckColumnExists(tableName, "CmpyCode", connection);

               
                    query = $"SELECT * FROM {tableName} where CmpyCode='" + GlobalVariable.CmpyCode + "'  ";
               

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = new T();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {

                                object value = reader[prop.Name];

                                if (!Convert.IsDBNull(value))
                                {
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        prop.SetValue(record, Convert.ToInt32(value));
                                    }
                                    else if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(record, Convert.ToString(value));
                                    }
                                    else if (prop.PropertyType == typeof(double))
                                    {
                                        prop.SetValue(record, Convert.ToDouble(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        prop.SetValue(record, Convert.ToDecimal(value));
                                    }
                                    else if (prop.PropertyType == typeof(long))
                                    {
                                        prop.SetValue(record, Convert.ToInt64(value));
                                    }
                                }
                            }

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }

        public T ReadSingle(string tableName, string idColumnName, string Id)
        {
            T records = new T();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} where CmpyCode='" + GlobalVariable.CmpyCode + "'  and " + idColumnName + "='" + Id + "'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = new T();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                object value = reader[prop.Name];

                                if (!Convert.IsDBNull(value))
                                {
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        prop.SetValue(record, Convert.ToInt32(value));
                                    }
                                    else if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(record, Convert.ToString(value));
                                    }
                                    else if (prop.PropertyType == typeof(double))
                                    {
                                        prop.SetValue(record, Convert.ToDouble(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        prop.SetValue(record, Convert.ToDecimal(value));
                                    }
                                    else if (prop.PropertyType == typeof(long))
                                    {
                                        prop.SetValue(record, Convert.ToInt64(value));
                                    }
                                   
                                }
                            }

                            records = record;
                        }
                    }
                }
            }

            return records;
        }

        public List<T> ReadFromDetail(string tableName, string idColumnName, string Id)
        {
            List<T> records = new List<T>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} where CmpyCode='" + GlobalVariable.CmpyCode + "'  and " + idColumnName + "='" + Id + "'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = new T();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                object value = reader[prop.Name];

                                if (!Convert.IsDBNull(value))
                                {
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        prop.SetValue(record, Convert.ToInt32(value));
                                    }
                                    else if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(record, Convert.ToString(value));
                                    }
                                    else if (prop.PropertyType == typeof(double))
                                    {
                                        prop.SetValue(record, Convert.ToDouble(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        prop.SetValue(record, Convert.ToDecimal(value));
                                    }
                                    else if (prop.PropertyType == typeof(long))
                                    {
                                        prop.SetValue(record, Convert.ToInt64(value));
                                    }
                                }
                            }

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }

        public void Update(T record, string tableName, string idColumnName, string id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string updateValues = string.Join(", ", typeof(T).GetProperties()
                        .Where(p => p.Name != idColumnName)
                        .Select(p => $"{p.Name} = ?"));

                    string query = $"UPDATE {tableName} SET {updateValues} WHERE {idColumnName} = ? and CmpyCode='" + GlobalVariable.CmpyCode + "'";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        foreach (var prop in typeof(T).GetProperties().Where(p => p.Name != idColumnName))
                        {
                            if (prop.PropertyType == typeof(DateTime) && (DateTime)prop.GetValue(record) == DateTime.MinValue)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                            }
                            else if (prop.PropertyType == typeof(bool))
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record));
                            }
                            else if (prop.PropertyType == typeof(string) && prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, "");
                            }
                            else
                            {
                                if (prop.GetValue(record) != null)
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record).ToString().Trim());
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                                }
                            }
                        }

                        command.Parameters.AddWithValue("@" + idColumnName, id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Update(object record, string tableName, string idColumnName, string id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string updateValues = string.Join(", ", typeof(T).GetProperties()
                        .Where(p => p.Name != idColumnName)
                        .Select(p => $"{p.Name} = ?"));

                    string query = $"UPDATE {tableName} SET {updateValues} WHERE {idColumnName} = ? and CmpyCode='" + GlobalVariable.CmpyCode + "'";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        foreach (var prop in typeof(T).GetProperties().Where(p => p.Name != idColumnName))
                        {
                            if (prop.PropertyType == typeof(DateTime) && (DateTime)prop.GetValue(record) == DateTime.MinValue)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                            }
                            else if (prop.PropertyType == typeof(bool))
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record));
                            }
                            else if (prop.PropertyType == typeof(string) && prop.GetValue(record) == null)
                            {
                                command.Parameters.AddWithValue("@" + prop.Name, "");
                            }
                            else
                            {
                                if (prop.GetValue(record) != null)
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(record).ToString().Trim());
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@" + prop.Name, DBNull.Value);
                                }
                            }
                        }

                        command.Parameters.AddWithValue("@" + idColumnName, id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(string tableName, string idColumnName, string id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM  {tableName}  WHERE {idColumnName} = ? and CmpyCode='" + GlobalVariable.CmpyCode + "' ";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        //command.Parameters.AddWithValue("@{idColumnName}", id);
                        command.Parameters.AddWithValue($"@{idColumnName}", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<TResult> ExecuteQuery<TResult>(string query) where TResult : new()
        {
            List<TResult> results = new List<TResult>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TResult result = new TResult();

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string fieldName = reader.GetName(i);
                                PropertyInfo prop = typeof(TResult).GetProperty(fieldName);

                                if (prop != null && !reader.IsDBNull(i))
                                {
                                    prop.SetValue(result, reader[i]);
                                }
                            }

                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }

        public void DeleteAll(string tableName)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = $"DELETE FROM {tableName}";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        public DataTable GetDataByQuery(string QueryString)
        {
            DataTable dataTable = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(QueryString, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        public DataSet GetAllData_DataSet(string tableName, string idColumnName, string Id)
        {
            DataSet ds = new DataSet();
            string query = "";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                query = $"SELECT * FROM {tableName} where CmpyCode='" + GlobalVariable.CmpyCode + "'  and " + idColumnName + "='" + Id + "'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@tripid", TRIP_ID);
                    using (OleDbDataAdapter da = new OleDbDataAdapter(command))
                    {
                        da.Fill(ds, tableName);
                    }
                }
            }

            return ds;
        }

        public DataTable GetAllData_DataTable(string tableName, string idColumnName, string Id)
        {
            DataTable dataTable = new DataTable();
            string query = "";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                query = $"SELECT * FROM {tableName} where CmpyCode='" + GlobalVariable.CmpyCode + "'  and " + idColumnName + "='" + Id + "'";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        public List<T> FillDropdown(string tableName, string Code, string Description, string condition, Boolean chkCompanyFlag = true)
        {
            List<T> records = new List<T>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {Code},{Description} FROM {tableName} where ";
                if (chkCompanyFlag == true)
                {
                    query = query + " CmpyCode = '" + GlobalVariable.CmpyCode + "' ";
                }
                if (condition != "" && chkCompanyFlag == true)
                {
                    query = query + " and " + condition;
                }
                else
                {
                    query = query + " " + condition;
                }

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T record = new T();

                            foreach (PropertyInfo prop in typeof(T).GetProperties())
                            {
                                object value = reader[prop.Name];

                                if (!Convert.IsDBNull(value))
                                {
                                    if (prop.PropertyType == typeof(int))
                                    {
                                        prop.SetValue(record, Convert.ToInt32(value));
                                    }
                                    else if (prop.PropertyType == typeof(string))
                                    {
                                        prop.SetValue(record, Convert.ToString(value));
                                    }
                                    else if (prop.PropertyType == typeof(double))
                                    {
                                        prop.SetValue(record, Convert.ToDouble(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(DateTime))
                                    {
                                        prop.SetValue(record, Convert.ToDateTime(value));
                                    }
                                    else if (prop.PropertyType == typeof(decimal))
                                    {
                                        prop.SetValue(record, Convert.ToDecimal(value));
                                    }
                                    else if (prop.PropertyType == typeof(long))
                                    {
                                        prop.SetValue(record, Convert.ToInt64(value));
                                    }
                                }
                            }

                            records.Add(record);
                        }
                    }
                }
            }

            return records;
        }

    }
}

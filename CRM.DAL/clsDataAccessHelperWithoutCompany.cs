using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using EZMasterSetup;
namespace CRM.DAL
{
    
   public class clsDataAccessHelperWithoutCompany<T> : IDataAccess<T> where T : new()
       {
        private string connectionString;
        public bool blnCompanyFilter { get; set; } = true;
        public clsDataAccessHelperWithoutCompany()
        {
             connectionString = ConfigurationManager.ConnectionStrings["myDbConnection"].ConnectionString;
           // connectionString = connectionString;// GlobalVariable.fileDSNPath; // Replace fileDSNPath with the appropriate connection string
                                                           //connectionString = ConfigurationManager.ConnectionStrings["EMCCDB"].ConnectionString;

        }

        //public T GetById(int id, string tableName, string idColumnName, string OrderByColumnName = "")
        //{
        //    T record = new T();
        //    string query = "";
        //    try
        //    {
        //        using (OleDbConnection connection = new OleDbConnection(connectionString))
        //        {
        //            connection.Open();

        //            if (string.IsNullOrWhiteSpace(OrderByColumnName))
        //            {
        //                query = $"SELECT * FROM {tableName} WHERE CmpyCode='" + GlobalVariable.CmpyCode + "' and  {idColumnName} = ?";
        //            }
        //            else
        //            {
        //                query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ? ORDER BY {OrderByColumnName}";
        //            }

        //            using (OleDbCommand command = new OleDbCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@ID", id);

        //                using (OleDbDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        foreach (PropertyInfo prop in typeof(T).GetProperties())
        //                        {
        //                            object value = reader[prop.Name];

        //                            if (!Convert.IsDBNull(value))
        //                            {
        //                                if (prop.PropertyType == typeof(int))
        //                                {
        //                                    prop.SetValue(record, Convert.ToInt32(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(string))
        //                                {
        //                                    prop.SetValue(record, Convert.ToString(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(double))
        //                                {
        //                                    prop.SetValue(record, Convert.ToDouble(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(DateTime))
        //                                {
        //                                    prop.SetValue(record, Convert.ToDateTime(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(DateTime))
        //                                {
        //                                    prop.SetValue(record, Convert.ToDateTime(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(decimal))
        //                                {
        //                                    prop.SetValue(record, Convert.ToDecimal(value));
        //                                }
        //                                else if (prop.PropertyType == typeof(long))
        //                                {
        //                                    prop.SetValue(record, Convert.ToInt64(value));
        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return default(T);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return record;
        //}
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
                        query = $"SELECT * FROM {tableName} WHERE CmpyCode=@CmpyCode AND {idColumnName} = ?";
                    }
                    else
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ? ORDER BY {OrderByColumnName}";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@CmpyCode", GlobalVariable.CmpyCode);

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
            try
            {
                List<T> records = new List<T>();
                string query = "";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    if (string.IsNullOrWhiteSpace(OrderByColumnName))
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ?";
                    }
                    else
                    {
                        query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ? ORDER BY {OrderByColumnName}";
                    }

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
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
            catch (Exception ex)
            {
                throw;
            }
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

                    columns = ReplaceSpecialCharFields(tableName, columns);

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
                        /*command.CommandText = "SELECT @@IDENTITY";
                        int newId = Convert.ToInt32(command.ExecuteScalar());*/

                        return (1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        static bool CheckColumnExists(string tableName, string columnName, OleDbConnection connection)
        {
            using (OleDbCommand command = new OleDbCommand($"SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' AND COLUMN_NAME = '{columnName}'", connection))
            {
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }


            }
        }
        public List<T> ReadAll(string tableName)
        {
            List<T> records = new List<T>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName}";

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

                string query = $"SELECT * FROM {tableName} WHERE {idColumnName} = ?";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", Id);

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

                string query = $"SELECT * FROM {tableName} WHERE {idColumnName} = @Id";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", Id);

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

                    string query = $"UPDATE {tableName} SET {updateValues} WHERE {idColumnName} = ? ";

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

                    string updateValues = string.Join(", ", record.GetType().GetProperties()
                        .Where(p => p.Name != idColumnName)
                        .Select(p => $"{p.Name} = ?"));

                    string query = $"UPDATE {tableName} SET {updateValues} WHERE {idColumnName} = ? ";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        foreach (var prop in record.GetType().GetProperties().Where(p => p.Name != idColumnName))
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
                    string query = $"DELETE FROM  {tableName}  WHERE {idColumnName} = ?  ";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
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

        public DataTable GetAllData(string tableName)
        {
            DataTable dataTable = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} ";

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

                query = $"SELECT * FROM {tableName} where " + idColumnName + "='" + Id + "'";

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


                query = $"SELECT * FROM {tableName} where " + idColumnName + "='" + Id + "'";


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

        private string ReplaceSpecialCharFields(string tableName, string cols)
        {
            switch (tableName)
            {
                case "CustomerServiceAgreementsTable":
                    return cols.Replace("BW_ALLOWED", "[B&W_ALLOWED]").Replace("BW_OVERAGES", "[B&W_OVERAGES]");
                default:
                    return cols;
            }
        }

        public List<T> FillDropdown(string tableName, string Code, string Description, string condition, bool chkCompanyFlag = true)
        {
            List<T> records = new List<T>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT {Code},{Description} FROM {tableName} where ";

                query = query + " " + condition;

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

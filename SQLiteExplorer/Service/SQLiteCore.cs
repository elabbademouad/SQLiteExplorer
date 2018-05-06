using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SQLiteExplorer.Resources.ScriptSQL;
using System.Data;
using System.IO;

namespace SQLiteExplorer.Service
{
    /// <summary>
    /// SQLite service 
    /// </summary>
    public static class SQLiteCore
    {
        /// <summary>
        /// Return list of tables names
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns></returns>
        public static DataTable GetTablesNames(string connectionString)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(SchemaInfos.GetTablesName, connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Return list of views names
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <returns></returns>
        public static DataTable GetViewsNames(string connectionString)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(SchemaInfos.GetVewsName, connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Return list of Triggers names
        /// </summary>
        /// <param name="connectionString">connection string</param>
        /// <returns></returns>
        public static DataTable GetTriggersNames(string connectionString)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(SchemaInfos.GetTriggersName, connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Return list of columns and description
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="tableName">table name</param>
        /// <returns></returns>
        public static DataTable GetCulumnsByTable(string connectionString,string tableName)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(string.Format(SchemaInfos.GetColumnsByTable,tableName), connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }

        /// <summary>
        /// Return list of index from table 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName">table name</param>
        /// <returns>list of index from table</returns>
        public static DataTable GetIndexByTable(string connectionString, string tableName)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(string.Format(SchemaInfos.GetIndexsByTable, tableName), connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }
        /// <summary>
        /// return foreign key from table
        /// </summary>
        /// <param name="connectionString">connection string</param>
        /// <param name="tableName">table name</param>
        /// <returns></returns>
        public static DataTable GetForeignKeysByTable(string connectionString, string tableName)
        {
            List<string> tablesNames = new List<string>();
            SQLiteDataAdapter sqliteDataAdapter = new SQLiteDataAdapter(string.Format(SchemaInfos.GetForeignkeysByTable, tableName), connectionString);
            DataTable dataTable = new DataTable();
            sqliteDataAdapter.Fill(dataTable);
            return dataTable;
        }
        /// <summary>
        /// return list paths of database
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDataBasesPaths()
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SqliteExplorer";
            var dataPath = rootPath + @"\AppData";
            var connctionString = string.Format("Data source={0};", dataPath);
            var pathsLis = new List<string>();
            if (Directory.Exists(rootPath))
            { 
                if (File.Exists(dataPath))
                {
                    using (var connectionAppData=new SQLiteConnection(connctionString))
                    {
                        
                        using (var command=new SQLiteCommand(connectionAppData))
                        {
                            try
                            {
                                connectionAppData.Open();
                                command.CommandText = "select * from History";
                                var dataReader = command.ExecuteReader();

                                while (dataReader.Read())
                                {
                                    string path = dataReader.GetString(0);
                                    pathsLis.Add(path);
                                }
                                connectionAppData.Close();
                                return pathsLis;
                            }
                            catch (Exception)
                            {
                                command.CommandText = "CREATE TABLE(History text);";
                                command.ExecuteNonQuery();
                                connectionAppData.Close();
                                return pathsLis;

                            }

                        }
                    }
                }
                else
                {
                    SQLiteConnection.CreateFile(dataPath);
                    using (var connection = new SQLiteConnection(connctionString))
                    {
                        connection.Open();
                        using (var command = new SQLiteCommand(connection))
                        {
                            command.CommandText = "CREATE TABLE(History text);";
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }
                    return pathsLis;
                }
            }
            else
            {
                Directory.CreateDirectory(rootPath);
                SQLiteConnection.CreateFile(dataPath);
                using (var connection = new SQLiteConnection(connctionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "CREATE TABLE History (History varchar primary key);";
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                return pathsLis;
            }
        }

        /// <summary>
        /// Add database to hostory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool AddDataBaseToHistory(string path)
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SqliteExplorer";
            var dataPath = rootPath + @"\AppData";
            var connctionString = string.Format("Data source={0};", dataPath);
            using (var connection = new SQLiteConnection(connctionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    try
                    {
                        command.CommandText = string.Format(SchemaInfos.AddDataBaseToHistory, path);
                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// remove database from history
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool RemoveDatabaseFromHistory(string path)
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SqliteExplorer";
            var dataPath = rootPath + @"\AppData";
            var connctionString = string.Format("Data source={0};", dataPath);
            using (var connection = new SQLiteConnection(connctionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    try
                    {
                        command.CommandText = string.Format(SchemaInfos.DeleteDataBaseFromaHistory, path);
                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                    catch (Exception)
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// check de file if it is a sqlite database
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static bool CheckConnection(string connectionString)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

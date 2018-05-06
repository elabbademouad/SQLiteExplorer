using SQLiteExplorer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SQLiteExplorer.Service
{
    public static class DataBaseBuilder
    {
        public static DataBaseViewModel BuildDataBaseObject(string path,ObjectExplorerViewModel objectExplorer)
        {
            string connectionString = string.Format("Data source= {0} ;", path);
            string fileName= path.Split('\\').Last().ToString();
            DataBaseViewModel dataBaseViewModel = new DataBaseViewModel(objectExplorer);
            dataBaseViewModel.Name = fileName;
            dataBaseViewModel.Path = path;
            var tables = SQLiteCore.GetTablesNames(connectionString);
            var views = SQLiteCore.GetViewsNames(connectionString);
            var triggers = SQLiteCore.GetTriggersNames(connectionString);
            //Create Tables
            foreach (DataRow tableRow in tables.Rows)
            {
                var table = new TableViewModel();
                table.Name = tableRow[0].ToString();
                var columns = SQLiteCore.GetCulumnsByTable(connectionString,table.Name);
                var indexs = SQLiteCore.GetIndexByTable(connectionString, table.Name);
                var foreignkeys = SQLiteCore.GetForeignKeysByTable(connectionString, table.Name);
                //Create ForeignKeys
                foreach (DataRow foreignKeyRow in foreignkeys.Rows)
                {
                    table.ForeignKeys.Add(new ForeignKeyViewModel()
                    {
                        Name= foreignKeyRow[3].ToString(),
                        Description= string.Format(" To {0}({1})" , foreignKeyRow[2].ToString(), foreignKeyRow[4].ToString())
                    });
                }
                //Create Columns
                foreach (DataRow columnRow in columns.Rows)
                {
                    var column = new ColumnViewModel();
                    column.Name = columnRow[1].ToString();
                    string description= string.Format(" {0} ", columnRow[2].ToString());
                    if (columnRow[3].ToString() != "0")
                        description += ", NOT Null ";
                    if (!columnRow.IsNull(4))
                        description += string.Format(",Default= {0}",columnRow[4].ToString());
                    if (columnRow[5].ToString() != "0")
                        column.IsPrimaryKey = true;
                    column.Description = description;
                    if (table.ForeignKeys.Where(e => e.Name==column.Name).Count() != 0)
                        column.IsForeignKey = true;
                    table.Columns.Add(column);
                }
                //Create Indexs
                foreach (DataRow indexRow in indexs.Rows)
                {
                    table.Indexs.Add(indexRow[1].ToString());
                }
                
                dataBaseViewModel.Tables.Add(table);
            }
            //Create Views
            foreach (DataRow viewRow in views.Rows)
            {
                dataBaseViewModel.Views.Add(
                    new ViewViewModel()
                    {
                        Name = viewRow[0].ToString()
                    }
                    );
            }
            //Create Triggers
            foreach (DataRow triggerRow in triggers.Rows)
            {
                dataBaseViewModel.Triggers.Add(
                    new TriggerViewModel()
                    {
                        Name = triggerRow[0].ToString(),
                        TableName = triggerRow[1].ToString()
                    });
            }

            return dataBaseViewModel;
        }
    }
}

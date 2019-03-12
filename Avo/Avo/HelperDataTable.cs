using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public class HelperDataTable
    {
        public static System.Data.DataTable MergeRowsToColumns(DataTable rowDataTable, string rowDataTableIdColumnName, string friendlyName, DataTable columData)
        {
            List<string> columnsToAdd = new List<string>();
            if (rowDataTable == null)
            {
                return null;
            }
            DataTable finalDataTable = new DataTable();
            finalDataTable.Columns.Add(friendlyName.ToLower());
            finalDataTable.Columns.Add(rowDataTableIdColumnName.ToLower());

            foreach (DataColumn column in columData.Columns)
            {
                if (column.ColumnName.ToString() == rowDataTableIdColumnName.ToString())
                {
                    continue;
                }
                else
                {
                    finalDataTable.Columns.Add(column.ColumnName.ToString());
                    columnsToAdd.Add(column.ColumnName.ToString());
                }
            }
            
            foreach (DataRow row in rowDataTable.Rows)
            {
                DataRow newRow = finalDataTable.NewRow();
                newRow[rowDataTableIdColumnName] = row[rowDataTableIdColumnName];
                newRow[friendlyName] = row[friendlyName];
                foreach (DataRow columnRows in columData.Rows)
                {

                    foreach (string column in columnsToAdd)
                    {
                        var value = columnRows[column].ToString();
                        newRow[column] = value; 
                    }
                }
                finalDataTable.Rows.Add(newRow);
            }
            return finalDataTable;
        }
    }
}

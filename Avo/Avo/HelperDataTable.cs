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
        public static System.Data.DataTable MergeRowsToColumns(DataTable rowDataTable, string rowDataTableIdColumnName, string friendlyName, DataTable dataAllValue , string dataColumnValue , string  dataColumnKey , bool IncludeTotal , string totalFriendlyName)
        {
            var ColumnKeyTotalName = "dataTableRowTotalForAllColumns";
            List<string> columnsToAdd = new List<string>();
            if (rowDataTable == null)
            {
                return null;
            }
            DataTable finalDataTable = new DataTable();
            finalDataTable.Columns.Add(friendlyName);
            finalDataTable.Columns.Add(rowDataTableIdColumnName);
            if (IncludeTotal)
            { 
                finalDataTable.Columns.Add(ColumnKeyTotalName);
            }
            foreach (DataRow row in dataAllValue.Rows)
            {
                if (row[rowDataTableIdColumnName].ToString() == rowDataTableIdColumnName.ToString())
                {
                    continue;
                }
                else
                {
                    var isExistColumnValue = columnsToAdd.Where(c => c == row[dataColumnKey].ToString()).FirstOrDefault();
                    if(isExistColumnValue == null)
                    {
                        columnsToAdd.Add(row[dataColumnKey].ToString());
                        finalDataTable.Columns.Add(row[dataColumnKey].ToString());
                    }
                }
            }
            
            foreach (DataRow row in rowDataTable.Rows)
            {
                DataRow newRow = finalDataTable.NewRow();
                newRow[rowDataTableIdColumnName] = row[rowDataTableIdColumnName];
                newRow[friendlyName] = row[friendlyName];

                decimal _total = 0;
                foreach (DataRow columnRows in dataAllValue.Rows)
                { 
                    if(row[rowDataTableIdColumnName].ToString() != columnRows[rowDataTableIdColumnName].ToString())
                    {
                        continue;
                    }
                    var columnName = columnRows[dataColumnKey].ToString();
                    var columnValue = columnRows[dataColumnValue].ToString();
                    newRow[columnName] = columnValue;

                    try
                    {
                        _total += decimal.Parse(columnValue);
                    }
                    catch (Exception)
                    {

                    }
                }
                if (IncludeTotal)
                {
                    newRow[ColumnKeyTotalName] = _total;
                }
                finalDataTable.Rows.Add(newRow);
            }
            if (IncludeTotal)
            {
                if (!string.IsNullOrEmpty(totalFriendlyName))
                {
                    if (!finalDataTable.Columns.Contains(totalFriendlyName))
                    {
                        finalDataTable.RenameColumn(ColumnKeyTotalName, totalFriendlyName);
                    }
                }
            }
            return finalDataTable;
        }

    }
}

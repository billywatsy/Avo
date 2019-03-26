using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionDataTable
    {
        public static bool IsColumnExist(this DataTable dataTable, string columnName)
        {
            if (dataTable.Columns.Contains(columnName))
            {
                return true;
            }
            return false;
        }
 
        private static decimal GetSumDataTableValue(this DataTable dataTable , string rowValueId, string columnKey, string columnValue)
        {
            if (dataTable == null) return 0;
            decimal value = 0; 
            if (dataTable.Columns.Contains(columnKey) && dataTable.Columns.Contains(columnValue))
            {
                if (dataTable != null)
                {
                    foreach (DataRow drRow in dataTable.Rows)
                    {
                        if (drRow[columnKey].ToString() == rowValueId)
                        {
                            value += decimal.Parse(drRow[columnValue].ToString());
                        }
                    }
                }
            }
            return value;
        }

        public static string GetRowColumnValue(this DataTable dataTable , int rowNumber , int columnNumber)
        {
            var value = dataTable.Rows[rowNumber][columnNumber].ToString();
            return value;
        }

        public static bool RemoveColumn(this DataTable dataTable , string columnName)
        {
            if (dataTable.Columns.Contains(columnName))
            {
                dataTable.Columns.Remove(columnName);
                return true;
            }
            return false;
        }

        public static bool RenameColumn(this DataTable dataTable , string oldName , string newName)
        {
            if (dataTable.Columns.Contains(oldName))
            {
                dataTable.Columns[oldName].ColumnName = newName;
                dataTable.AcceptChanges();
                return true;
            }
            return false;
        } 
        
        public static System.Data.DataTable RemoveDuplicateRows(this System.Data.DataTable dataTable, string columnName)
        {
            if (dataTable == null)
            {
                return null;
            }

            System.Collections.Hashtable hTable = new System.Collections.Hashtable();
            System.Collections.ArrayList duplicateList = new System.Collections.ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (System.Data.DataRow drow in dataTable.Rows)
            {
                if (hTable.Contains(drow[columnName]))
                {
                    duplicateList.Add(drow);
                }
                else
                {
                    hTable.Add(drow[columnName], string.Empty);
                } 
            }

            //Removing a list of duplicate items from datatable.
            foreach (System.Data.DataRow dRow in duplicateList)
            {
                dataTable.Rows.Remove(dRow);
            }

            //Datatable which contains unique records will be return as output.
            return dataTable;
        }

        public static string ToHtmlTable(this DataTable dt ,string tableCssClass)
        {
            if (dt == null)
            {
                return null;
            }
            string html = "<table class='"+ tableCssClass +"'>";
            //add header row
            html += "<thead>";
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html += "<th>" + dt.Columns[i].ColumnName + "</th>";
            }
            html += "</tr>";
            html += "</thead>";
            //add rows
            html += "<tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                { 
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            return html;
        }
    }
}

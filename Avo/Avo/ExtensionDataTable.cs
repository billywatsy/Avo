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

        public static decimal GetSumDataTableValue(this DataTable dataTable , string id, string columnKey, string columnValue )
        {
            if (dataTable == null) return 0;
            var value = 0M;
            if (dataTable.Columns.Contains(columnKey) && dataTable.Columns.Contains(columnValue))
            { 
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row[columnKey].ToString() == id)
                    {
                        value += decimal.Parse(row[columnValue].ToString());
                    }
                }
            }
            else
            {
                throw new Exception("Column Key or value name does not exist");
            }
            return value;
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
    }
}

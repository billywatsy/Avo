using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class ExtensionDataTable
    {
              
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    public static class Extension_DataTable
    {
        public static System.Data.DataTable RemoveDuplicateRows(this System.Data.DataTable dTable, string colName)
        {
            if (dTable == null)
            {
                return null;
            }

            System.Collections.Hashtable hTable = new System.Collections.Hashtable();
            System.Collections.ArrayList duplicateList = new System.Collections.ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (System.Data.DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                {
                    duplicateList.Add(drow);
                }
                else
                {
                    hTable.Add(drow[colName], string.Empty);
                } 
            }

            //Removing a list of duplicate items from datatable.
            foreach (System.Data.DataRow dRow in duplicateList)
            {
                dTable.Rows.Remove(dRow);
            }

            //Datatable which contains unique records will be return as output.
            return dTable;
        }
    }
}

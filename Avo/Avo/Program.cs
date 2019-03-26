using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtProduct = new DataTable();
            dtProduct.Columns.Add("productId");
            dtProduct.Columns.Add("name");

            DataRow dataRow = dtProduct.NewRow();
            dataRow["productId"] = 1;
            dataRow["name"] = "Burger";
            dtProduct.Rows.Add(dataRow);
            
            DataRow dataRow2 = dtProduct.NewRow();
            dataRow2["productId"] = 2;
            dataRow2["name"] = "Chicken";
            dtProduct.Rows.Add(dataRow2);

            DataTable dtSales = new DataTable();
            dtSales.Columns.Add("productId");
            dtSales.Columns.Add("saleId");
            dtSales.Columns.Add("month");
            dtSales.Columns.Add("quantity");

            DataRow dataSalesRow = dtSales.NewRow();
            dataSalesRow["productId"] = 1;
            dataSalesRow["saleId"] = "1";
            dataSalesRow["month"] = "Jan";
            dataSalesRow["quantity"] = 3433;
            dtSales.Rows.Add(dataSalesRow);


            DataRow drSales2 = dtSales.NewRow();
            drSales2["productId"] = 1;
            drSales2["saleId"] = "2";
            drSales2["month"] = "Feb"; 
            drSales2["quantity"] = 56; 
            dtSales.Rows.Add(drSales2);

            DataRow drSales3 = dtSales.NewRow();
            drSales3["productId"] = 1;
            drSales3["saleId"] = "3";
            drSales3["month"] = "Mar";
            drSales3["quantity"] = 34522;
            dtSales.Rows.Add(drSales3);


            DataRow drSales4 = dtSales.NewRow();
            drSales4["productId"] = 2;
            drSales4["saleId"] = "4";
            drSales4["month"] = "Feb";
            drSales4["quantity"] = 345;
            dtSales.Rows.Add(drSales4);
             
           
            DataTable dtStudents = new DataTable();
            dtStudents.Columns.Add("studentId");
            dtStudents.Columns.Add("fullname");

            DataRow drStudentrow = dtStudents.NewRow();
            drStudentrow["studentId"] = 1;
            drStudentrow["fullname"] = "Bil";
            dtStudents.Rows.Add(drStudentrow);
            
            DataRow drStudentrow2 = dtStudents.NewRow();
            drStudentrow2["studentId"] = 2;
            drStudentrow2["fullname"] = "Paul";
            dtStudents.Rows.Add(drStudentrow2);
             

            DataTable dtStudentExam = new DataTable();
            dtStudentExam.Columns.Add("studentId");
            dtStudentExam.Columns.Add("subjectId");
            dtStudentExam.Columns.Add("mark");

            DataRow dataStudentExamRow = dtStudentExam.NewRow();
            dataStudentExamRow["studentId"] = 1;
            dataStudentExamRow["subjectId"] = "E123";
            dataStudentExamRow["mark"] = 34;
            dtStudentExam.Rows.Add(dataStudentExamRow);

            DataRow dataStudentExamRow2 = dtStudentExam.NewRow();
            dataStudentExamRow2["studentId"] = 2;
            dataStudentExamRow2["subjectId"] = "E123";
            dataStudentExamRow2["mark"] = 90;
            dtStudentExam.Rows.Add(dataStudentExamRow2);

            DataRow dataStudentExamRow3 = dtStudentExam.NewRow();
            dataStudentExamRow3["studentId"] = 1;
            dataStudentExamRow3["subjectId"] = "E155";
            dataStudentExamRow3["mark"] = 78;
            dtStudentExam.Rows.Add(dataStudentExamRow3);

            DataRow dataStudentExamRow4 = dtStudentExam.NewRow();
            dataStudentExamRow4["studentId"] = 1;
            dataStudentExamRow4["subjectId"] = "E101";
            dataStudentExamRow4["mark"] = 12;
            dtStudentExam.Rows.Add(dataStudentExamRow4);

            DataRow dataStudentExamRow5 = dtStudentExam.NewRow();
            dataStudentExamRow5["studentId"] = 1;
            dataStudentExamRow5["subjectId"] = "E234";
            dataStudentExamRow5["mark"] = 42;
            dtStudentExam.Rows.Add(dataStudentExamRow5);

           var dt = HelperDataTable.MergeRowsToColumns(dtProduct, "productId", "name", dtSales , "quantity", "month" , true , "Total Sales");
           var dt2 = HelperDataTable.MergeRowsToColumns(dtStudents, "studentId", "fullname", dtStudentExam , "mark", "subjectId" , true , "Overal Score");

            dt.Columns.Remove("productId");
            dt2.Columns.Remove("studentId");

            DataTable dtSubject = new DataTable();
            dtSubject.Columns.Add("subjectId");
            dtSubject.Columns.Add("name");
           
            DateTime dtr = new DateTime(2019, 3, 15);

            var sm = dtr.ToShortTimeDisplay();
            string diff = dtr.ToTimeSpanDifference();
            string dtHtml = dt.ToHtmlTable(null);
            string dtHtml2 = dt2.ToHtmlTable(null);
            Console.ReadKey();
        }
    }
}

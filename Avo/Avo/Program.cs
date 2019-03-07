using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal tes = 294944.8484827M;
            int iint = 34;
            Console.WriteLine(tes.ToThousandSeparator(3));
            Console.WriteLine(iint.ToThousandSeparator(2)); 
            Console.ReadKey();
        }
    }
}

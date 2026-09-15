using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Số lượng phần tử: ");
            int n = int.Parse(Console.ReadLine());
            double tong = 0.0;

            Console.WriteLine("Dãy số điều hòa:");
            for (int i = 1; i <= n; i++)
            {
                tong += 1.0 / i;
                Console.Write("1/{0}", i);
                if (i < n)
                    Console.Write(" + ");
            }

            Console.WriteLine();
            Console.WriteLine($"Tổng của dãy số  = {tong}");
        }
    }
}

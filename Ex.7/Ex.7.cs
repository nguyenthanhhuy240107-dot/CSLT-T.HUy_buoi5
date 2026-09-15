using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Khoảng dưới: ");
            int lower = int.Parse(Console.ReadLine());
            Console.Write("Khoảng trên: ");
            int upper = int.Parse(Console.ReadLine());

            Console.WriteLine($"Các số hoàn hảo trong khoảng ({lower}-{upper}) là:");

            for (int num = lower; num <= upper; num++)
            {
                int tongUoc = 0;

                for (int i = 1; i < num; i++)
                {
                    if (num % i == 0)
                        tongUoc += i;
                }

                if (tongUoc == num)
                    Console.WriteLine(num);
            }
        }
    }
}

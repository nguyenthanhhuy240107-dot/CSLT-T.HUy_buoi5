using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_xí_ngầu
{
    internal class game_xí_ngầu
    {
        public static void Main(string[] args)
        {
            long Tien = 2000000;
            int Lan = 0;
            int Thua = 0;
            int Dbiet = 0;
            bool continuePlaying = true;
            do
            {
                Lan++;
                Console.Write($"Bạn có {Tien} đồng. Bạn đặt bao nhiêu? ");
                long Tdat = 0;
                do
                {
                    bool ok = long.TryParse(Console.ReadLine(), out long result);
                    if (ok && result <= Tien && result > 1000)
                    {
                        Tdat = result;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập một số hợp lệ hoặc số tiền đặt " +
                            $"cược không được vượt quá số tiền hiện có {Tien}. Hoặc trên 1000 đồng");
                        Console.Write("Bạn đặt bao nhiêu? ");
                    }
                } while (true);
                Random r = new Random();
                int d1 = r.Next(1, 7);
                int d2 = r.Next(1, 7);
                int sum = d1 + d2;
                string doan;
                do
                {
                    Console.Write("Bạn đoán tài(T), xỉu(X) hay lục (L)? ");
                    doan = Console.ReadLine().ToUpper();
                    if (doan != "T" && doan != "X" && doan != "L")
                    {
                        Console.WriteLine("Vui lòng nhập T, X hoặc L.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                bool thang = false;
                bool kodb = false;
                if (doan == "T" && sum > 6)
                {
                    thang = true;
                }
                else if (doan == "X" && sum < 6)
                {
                    thang = true;
                }
                else if (doan == "L" && sum == 6)
                {
                    thang = true;
                    kodb = true;
                }
                Console.WriteLine($"Kết quả gieo súc sắc: {d1} + {d2} = {sum}");
                if (thang)
                {
                    if (kodb)
                    {
                        Dbiet++;
                        Tien += Tdat * 3;
                        Console.WriteLine($"Bạn thắng đặc biệt! Tổng số tiền hiện tại: {Tien} đồng.");
                    }
                    else
                    {
                        Tien += Tdat;
                        Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {Tien} đồng.");
                    }
                }
                else
                {
                    Thua++;
                    Tien -= Tdat;
                    Console.WriteLine($"Bạn thua! Tổng số tiền hiện tại: {Tien} đồng.");
                }
                Console.Write("\nBạn có muốn tiếp tục chơi không? (Y/N): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "n")
                {
                    continuePlaying = false;
                }
            } while (continuePlaying);
            Console.WriteLine($"\nTrò chơi kết thúc!");
            Console.WriteLine($"Tổng số lần chơi: {Lan}");
            Console.WriteLine($"Tổng số lần thắng: {Lan - Thua - Dbiet}");
            Console.WriteLine($"Tổng số lần thua: {Thua}");
            Console.WriteLine($"Tổng số lần thắng đặc biệt: {Dbiet}");
        }
    }
}

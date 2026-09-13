using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_đoán_số
{
    internal class game_đoán_số
    {

        public static void Main(string[] args)
        {
            //Máy tính nghĩ ra ngẫu nhiên 1 số từ 1 đến 100, cho người dùng đoán. Game có 3 levels dễ/trung bình/khó tương ứng với được gieo 9/6/4 lần gieo.

            //nếu mức dễ thì tiền cược được 1 / 2 lần tiền đặt, trung bình thì được 1 lần đặt, khó thì thắng 3 lần đặt.

            //Trò chơi sẽ kết thúc khi người chơi chọn không chơi nữa hoặc số tiền còn lại 0 đồng.

            //Các logic khác có thể tự thêm.
            long tien = 1000000;
            int soLanChoi = 0;
            int soLanThua = 0;
            bool continuePlaying = true;
            do
            {
                soLanChoi++;
                Console.WriteLine($"Bạn có {tien} đồng.");
                Console.Write($"Bạn đặt bao nhiêu? ");
                long tCuoc = 0;
                do
                {
                    bool ok = long.TryParse(Console.ReadLine(), out long r);
                    if (ok && r <= tien && r > 1000)
                    {
                        tCuoc = r;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập một số hợp lệ hoặc số tiền đặt " +
                            $"cược không được vượt quá số tiền hiện có {tien}. Hoặc trên 1000 đồng");
                        Console.Write("Bạn đặt bao nhiêu? ");
                    }
                } while (true);
                //random số
                Random rand = new Random();
                int so = rand.Next(1, 101);
                //Chọn level và đoán
                string level;
                do
                {
                    Console.Write("Bạn chọn level dễ(D), trung bình(TB) hay khó(K)? ");
                    level = Console.ReadLine().ToUpper();
                    if (level != "D" && level != "TB" && level != "K")
                    {
                        Console.WriteLine("Vui lòng nhập D, TB hoặc K.");
                    }
                    else
                    {
                        break;
                    }
                }               
                while (true);
                Console.Write("Bạn đoán số mấy (1-100)? ");
                byte doan = 0;
                do
                {
                    bool num = byte.TryParse(Console.ReadLine(),out byte f );
                    if (num && f >= 1 && f <= 100)
                    { 
                        doan = f;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng nhập một số hợp lệ");
                        Console.Write("Bạn đoán số mấy (1-100)? ");
                    }
                }while (true);

                bool thang = false;
                if (doan == so)
                {
                    thang = true;
                }
                Console.WriteLine($"Kết quả (Số đoán/đáp án): {doan}/{so}");
                if (thang)
                {
                    if (level == "D")
                    {
                        tien += tCuoc / 2;
                    }
                    else if (level == "TB")
                    {
                        tien += tCuoc;
                    }
                    else if (level == "K")
                    {
                        tien += tCuoc * 3;
                    }
                    Console.WriteLine($"Bạn thắng! Tổng số tiền hiện tại: {tien} đồng.");
                    
                }
                else
                {
                    soLanThua++;
                    tien -= tCuoc;
                    Console.WriteLine($"Bạn thua! Tổng số tiền hiện tại: {tien} đồng.");
                }
                Console.Write("\nBạn có muốn chơi tiếp không? (Y/N): ");
                string input = Console.ReadLine().ToUpper();
                if (input == "N")
                {
                    continuePlaying = false;
                }
            }
            while (continuePlaying || tien == 0);
            Console.WriteLine($"\nTrò chơi kết thúc!");
            Console.WriteLine($"Tổng số lần chơi: {soLanChoi}");
            Console.WriteLine($"Tổng số lần thắng: {soLanChoi - soLanThua}");
            Console.WriteLine($"Tổng số lần thua: {soLanThua}");
            Console.WriteLine($"Tổng số tiền còn lại: {tien} đồng");

        }

    }
}

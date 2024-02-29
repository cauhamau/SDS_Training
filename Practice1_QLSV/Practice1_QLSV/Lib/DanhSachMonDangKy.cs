using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Lib
{
    class DanhSachMonDangKy
    {
        List<MonDangKy> _monDangKy = new List<MonDangKy>();
        public List<MonDangKy> ListMonDangKy { get => _monDangKy; set => _monDangKy = value; }
        public void SoMonHocSinhVienDangKy(int MSSV)
        {
            List<MonDangKy> monDK = ListMonDangKy.Where(x=>x.MSSV==MSSV).ToList();
            if (monDK.Count==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Không tìm thấy thông tin.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("Sinh viên đã đăng ký {0} môn: ", monDK.Count);
                Console.ResetColor();
                foreach (MonDangKy monDangKy in monDK)
                {
                    Console.Write(" {0}", monDangKy.MaMH);
                }
                Console.WriteLine();
            }

        }
        public void NhapDiemSinhVien(int MSSV,string MaMH)
        {
            MonDangKy monDK = new MonDangKy();
            monDK.MSSV = MSSV;
            monDK.MaMH = MaMH;
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Nhập điểm quá trình: ");
                Console.ResetColor();
                monDK.DQT = int.Parse(Console.ReadLine());
                if (monDK.DQT > 10 || monDK.DQT < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập sai, vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else break;
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Nhập điểm quá trình: ");
                Console.ResetColor();
                monDK.DTP = int.Parse(Console.ReadLine());
                if (monDK.DTP > 10 || monDK.DTP < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập sai, vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else break;
            }
            ListMonDangKy.Add(monDK);

        }
        
    }
}

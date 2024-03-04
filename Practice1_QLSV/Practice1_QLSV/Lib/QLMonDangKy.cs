using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_QLSV.Lib
{
    class QLMonDangKy
    {
        List<MonDangKy> _monDangKy = new List<MonDangKy>();
        public List<MonDangKy> ListMonDangKy { get => _monDangKy; set => _monDangKy = value; }

        public void GetJSON(string link)
        {
            string json_MonDangKy = File.ReadAllText(link);
            ListMonDangKy = JsonConvert.DeserializeObject<List<MonDangKy>>(json_MonDangKy);
        }
        public void SoMonHocSinhVienDangKy(int MSSV)
        {
            List<MonDangKy> listmonDK = ListMonDangKy.Where(x=>x.MSSV==MSSV).ToList();
            if (listmonDK.Count==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Không tìm thấy thông tin.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.Write("Sinh viên đã đăng ký {0} môn: ", listmonDK.Count);
                Console.ResetColor();
                foreach (MonDangKy monDangKy in listmonDK)
                {
                    Console.Write(" {0}", monDangKy.MaMH);
                }
                Console.WriteLine();
            }

        }
        public void NhapDiemSinhVien(int MSSV,string MaMH)
        {
            MonDangKy listmonDK = new MonDangKy();
            listmonDK.MSSV = MSSV;
            listmonDK.MaMH = MaMH;
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Nhập điểm quá trình: ");
                Console.ResetColor();
                listmonDK.DQT = int.Parse(Console.ReadLine());
                if (listmonDK.DQT > 10 || listmonDK.DQT < 0)
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
                listmonDK.DTP = int.Parse(Console.ReadLine());
                if (listmonDK.DTP > 10 || listmonDK.DTP < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập sai, vui lòng nhập lại.");
                    Console.ResetColor();
                }
                else break;
            }
            ListMonDangKy.Add(listmonDK);

        }
        
    }
}

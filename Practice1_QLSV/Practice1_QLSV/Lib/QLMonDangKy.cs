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
            bool res;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Nhập điểm quá trình: ");
                Console.ResetColor();
                res = float.TryParse(Console.ReadLine(), out float temp);
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm phải là số thực.");
                    Console.ResetColor();
                }
                else if (temp > 10 || temp < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm phải có giá trị từ 0 đến 10.");
                    Console.ResetColor();
                }
                else
                {
                    listmonDK.DQT = temp;
                    break;
                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Nhập điểm thành phần: ");
                Console.ResetColor();
                res = float.TryParse(Console.ReadLine(), out float temp);
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm phải là số thực.");
                    Console.ResetColor();
                }
                else if (temp > 10 || temp < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Điểm phải có giá trị từ 0 đến 10.");
                    Console.ResetColor();
                }
                else
                {
                    listmonDK.DTP = temp;
                    break;
                }
                
            }
            ListMonDangKy.Add(listmonDK);

        }
        
    }
}

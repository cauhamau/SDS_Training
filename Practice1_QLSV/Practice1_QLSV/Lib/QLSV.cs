using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practice1_QLSV.Lib
{
    class QLSV
    {
        List<Sinhvien> _ListSV = new List<Sinhvien>();

        public List<Sinhvien> ListSV { get => _ListSV; set => _ListSV = value; }

        public void GetJSON(string link)
        {
            string json_SinhVien = File.ReadAllText(link);
            ListSV = JsonConvert.DeserializeObject<List<Sinhvien>>(json_SinhVien, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
        }
        public void XuatDanhSachSV()
        {
            Console.WriteLine("{0,60}","Danh sách sinh viên");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-15} {1,-20} {2,-15} {3,-15} {4,-10} {5,-10} ", "Mã sinh viên", "Tên sinh viên", "Giới tính","Ngày sinh","Lớp","Khoá");
            Console.ResetColor();
            
            foreach (var item in _ListSV)
            {
                Console.WriteLine("{0,-15} {1,-20} {2,-15} {3,-15} {4,-10} {5,-10} ", item.MSSV, item.TenSV,item.Gioitinh,item.Ngaysinh.ToString("dd/MM/yyyy"),item.Lop,item.Khoa);
            }
        }
        public void ChiTietSV(int MSSV)
        {
            Sinhvien sv = ListSV.SingleOrDefault(x=>x.MSSV==MSSV);
            if (sv!=null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=> Tìm thấy");
                Console.ResetColor();
                sv.XemSinhVien();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=> Không tìm thấy sinh viên.");
                Console.ResetColor();
            }

        }
    }
}
using Practice1_QLSV.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax.Lib
{
    class DanhSachMH
    {
        List<Monhoc> _ListMH = new List<Monhoc>();

        public List<Monhoc> ListMH { get => _ListMH; set => _ListMH = value; }
        public void XuatDanhSachMH()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0,-15} {1,-23} {2,-23} {3,-30} {4}", "Mã môn học", "Tên môn học", "Số tiết", "Tỉ lệ điểm quá trình", "Tỉ lệ điểm thành phần");

            Console.ResetColor();
            foreach (Monhoc monh in ListMH)
            {
                Console.WriteLine("{0,-15} {1,-23} {2,-23} {3}% {5,-26} {4}%", monh.MaMH, monh.TenMH, monh.SoTiet, monh.RateDQT*100, monh.RateDTP*100, "");
            }
        }
    }
}

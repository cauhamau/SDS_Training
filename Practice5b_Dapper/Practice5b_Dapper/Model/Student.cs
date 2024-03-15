using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Model
{
    internal class Student
    {
        int _MSSV;
        string _HOTENSV;
        string _GIOITINH;
        DateTime _NGAYSINH;
        string _LOP;
        int _KHOA;

        public Student(int mSSV, string hOTENSV, string gIOITINH, DateTime nGAYSINH, string lOP, int kHOA)
        {
            _MSSV = mSSV;
            _HOTENSV = hOTENSV;
            _GIOITINH = gIOITINH;
            _NGAYSINH = nGAYSINH;
            _LOP = lOP;
            _KHOA = kHOA;
        }

        public int MSSV { get => _MSSV; set => _MSSV = value; }
        public string HOTENSV { get => _HOTENSV; set => _HOTENSV = value; }
        public string GIOITINH { get => _GIOITINH; set => _GIOITINH = value; }
        public DateTime NGAYSINH { get => _NGAYSINH; set => _NGAYSINH = value; }
        public string LOP { get => _LOP; set => _LOP = value; }
        public int KHOA { get => _KHOA; set => _KHOA = value; }

        public void XemSinhVien()
        {
            Console.WriteLine("Thông tin sinh viên");
            Console.WriteLine("Mã sinh viên: {0}", MSSV);
            Console.WriteLine("Họ và tên: {0}", HOTENSV);
            Console.WriteLine("Giới tính: {0}", GIOITINH);
            Console.WriteLine("Ngày sinh: {0}", NGAYSINH.ToString("dd/MM/yyyy"));
            Console.WriteLine("Sinh viên khoá: {0}", KHOA);

        }
    }
}

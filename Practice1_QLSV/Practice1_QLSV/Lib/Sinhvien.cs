using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_QLSV.Lib
{
    class Sinhvien
    {

        int _MSSV;
        string _TenSV;
        string _Gioitinh;
        DateTime _Ngaysinh;
        string _Lop;
        int _Khoa;

        public int MSSV { get => _MSSV; set => _MSSV = value; }
        public string TenSV { get => _TenSV; set => _TenSV = value; }
        public string Gioitinh { get => _Gioitinh; set => _Gioitinh = value; }
        public DateTime Ngaysinh { get => _Ngaysinh; set => _Ngaysinh = value; }
        public string Lop { get => _Lop; set => _Lop = value; }
        public int Khoa { get => _Khoa; set => _Khoa = value; }

        public Sinhvien(int mSSV, string tenSV, string gioitinh, DateTime ngaysinh, string lop, int khoa)
        {
            MSSV = mSSV;
            TenSV = tenSV;
            Gioitinh = gioitinh;
            Ngaysinh = ngaysinh;
            Lop = lop;
            Khoa = khoa;
        }
        public void XemSinhVien()
        {
            Console.WriteLine("Thông tin sinh viên");
            Console.WriteLine("Mã sinh viên: {0}", MSSV);
            Console.WriteLine("Họ và tên: {0}", TenSV);
            Console.WriteLine("Giới tính: {0}", Gioitinh);
            Console.WriteLine("Ngày sinh: {0}", Ngaysinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Sinh viên khoá: {0}", Khoa);

        }
    }
}

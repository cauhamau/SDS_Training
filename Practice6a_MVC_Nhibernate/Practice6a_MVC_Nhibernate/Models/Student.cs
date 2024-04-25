using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Models
{
    public class Student
    {
        [DebuggerDisplay("Mã số sinh viên")]
        int _MSSV;
        string _HOTENSV;
        string _GIOITINH;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        DateTime _NGAYSINH;
        string _LOP;
        int _KHOA;

        //public Student(int mSSV, string hOTENSV, string gIOITINH, DateTime nGAYSINH, string lOP, int kHOA)
        //{
        //    _MSSV = mSSV;
        //    _HOTENSV = hOTENSV;
        //    _GIOITINH = gIOITINH;
        //    _NGAYSINH = nGAYSINH;
        //    _LOP = lOP;
        //    _KHOA = kHOA;
        //}

        public virtual int MSSV { get => _MSSV; set => _MSSV = value; }
        public virtual string HOTENSV { get => _HOTENSV; set => _HOTENSV = value; }
        public virtual string GIOITINH { get => _GIOITINH; set => _GIOITINH = value; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime NGAYSINH { get => _NGAYSINH; set => _NGAYSINH = value; }
        public virtual string LOP { get => _LOP; set => _LOP = value; }
        public virtual int KHOA { get => _KHOA; set => _KHOA = value; }
    }
}
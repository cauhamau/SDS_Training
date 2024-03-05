using Practice3_ServiceDI_StudentManagement.Interfaces.IData;
using Practice3_ServiceDI_StudentManagement.Interfaces.IServices;
using Practice3_ServiceDI_StudentManagement.Model;
using Practice3_ServiceDI_StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudentService() { }
        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public List<Student> GetAll()
        {
            return _studentData.GetAll();
        }

        //public Student Create()
        //{
        //    Student student = new Student();
        //    Console.Write("MSSV: ");
        //    student.MASV = int.Parse(Console.ReadLine());
        //    Console.Write("Họ tên: ");
        //    student.HOTEN = Console.ReadLine();
        //    Console.Write("Mã khoa: ");
        //    student.MAKHOA = Console.ReadLine();
        //    Console.Write("Năm sinh: ");
        //    student.NAMSINH = int.Parse(Console.ReadLine());
        //    Console.Write("Quê quán: ");
        //    student.QUEQUAN = Console.ReadLine();
        //    _studentData.Add(student);
        //    return student;
        //}

        public void ShowList(List<Student> student)
        {
            var t = new TablePrinter("MSSV", "Họ tên", "Giới tính", "Ngày sinh", "Lớp", "Khoá");
            foreach (var s in student)
            {
                t.AddRow(s.MSSV, s.HOTENSV,s.GIOITINH,s.NGAYSINH,s.LOP,s.KHOA);
            }
            t.Print();

        }
        public void ShowStudent(Student student)
        {

        }
    }
}

﻿using Practice3_ServiceDI_StudentManagement.Interfaces.IData;
using Practice3_ServiceDI_StudentManagement.Interfaces.IServices;
using Practice3_ServiceDI_StudentManagement.Model;
using Practice3_ServiceDI_StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public void ShowList(List<Student> students)
        {
            var t = new TablePrinter("MSSV", "Họ tên", "Giới tính", "Ngày sinh", "Lớp", "Khoá");
            foreach (var s in students)
            {
                t.AddRow(s.MSSV, s.HOTENSV,s.GIOITINH,s.NGAYSINH,s.LOP,s.KHOA);
            }
            t.Print();

        }
        public void ShowStudent(List<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem thông tin: ");
            Console.ResetColor();
            int MSSV = int.Parse(Console.ReadLine());
            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=> Tìm thấy");
                Console.ResetColor();
                s.XemSinhVien();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=> Không tìm thấy sinh viên.");
                Console.ResetColor();
            }
        }

        public void CountSubjects(List<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Nhập mã sinh viên để xem thông tin: ");
            Console.ResetColor();
            int MSSV = int.Parse(Console.ReadLine());
            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {

                List<string> result = _studentData.GetNumberSubjectRegisted(MSSV);


                if (result != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write($"Sinh viên đã đăng ký {result.Count} môn: ");
                    foreach (string i in result)
                    {
                        Console.Write("  " + i);
                    }
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Sinh viên chưa đăng ký môn học.");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=> Không tìm thấy sinh viên.");
                Console.ResetColor();
            }
        }

        public void ShowEnrolledCourseInfoForStudent(List<Student> students)
        {
            var t = new TablePrinter("Mã môn học", "Tên môn học", "Điểm thành phần", "Điểm quá trình");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem điểm: ");
            Console.ResetColor();
            int MSSV = int.Parse(Console.ReadLine());
            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {

                DataTable result = _studentData.GetEnrolledCourseInfoForStudent(MSSV);


                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        t.AddRow(row["MAMH"], row["TENMH"], row["DTP"], row["DQT"]);
                    }
                    t.Print();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Sinh viên chưa đăng ký môn học.");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("=> Không tìm thấy sinh viên.");
                Console.ResetColor();
            }
        }
        public void ShowResultStudent(List<Student> students)
        {
            var t = new TablePrinter("Mã môn học", "Tên môn học", "Điểm thành phần", "Điểm quá trình","Điểm tổng kết","Kết quả");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem điểm: ");
            Console.ResetColor();
            int MSSV = int.Parse(Console.ReadLine());
            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {

                DataTable result = _studentData.GetResultStudent(MSSV);
                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        t.AddRow(row["MAMH"], row["TENMH"], row["DTP"], row["DQT"], float.Parse(row["DTK"].ToString()), row["KETQUA"]);
                    }
                    t.Print();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Sinh viên chưa đăng ký môn học.");
                    Console.ResetColor();
                }

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

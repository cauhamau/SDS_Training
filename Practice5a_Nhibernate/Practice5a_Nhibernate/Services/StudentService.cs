using Practice5a_Nhibernate.Data.Files;
using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Interfaces.IServices;
using Practice5a_Nhibernate.Models.Classes;
using Practice5a_Nhibernate.Services;
using Practice5a_Nhibernate.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudentService() { }
        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public IList<Student> GetAll()
        {
            return _studentData.GetAll();
        }

        public void ShowList(IList<Student> students)
        {
            var t = new TablePrinter("MSSV", "Họ tên", "Giới tính", "Ngày sinh", "Lớp", "Khoá");
            foreach (var s in students)
            {
                t.AddRow(s.MSSV, s.HOTENSV, s.GIOITINH, s.NGAYSINH.ToString("dd/MM/yyyy"), s.LOP, s.KHOA);
            }
            t.Print();

        }
        public void ShowStudent(IList<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem thông tin: ");
            Console.ResetColor();

            #region MSSV is an integer
            bool res;
            res = int.TryParse(Console.ReadLine(), out int MSSV);
            if (!res)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                Console.ResetColor();
                return;
            }
            #endregion

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

        public void CountSubjects(IList<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Nhập mã sinh viên để xem thông tin: ");
            Console.ResetColor();

            #region MSSV is an integer
            bool res;
            res = int.TryParse(Console.ReadLine(), out int MSSV);
            if (!res)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                Console.ResetColor();
                return;
            }
            #endregion


            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {

                IList<SubjectRegisted> result = _studentData.GetNumberSubjectRegisted(MSSV);


                if (result != null)
                {
                    //ISubjectService subjectService = new SubjectService();
                    
                    //subjectService.ShowList(subjectService.GetAll());
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write($"Sinh viên đã đăng ký {result.Count} môn: ");
                    foreach (SubjectRegisted i in result)
                    {
                        Console.Write("  " + i.MAMH);
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

        public void ShowEnrolledCourseInfoForStudent(IList<Student> students)
        {
            var t = new TablePrinter("Mã môn học", "Tên môn học", "Điểm thành phần", "Điểm quá trình");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem điểm: ");
            Console.ResetColor();

            #region MSSV is an integer
            bool res;
            res = int.TryParse(Console.ReadLine(), out int MSSV);
            if (!res)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                Console.ResetColor();
                return;
            }
            #endregion


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
        public void ShowResultStudent(IList<Student> students)
        {
            var t = new TablePrinter("Mã môn học", "Tên môn học", "Điểm thành phần", "Điểm quá trình", "Điểm tổng kết", "Kết quả");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để xem điểm: ");
            Console.ResetColor();

            #region MSSV is an integer
            bool res;
            res = int.TryParse(Console.ReadLine(), out int MSSV);
            if (!res)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                Console.ResetColor();
                return;
            }
            #endregion


            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {

                DataTable result = _studentData.GetResultStudent(MSSV);
                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        t.AddRow(row["MAMH"], row["TENMH"], row["DTP"], row["DQT"], float.Parse(row["DTK"].ToString().Replace(" ", "")), row["KETQUA"]);
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

        public void InputScore(IList<Student> students, IList<Subject> subjects)
        {
            ISubjectService subjectService = new SubjectService();
            
            subjectService.ShowList(subjects);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Nhập mã sinh viên để nhập điểm: ");

            #region MSSV is an integer
            bool res;
            res = int.TryParse(Console.ReadLine(), out int MSSV);
            if (!res)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Mã sinh viên phải là số nguyên.");
                Console.ResetColor();
                return;
            }
            #endregion

            Student s = students.SingleOrDefault(x => x.MSSV == MSSV);
            if (s != null)
            {
                Console.Write("Nhập mã môn học để nhập điểm: ");
                string MAMH = Console.ReadLine();
                //Console.WriteLine(ListMonHoc[0].MaMH.ToString()+MAMH);
                Subject monhoc = subjects.SingleOrDefault(x => x.MAMH.ToString().Replace(" ", "") == MAMH);

                if (monhoc != null)
                {
                    Console.Write("Nhập điểm quá trình: ");
                    float DQT = float.Parse(Console.ReadLine());
                    Console.Write("Nhập điểm thành phần: ");
                    float DTP = float.Parse(Console.ReadLine());
                    _studentData.InputDataScore(MSSV, MAMH, DQT, DTP);
                    Console.ResetColor();
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("=> Không tìm thấy môn học");
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

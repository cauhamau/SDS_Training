using Practice3_ServiceDI_StudentManagement.Data.Files;
using Practice3_ServiceDI_StudentManagement.Interfaces.IServices;
using Practice3_ServiceDI_StudentManagement.Model;
using Practice3_ServiceDI_StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            //Inject
            IStudentService studentService = new StudentService(new StudentFileData("data source=.;initial catalog=QLSV;integrated security=true;"));
            List<Student> students =  studentService.GetAll();

            int choice;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("0. Thoát chương trình.");
                Console.WriteLine("1. Xem danh sách sinh viên.");
                Console.WriteLine("2. Xem chi tiết sinh viên.");
                Console.WriteLine("3. Xem số môn học sinh viên đăng ký.");
                Console.WriteLine("4. Xem điểm môn học của sinh viên.");
                Console.WriteLine("5. Nhập điểm sinh viên.");
                Console.WriteLine("6. Xem kết quả trượt đỗ của sinh viên.");
                Console.Write("Chọn chức năng: ");
                Console.ResetColor();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        studentService.ShowList(students);
                        break;
                    case 2:
                        studentService.ShowStudent(students);
                        break;
                    case 3:
                        studentService.CountSubjects(students);
                        break;
                    case 4:
                        studentService.ShowEnrolledCourseInfoForStudent(students);
                        break;
                    case 5:
                        studentService.InputScore(students);
                        break;
                    case 6:
                        studentService.ShowResultStudent(students);
                        break;
                    default:
                        Console.WriteLine("Nhập sai vui lòng nhập lại.");
                        break;
                }
            }

        }


    }
}

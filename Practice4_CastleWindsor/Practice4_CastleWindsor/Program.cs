using Practice4_CastleWindsor.Data.Files;
using Practice4_CastleWindsor.Interfaces.IServices;
using Practice4_CastleWindsor.Model;
using Practice4_CastleWindsor.Services;
using Practice4_CastleWindsor.Data.Files;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Practice4_CastleWindsor.Interfaces.IData;

namespace Practice4_CastleWindsor
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var container = new WindsorContainer();
            container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
                   Component.For<IStudentData>().ImplementedBy<StudentFileData>().DependsOn(Dependency.OnValue("connectionString", "data source=.;initial catalog=QLSV;integrated security=true;"))
                   );
            var studentService = container.Resolve<IStudentService>();
            
            List<Student> students = studentService.GetAll();
            bool res;
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

                #region choice is an integer
                res = int.TryParse(Console.ReadLine(), out choice);
                if (!res)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nhập sai, vui lòng nhập lại");
                    Console.ResetColor();
                    continue;
                }
                #endregion

                switch (choice)
                {
                    case 0:
                        return;
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

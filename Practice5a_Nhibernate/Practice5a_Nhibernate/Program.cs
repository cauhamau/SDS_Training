using NHibernate.Dialect;
using NHibernate.Driver;

using System;
using System.Reflection;
using Practice5a_Nhibernate.Models.Classes;
using Practice5a_Nhibernate.Data.Files;
using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Interfaces.IServices;
using Practice5a_Nhibernate.Services;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using System.Collections.Generic;

namespace Practice5a_Nhibernate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var cfg = new NHibernate.Cfg.Configuration();

            //cfg.DataBaseIntegration(x =>
            //{
            //    x.ConnectionString = "data source=.;initial catalog=QLSV;integrated security=true;";
            //    x.Driver<SqlClientDriver>();
            //    x.Dialect<MsSql2008Dialect>();
            //});





            //cfg.AddAssembly(Assembly.GetExecutingAssembly());
            //var sefact = cfg.BuildSessionFactory();

            //using (var session = sefact.OpenSession())
            //{

            //    using (var tx = session.BeginTransaction())
            //    {
            //        IList<Student> _students = session.CreateCriteria<Student>().List<Student>();

            //        foreach (var student in _students)
            //        {
            //            Console.WriteLine("{0} \t{1} \t{2}",
            //               student.MSSV, student.HOTENSV, student.GIOITINH);
            //        }

            //        tx.Commit();
            //    }

            //    Console.ReadLine();
            //}
            //sefact.Close();


            Console.OutputEncoding = Encoding.UTF8;

            var container = new WindsorContainer();
            container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
                   Component.For<ISubjectService>().ImplementedBy<SubjectService>(),
                   Component.For<IStudentData>().ImplementedBy<StudentFileData>().DependsOn(Dependency.OnValue("connectionString", "data source=.;initial catalog=QLSV;integrated security=true;")),
                   Component.For<ISubjectData>().ImplementedBy<SubjectFileData>().DependsOn(Dependency.OnValue("connectionString", "data source=.;initial catalog=QLSV;integrated security=true;"))
                   );
            var studentService = container.Resolve<IStudentService>();
            var subjectService = container.Resolve<ISubjectService>();
            IList<Student> students = studentService.GetAll();
            IList<Subject> subjects = subjectService.GetAll();
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
                        return;
                    case 1:
                        studentService.ShowList(students);
                        break;
                    case 2:
                        studentService.ShowStudent(students);
                        break;
                    case 3:
                        subjectService.ShowList(subjects);
                        studentService.CountSubjects(students);
                        break;
                    case 4:
                        studentService.ShowEnrolledCourseInfoForStudent(students);
                        break;
                    //case 5:
                    //    studentService.InputScore(students);
                    //    break;
                    //case 6:
                    //    studentService.ShowResultStudent(students);
                    //    break;
                    default:
                        Console.WriteLine("Nhập sai vui lòng nhập lại.");
                        break;
                }
            }
        }
    }
}

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
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Danh sách sinh viên");
                Console.Write("Chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //try
                        //{
                        //    students.Add(studentService.Create());
                        //}    
                        //catch(Exception ex)
                        //{ Console.WriteLine("Lỗi:",ex.Message); }

                        break;
                    case 2:
                        studentService.ShowList(students);
                        break;
                }
            }
            //
            studentService.ShowList(students);

        }


    }
}

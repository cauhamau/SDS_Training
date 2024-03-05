using Practice3_ServiceDI_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Interfaces.IServices
{
    internal interface IStudentService
    {
        List<Student> GetAll();
        //Student Create();
        void ShowList(List<Student> student);
        void ShowStudent(Student student);
    }
}

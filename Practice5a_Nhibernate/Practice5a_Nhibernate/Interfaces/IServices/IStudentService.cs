
using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Interfaces.IServices
{
    internal interface IStudentService
    {
        IList<Student> GetAll();

        void ShowList(IList<Student> student);

        void ShowStudent(List<Student> student);

        void CountSubjects(List<Student> students);

        void ShowEnrolledCourseInfoForStudent(List<Student> students);

        void ShowResultStudent(List<Student> students);

        void InputScore(List<Student> students);
    }
}

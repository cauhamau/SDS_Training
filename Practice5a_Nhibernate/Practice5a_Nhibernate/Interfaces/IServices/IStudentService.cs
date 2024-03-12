
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

        void ShowStudent(IList<Student> student);

        void CountSubjects(IList<Student> students);

        void ShowEnrolledCourseInfoForStudent(IList<Student> students);

        void ShowResultStudent(IList<Student> students);

        void InputScore(IList<Student> students);
    }
}

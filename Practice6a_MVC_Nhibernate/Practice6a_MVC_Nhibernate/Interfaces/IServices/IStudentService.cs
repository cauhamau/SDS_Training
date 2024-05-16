using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IServices
{
    internal interface IStudentService : IBasicService<Student>
    {
        //private readonly IStudentData _studentData;
        //DataTable GetResultSubjectRegisted(int id);
        //string InsertDataScore(SubjectRegisted subjectRegisted);
        string SaveStudent(Student student); 
    }
}

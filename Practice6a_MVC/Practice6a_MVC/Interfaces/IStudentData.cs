using Practice6a_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC.Interfaces
{
    internal interface IStudentData : IBasicService<Student>
    {
        DataTable GetResultSubjectRegisted(int id);
        string InputDataScore(SubjectRegisted subjectRegisted);
    }
}

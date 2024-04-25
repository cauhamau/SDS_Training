using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IData
{
    internal interface IStudentData : IBasicData<Student>
    {
        //DataTable GetResultSubjectRegisted(int id);
        //string InsertDataScore(SubjectRegisted subjectRegisted);
    }
}

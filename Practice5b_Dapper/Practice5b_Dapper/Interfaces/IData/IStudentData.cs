using Practice5b_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Interfaces.IData
{
    internal interface IStudentData
    {
        List<Student> GetAll();
        List<SubjectRegisted> GetNumberSubjectRegisted(int MSSV);
        DataTable GetEnrolledCourseInfoForStudent(int MSSV);

        DataTable GetResultStudent(int MSSV);

        void InputDataScore(SubjectRegisted subjectRegisted);
    }
}


using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Interfaces.IData
{
    internal interface IStudentData
    {
        IList<Student> GetAll();
        IList<SubjectRegisted> GetNumberSubjectRegisted(int MSSV);
        DataTable GetEnrolledCourseInfoForStudent(int MSSV);

        DataTable GetResultStudent(int MSSV);

        void InputDataScore(int MSSV, string MAMH, float DQT, float DTP);
    }
}


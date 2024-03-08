using Practice4_CastleWindsor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_CastleWindsor.Interfaces.IData
{
    internal interface IStudentData
    {
        List<Student> GetAll();
        List<string> GetNumberSubjectRegisted(int MSSV);
        DataTable GetEnrolledCourseInfoForStudent(int MSSV);

        DataTable GetResultStudent(int MSSV);

        void InputDataScore(int MSSV, string MAMH, float DQT, float DTP);
    }
}


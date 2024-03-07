using Practice3_ServiceDI_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Interfaces.IData
{
    internal interface IStudentData
    {
        List<Student> GetAll();
        List<string> GetNumberSubjectRegisted(int MSSV);
        DataTable GetEnrolledCourseInfoForStudent(int MSSV);

        DataTable GetResultStudent(int MSSV);
    }
}


using Practice6a_MVC_Nhibernate.Interfaces;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Practice6a_MVC_Nhibernate.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudentService() { }
        public StudentService(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public IList<Student> GetAll()
        {
            return _studentData.GetAll();
        }

        public Student GetByID(object key)
        {
            return _studentData.GetByID(key);
        }

        public string SaveStudent(Student student)
        {
            return _studentData.SaveStudent(student);
        }

        //public DataTable GetResultSubjectRegisted(int id)
        //{
        //    return _studentData.GetResultSubjectRegisted(id);
        //}
        //public string InsertDataScore(SubjectRegisted subjectRegisted)
        //{
        //    return _studentData.InsertDataScore(subjectRegisted);
        //}
    }
}
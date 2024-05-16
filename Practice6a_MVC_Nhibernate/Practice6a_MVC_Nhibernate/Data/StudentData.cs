using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Practice6a_MVC_Nhibernate.Interfaces;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Web;
using static System.Net.WebRequestMethods;

namespace Practice6a_MVC_Nhibernate.Data
{
    public class StudentData : IStudentData
    {
        NHibernate.ISessionFactory _sefact;

        public StudentData(string connectionString)
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.DataBaseIntegration(x => {
                x.ConnectionString = connectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            _sefact = cfg.BuildSessionFactory();
        }

        public IList<Student> GetAll()
        {
            IList<Student> students;
            using (var session = _sefact.OpenSession())
            {
                try
                {
                    students = session.CreateCriteria<Student>().List<Student>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return students;
        }

        public Student GetByID(object id)
        {
            Student student;
            using (var session = _sefact.OpenSession())
            {
                try
                {
                    //IQuery sqlQuery = session.CreateSQLQuery($"SELECT * FROM SINHVIEN WHERE MSSV={id}").AddEntity(typeof(Student));
                    //student = sqlQuery.List<Student>()[0];
                    student = session.Get<Student>(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return student;
        }

        public string SaveStudent(Student student)
        {

            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(student);
                        tx.Commit();

                    }
                    catch (Exception ex)
                    {
                        return ex.ToString();
                    }
                }
            }
            return "Cập nhật sinh viên thành công";
        }

    }
}
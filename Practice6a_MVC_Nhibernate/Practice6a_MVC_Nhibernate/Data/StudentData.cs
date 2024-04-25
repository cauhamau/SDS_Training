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

        //public DataTable GetResultSubjectRegisted(int id)
        //{
        //    return null;//throw new NotImplementedException();
        //}

        //public DataTable GetResultSubjectRegisted(int id)
        //{
        //    DataTable dataTable = new DataTable();
        //    using (var session = _sefact.OpenSession())
        //    {
        //        string sqlQuery = "Select DANGKYMH.MAMH,TENMH, DTP, DQT, RATEDQT, RATEDTP, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK," +
        //                          " CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA" +
        //                          " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH" +
        //                          $" WHERE MSSV={id}";
        //        IQuery query = session.CreateSQLQuery(sqlQuery);

        //        dataTable.Columns.Add("MAMH", typeof(string));
        //        dataTable.Columns.Add("TENMH", typeof(string));
        //        dataTable.Columns.Add("DTP", typeof(decimal));
        //        dataTable.Columns.Add("DQT", typeof(decimal));
        //        dataTable.Columns.Add("RATEDQT", typeof(string));
        //        dataTable.Columns.Add("RATEDTP", typeof(string));
        //        dataTable.Columns.Add("DTK", typeof(decimal));
        //        dataTable.Columns.Add("KETQUA", typeof(string));

        //        var results = query.List<object[]>();
        //        foreach (var row in results)
        //        {
        //            dataTable.Rows.Add(row);
        //        }

        //        if (results is null) return null;
        //    }

        //    return dataTable;
        //}

        //public string InsertDataScore(SubjectRegisted subjectRegisted)
        //{
        //    using (var session = _sefact.OpenSession())
        //    {
        //        using (var tx = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Save(subjectRegisted);
        //                tx.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex.Message.Contains("Violation of PRIMARY KEY constraint"))
        //                {
        //                    return "Môn học đã có điểm";
        //                }
        //                else
        //                {
        //                    return ex.ToString();
        //                }
        //            }
        //        }

        //    }
        //    return "Nhập điểm thành công";
        //}

    }
}
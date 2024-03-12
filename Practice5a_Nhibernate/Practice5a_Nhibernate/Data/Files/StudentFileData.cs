using Castle.Core.Resource;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Data.Files
{
    internal class StudentFileData : IStudentData
    {
        NHibernate.Cfg.Configuration _cfg;
        NHibernate.ISessionFactory _sefact;
        

        public StudentFileData(string connectionString)
        {
            _cfg = new NHibernate.Cfg.Configuration();
            _cfg.DataBaseIntegration(x => {
                x.ConnectionString = "data source=.;initial catalog=QLSV;integrated security=true;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });
            _cfg.AddAssembly(Assembly.GetExecutingAssembly());
            _sefact = _cfg.BuildSessionFactory();
        }

        public IList<Student> GetAll()
        {
            var _session = _sefact.OpenSession();
            IList<Student> students = _session.CreateCriteria<Student>().List<Student>();
            _session.Close();
            return students;
        }
        public IList<SubjectRegisted> GetNumberSubjectRegisted(int MSSV)
        {
            var _session = _sefact.OpenSession();
            IQuery sqlQuery = _session.CreateSQLQuery($"SELECT * FROM DANGKYMH WHERE MSSV={MSSV}").AddEntity(typeof(SubjectRegisted));
            IList<SubjectRegisted> result = sqlQuery.List<SubjectRegisted>();
            _session.Close();
            return result; 
        }   
        public DataTable GetEnrolledCourseInfoForStudent(int MSSV)
        {
            string sqlQuery = $"SELECT MONHOC.MAMH, MONHOC.TENMH, DANGKYMH.DTP, DANGKYMH.DQT FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH = DANGKYMH.MAMH WHERE DANGKYMH.MSSV = '{MSSV}'";
            var _session = _sefact.OpenSession();
            // Tạo câu truy vấn SQL và chỉ định kiểu trả về cho các cột
            IQuery query = _session.CreateSQLQuery(sqlQuery);
            var results = query.List<object[]>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MAMH", typeof(string));
            dataTable.Columns.Add("TENMH", typeof(string));
            dataTable.Columns.Add("DTP", typeof(double));
            dataTable.Columns.Add("DQT", typeof(double));

            foreach (var row in results)
            {
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable GetResultStudent(int MSSV)
        {
            //_cnn.Open();
            //string sql = "Select DANGKYMH.MAMH,TENMH, DTP, DQT, ROUND((DTP*RATEDTP+DQT*RATEDQT),2) AS DTK,"+
            //              " CASE WHEN ROUND((DTP*RATEDTP+DQT*RATEDQT),2) > 4.0 THEN 'Pass' ELSE 'Fail' END AS KETQUA"+
            //              " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH"+
            //              $" WHERE MSSV={MSSV}";
            //SqlCommand cmd = new SqlCommand(sql, _cnn);
            //DataTable result = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(result);
            //_cnn.Close();

            //if (result is null) return null;
            //return result;
            return null;
        }


        public void InputDataScore(int  MSSV, string MAMH,float DQT, float DTP)
        {
            //_cnn.Open();
            //string sql = $"INSERT INTO DANGKYMH(MAMH, MSSV, DQT, DTP) VALUES ('{MAMH}',{MSSV},{DQT},{DTP})";
            //Console.WriteLine(sql);
            //try
            //{
            //    SqlCommand cmd = new SqlCommand(sql, _cnn);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //_cnn.Close();
        }
    }
}


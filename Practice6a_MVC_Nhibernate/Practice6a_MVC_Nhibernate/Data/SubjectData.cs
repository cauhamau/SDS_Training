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
using System.Web;
using System.Web.Mvc;

namespace Practice6a_MVC_Nhibernate.Data
{
    internal class SubjectData : ISubjectData
    {
        
        NHibernate.ISessionFactory _sefact;

        public SubjectData(string connectionString)
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

        public IList<Subject> GetAll()
        {
            IList<Subject> subjects;
            using (var _session = _sefact.OpenSession())
            {
                subjects = _session.CreateCriteria<Subject>().List<Subject>();
            }
            return subjects;
        }

        public Subject GetByID(object key)
        {

            throw new NotImplementedException();
        }
        public IList<Subject> GetUnregistered(int Id)
        {
                using (var session = _sefact.OpenSession())
                {
                    IList<Subject> subjects = new List<Subject>();
                    string query = "SELECT* FROM MONHOC" +
                                    " WHERE NOT EXISTS(" +
                                    " SELECT 1" +
                                    " FROM DANGKYMH" +
                                    " WHERE MONHOC.MAMH = DANGKYMH.MAMH" +
                                    $" AND MSSV = {Id}" +
                                    " AND(DANGKYMH.DTP IS NULL OR DANGKYMH.DQT IS NULL));";
                    IQuery sqlQuery = session.CreateSQLQuery(query).AddEntity(typeof(Subject));

                    subjects = sqlQuery.List<Subject>();
                    return subjects;
                }

        }
    }
}
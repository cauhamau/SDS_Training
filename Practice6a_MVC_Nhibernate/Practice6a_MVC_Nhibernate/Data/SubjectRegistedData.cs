﻿using NHibernate;
using NHibernate.Dialect;
using NHibernate.Driver;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Data
{
    internal class SubjectRegistedData : ISubjectRegistedData
    {
        NHibernate.ISessionFactory _sefact;

        public SubjectRegistedData(string connectionString)
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
        public IList<SubjectRegisted> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubjectRegisted GetByID(object key)
        {
            throw new NotImplementedException();
        }

        public DataTable GetResultSubjectRegisted(int id)
        {
            DataTable dataTable = new DataTable();
            using (var session = _sefact.OpenSession())
            {
                string sqlQuery = "Select SOLANHOC, DANGKYMH.MAMH, TENMH, DTP, DQT, RATEDQT, RATEDTP, DTK, KETQUA" +
                                  " FROM DANGKYMH INNER JOIN MONHOC ON MONHOC.MAMH=DANGKYMH.MAMH" +
                                  $" WHERE MSSV={id}" +
                                  " ORDER BY SOLANHOC ASC";
                IQuery query = session.CreateSQLQuery(sqlQuery);

                dataTable.Columns.Add("SOLANHOC", typeof(int));
                dataTable.Columns.Add("MAMH", typeof(string));
                dataTable.Columns.Add("TENMH", typeof(string));
                dataTable.Columns.Add("DTP", typeof(decimal));
                dataTable.Columns.Add("DQT", typeof(decimal));
                dataTable.Columns.Add("RATEDQT", typeof(string));
                dataTable.Columns.Add("RATEDTP", typeof(string));
                dataTable.Columns.Add("DTK", typeof(decimal));
                dataTable.Columns.Add("KETQUA", typeof(string));

                var results = query.List<object[]>();
                foreach (var row in results)
                {
                    dataTable.Rows.Add(row);
                }

                if (results is null) return null;
            }

            return dataTable;
        }
        public IList<SubjectRegisted> GetSubjectRegisted(int Id)
        {
            IList<SubjectRegisted> subjectRegisteds = new List<SubjectRegisted>();
            try
            {
                using (var session = _sefact.OpenSession())
                {
                    string query = " SELECT * FROM DANGKYMH dm" +
                                    $" WHERE MSSV = {Id} AND NOT EXISTS (" +
                                    " SELECT 1" +
                                    " FROM DANGKYMH dm2" +
                                    " WHERE dm.MSSV = dm2.MSSV " +
                                    " AND dm.MAMH = dm2.MAMH" +
                                    " AND dm.SOLANHOC < dm2.SOLANHOC);";
                    IQuery sqlQuery = session.CreateSQLQuery(query).AddEntity(typeof(SubjectRegisted));

                    subjectRegisteds = sqlQuery.List<SubjectRegisted>();
                }
                return subjectRegisteds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string InsertDataScore(SubjectRegisted subjectRegisted)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(subjectRegisted);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                            return ex.ToString();

                    }
                }
            }
            return "Nhập điểm thành công";
        }


        public string SubjectRegister(SubjectRegisted subjectRegisted)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(subjectRegisted);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        return ex.ToString();

                    }
                }
            }
            return "Đăng ký môn thành công";
        }

        public string DeleteRegisted(SubjectRegisted subjectRegisted)
        {
            using (var session = _sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(subjectRegisted);
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        return ex.ToString();

                    }
                }
            }
            return "Xoá thành công";
        }
    }
}
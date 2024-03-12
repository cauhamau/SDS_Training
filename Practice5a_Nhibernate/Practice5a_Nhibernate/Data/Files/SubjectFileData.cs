using NHibernate.Dialect;
using NHibernate.Driver;
using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Data.Files
{
    internal class SubjectFileData : ISubjectData
    {
        NHibernate.Cfg.Configuration _cfg;
        NHibernate.ISessionFactory _sefact;

        public SubjectFileData(string connectionString)
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

        public IList<Subject> GetAll()
        {
            var _session = _sefact.OpenSession();
            IList<Subject> subjects = _session.CreateCriteria<Subject>().List<Subject>();
            _session.Close();
            return subjects;
        }

    }
}

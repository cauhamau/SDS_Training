using NHibernate.Dialect;
using NHibernate.Driver;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Data
{
    public class UserData : IUserData
    {
        NHibernate.ISessionFactory _sefact;

        public UserData(string connectionString)
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

        public IList<User> GetAll()
        {
            IList<User> users;
            using (var session = _sefact.OpenSession())
            {
                try
                {
                    users = session.CreateCriteria<User>().List<User>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return users;
        }

        public User GetByID(object id)
        {
            User user;
            using (var session = _sefact.OpenSession())
            {
                try
                {
                    user = session.Get<User>(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            return user;
        }
    }
}
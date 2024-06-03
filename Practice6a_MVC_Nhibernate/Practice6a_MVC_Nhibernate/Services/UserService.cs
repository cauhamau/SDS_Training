using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }

        public IList<User> GetAll()
        {
            return _userData.GetAll();
        }

        public User GetByID(object key)
        {
            return _userData.GetByID(key);
        }

        public User CheckAccountLogIn(string username, byte[] password)
        {
            IList<User> users = _userData.GetAll();
            User user = users.FirstOrDefault(u => u.USERNAME==username);
            if (user==null)
            {
                return null;
            }
            else if(user.PASSWORD.SequenceEqual(password))
            {
                return user;
            }
            return null;
        }
    }
}
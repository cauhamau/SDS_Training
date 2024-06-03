using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Interfaces.IServices
{
    internal interface IUserService:IBasicService<User>
    {
        User CheckAccountLogIn(string username, byte[] password);
    }
}
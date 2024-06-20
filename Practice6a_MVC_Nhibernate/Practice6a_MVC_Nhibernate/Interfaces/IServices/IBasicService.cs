using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IServices
{
    internal interface IBasicService<T> where T : class
    {
        T GetByID(object key);
        IList<T> GetAll();
    }
}

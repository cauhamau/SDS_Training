using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IData
{
    internal interface IBasicData<T> where T : class
    {
        T GetByID(object key);
        IList<T> GetAll();
    }
}

using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practice6a_MVC_Nhibernate.Interfaces.IData
{
    internal interface ISubjectData : IBasicData<Subject>
    {
        IList<Subject> GetUnregistered(int Id);
    }
}

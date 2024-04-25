using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IServices
{
    internal interface ISubjectService : IBasicService<Subject>
    {
        IList<Subject> GetUnregistered(int Id);
    }
}

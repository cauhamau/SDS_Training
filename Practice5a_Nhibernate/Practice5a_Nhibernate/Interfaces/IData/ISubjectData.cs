
using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Interfaces.IData
{
    internal interface ISubjectData
    {
        IList<Subject> GetAll();
    }
}

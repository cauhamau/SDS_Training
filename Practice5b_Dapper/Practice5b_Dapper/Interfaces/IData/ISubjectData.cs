using Practice5b_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Interfaces.IData
{
    internal interface ISubjectData
    {
        List<Subject> GetAll();
    }
}

using Practice5b_Dapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Interfaces.IServices
{
    internal interface ISubjectService
    {
        List<Subject> GetAll();
        void ShowList(List<Subject> subjects);
    }
}

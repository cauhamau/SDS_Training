using Practice5a_Nhibernate.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Interfaces.IServices
{
    internal interface ISubjectService
    {
        List<MonHoc> GetAll();
        void ShowList(List<MonHoc> subjects);
    }
}

using Practice4_CastleWindsor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_CastleWindsor.Interfaces.IServices
{
    internal interface ISubjectService
    {
        List<MonHoc> GetAll();
        void ShowList(List<MonHoc> subjects);
    }
}

using Practice3_ServiceDI_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Interfaces.IData
{
    internal interface ISubjectData
    {
        List<MonHoc> GetAll();
    }
}

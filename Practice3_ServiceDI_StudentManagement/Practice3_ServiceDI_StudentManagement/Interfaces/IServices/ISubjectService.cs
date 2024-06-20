using Practice3_ServiceDI_StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Interfaces.IServices
{
    internal interface ISubjectService
    {
        List<MonHoc> GetAll();
        void ShowList(List<MonHoc> subjects);
    }
}

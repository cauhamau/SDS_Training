using Practice3_ServiceDI_StudentManagement.Interfaces.IData;
using Practice3_ServiceDI_StudentManagement.Interfaces.IServices;
using Practice3_ServiceDI_StudentManagement.Model;
using Practice3_ServiceDI_StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;
        public SubjectService() { }

        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public List<MonHoc> GetAll()
        {
            return _subjectData.GetAll();
        }

        public void ShowList(List<MonHoc> subjects)
        {
            {
                var t = new TablePrinter("Mã môn học", "Tên môn học", "Tỉ lệ điểm thành phần", "Tỉ lệ điểm quá trình", "Số tiết");
                foreach (var s in subjects)
                {
                    t.AddRow(s.MaMH, s.TenMH, s.RateDTP, s.RateDQT, s.SoTiet);
                }
                t.Print();

            }
        }
    }
}

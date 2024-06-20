using Practice4_CastleWindsor.Interfaces.IData;
using Practice4_CastleWindsor.Interfaces.IServices;
using Practice4_CastleWindsor.Model;
using Practice4_CastleWindsor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_CastleWindsor.Services
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

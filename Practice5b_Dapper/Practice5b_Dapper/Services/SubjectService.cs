using Practice5b_Dapper.Interfaces.IData;
using Practice5b_Dapper.Interfaces.IServices;
using Practice5b_Dapper.Model;
using Practice5b_Dapper.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5b_Dapper.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;
        public SubjectService() { }

        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public List<Subject> GetAll()
        {
            return _subjectData.GetAll();
        }

        public void ShowList(List<Subject> subjects)
        {
            {
                var t = new TablePrinter("Mã môn học", "Tên môn học", "Tỉ lệ điểm thành phần", "Tỉ lệ điểm quá trình", "Số tiết");
                foreach (var s in subjects)
                {
                    t.AddRow(s.MAMH, s.TENMH, s.RATEDTP, s.RATEDQT, s.SOTIET);
                }
                t.Print();

            }
        }
    }
}

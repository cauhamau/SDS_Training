using Practice5a_Nhibernate.Interfaces.IData;
using Practice5a_Nhibernate.Interfaces.IServices;
using Practice5a_Nhibernate.Models.Classes;
using Practice5a_Nhibernate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;
        public SubjectService() { }

        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public IList<Subject> GetAll()
        {
            return _subjectData.GetAll();
        }

        public void ShowList(IList<Subject> subjects)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Models.Classes
{
    internal class Subject
    {
        string _MaMH;
        string _TenMH;
        int _SoTiet;
        float _RateDQT, _RateDTP;

        public Subject() { }
        public Subject(string maMH, string tenMH, float rateDQT, float rateDTP, int soTiet)
        {
            _MaMH = maMH;
            _TenMH = tenMH;
            _SoTiet = soTiet;
            _RateDQT = rateDQT;
            _RateDTP = rateDTP;
        }

        public virtual string TENMH { get => _TenMH; set => _TenMH = value; }
        public virtual int SOTIET { get => _SoTiet; set => _SoTiet = value; }
        public virtual float RATEDQT { get => _RateDQT; set => _RateDQT = value; }
        public virtual float RATEDTP { get => _RateDTP; set => _RateDTP = value; }
        public virtual string MAMH { get => _MaMH; set => _MaMH = value; }
    }
}

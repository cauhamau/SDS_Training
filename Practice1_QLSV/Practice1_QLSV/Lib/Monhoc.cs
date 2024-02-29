using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1_QLSV.Lib
{
    class Monhoc
    {
        string _MaMH;
        string _TenMH;
        int _SoTiet;
        float _RateDQT, _RateDTP;

        public string TenMH { get => _TenMH; set => _TenMH = value; }
        public int SoTiet { get => _SoTiet; set => _SoTiet = value; }
        public float RateDQT { get => _RateDQT; set => _RateDQT = value; }
        public float RateDTP { get => _RateDTP; set => _RateDTP = value; }
        public string MaMH { get => _MaMH; set => _MaMH = value; }

    }
}

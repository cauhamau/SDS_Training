using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_CastleWindsor.Model
{
    internal class MonHoc
    {
        string _MaMH;
        string _TenMH;
        int _SoTiet;
        float _RateDQT, _RateDTP;

        public MonHoc(string maMH, string tenMH,  float rateDQT, float rateDTP, int soTiet)
        {
            _MaMH = maMH;
            _TenMH = tenMH;
            _SoTiet = soTiet;
            _RateDQT = rateDQT;
            _RateDTP = rateDTP;
        }

        public string TenMH { get => _TenMH; set => _TenMH = value; }
        public int SoTiet { get => _SoTiet; set => _SoTiet = value; }
        public float RateDQT { get => _RateDQT; set => _RateDQT = value; }
        public float RateDTP { get => _RateDTP; set => _RateDTP = value; }
        public string MaMH { get => _MaMH; set => _MaMH = value; }
    }
}

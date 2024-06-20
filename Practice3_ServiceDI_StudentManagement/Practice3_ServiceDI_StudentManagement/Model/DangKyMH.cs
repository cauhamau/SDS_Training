using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_ServiceDI_StudentManagement.Model
{
    internal class DangKyMH
    {
        string _MaMH;
        int _MSSV;
        float _DQT;
        float _DTP;

        public DangKyMH(string maMH, int mSSV, float dQT, float dTP)
        {
            _MaMH = maMH;
            _MSSV = mSSV;
            _DQT = dQT;
            _DTP = dTP;
        }

        public string MaMH { get => _MaMH; set => _MaMH = value; }
        public int MSSV { get => _MSSV; set => _MSSV = value; }
        public float DQT { get => _DQT; set => _DQT = value; }
        public float DTP { get => _DTP; set => _DTP = value; }
    }
}

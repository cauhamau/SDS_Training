using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC.Models
{
    public class SubjectRegisted
    {
        string _MaMH;
        int _MSSV;
        float _DQT;
        float _DTP;

        public SubjectRegisted() { }
        public SubjectRegisted(string maMH, int mSSV, float dQT, float dTP)
        {
            _MaMH = maMH;
            _MSSV = mSSV;
            _DQT = dQT;
            _DTP = dTP;
        }
        public SubjectRegisted(string maMH, int mSSV, decimal dQT, decimal dTP)
        {
            _MaMH = maMH;
            _MSSV = mSSV;
            _DQT = (float)dQT;
            _DTP = (float)dTP;
        }
        public string MAMH { get => _MaMH; set => _MaMH = value; }
        public int MSSV { get => _MSSV; set => _MSSV = value; }
        public float DQT { get => _DQT; set => _DQT = value; }
        public float DTP { get => _DTP; set => _DTP = value; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5a_Nhibernate.Models.Classes
{
    internal class SubjectRegisted
    {
        string _MaMH;
        int _MSSV;
        float _DQT;
        float _DTP;

        //public SubjectRegisted() { }
        //public SubjectRegisted(string maMH, int mSSV, float dQT, float dTP)
        //{
        //    _MaMH = maMH;
        //    _MSSV = mSSV;
        //    _DQT = dQT;
        //    _DTP = dTP;
        //}

        public virtual string MAMH { get => _MaMH; set => _MaMH = value; }
        public virtual int MSSV { get => _MSSV; set => _MSSV = value; }
        public virtual float DQT { get => _DQT; set => _DQT = value; }
        public virtual float DTP { get => _DTP; set => _DTP = value; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as SubjectRegisted;
            if (t == null)
                return false;
            if (MAMH == t.MAMH && MSSV == t.MSSV)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (MAMH + "|" + MSSV).GetHashCode();
        }
    }
}

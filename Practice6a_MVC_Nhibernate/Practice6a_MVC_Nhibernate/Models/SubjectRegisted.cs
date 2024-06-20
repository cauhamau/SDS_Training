using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Models
{
    public class SubjectRegisted
    {
        int _SoLanHoc;
        string _MaMH;
        int _MSSV;
        decimal? _DQT;
        decimal? _DTP;
        decimal? _DTK;
        string _KETQUA;
        public virtual string MAMH { get => _MaMH; set => _MaMH = value; }
        public virtual int MSSV { get => _MSSV; set => _MSSV = value; }
        public virtual decimal? DQT { get => _DQT; set => _DQT = value; }
        public virtual decimal? DTP { get => _DTP; set => _DTP = value; }
        public virtual int SOLANHOC { get => _SoLanHoc; set => _SoLanHoc = value; }
        public virtual decimal? DTK { get => _DTK; set => _DTK = value; }
        public virtual string KETQUA { get => _KETQUA; set => _KETQUA = value; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as SubjectRegisted;
            if (t == null)
                return false;
            if (MAMH == t.MAMH && MSSV == t.MSSV && SOLANHOC==t.SOLANHOC)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return (MAMH + "|" + MSSV + "|" + SOLANHOC).GetHashCode();
        }
    }
}
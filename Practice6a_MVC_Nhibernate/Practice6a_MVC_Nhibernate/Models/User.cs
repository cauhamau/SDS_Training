using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Models
{
    public class User
    {
        private string uSERNAME;
        private string pASSWORD;
        private string rOLE;

        public virtual string USERNAME { get => uSERNAME; set => uSERNAME = value; }
        public virtual string PASSWORD { get => pASSWORD; set => pASSWORD = value; }
        public virtual string ROLE { get => rOLE; set => rOLE = value; }
    }
}
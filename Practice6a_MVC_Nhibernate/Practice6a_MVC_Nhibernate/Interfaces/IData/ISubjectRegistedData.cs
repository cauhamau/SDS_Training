using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IData
{
    internal interface ISubjectRegistedData : IBasicData<SubjectRegisted>
    {
        DataTable GetResultSubjectRegisted(int id);
        string InsertDataScore(SubjectRegisted subjectRegisted);

        IList<SubjectRegisted> GetSubjectRegisted(int id);

        string SubjectRegister(SubjectRegisted subjectRegisted);

        string DeleteRegisted(SubjectRegisted subjectRegisted);
    }
}
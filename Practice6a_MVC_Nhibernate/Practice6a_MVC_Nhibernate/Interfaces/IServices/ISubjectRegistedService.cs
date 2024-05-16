using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice6a_MVC_Nhibernate.Interfaces.IServices
{
    internal interface ISubjectRegistedService : IBasicService<SubjectRegisted>
    {
        DataTable GetResultSubjectRegisted(int Id);
        string InsertDataScore(SubjectRegisted subjectRegisted);

        IList<SubjectRegisted> GetSubjectRegisted(int Id);

        string SubjectRegister(SubjectRegisted subjectRegisted);
        string DeleteRegisted(SubjectRegisted subjectRegisted);
    }
}

using Practice6a_MVC_Nhibernate.Data;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Services
{
    internal class SubjectRegistedService : ISubjectRegistedService

    {
        private readonly ISubjectRegistedData _registedData;

        public SubjectRegistedService(ISubjectRegistedData registedData)
        {
            _registedData = registedData;
        }

        public IList<SubjectRegisted> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubjectRegisted GetByID(object key)
        {
            throw new NotImplementedException();
        }

        public DataTable GetResultSubjectRegisted(int id)
        {
            return _registedData.GetResultSubjectRegisted(id);
        }

        public string InsertDataScore(SubjectRegisted subjectRegisted)
        {
            return _registedData.InsertDataScore(subjectRegisted);
        }
        public IList<SubjectRegisted> GetSubjectRegisted(int id)
        {
            return _registedData.GetSubjectRegisted(id);
        }


        public string SubjectRegister(SubjectRegisted subjectRegisted)
        {
            return _registedData.SubjectRegister(subjectRegisted);
        }

        public string DeleteRegisted(SubjectRegisted subjectRegisted)
        {
            return _registedData.DeleteRegisted(subjectRegisted);
        }
    }
}
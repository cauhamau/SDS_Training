using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.Services
{
    internal class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;

        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public IList<Subject> GetAll()
        {
            throw new NotImplementedException();
        }

        public Subject GetByID(object key)
        {
            throw new NotImplementedException();
        }

        public IList<Subject> GetUnregistered(int id)
        {
            return _subjectData.GetUnregistered(id);
        }
    }
}
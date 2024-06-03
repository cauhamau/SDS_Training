using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Practice6a_MVC_Nhibernate.Data;
using Practice6a_MVC_Nhibernate.Interfaces.IData;
using Practice6a_MVC_Nhibernate.Interfaces.IServices;
using Practice6a_MVC_Nhibernate.Models;
using Practice6a_MVC_Nhibernate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.App_Start
{
    public class DependencyInstaller : IWindsorInstaller
    {
        string _connectionString = "data source=.;initial catalog=QLSV;integrated security=true;";
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
                       Component.For<ISubjectRegistedService>().ImplementedBy<SubjectRegistedService>(),
                       Component.For<ISubjectService>().ImplementedBy<SubjectService>(),
                       Component.For<IUserService>().ImplementedBy<UserService>(),
                       Component.For<IEncryptService>().ImplementedBy<EncryptService>(),
                       Component.For<ISubjectRegistedData>().ImplementedBy<SubjectRegistedData>().DependsOn(Dependency.OnValue("connectionString", _connectionString)),
                       Component.For<IStudentData>().ImplementedBy<StudentData>().DependsOn(Dependency.OnValue("connectionString", _connectionString)), //"data source=.;initial catalog=QLSV;integrated security=true;")),
                       Component.For<ISubjectData>().ImplementedBy<SubjectData>().DependsOn(Dependency.OnValue("connectionString", _connectionString)),
                       Component.For<IUserData>().ImplementedBy<UserData>().DependsOn(Dependency.OnValue("connectionString", _connectionString)));//"data source=.;initial catalog=QLSV;integrated security=true;")));
        }
    }
}
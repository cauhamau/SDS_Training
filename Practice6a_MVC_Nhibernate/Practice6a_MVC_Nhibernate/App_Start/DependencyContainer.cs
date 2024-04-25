using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice6a_MVC_Nhibernate.App_Start
{
    public class DependencyContainer : IContainerAccessor, IDisposable
    {
        readonly IWindsorContainer _container;

        public DependencyContainer(IWindsorContainer container)
        {
            _container = container;
        }
        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static DependencyContainer Bootstrap()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            return new DependencyContainer(container);
        }
        public void Dispose()
        {
            Container.Dispose();
        }

    }
}
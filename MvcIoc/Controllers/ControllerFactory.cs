using IocContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcIoc.Controllers
{
    public class ControllerFactory : DefaultControllerFactory
    {
        private readonly Ioc _container;

        public ControllerFactory(Ioc container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;
            return _container.Resolve(controllerType) as Controller;
        }
        
    }
}
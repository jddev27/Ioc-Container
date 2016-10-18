using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IocContainer;
using MvcIoc.Services;
using MvcIoc.Controllers;

namespace MvcIoc.App_Start
{
    public static class IocConfigurator
    {
        public static void configureContainer(Ioc container)
        {
    
            registerService(container);

            
            

        }

        private static void registerService(Ioc container)
        {
            container.Register<ILocalWeatherProvider, LocalWeatherProvider>();
            container.Register<IocController, IocController>();
            container.Register<HomeController, HomeController>();
          

        }

     
    }
}
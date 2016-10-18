using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcIoc.Services;

namespace MvcIoc.Controllers
{
    public class IocController : Controller
    {
        private ILocalWeatherProvider _weatherProvider;

        //public IocController () {
        //}
        public IocController(ILocalWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Message = _weatherProvider.getLocalWeatherServiceByCity("Salt Lake City");
            return View();
        }
    }
}
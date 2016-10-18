using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIoc.Services
{
    public class LocalWeatherProvider : ILocalWeatherProvider
    {
        public string getLocalWeatherServiceByCity(string city)
        {
            return "It is rainning in " + city;
        }
    }
}
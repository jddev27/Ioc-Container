using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcIoc.Services
{
    public interface ILocalWeatherProvider
    {
          string getLocalWeatherServiceByCity(string city);
    }
}

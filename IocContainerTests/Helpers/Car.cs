using IocContainerTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainerTests
{
    public class Car : ICar
    {
        public void print()
        {
            Console.WriteLine("This is a Car");
        }
    }
}

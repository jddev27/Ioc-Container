using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainerTests.Helpers
{
    class Speakers : ISpeakers
    {   
        public void sound()
        {
            Console.WriteLine("I'm making a sound");
        }
    }
}

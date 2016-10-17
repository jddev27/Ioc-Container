using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainerTests.Helpers
{
    class SoundSystem : ISoundSystem
    {
        ISpeakers logitech { get; set; }
        ICdPlayer pionner { get; set; }

        public SoundSystem(ISpeakers logitech, ICdPlayer pionner)
        {
            this.logitech = logitech;
            this.pionner = pionner;
        }

        public void reproduceMusic()
        {
            Console.WriteLine("I am playing music");
        }



    }
}

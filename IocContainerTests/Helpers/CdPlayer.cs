using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IocContainerTests.Helpers
{
    class CdPlayer : ICdPlayer
    {
        public void playingCd()
        {
            Console.WriteLine("I'm playing cds");
        }
    }
}

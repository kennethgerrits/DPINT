using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionStarter.Library
{
    public class KeyBoard : IInstrument
    {
        public string Play()
        {
          return  "ping pling ping";

        }
    }
}

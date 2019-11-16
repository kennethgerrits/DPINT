using System;
using System.Collections.Generic;

namespace DependencyInjectionStarter.Library
{
    public class RockBand
    {
        private List<IInstrument> _instruments;

        public RockBand(List<IInstrument> instruments)
        {
            _instruments = instruments;
        }
        public void DoSoundCheck()
        {
            foreach (var instrument in _instruments)
            {
                Console.WriteLine(instrument.Play());
            }
        }
    }
}

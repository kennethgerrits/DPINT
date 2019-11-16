using System;
using System.Collections.Generic;

namespace DependencyInjectionStarter.Library
{
    public class RockBand
    {
        private List<IInstrument> instruments;

        public RockBand(List<IInstrument> instruments)
        {
            this.instruments = instruments;
        }

        public void DoSoundCheck()
        {
            this.instruments.ForEach(i => Console.WriteLine(i.Play()));
        }
    }
}

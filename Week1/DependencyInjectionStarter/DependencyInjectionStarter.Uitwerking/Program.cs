using System;

namespace DependencyInjectionStarter
{
    class Program
    {
        /** Testing 123 */
        static void Main()
        {
            ////via custom create band
            //List<IInstrument> instrumenten = new List<IInstrument>();
            //instrumenten.Add(new Guitar());
            //instrumenten.Add(new Guitar());
            //instrumenten.Add(new BassGuitar());
            //instrumenten.Add(new Drums());
            //instrumenten.Add(new Vocal());

            //Via locator
            var locator = new BandLocator();
            var rockBand = locator.DefaultRockband;
            rockBand.DoSoundCheck();
            Console.ReadLine();
        }
    }
}

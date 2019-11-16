using System;
using System.Collections.Generic;
using DependencyInjectionStarter.Library;

namespace DependencyInjectionStarter
{
    internal class Program
    {
        /** Testing 123 */

        //groetjes stijn

        private static void Main()
        {
            /** Metallica  */
            var instruments = new List<IInstrument>
            {
                new BassGuitar(),
                new Guitar(),
                new Guitar(),
                new Drums(),
                new Vocal()
            };

            var rockBand = new RockBand(instruments);
            Console.WriteLine("Metallica:");
            rockBand.DoSoundCheck();
            Console.WriteLine();

            /** Coldplay  */
            var instruments2 = new List<IInstrument>
            {
                new BassGuitar(),
                new Guitar(),
                new Drums(),
                new Vocal(),
                new KeyBoard()
            };

            var rockBand2 = new RockBand(instruments2);
            Console.WriteLine("Coldplay:");
            rockBand2.DoSoundCheck();

            Console.ReadLine();
        }
    }
}
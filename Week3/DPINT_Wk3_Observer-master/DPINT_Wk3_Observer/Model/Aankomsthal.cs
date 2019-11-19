using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk3_Observer.Model
{
    public class Aankomsthal : IObserver<Baggageband>
    {
        public ObservableCollection<Vlucht> WachtendeVluchten { get; private set; }
        public ObservableCollection<Baggageband> Baggagebanden { get; private set; }

        public Aankomsthal()
        {
            WachtendeVluchten = new ObservableCollection<Vlucht>();
            Baggagebanden = new ObservableCollection<Baggageband>
            {
                new Baggageband("Band 1", 30),
                new Baggageband("Band 2", 60),
                new Baggageband("Band 3", 90)
            };

            foreach (var bb in Baggagebanden)
                bb.Subscribe(this);
        }

        public void NieuweInkomendeVlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            Vlucht newVlucht = new Vlucht(vertrokkenVanuit, aantalKoffers);
            Baggageband legeBand = Baggagebanden.FirstOrDefault(b => b.AantalKoffers == 0);

            if (legeBand == null)
                WachtendeVluchten.Add(newVlucht);
            else
                legeBand.HandelNieuweVluchtAf(newVlucht);

        }

        public void WachtendeVluchtenNaarBand()
        {
            Baggageband legeBand = Baggagebanden.FirstOrDefault(bb => bb.AantalKoffers == 0);
            Vlucht volgendeVlucht = WachtendeVluchten.FirstOrDefault();
           
            if (legeBand == null || volgendeVlucht == null)
                return;

            WachtendeVluchten.RemoveAt(0);
            legeBand.HandelNieuweVluchtAf(volgendeVlucht);
        }

        public void OnNext(Baggageband value)
        {
            WachtendeVluchtenNaarBand();
        }

        //gebruiken we niet
        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        //gebruiken we niet
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}

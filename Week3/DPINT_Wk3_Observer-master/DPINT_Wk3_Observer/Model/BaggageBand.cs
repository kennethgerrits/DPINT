﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPINT_Wk3_Observer.Observer;

namespace DPINT_Wk3_Observer.Model
{
    public class Baggageband : Observable<Baggageband>
    {
        public string Naam { get; set; }
        private int _aantalKoffersPerMinuut;
        public int AantalKoffers { get; set; }
        public string VluchtVertrokkenVanuit { get; set; }
        private Timer _huidigeVluchtTimer;

        public Baggageband(string naam, int aantalKoffersPerMinuut)
        {
            Naam = naam;
            _aantalKoffersPerMinuut = aantalKoffersPerMinuut;
        }

        public void HandelNieuweVluchtAf(Vlucht vlucht)
        {
            VluchtVertrokkenVanuit = vlucht.VertrokkenVanuit;
            AantalKoffers = vlucht.AantalKoffers;

            if (_huidigeVluchtTimer != null)
            {
                _huidigeVluchtTimer.Stop();
            }

            _huidigeVluchtTimer = new Timer {Interval = (int) ((60.0 / _aantalKoffersPerMinuut) * 1000)};
            _huidigeVluchtTimer.Tick += KofferVanBandGehaald;

            _huidigeVluchtTimer.Start();

            Notify(this);
        }

        private void KofferVanBandGehaald(object sender, EventArgs e)
        {
            AantalKoffers--;

            if(AantalKoffers == 0)
            {
                VluchtVertrokkenVanuit = null;
                _huidigeVluchtTimer.Stop();
            }
            Notify(this);
        }
    }
}

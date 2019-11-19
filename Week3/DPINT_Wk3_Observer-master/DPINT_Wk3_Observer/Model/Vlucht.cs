﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPINT_Wk3_Observer.Observer;

namespace DPINT_Wk3_Observer.Model
{
    public class Vlucht : Observable<Vlucht>
    {
        public Vlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            VertrokkenVanuit = vertrokkenVanuit;
            AantalKoffers = aantalKoffers;
        }

        private string _vertrokkenVanuit;
        public string VertrokkenVanuit
        {
            get { return _vertrokkenVanuit; }
            set { _vertrokkenVanuit = value; Notify(this); } // TODO: Kunnen we hier straks net zoiets doen als RaisePropertyChanged?
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get { return _aantalKoffers; }
            set { _aantalKoffers = value; Notify(this); } // TODO: Kunnen we hier straks net zoiets doen als RaisePropertyChanged?
        }

    }
}

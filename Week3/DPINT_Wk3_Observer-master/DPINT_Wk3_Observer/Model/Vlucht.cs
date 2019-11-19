using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPINT_Wk3_Observer.Observer;

namespace DPINT_Wk3_Observer.Model
{
    public class Vlucht : Observable<Vlucht>
    {
        public Vlucht(string vertrokkenVanuit, int aantalKoffers)
        {
            VertrokkenVanuit = vertrokkenVanuit;
            AantalKoffers = aantalKoffers;

            _waitingTimer = new Timer { Interval = 1000 };
            _waitingTimer.Tick += (o, e) => TimeWaiting = TimeWaiting.Add(new TimeSpan(0, 0, 1));
            _waitingTimer.Start();
        }

        private string _vertrokkenVanuit;
        public string VertrokkenVanuit
        {
            get => _vertrokkenVanuit;
            set { _vertrokkenVanuit = value; Notify(this); }
        }

        private int _aantalKoffers;
        public int AantalKoffers
        {
            get => _aantalKoffers;
            set { _aantalKoffers = value; Notify(this); }
        }

        private readonly Timer _waitingTimer;

        private TimeSpan _timeWaiting;
        public TimeSpan TimeWaiting
        {
            get => _timeWaiting;
            set { _timeWaiting = value; Notify(this); }
        }
        public void StopWaiting()
        {
            _waitingTimer.Stop();
            _waitingTimer.Dispose();
        }
    }
}

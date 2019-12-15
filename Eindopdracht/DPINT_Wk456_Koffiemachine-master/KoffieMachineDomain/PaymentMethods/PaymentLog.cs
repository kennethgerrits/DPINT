using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.PaymentMethods
{
    public class PaymentLog
    {
        public ObservableCollection<string> Log { get; private set; }

        public void Add(string logLine)
        {
            Log.Add(logLine);
        }

        public void Add(string[] logLines)
        {
            foreach (string line in logLines)
            {
                Add(line);
            }
        }

        public PaymentLog()
        {
            Log = new ObservableCollection<string>();
        }
    }
}

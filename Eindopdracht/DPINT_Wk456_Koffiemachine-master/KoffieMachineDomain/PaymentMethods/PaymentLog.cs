using System.Collections.ObjectModel;

namespace KoffieMachineDomain.PaymentMethods
{
    public class PaymentLog
    {
        public PaymentLog()
        {
            Log = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Log { get; }

        public void Add(string logLine)
        {
            Log.Add(logLine);
        }

        public void Add(string[] logLines)
        {
            foreach (var line in logLines) Add(line);
        }
    }
}
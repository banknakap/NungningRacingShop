using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NungningRacingShop
{
    public class NNObservable
    {
        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    public class NNObserver
    {
        public void HandleEvent(object sender, EventArgs args)
        {
            Console.WriteLine("Something happened to " + sender);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface ISubject
    {
        void AdicionarObservers(IObserver observer);

        void MonitorWorkers(ISubject dateObservers);

    }
}

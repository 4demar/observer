using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main()
        {
            var singleton = Singleton.ClassSingleton.GetInstancia;

            IniciarProcesso iniciar = new IniciarProcesso();
            var monitor =  ConcreteSubject.GetInstancia;

            //sem observer
            //for (int i = 0; i <= 2; i++)
            //{
            //    iniciar.IniciarPaint(i, GestorSubject);
            //}

            //com observer
            for (int i = 0; i <= 2; i++)
            {
                iniciar.IniciarAppObserver(i, monitor);
            }

            Thread.Sleep(TimeSpan.FromSeconds(20)); // 30 Segundos

            //monitorar.MonitorarProcesso(); //sem observer
            monitor.MonitorWorkers(monitor); //Com observer



        }
    }
}

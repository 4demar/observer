using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ConsoleApp1
{
    public class ConcreteSubject : ISubject
    {
        public static ConcreteSubject instancia;
        public ConcreteSubject() { }
        public static ConcreteSubject GetInstancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConcreteSubject();
                }
                return instancia;
            }
        }

        private List<IObserver> observers = new List<IObserver>();

        public void AdicionarObservers(IObserver observer)
        {
            Console.WriteLine("Observer Adicionado : App" + ((ConcreteObserver)observer).NumeroApp);
            observers.Add(observer);
        }

        public void RemoveObserver(int numero)
        {
            var observer = observers.Find(x => x.getNumeroApp() == numero);
            observers.Remove(observer);
        }

        public void MonitorWorkers(ISubject dateObservers)
        {
            IniciarProcesso iniciar = new IniciarProcesso();
            Process[] processAberto = Process.GetProcessesByName("mspaint");
            List<int> processoAtual = new List<int>();
            List<int> listObserver = new List<int>();
            List<IProcesso> processoObserver = new List<IProcesso>();
            for (int i = 0; i < processAberto.Length; i++)
            {
                processoAtual.Add(processAberto[i].Id); //gera lista com o numero dos PID, pelo Process
            }

            foreach (IObserver observer in observers)
            {
                listObserver.Add(observer.getListaPID()); //gera lista com o numero dos PID, pelo Observer
                processoObserver.Add(observer.getListaProcesso());
            }

            var listaCaiu = listObserver.Except(processoAtual).ToList(); //mostra PID que foi fechado...

            for (int i = 0; i < listaCaiu.Count; i++)
            {
                Console.WriteLine("Paint de PID: " + listaCaiu[i] + " fechou...");
                foreach (IProcesso dados in processoObserver)
                {
                    if (dados.numeroPID == listaCaiu[i])
                    {
                        Console.WriteLine("Paint: " + dados.nomeProcesso + " fechou...");
                        processoObserver.Remove(dados);
                        RemoveObserver(dados.nomeProcesso);

                        iniciar.IniciarAppObserver(dados.nomeProcesso, instancia);
                        break;
                    }
                }
            }
            Thread.Sleep(TimeSpan.FromSeconds(30));
            MonitorWorkers(dateObservers);// 30 Segundos
        }
    }
}

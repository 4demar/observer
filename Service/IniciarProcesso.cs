using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class IniciarProcesso
    {
        
        public void IniciarPaint(int numero)
        {
            var singleton = Singleton.ClassSingleton.GetInstancia;
            Process inicioWorker = new Process();

            inicioWorker.StartInfo.CreateNoWindow = false;
            inicioWorker.StartInfo.UseShellExecute = true;
            inicioWorker.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            inicioWorker.StartInfo.WorkingDirectory = "%windir%\\system32";
            inicioWorker.StartInfo.FileName = "mspaint.exe";

            //inicioWorker.StartInfo.Arguments = numeroworker.ToString();

            try
            {
                inicioWorker.Start();
                singleton.numeroProcess.Add(inicioWorker.Id);
                singleton.Processo.Add(new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void IniciarAppObserver(int numero, ISubject gestorWorker)
        {
            var singleton = Singleton.ClassSingleton.GetInstancia;
            Process inicioWorker = new Process();

            inicioWorker.StartInfo.CreateNoWindow = false;
            inicioWorker.StartInfo.UseShellExecute = true;
            inicioWorker.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            inicioWorker.StartInfo.WorkingDirectory = "%windir%\\system32";
            inicioWorker.StartInfo.FileName = "mspaint.exe";

            //inicioWorker.StartInfo.Arguments = numeroworker.ToString();

            try
            {
                inicioWorker.Start();
                var processo = new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero };
                ConcreteObserver consoleWorker = new ConcreteObserver(numero, processo, gestorWorker);
                //singleton.numeroProcess.Add(inicioWorker.Id);
                //singleton.Processo.Add(new IProcesso() { numeroPID = inicioWorker.Id, nomeProcesso = numero });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
    
}
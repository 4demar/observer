using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IObserver
    {
        int getNumeroApp();
        int getListaPID();
        IProcesso getListaProcesso();

    }
}

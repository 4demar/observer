using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SingletonSubject
    {
        public class ConcreteSubject
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


        }
    }
}

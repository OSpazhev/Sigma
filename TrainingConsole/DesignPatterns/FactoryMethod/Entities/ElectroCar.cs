using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Entities
{
    public class ElectroCar : Car
    {
        public ElectroCar()
        {
            Console.WriteLine("Elecrical car created.");
        }
    }
}

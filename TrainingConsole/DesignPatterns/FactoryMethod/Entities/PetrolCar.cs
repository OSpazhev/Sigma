using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Entities
{
    public class PetrolCar : Car
    {
        public PetrolCar()
        {
            Console.WriteLine("Petrol car created");
        }
    }
}

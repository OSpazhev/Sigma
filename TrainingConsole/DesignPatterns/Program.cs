using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.FactoryMethod.Creators;
using DesignPatterns.FactoryMethod.Entities;

namespace DesignPatterns
{
    class Program
    {
        static void FactoryMethod()
        {
            CarCreator carCreator = new ElectroCarCreator();
            carCreator.Create();
            carCreator = new PetrolCarCreator();
            carCreator.Create();
        }

        static void Main(string[] args)
        {
            FactoryMethod();
        }
    }
}

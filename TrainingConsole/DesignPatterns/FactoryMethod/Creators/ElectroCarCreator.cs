using DesignPatterns.FactoryMethod.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Creators
{
    public class PetrolCarCreator : CarCreator
    {
        public override Car Create()
        {
            return new PetrolCar();
        }
    }
}

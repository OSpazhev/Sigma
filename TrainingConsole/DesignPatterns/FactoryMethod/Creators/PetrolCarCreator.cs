using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethod.Creators
{
    public class ElectroCarCreator : CarCreator
    {
        public override Car Create()
        {
            return new ElectroCar();
        }
    }
}

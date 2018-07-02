using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsole
{
    class Cat : Animal
    {
        public string eyeColor;

        public void saySomething()
        {
            Console.WriteLine("Мяу");
        }
    }
}

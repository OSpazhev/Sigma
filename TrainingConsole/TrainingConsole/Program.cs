using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Project from Youtube https://www.youtube.com/watch?v=OzkoxBXRWYc&index=3&list=PLDywto_IU4_5UdZeKaoe-JWSl9LoaWmH9
/// </summary>
namespace TrainingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // class, object
            Animal testAnimal = new Animal();
            Animal myAnimal = new Animal(); 

            testAnimal.name = "Барсик";
            testAnimal.age = 3;

            myAnimal.name = "Мурка";
            myAnimal.age = 2;

            Console.WriteLine(testAnimal.name);

            // inheritance
            Cat myCat = new Cat();

            myCat.name = "Беляш";
            myCat.age = 1;
            myCat.eyeColor = "Синий";
            Console.WriteLine(myCat.eyeColor);
            myCat.saySomething();

            // Polymorphism
            int i1num = 2, i2num = 2;

            float f1num = 2.2F, f2num = 2.2F;

            iSum(i1num, i2num);

            fSum(f1num, f2num);

            sum(i1num, i2num);

            sum(f1num, f2num);

            // encapsulation
            //Class1.test //Error CS0426  The type name 'test' does not exist in the type 'Class1'

            Console.ReadKey();
        }

        public static void iSum(int fnum, int lnum)
        {
            Console.WriteLine(fnum + lnum);
        }
        
        public static void fSum(float fnum, float lnum)
        {
            Console.WriteLine(fnum + lnum);
        }

        public static void sum(int fnum, int lnum)
        {
            Console.WriteLine(fnum + lnum);
        }

        public static void sum(float fnum, float lnum)
        {
            Console.WriteLine(fnum + lnum);
        }
    }
}

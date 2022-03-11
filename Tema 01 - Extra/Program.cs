using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1Extra
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> genericCollection = new Set<int>();   
            for(int i = 0; i < 100000000; i++)    //puneti un numar mai mic, eu am pus sa adauge pana la 100000000 sa vad daca imi da OutOfMemoryException.
            {                                     // Later Edit, la numarul 1000000000 am dat de exceptia cu memoria
                genericCollection.AddElement(i);
            }

            foreach (int i in genericCollection)
            { 
		Console.WriteLine(i); 
	    }

            Console.ReadLine();
        }
    }
}

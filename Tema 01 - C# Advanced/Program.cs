using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1Cegeka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing for int:");
            Set<int> test2 = new Set<int>();    //creez un obiect nou cu lista goala.
           
            try
            {
                test2.Remove(9);                //Incerc sa sterg dintr-o lista goala.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);     //arunc exceptia corespunzatoare
            }

            Set<int> test1 = new Set<int>(new List<int>{-5,12,21,-3,-2,0});      // creez un obiect nou dar acum lista nu mai e goala.
            
            try
            {
                test1.Insert(4);                            //incerc sa adaug un duplicat         
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);     //arunc exceptia corenspuzatoare
            }

            try
            {
                test1.Remove(2);
            }
            catch (Exception e)            //incerc sa sterg ceva ce nu exista in lista
            {
                Console.WriteLine(e.Message); //arunc exceptia corenspuzatoare
            }

            Set<int> test3 = new Set<int>(new List<int> { 1,6,10,14,-2,7,12,4});
            try
            {
                Console.WriteLine("Merged list is :");
                Console.WriteLine(test1.Merge(test3).ToString());      // fac merge la cele doua Set-uri
            }
            catch (Exception e)           
            {
                Console.WriteLine(e.Message); 
            }




            Func<int, bool> condition = x => x >= 4;            //lambda expresie, daca tipul listei este int, luam doar numerele mai mari sau egale cu 4             
            Console.WriteLine("The subset that respects the condition is : ");
            Set<int> subSet = test1.Filter(condition);                   //pun in lista subSet rezultatul metodei care are ca parametru condition
            Console.WriteLine(subSet.ToString());  




            Console.WriteLine("\nTesting for string");
            Set<string> test4 = new Set<string>();    //creez un obiect nou cu lista goala.

            try
            {
                test4.Remove("Cegeka");                //Incerc sa sterg dintr-o lista goala.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);     //arunc exceptia corespunzatoare
            }

            Set<string> test5 = new Set<string>(new List<string> { "Ana","are","mere?","car","war"});      // creez un obiect nou dar acum lista nu mai e goala.

            try
            {
                test5.Insert("war");                            //incerc sa adaug un duplicat         
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);     //arunc exceptia corenspuzatoare
            }

            try
            {
                test5.Remove("ok");
            }
            catch (Exception e)            //incerc sa sterg ceva ce nu exista in lista
            {
                Console.WriteLine(e.Message); //arunc exceptia corenspuzatoare
            }

            Set<string> test6 = new Set<string>(new List<string> { "scump","Cegeka","Ana","mere?"});
            try
            {
                Console.WriteLine("Merged list is :");
                Console.WriteLine(test5.Merge(test6));      // fac merge la cele doua Set-uri
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Func<string, bool> condition1 = x => x.Length == 3;          
            Set<string> subSet1 = test5.Filter(condition1);
            Console.WriteLine("The subset is:");
            Console.WriteLine(subSet1.ToString());
       
        }
    }
}

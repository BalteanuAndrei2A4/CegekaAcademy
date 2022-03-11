using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1Extra
{
    public class Set<T> : IEnumerable<T>
    {
        
        private T[] collection = new T[5]; // declar un array de tip T si initializez cu o valoare aleatorie

        private int numberElements = 0; // numarul de elemtente initializat cu 0

        public void AddElement(T element)
        {
            if(numberElements == collection.Length)         //daca array-ul este full, ii dublez dimensiunea
            {
                Array.Resize(ref collection, collection.Length * 2);

                
            }
            collection[numberElements++] = element;     // adaug noul element
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i=0;i<numberElements;i++)
            {
                yield return collection[i];         // iterez si fac yield return
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1Cegeka
{
    class Set<T>
    {
        private List<T> list = new List<T>();

        public Set(List<T> list)
        {
            this.list = list;
        }
        public Set()
        {

        }
        public override string ToString()
        {
            string text = "";
            foreach(T x in list)
            {
                text += x.ToString() + " ";
            }
            return text;
        }

        public void Insert(T item)
        {
            if (item == null)
            {
                throw new Exception("Insert Null Object");
            }
            else if (this.list.Contains(item))
            {
                throw new Exception("Insert duplicate exception!");
            }
            this.list.Add(item);
        }


        public void Remove(T item)
        {
            if (item == null)
            {
                throw new Exception("Remove null object exception!");
            }
            if(this.list.Count()==0)
            {
                throw new Exception("Empty list removal exception!");
            }
            if (!this.list.Contains(item))
            {
                throw new Exception("Nonexistent item removal exception!");
            }
            this.list.Remove(item);
        }
        public bool Contains(T item)
        {

            if (item == null)
            {
                throw new Exception("Null object exception!");
            }
            if (this.list.Count() == 0)
            {
                throw new Exception("Empty list exception!");
            }
            return this.list.Contains(item);
        }
        public Set<T> Merge(Set<T> other)
        {
            if (other == null)
            {
                throw new Exception("Merge null object exception!");
            }
            try
            {
                foreach (T x in other.list)
                {

                    if (!this.Contains(x)) this.Insert(x);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this;
        }

        public Set<T> Filter(Func<T,bool> lambda)
        {
            Set<T> newSet = new Set<T>();
      
                foreach (T x in this.list)
                {
                    if (lambda(x) == true)
                    {
                        newSet.Insert(x);
                    }
                }
                
         
            return newSet;

        }
    }
}

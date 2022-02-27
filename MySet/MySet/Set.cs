using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace MySet
{
    class Set<T>:IEnumerable<T> where T: IComparable 
    {
        List<T> list = new List<T>();
        public void Add(T item)
        {
            if (!InSet(item)) list.Add(item);
        }
        public void Remove(T item)
        {
            if (!InSet(item))
            {
                throw new Exception($"Элемента {item} нет в множестве");
            }
            else
            {
                list.Remove(item);
            }
        }
        public void Add(IEnumerable<T> set)
        {
            foreach(T item in set)
            {
                Add(item);
            }
        }
        public void Remove(IEnumerable<T> set)
        {
            foreach (T item in set)
            { 
                Remove(item);   
            }
        }

        public bool InSet(T item)
        {
            return list.Contains(item);
        }
        public bool InSet(IEnumerable<T> set)
        {
            foreach(T item in set)
            {
                if (!InSet(item)) return false;
            }
            return true;
        }
        public static Set<T> operator +(Set<T> set1, Set<T> set2)
        {
            Set<T> set = new Set<T>();
            set.Add(set1);
            set.Add(set2);
            return set;
        }
        public static Set<T> operator -(Set<T> set1, Set<T> set2)
        {
            Set<T> set = new Set<T>();
            set.Add(set1);
            foreach(T item in set2)
            {
                if (set.InSet(item))
                {
                    set.Remove(item);
                }
            }
            return set;
        }
        public static Set<T> operator *(Set<T> set1, Set<T> set2)
        {
            Set<T> set = new Set<T>();
            foreach (T item in set1)
            {
                if (set2.InSet(item))
                {
                    set.Add(item);
                }
            }
            return set;
        }
        public static Set<T> XOR(Set<T> set1, Set<T> set2)
        {
            Set<T> set = new Set<T>();
            set = (set1 + set2) - (set1 * set2);
            return set;
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
        public override string ToString()
        {
            string str = "";
            foreach(T item in list)
            {
                str += item.ToString();
            }
            return str;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}

using System;

namespace MySet
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set = new Set<int>();
            int[] nums = { 1, 2, 3, 4, 5 };
            set.Add(nums);
            Set<int> set2 = new Set<int>();
            set2.Add(4);
            set2.Add(5);
            set2.Add(6);
            set2.Add(7);
            Set<int> set3 = set + set2;
            foreach(int item in set3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            set3 = Set<int>.XOR(set, set2);
            foreach (int item in set3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            set3 = set-set2;
            foreach (int item in set3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            set3.Remove(1);
            foreach (int item in set3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine(set3.InSet(2));
            Console.WriteLine(set3.InSet(new int[] { 2, 3 }));
            Console.WriteLine(set3.InSet(new int[] { 2, 3,5 }));
        }
    }
}

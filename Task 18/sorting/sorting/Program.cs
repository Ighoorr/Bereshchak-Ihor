using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    

class Program
{

        private static int ComparerInt(object o1, object o2)
        {
            return ((int)o1).CompareTo((int)o2);
        }
        private static int ComparerString(object o1, object o2)
        {
            return ((string)o1).CompareTo((string)o2);
        }
        static void Main(string[] args)
        {
        var array = new Product[3];

            array[0] = new Product() { Price = 3, Name = "BBB" };
            array[1] = new Product() { Price = 1, Name = "CCC" };
            array[2] = new Product() { Price = 2, Name = "AAA" };
     

       
            SortClass.QuickSort<Product>(array, ComparerInt, 0, array.Length - 1, array[0].GetType().GetProperty("Price"), false);//1 CCC ;2 AAA; 3 BBB
            SortClass.QuickSort<Product>(array, ComparerString, 0, array.Length - 1, array[0].GetType().GetProperty("Name"), false);//1 AAA ; 2 BBB ; 3 CCC
            SortClass.HeapSort<Product>(array, ComparerString, 0, array.Length - 1, array[0].GetType().GetProperty("Name"), true);//1 CCC; 2 BBB; 3 AAA

            
        }
}
}

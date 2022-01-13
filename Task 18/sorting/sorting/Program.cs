using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    

class Program
{
    static void Main(string[] args)
    {
        var array = new Product[3];

            array[0] = new Product() { Price = 3, Name = "BBB" };
            array[1] = new Product() { Price = 1, Name = "CCC" };
            array[2] = new Product() { Price = 2, Name = "AAA" };
     

       
            SortClass.QuickSort<Product>(array, 0, array.Length - 1, array[0].GetType().GetProperty("Price"), false);//1 CCC ;2 AAA; 3 BBB
            SortClass.QuickSort<Product>(array, 0, array.Length - 1, array[0].GetType().GetProperty("Name"), false);//1 AAA ; 2 BBB ; 3 CCC
            SortClass.HeapSort<Product>(array, 0, array.Length - 1, array[0].GetType().GetProperty("Name"), true);//1 CCC; 2 BBB; 3 AAA

         
    }
}
}

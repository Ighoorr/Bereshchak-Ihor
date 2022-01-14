using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{       
    public delegate int Comparer(object o1, object o2);
    
    class SortClass
    {

         
           
            public static void QuickSort<T>(T[] array,Comparer compare, int low, int high, System.Reflection.PropertyInfo propertyInfo, bool order)
            {
                int p=0;
                if (low < high)
                {
                    Comparer comparer = compare;
                    T pivot = array[low];
                     int i = high + 1;

                    for (int j = high; j >= low + 1; j--)
                    {
                        if (comparer(propertyInfo.GetValue(array[j]), propertyInfo.GetValue(pivot)) * ((order) ? -1 : 1) > 0)
                        {
                            i--;
                            Swap(array, i, j);
                         }
                     }
    
                     Swap(array, i - 1, low);
                     p= (i - 1);

                 QuickSort<T>(array, compare, low, p - 1, propertyInfo, order);
                 QuickSort<T>(array, compare, p + 1, high, propertyInfo, order);
                   

                }

                    
            }


            private static void Swap<T>(T[] array, int i, int j)
            {
                T temp = array[i];
                array[i] = array[j];
                 array[j] = temp;
            }

           

            public static void HeapSort<T>(T[] array, Comparer comparer, int low, int high, System.Reflection.PropertyInfo propertyInfo, bool order)
            {
                int length = array.Length;

                for (int i = (array.Length) / 2; i > 0; i--)
                {
                    int pos = BuildHeap<T>(array, comparer, i, length, propertyInfo, order);
                    while (pos >= 0)
                    pos = BuildHeap<T>(array, comparer, pos + 1, length, propertyInfo, order);
                }

                for (int i = array.Length; i > 1; i--)
                {
                    T temp = array[length - 1];
                array[length - 1] = array[0];
                array[0] = temp;

                    int pos = BuildHeap<T>(array, comparer, 1, --length, propertyInfo, order);
                    while (pos >= 0)
                    pos = BuildHeap<T>(array, comparer, pos + 1, length, propertyInfo, order);
                }
            }

            private static int BuildHeap<T>(T[] array, Comparer compare, int fatherNumber, int bound, System.Reflection.PropertyInfo propertyInfo, bool order)
            {
                int fatherIndex = fatherNumber - 1;
                int leftSonIndex = (fatherNumber * 2 - 1 < array.Length && fatherNumber * 2 - 1 < bound) ? fatherNumber * 2 - 1 : -1;
                int rightSonIndex = (fatherNumber * 2 < array.Length && fatherNumber * 2 < bound) ? fatherNumber * 2 : -1;

              Comparer comparer = compare;


                
                    if ((leftSonIndex < 0 && rightSonIndex < 0) || (rightSonIndex < 0 && comparer(propertyInfo.GetValue(array[fatherIndex]), propertyInfo.GetValue(array[leftSonIndex])) <= 0) || (comparer(propertyInfo.GetValue(array[fatherIndex]), propertyInfo.GetValue(array[leftSonIndex])) <= 0 && comparer(propertyInfo.GetValue(array[fatherIndex]), propertyInfo.GetValue(array[rightSonIndex])) <= 0))
                        return -1;
                    else if ((rightSonIndex < 0 && comparer(propertyInfo.GetValue(array[leftSonIndex]), propertyInfo.GetValue(array[fatherIndex])) <= 0) || (comparer(propertyInfo.GetValue(array[leftSonIndex]), propertyInfo.GetValue(array[fatherIndex])) <= 0 && comparer(propertyInfo.GetValue(array[leftSonIndex]), propertyInfo.GetValue(array[rightSonIndex])) <= 0))
                    {
                        T temp = array[fatherIndex];
                    array[fatherIndex] = array[leftSonIndex];
                    array[leftSonIndex] = temp;
                        return leftSonIndex;
                    }
                    else if (comparer(propertyInfo.GetValue(array[rightSonIndex]), propertyInfo.GetValue(array[fatherIndex])) <= 0 && comparer(propertyInfo.GetValue(array[rightSonIndex]), propertyInfo.GetValue(array[leftSonIndex])) <= 0)
                    {
                        T temp = array[fatherIndex];
                    array[fatherIndex] = array[rightSonIndex];
                    array[rightSonIndex] = temp;
                        return rightSonIndex;
                    }
                
               

                return -1;
            }

            

            

          
        
    }
}

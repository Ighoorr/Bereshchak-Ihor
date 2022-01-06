using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{
    interface IStorageManagerDiscount
    {
         void AddDiscount(Discount discount);
         void RemoveDiscount(Discount discount);
         bool ClearDiscounts();

    }
}

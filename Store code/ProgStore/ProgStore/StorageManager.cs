using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{
    class StorageManager:IStorageManagerDiscount
    {

        List<Storage> storages;
        List<Discount> discounts;
        StorageManager storegmanger;

    private StorageManager() { }
    public StorageManager Instance()
        {
            if (storegmanger == null)
                storegmanger = new StorageManager();
            return storegmanger;
        }
    public void AddStorage(Storage storage)
        {

            storages.Add(storage);
        }
     public void  RemoveStorage(Storage storage)
        {   
            storages.Remove(storage);

        }

        public void AddDiscount(Discount discount)
        {
            discounts.Add(discount);
        }

        public void RemoveDiscount(Discount discount)
        {
            discounts.Remove(discount);
        }

        public bool ClearDiscounts()
        {  
            
            discounts.Clear();
            return true;
        }
    }
}

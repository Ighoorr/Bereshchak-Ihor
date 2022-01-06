using ProgStore.Classes;
using ProgStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{

    enum Status { 
    simple,
    Vip
    }

    class Customer:ICustomerDiscount
    {
        string name;
        Status status;
        string login;
        string password;
        DateTime birthday;
        string adress;
        Basket myBasket;
        List<Discount> discounts;





        public void AddDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscount(Discount discount)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{
    interface IStorage
    {

        void AddProduct(Product product);

        void  RemoveProduct(Product product);
    }
}

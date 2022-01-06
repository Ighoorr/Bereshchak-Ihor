using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgStore
{
    class Discount
    {
        string ProductName;
        double percent;

        public Discount(string name,double perc) {
            ProductName = name;
            percent = perc;
        }
    }
}

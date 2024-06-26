using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public abstract class RevenueFactory
    {
        //TODO: Regla:
        //TODO: La clase abstracta RevenueFactory tiene un método abstracto GetRevenue
        //TODO: que tiene como objetivo crear un objeto de tipo IRevenue.
        public abstract IRevenue GetRevenue();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public class LocalRevenue : IRevenue
    {
        private decimal _percentage;
        //TODO: Constructor
        public LocalRevenue(decimal percentage)
        {
            _percentage = percentage;
        }
        public decimal Revenue(decimal amount)
        {
            return amount * _percentage;
        }
    }
}

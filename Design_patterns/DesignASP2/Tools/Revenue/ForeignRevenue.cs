using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public class ForeignRevenue : IRevenue
    {
        private decimal _percentage;
        private decimal _extra;
        
        public ForeignRevenue(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public decimal Revenue(decimal amount)
        {
            return (amount * _percentage) + _extra;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public class LocalRevenueFactory : RevenueFactory
    {
        private decimal _percentage;

        public LocalRevenueFactory(decimal percentage)
        {
            _percentage = percentage;
        }

        public override IRevenue GetRevenue()
        {
            return new LocalRevenue(_percentage);
        }
    }
}

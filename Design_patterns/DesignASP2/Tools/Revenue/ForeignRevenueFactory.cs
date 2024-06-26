using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Revenue
{
    public class ForeignRevenueFactory : RevenueFactory
    {
        private decimal _percentage;
        private decimal _extra;

        public ForeignRevenueFactory(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public override IRevenue GetRevenue()
        {
            return new ForeignRevenue(_percentage, _extra);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Tools.Revenue;

namespace DesignASP2.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(decimal total)
        {
            //Factory
            LocalRevenueFactory localRevenueFactory = new LocalRevenueFactory(0.30m);
            ForeignRevenueFactory foreignRevenueFactory = new ForeignRevenueFactory(0.40m, 20);
            //Product
            var localRevenue = localRevenueFactory.GetRevenue();
            var foreignRevenue = foreignRevenueFactory.GetRevenue();
            //Metodo de objeto 
            ViewBag.totalLocal = total + localRevenue.Revenue(total);
            ViewBag.totalForeign = total + foreignRevenue.Revenue(total);
            return View();
        }
    }
}

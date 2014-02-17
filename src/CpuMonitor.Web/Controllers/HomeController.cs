using System.Web.Mvc;

namespace CpuMonitor.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System.Web.Mvc;

namespace HelloWorlds.Controllers
{
    public class ReactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
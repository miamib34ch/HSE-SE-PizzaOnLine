using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PizzaOnLine.Controllers
{
    public class InfoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

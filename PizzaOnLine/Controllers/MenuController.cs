using Microsoft.AspNetCore.Mvc;
using PizzaOnLine.Models;
using System.Diagnostics;

namespace PizzaOnLine.Controllers
{
    public class MenuController : Controller
    {
        SiteContext db = new SiteContext();

        public IActionResult Index()
        {
            ViewBag.Pizzas = db.Pizzas; 

            return View();
        }
    }
}
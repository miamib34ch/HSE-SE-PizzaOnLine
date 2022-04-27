using Microsoft.AspNetCore.Mvc;
using PizzaOnLine.Models;
using System.Text.Json;

namespace PizzaOnLine.Controllers
{
    public class CartController : Controller
    {
        SiteContext db = new SiteContext();

        public ViewResult Index()
        {
            Cart tmp = GetCart();
            if (tmp.lineCollection == null)
            {
                tmp.lineCollection = new List<CartLine>();
                HttpContext.Session.Set("Cart", tmp);
            }
            ViewBag.Cart = tmp;
            ViewBag.Pizzas = db.Pizzas;
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            Pizza pizza = db.Pizzas.Where(p => p.PizzaId == productId).FirstOrDefault();
            if (pizza != null)
            {
                Cart tmp = GetCart();
                tmp.AddItem(pizza, 1);
                HttpContext.Session.Set("Cart", tmp);
            }
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult Clear()
        {
            Cart tmp = GetCart();
            tmp.Clear();
            HttpContext.Session.Set("Cart", tmp);
            return RedirectToAction("Index", "Cart");
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.Get<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.Set("Cart",cart);
            }
            return cart;
        }

        public ViewResult Save()
        {
            db.Carts.Add(new Cart { Id = db.Carts.Count(), lineCollection = GetCart().lineCollection});
            db.SaveChanges();
            Cart tmp = GetCart();
            tmp.Clear();
            HttpContext.Session.Set("Cart", tmp);
            return View();
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null)
                return JsonSerializer.Deserialize<T>(value);
            else 
                return default(T);
        }
    }
}

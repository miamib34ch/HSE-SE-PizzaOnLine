using System.Data.Entity;

namespace PizzaOnLine.Models
{
    public class DbInitializer: DropCreateDatabaseAlways<SiteContext>
    {
        protected override void Seed(SiteContext db)
        {
            db.Pizzas.Add(new Pizza { Name = "Пепперони", Description = "Cыры моцарелла и пармезан, шампиньоны, бекон, колбаса пепперони, помидоры, куриная грудка, чеснок, лук красный, зелень.", Price = 220 });
            db.Pizzas.Add(new Pizza { Name = "Маргарита", Description = "Cыр моцарелла, помидоры.", Price = 200 });
            db.Pizzas.Add(new Pizza { Name = "Гавайская", Description = "Cыр моцарелла, ветчина, ананасы.", Price = 200 });

            base.Seed(db);
        }
    }
}
